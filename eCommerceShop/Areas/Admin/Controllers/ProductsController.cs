using eCommerceShop.Data;
using eCommerceShop.Data.Migrations;
using eCommerceShop.Models;
using eCommerceShop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _he;

        public ProductsController(ApplicationDbContext context, IHostingEnvironment he)
        {
            _context = context;
            _he = he;
        }
        //public IActionResult Index()
        //{
        //    return View(_context.Products.Include(c => c.ProductTypes).ToList());
        //}

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var products = from s in _context.Products.Include(c => c.ProductTypes)
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }
            return View(await products.AsNoTracking().ToListAsync());
        }

            //Create method
            public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "ProductType");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Products products, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var searchProduct = _context.Products.FirstOrDefault(c => c.Name == products.Name);
                if (searchProduct != null)
                {
                    ViewBag.message = "This product is already listed";
                    ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "ProductType");
                    return View();
                }

                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    products.Image = "Images/noimage.PNG";
                }

                _context.Products.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        //Edit method
        public IActionResult Edit(int? id)
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "ProductType");
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Products products, IFormFile image)
        {
            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    products.Image = "Images/noimage.PNG";
                }

                _context.Products.Update(products);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        //Details method
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        // Delete method

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Products.Include(c => c.ProductTypes).Where(c => c.Id == id).FirstOrDefault();

            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Products.FirstOrDefault(c => c.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}