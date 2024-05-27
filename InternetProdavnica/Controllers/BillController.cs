using InternetProdavnica.Data;
using InternetProdavnica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternetProdavnica.Controllers
{
    public class BillController : Controller
    {
        private readonly InternetProdavnicaContext _context;
        public BillController(InternetProdavnicaContext context)
        {
            _context = context;
        }

        public IActionResult AllBills()
        {
            List<Racun> allBills = _context.Racuns.Include(p=> p.NarudzbenicaIdfkNavigation).ToList();
            return View(allBills);
        }
    }
}
