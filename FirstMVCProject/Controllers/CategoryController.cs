using FirstMVCProject.Models;
using FirstMVCProject.Repositories;
using FirstMVCProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCProject.Controllers
{
    public class CategoryController : Controller
    {

        CategoryRepository categoryRepo = new CategoryRepository();
        public IActionResult Index()
        {
            var categories = categoryRepo.GetAllActive();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryAddVM category)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new()
                {
                    Name = category.Name,
                };
                categoryRepo.Add(newCategory);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var data = categoryRepo.Get(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Category category, int id)
        {
            var data = categoryRepo.Get(id);
            data.Name = category.Name;
            categoryRepo.Update(data);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var data = categoryRepo.Get(id);
            data.IsDeleted = true;
            categoryRepo.Update(data);
            return RedirectToAction("Index");
        }

    }

}
