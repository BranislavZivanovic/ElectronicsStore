using InternetProdavnica.Data;
using InternetProdavnica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternetProdavnica.Controllers
{
    public class CartController : Controller
    {
        private readonly InternetProdavnicaContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartController(InternetProdavnicaContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // Where(k => k.KorisnikID == temp) dodati kad se instancira HttpPreprocessor za user ID
        public IActionResult AllProductsInCart()
        {
            bool loggedIn = HttpContext.User.Identity.IsAuthenticated;
            if (loggedIn == true)
            {
                List<Korpa> allCartProducts = _context.Korpas.Include(c => c.ProizvodIdfkNavigation).Where(p => p.Active == true && p.KorisnikId == _httpContextAccessor.HttpContext.User.Identity.Name).ToList();
                ViewBag.countCart = allCartProducts.Count();
                return View(allCartProducts);
            }
            else
            {
                List<Korpa> allCartProducts = _context.Korpas.Include(c => c.ProizvodIdfkNavigation).Where(p => p.Active == true && p.KorisnikId == "UnregisteredUser").ToList();
                ViewBag.countCart = allCartProducts.Count();
                return View(allCartProducts);
            }
        }

        public IActionResult DeleteCartProduct(int id)
        {
            Korpa cartItem = _context.Korpas.Find(id);
            _context.Korpas.Remove(cartItem);
            _context.SaveChanges();
            TempData["AlertMessage"] = "Uspešno ste uklonili proizvod iz korpe!";

            return RedirectToAction("AllProductsInCart");
        }

        public IActionResult AddMore(int id)
        {
            Korpa cart = _context.Korpas.Find(id);
            
            int productId = cart.ProizvodIdfk;
            Proizvod product = _context.Proizvods.Find(productId);

            cart.Kolicina += 1;
            cart.UkupnaVrednost = product.JedinicnaCena * cart.Kolicina;

            _context.SaveChanges();
            return RedirectToAction("AllProductsInCart");
        }

        public IActionResult Subtract(int id)
        {
            Korpa cart = _context.Korpas.Find(id);

            int productId = cart.ProizvodIdfk;
            Proizvod product = _context.Proizvods.Find(productId);

            if(cart.Kolicina != 1 && cart.Kolicina >= 1)
            {
                cart.Kolicina -= 1;
                cart.UkupnaVrednost = product.JedinicnaCena * cart.Kolicina;
                _context.SaveChanges();
            }
            return RedirectToAction("AllProductsInCart");
        }
    }
}
