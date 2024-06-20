using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_Project_DotNet.Models;
using Mini_Project_DotNet.Services;

namespace Mini_Project_DotNet.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }
        // GET: CategoryController
        public ActionResult CategoryList()
        {
            var model = service.GetCategories();
            return View(model);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult AddCategory()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(Category category)
        {
            try
            {
                int result = service.AddCategory(category);
                if(result >= 1)
                {
                    return RedirectToAction("CategoryList");
                }
                else
                {
                    ViewBag.ErrorMsg = "Something Went Wrong";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
           var model = service.GetCategory(id);
            return View(model);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                int result = service.UpdateCategory(category);
                if (result >= 1)
                {
                    return RedirectToAction("CategoryList");
                }
                else
                {
                    ViewBag.ErrorMsg = "Something Went Wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = service.GetCategory(id);
            return View(model);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = service.DeleteCategory(id);
                if (result >= 1)
                {
                    return RedirectToAction("CategoryList");
                }
                else
                {
                    ViewBag.ErrorMsg = "Something Went Wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}
