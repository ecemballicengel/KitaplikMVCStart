using Kitaplik.DataAccess.Data;
using Kitaplik.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AplicationDbContext _context;

        public CategoryController(AplicationDbContext context)
        {
            _context = context;    //Dependency Injection
        }
        [HttpGet]
        public IActionResult Index()
        {
            //List<Category> objCategoryList = _context.Categories.ToList();

            IEnumerable<Category> categories = _context.Categories;
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                TempData["success"] = "Category created successfully";
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpGet]
        public IActionResult Edit(int? Id) 
        { 
            if(Id == null || Id==0) 
            { 
                return NotFound();
            }
            var category = _context.Categories.Find(Id);
           //var category = _context.Categories.FirstOrDefault(c => c.Id == Id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj) 
        { 
            if (ModelState.IsValid) 
            { 
                _context.Categories.Update(obj);
                TempData["success"] = "Category edited successfully";
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            //var category = _context.Categories.FirstOrDefault(c => c.Id == Id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        //[HttpPost]
        //public ActionResult Delete(Category obj)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _context.Categories.Remove(obj);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(obj);

        //}


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Category obj = _context.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(obj);
            TempData["success"] = "Category deleted successfully";
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
