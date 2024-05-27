using InternetProdavnica.Data;
using InternetProdavnica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace InternetProdavnica.Controllers
{
    public class OrderController : Controller
    {
        private readonly InternetProdavnicaContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderController(InternetProdavnicaContext context, IEmailSender emailSender, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult AllOrders()
        {
            List<Narudzbenica> allOrders = _context.Narudzbenicas.ToList();
            return View(allOrders);
        }
        public IActionResult ApprovedOrders()
        {
            List<Narudzbenica> approvedOrders = _context.Narudzbenicas.Where(p => p.Odobrena == true).ToList();
            return View(approvedOrders);
        }
        public IActionResult OrdersOnWaitList()
        {
            List<Narudzbenica> ordersOnWaitList = _context.Narudzbenicas.Where(p => p.Odobrena == false).ToList();
            return View(ordersOnWaitList);
        }

        public IActionResult AllOrderItems(int id)
        {
            List<StavkaNarudzbenice> orderItems = _context.StavkaNarudzbenices.Where(o => o.NarudzbenicaIdfk == id).ToList();
            Narudzbenica order = _context.Narudzbenicas.Where(o => o.NarudzbenicaId == id).FirstOrDefault();
            ViewBag.orderID = order.NarudzbenicaId;
            return View(orderItems);
        }

        #region Creating Order
        [HttpGet]
        public IActionResult CreateOrder()
        {
            Narudzbenica order = new Narudzbenica();
            return View(order);
        }
        [HttpPost]
        public IActionResult CreateOrder(Narudzbenica order, string email, string imeIPrezime, string adresaIsporuke, string grad, string postanskiBroj, string drzava, string telefon)
        {
            List<Korpa> cartList = _context.Korpas.Include(p => p.ProizvodIdfkNavigation).Where(p => p.Active == true).ToList();
            bool loggedIn = HttpContext.User.Identity.IsAuthenticated;
            // Nova narudzbenica ID 1
            // Za svaku korpu dodaj stavku naruzbenice na narudzbenicu sa ID 1
            double ukupnaVrednost = 0;
            if(cartList.Count > 0)
            {
                order.Datum = DateTime.Now;
                order.Odobrena = false;
                if (loggedIn == true)
                {
                    //Dodati ovde da se prenosi parametar za email ulogovanog korisnika
                    order.email = _httpContextAccessor.HttpContext.User.Identity.Name;
                    order.Korisnik = _httpContextAccessor.HttpContext.User.Identity.Name;
                }
                else
                {
                    order.email = email;
                    order.Korisnik = "UnregisteredUser";
                }
                order.ImeIprezime = imeIPrezime;
                order.AdresaIsporuke = adresaIsporuke;
                order.Grad = grad;
                order.PostanskiBroj = postanskiBroj;
                order.Drzava = drzava;
                order.Telefon = telefon;
                order.UkupnaVrednost = 0;
                order.Administrator = "undefined";

                _context.Add(order);
                _context.SaveChanges();

                foreach (Korpa cart in cartList)
                {
                    _context.Add(new StavkaNarudzbenice()
                    {
                        KorpaIdfk = cart.KorpaId,
                        NarudzbenicaIdfk = order.NarudzbenicaId,
                        UkupnaVrednostStavke = cart.UkupnaVrednost,
                        NazivProizvoda = cart.ProizvodIdfkNavigation.NazivProizvoda,
                        Kolicina = cart.Kolicina
                    });
                    ukupnaVrednost += cart.UkupnaVrednost;
                    order.UkupnaVrednost = ukupnaVrednost;
                    cart.Active = false;
                }
                TempData["AlertMessage"] = "Uspešno ste naručili proizvode! Bice Vam poslata potvrda i racun na Vas e-mail cim procesiramo Vasu narudzbenicu! ID narudzbenice:" + order.NarudzbenicaId;
            }
            else
            {
                return RedirectToAction("AllProductsInCart", "Cart", new { area = "" });
                TempData["AlertMessage"] = "Morate dodati barem jedan proizvod u korpu!";
            }

            _context.SaveChanges();
            return RedirectToAction("AllProductsInCart", "Cart", new { area = "" });
        }
        #endregion

        #region Creating bill
        [Authorize(Roles = "Administrator")]
        public IActionResult ApproveOrder(int id, Racun racun)
        {
            Narudzbenica order = _context.Narudzbenicas.Find(id);
            List<StavkaNarudzbenice> orderItems = _context.StavkaNarudzbenices.Where(p => p.NarudzbenicaIdfk == order.NarudzbenicaId).ToList();
            
            StringBuilder sb = new StringBuilder();
            foreach(var itemOrder in orderItems)
            {
                sb.Append(itemOrder.NazivProizvoda + "Kolicina: " + itemOrder.Kolicina + "\n");
            }

            if(order.Odobrena == false)
            {
                order.Odobrena = true;
                order.Administrator = _httpContextAccessor.HttpContext.User.Identity.Name;

                racun.DatumRacuna = DateTime.Now;
                racun.UkupnaVrednostRacuna = order.UkupnaVrednost;
                racun.Izdat = true;
                racun.NarudzbenicaIdfk = order.NarudzbenicaId;
                racun.StavkeRacuna = sb.ToString();
                _context.Add(racun);
                _context.SaveChanges();
                TempData["AlertMessage"] = "Uspešno ste potvrdili narudzbenicu!";

                var message = new Message(new string[] { order.email }, "Potvrdjena narudzbenica, izdat racun", $"Hvala Vam na porucivanju!\n Vas broj racuna je: {racun.RacunId}.\n Molimo sacuvajte broj racuna, u slucaju da zelite da reklamirate proizvod bice Vam potreban vas broj racuna. Hvala Vam na poverenju, vasa PC prodavnica Beograd! \nNaruceni proizvodi: \n{sb}\n Ukupno za naplatu: {order.UkupnaVrednost} RSD\n Detalji za isporuku -\n Ime i prezime: {order.ImeIprezime}\n Adresa: {order.AdresaIsporuke}\n Grad: {order.Grad}\n Postanski broj: {order.PostanskiBroj}\n Mobilni telefon: {order.Telefon}");
                _emailSender.SendEmail(message);
            }
            else
            {
                TempData["AlertMessage"] = "Narudzbenica je vec potvrdjena!";
            }
            return RedirectToAction("AllOrders");
        }
        #endregion
    }
}
