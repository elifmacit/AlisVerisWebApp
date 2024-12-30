﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlisVerisWebApp.Data;
using AlisVerisWebApp.Models;

namespace AlisVerisWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "Category_Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Product_Id,Product_Name,Product_Description,Product_Image,Product_Price,Category_Id,SubCategory_Id,Product_Feature")] Product product, IFormFile PictureImage)
        {
            if (PictureImage != null)
            {
                var uzanti = Path.GetExtension(PictureImage.FileName);
                string yeniisim = Guid.NewGuid().ToString() + uzanti;
                string yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImages/" + yeniisim);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    await PictureImage.CopyToAsync(stream);
                }
                product.Product_Image = yeniisim;
            }
            if (!ModelState.IsValid)
            {
                ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "Category_Name");
                return View(product);
            }
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public JsonResult CategoryList(int id) 
        {
            var sonuc=_context.SubCategories.Where(x => x.Category_Id == id).ToList();
            return Json(new SelectList(sonuc,"SubCategory_Id","SubCategory_Name"));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "Category_Name");
            if (product == null)
            {
                return NotFound();
            }
           
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Product_Id,Product_Name,Product_Description,Product_Image,Product_Price,Category_Id,SubCategory_Id,Product_Feature")] Product product, IFormFile PictureImage)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            if (PictureImage != null)
            {
                var uzanti = Path.GetExtension(PictureImage.FileName);
                string yeniisim = Guid.NewGuid().ToString() + uzanti;
                string yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImages/" + yeniisim);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    await PictureImage.CopyToAsync(stream);
                }
                product.Product_Image = yeniisim;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "Category_Name");
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
   
}
