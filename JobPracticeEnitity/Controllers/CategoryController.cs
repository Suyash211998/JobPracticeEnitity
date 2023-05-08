using JobPracticeEnitity.Data;
using JobPracticeEnitity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JobPracticeEnitity.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _db;
        
        public CategoryController(ApplicationDbContext db) {
            _db = db;

        }
        public IActionResult Index()
        {
            List<Category> objCategoryList =_db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("name", "dont fill same ");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Added Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
            
            
        }

        public IActionResult Edit(int ? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category obj = _db.Categories.Find(id);
            Category obj1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            Category obj2 = _db.Categories.Where(u=> u.Id==id).FirstOrDefault();
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("name", "dont fill same ");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();


        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category obj = _db.Categories.Find(id);
            Category obj1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            Category obj2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOSt(int ? id)
        {
            Category obj = _db.Categories.Find(id);

            if(obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");


        }




    }
        
 }

