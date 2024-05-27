using InternetProdavnica.Data;
using InternetProdavnica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternetProdavnica.Views.Shared.Components.SearchBar;
using Microsoft.AspNetCore.Authorization;

namespace InternetProdavnica.Controllers
{
    public class ProductController : Controller
    {
        private readonly InternetProdavnicaContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductController(InternetProdavnicaContext context, IWebHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Kategorije
        // Pretrazi po kategorijama
        public IActionResult DisplayByCategory(int id)
        {
            List<Proizvod> findProductByCategory = _context.Proizvods.Where(p => p.Aktivan == true && p.IsDeleted == false && p.PodkategorijaIdfk == id).ToList();
            ViewBag.allFound = findProductByCategory.Count();
            return View(findProductByCategory);
        }
        #endregion

        public IActionResult AllProducts(string SearchText = "", int pg = 1)
        {
            List<Proizvod> allProducts;

            if(SearchText != "" && SearchText != null)
            {
                allProducts = _context.Proizvods.Where(p => p.NazivProizvoda.Contains(SearchText) && p.Aktivan == true && p.IsDeleted == false).ToList();
            }
            else
            {
                allProducts = _context.Proizvods.Where(p=> p.Aktivan == true && p.IsDeleted == false).ToList();
            }
            const int pageSize = 12;
            if (pg < 1)
                pg = 1;
            int recsCount = allProducts.Count();
            int recSkip = (pg - 1) * pageSize;
            List<Proizvod> retProducts = allProducts.Skip(recSkip).Take(pageSize).ToList();
            SPager SearchPager = new SPager(recsCount, pg, pageSize) { Action = "AllProducts", Controller = "Product", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;
            ViewBag.allProducts = _context.Proizvods.Where(p => p.IsDeleted == false).ToList().Count();

            return View(retProducts);
        }

        public IActionResult ProductDetails(int id)
        {
            Proizvod product = _context.Proizvods.Include(p => p.PodkategorijaIdfkNavigation).Where(p => p.ProizvodId == id).First();
            return View(product);
        }

        #region Adding products
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult AddProduct()
        {
            Proizvod product = new Proizvod();
            ViewBag.podcategory = _context.Podkategorijas.Select(p => new SelectListItem { Value = p.PodkategorijaId.ToString(), Text = p.NazivPodkategorije });
            return View(product);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult AddProduct(Proizvod proizvod)
        {
            if(proizvod.ImageFile != null)
            {
                string folder = "images/products/";
                folder += Guid.NewGuid().ToString() + "_" + proizvod.ImageFile.FileName;
                string serverFolder = Path.Combine(_hostEnvironment.WebRootPath, folder);
                proizvod.Slika = "/" + folder;
                proizvod.ImageFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }
            proizvod.IsDeleted = false;

            _context.Add(proizvod);
            _context.SaveChanges();
            TempData["AlertMessage"] = "Uspešno ste dodali proizvod " + proizvod.NazivProizvoda + "!";
            return RedirectToAction("AddProduct");
        }
        #endregion

        #region Deleting products
        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteProduct(int id)
        {
            Proizvod proizvod = _context.Proizvods.Find(id);
            proizvod.IsDeleted = true;
            _context.SaveChanges();
            TempData["AlertMessage"] = "Uspešno ste obrisali proizvod!";
            return RedirectToAction("AllProducts");
        }
        #endregion

        #region Adding products to cart
        public IActionResult AddToCart(int id)
        {
            Proizvod product = _context.Proizvods.Find(id);
            bool loggedIn = HttpContext.User.Identity.IsAuthenticated;
            if (loggedIn == true)
            {
                _context.Add(new Korpa()
                {
                    ProizvodIdfk = product.ProizvodId,
                    Kolicina = 1,
                    KorisnikId = _httpContextAccessor.HttpContext.User.Identity.Name,
                    UkupnaVrednost = product.JedinicnaCena,
                    Active = true
                });
            }
            else
            {
                _context.Add(new Korpa()
                {
                    ProizvodIdfk = product.ProizvodId,
                    Kolicina = 1,
                    KorisnikId = "UnregisteredUser",
                    UkupnaVrednost = product.JedinicnaCena,
                    Active = true
                });
            }
            _context.SaveChanges();
            TempData["AlertMessage"] = "Uspešno ste dodali proizvod u korpu!";
            return RedirectToAction("AllProducts");
        }
        #endregion

        #region PC Builder
        [HttpGet]
        public IActionResult PcBuilder()
        {
            ViewBag.processor = _context.Proizvods.Where(p => p.PodkategorijaIdfk == 1 && p.IsDeleted == false && p.Aktivan == true).Select(p => new SelectListItem { Value = p.ProizvodId.ToString(), Text = p.NazivProizvoda });
            ViewBag.motherboard = _context.Proizvods.Where(p => p.PodkategorijaIdfk == 2 && p.IsDeleted == false && p.Aktivan == true).Select(p => new SelectListItem { Value = p.ProizvodId.ToString(), Text = p.NazivProizvoda });
            ViewBag.graphics = _context.Proizvods.Where(p => p.PodkategorijaIdfk == 3 && p.IsDeleted == false && p.Aktivan == true).Select(p => new SelectListItem { Value = p.ProizvodId.ToString(), Text = p.NazivProizvoda });
            ViewBag.ram = _context.Proizvods.Where(p => p.PodkategorijaIdfk == 4 && p.IsDeleted == false && p.Aktivan == true).Select(p => new SelectListItem { Value = p.ProizvodId.ToString(), Text = p.NazivProizvoda });
            ViewBag.hdd = _context.Proizvods.Where(p => p.PodkategorijaIdfk == 5 && p.IsDeleted == false && p.Aktivan == true).Select(p => new SelectListItem { Value = p.ProizvodId.ToString(), Text = p.NazivProizvoda });
            ViewBag.ssd = _context.Proizvods.Where(p => p.PodkategorijaIdfk == 6 && p.IsDeleted == false && p.Aktivan == true).Select(p => new SelectListItem { Value = p.ProizvodId.ToString(), Text = p.NazivProizvoda });
            ViewBag.psu = _context.Proizvods.Where(p => p.PodkategorijaIdfk == 7 && p.IsDeleted == false && p.Aktivan == true).Select(p => new SelectListItem { Value = p.ProizvodId.ToString(), Text = p.NazivProizvoda });
            ViewBag.PcCase = _context.Proizvods.Where(p => p.PodkategorijaIdfk == 8 && p.IsDeleted == false && p.Aktivan == true).Select(p => new SelectListItem { Value = p.ProizvodId.ToString(), Text = p.NazivProizvoda });
            return View();
        }
        [HttpPost]
        public IActionResult PcBuilder(Korpa korpa, int procesorID, int motherboardID, int graphicsID, int ramID, int hddID, int ssdID, int psuID, int caseID)
        {
            List<Proizvod> pcBuilder = new List<Proizvod>();
            Proizvod processor = _context.Proizvods.Find(procesorID);
            Proizvod motherboard = _context.Proizvods.Find(motherboardID);
            Proizvod graphics = _context.Proizvods.Find(graphicsID);
            Proizvod ram = _context.Proizvods.Find(ramID);
            Proizvod hdd = _context.Proizvods.Find(hddID);
            Proizvod ssd = _context.Proizvods.Find(ssdID);
            Proizvod psu = _context.Proizvods.Find(psuID);
            Proizvod pcCase = _context.Proizvods.Find(caseID);

            pcBuilder.Add(processor);
            pcBuilder.Add(motherboard);
            pcBuilder.Add(graphics);
            pcBuilder.Add(ram);
            pcBuilder.Add(hdd);
            pcBuilder.Add(ssd);
            pcBuilder.Add(psu);
            pcBuilder.Add(pcCase);

            foreach(Proizvod p in pcBuilder)
            {
                bool loggedIn = HttpContext.User.Identity.IsAuthenticated;
                if (loggedIn == true)
                {
                    _context.Add(new Korpa()
                    {
                        ProizvodIdfk = p.ProizvodId,
                        Kolicina = 1,
                        KorisnikId = _httpContextAccessor.HttpContext.User.Identity.Name,
                        UkupnaVrednost = p.JedinicnaCena,
                        Active = true
                    });
                }
                else
                {
                    _context.Add(new Korpa()
                    {
                        ProizvodIdfk = p.ProizvodId,
                        Kolicina = 1,
                        KorisnikId = "UnregisteredUser",
                        UkupnaVrednost = p.JedinicnaCena,
                        Active = true
                    });
                }
            }
            _context.SaveChanges();
            TempData["AlertMessage"] = "Uspešno ste dodali proizvode u korpu!";
            return RedirectToAction("PcBuilder");
        }
        #endregion
    }
}
