using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mini_Project_DotNet.Models;
using Mini_Project_DotNet.Services;

namespace Mini_Project_DotNet.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService service;
        private readonly ICategoryService catService;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService uService;

        public ProductController(IUserService uService,IHttpContextAccessor _httpContextAccessor,IProductService service, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, ICategoryService catService)
        {
            _env = env;
            this.service = service;
            this.catService = catService;
            this._httpContextAccessor = _httpContextAccessor;
            this.uService = uService;
            //ConfigureSession()
        }
        //private void ConfigureSession()
        //{
        //    var session = _httpContextAccessor.HttpContext.Session;
        //    if (session != null)
        //    {
        //        session.SetString("Key", "Value");
        //    }
        //}
        // GET: ProductController
        public ActionResult AdminProductPage()
        {
            var model = service.GetAllProducts();
            return View(model);
        }

        public ActionResult UserProductPage()
        {
            var model = service.GetAllProducts();
            return View(model);
        }

        private SelectList GetCategories()
        {
            var categories = catService.GetCategories();
            return new SelectList(categories, "CategoryId", "Name");
        }
            // GET: ProductController/Create
            public ActionResult AddProduct()
        {
            ViewBag.Categories = GetCategories();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Product prod, IFormFile file)
        {
            using(var fs = new FileStream(_env.WebRootPath+"\\images\\"+file.FileName,
                FileMode.Create,FileAccess.Write))
            {
                file.CopyTo(fs);
            }

                prod.Image = "~/images/" + file.FileName;
            

            service.AddProduct(prod);
            return RedirectToAction("AdminProductPage");

            ViewBag.Categories = GetCategories(); // Reassign in case of failure
            return View(prod);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = service.GetProduct(id);
            HttpContext.Session.SetString("oldImage", model.Image);
           ViewBag.Categories = GetCategories();
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod, IFormFile file)
        {
            string oldImage = HttpContext.Session.GetString("oldImage");
            if(file!=null)
            {
                using (var fs = new FileStream(_env.WebRootPath + "\\images\\" + file.FileName,
               FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fs);
                }

                prod.Image = "~/images/" + file.FileName;

                string[] str = oldImage.Split("/");
                string str1 = (str[str.Length - 1]);

                string path = _env.WebRootPath + "\\images\\" + str1;

                System.IO.File.Delete(path);
            }
            else
            {
                prod.Image = oldImage;
            }
            try
            {
                int result = service.UpdateProduct(prod);
                if(result>=1)
                {

                return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = "Something Went Wrong";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                ViewBag.Categories = GetCategories();
                return View();
            }
        }

        public ActionResult ProductDetails(int id)
        {
            var model = service.GetProduct(id);
            return View(model);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
