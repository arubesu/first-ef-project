using System.Linq;
using FirstEFProject.Data;
using FirstEFProject.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FirstEFProject.Controllers
{
    public class CategoryController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {

            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;

            var categorySelected = _context.Categories.FirstOrDefault(c => c.Id == id);

            return View(categorySelected);
        }

        [HttpPost]
        public IActionResult Register(Category category)
        {

            if (category.Id == 0)
                _context.Categories.Add(category);
            else
            {
                var categorySaved = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
                categorySaved.Name = category.Name;
                _context.Categories.Update(categorySaved);
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // [HttpPut]
        // public IActionResult Update(Category category, int id){

        //  }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var categorySaved = _context.Categories.FirstOrDefault(c => c.Id == id);
            _context.Categories.Remove(categorySaved);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}