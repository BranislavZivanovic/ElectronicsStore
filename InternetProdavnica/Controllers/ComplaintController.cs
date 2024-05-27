using InternetProdavnica.Data;
using InternetProdavnica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternetProdavnica.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly InternetProdavnicaContext _context;
        private readonly IEmailSender _emailSender;

        public ComplaintController(InternetProdavnicaContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        public IActionResult AllComplaints()
        {
            List<Reklamacija> allComplaints = _context.Reklamacijas.Include(p => p.RacunIdfkNavigation).Include(p=>p.RacunIdfkNavigation.NarudzbenicaIdfkNavigation).ToList();
            return View(allComplaints);
        }
        [HttpGet]
        public IActionResult AddComplaint()
        {
            Reklamacija reklamacija = new Reklamacija();
            return View(reklamacija);
        }

        [HttpPost]
        public IActionResult AddComplaint(Reklamacija reklamacija, int RacunID, string OpisReklamacije)
        {
            var id = from r in _context.Racuns
                     where r.RacunId == RacunID
                     select r;
            if(id.Any())
            {
                reklamacija.RacunIdfk = RacunID;
                reklamacija.OpisReklamacije = OpisReklamacije;
                reklamacija.Odobrena = false;
                _context.Add(reklamacija);
                _context.SaveChanges();
                TempData["AlertMessage"] = "Uspesno ste prijavili reklamaciju!";  
            }
            else
            {
                TempData["AlertMessage"] = "Ne postoji racun sa unetim brojem!";
            }
            return RedirectToAction("AddComplaint");
        }

        public IActionResult ApproveComplaint(int id)
        {
            Reklamacija complaint = _context.Reklamacijas.Include(p => p.RacunIdfkNavigation).Include(p => p.RacunIdfkNavigation.NarudzbenicaIdfkNavigation).Where(p => p.ReklamacijaId == id).First();
            if(complaint.Odobrena == false)
            {
                string email = complaint.RacunIdfkNavigation.NarudzbenicaIdfkNavigation.email;
                var message = new Message(new string[] { email }, "Reklamacija", $"Postovani {complaint.RacunIdfkNavigation.NarudzbenicaIdfkNavigation.ImeIprezime},\n Zelimo da Vas obavestimo da je vasa reklamacija vezana za broj racuna {complaint.RacunIdfk} odobrena! Bicete uskoro kontaktirani od strane naseg servisnog centra za dalja uputstva!\n Hvala Vam! Vasa PC Prodavnica Beograd.");
                _emailSender.SendEmail(message);
                complaint.Odobrena = true;
                _context.SaveChanges();
            }
            else
            {
                TempData["AlertMessage"] = "Reklamacija je vec potvrdjena!";
            }
            return View();
        }

        public IActionResult DisapproveComplaint(int id)
        {
            Reklamacija complaint = _context.Reklamacijas.Include(p => p.RacunIdfkNavigation).Include(p => p.RacunIdfkNavigation.NarudzbenicaIdfkNavigation).Where(p => p.ReklamacijaId == id).First();
            if (complaint.Odobrena == false)
            {
                string email = complaint.RacunIdfkNavigation.NarudzbenicaIdfkNavigation.email;
                var message = new Message(new string[] { email }, "Reklamacija", $"Postovani {complaint.RacunIdfkNavigation.NarudzbenicaIdfkNavigation.ImeIprezime},\n Zelimo da Vas obavestimo da je vasa reklamacija vezana za broj racuna {complaint.RacunIdfk} nazalost odbijena. Nazalost nismo mogli da nadjemo ni jedan los tehnicki detalj u vezi vasih kupljenih proizvoda!\n Hvala Vam! Vasa PC Prodavnica Beograd.");
                _emailSender.SendEmail(message);
                complaint.Odobrena = true;
                _context.SaveChanges();
            }
            else
            {
                TempData["AlertMessage"] = "Reklamacija je vec odbijena!";
            }
            return View();
        }
    }
}
