using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsDashBoard.Data;
using ProductsDashBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;




namespace MyApp.Namespacer.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;

        public DashBoardController(AppDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); 
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";
            return View();
        }

        public IActionResult Products()
        {
            var products = _context.products.ToList();
           // ViewBag.productsdata = products;
            return View(products);
        }

       



        public IActionResult ProductDetailes()
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            var details = _context.productDetailes
                          .Include(p => p.products)
                          .ToList();

            ViewBag.products = _context.products.ToList();

            return View(details);
        }

        public IActionResult Departments()
        {
            var departments = _context.departments.ToList();
            ViewBag.productsdata = departments;
            return View(departments);
        }

         public IActionResult Employees()
        {
            var employees = _context.employees.ToList();
            ViewBag.departments =  _context.departments.ToList();
            return View(employees);
        }



        public async Task<IActionResult> Add_Products(Products products)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            if (ModelState.IsValid)
            {
                _context.products.Add(products);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Products");
        }

        public async Task<IActionResult> Add_Departments(Departments departments)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            if (ModelState.IsValid)
            {
                _context.departments.Add(departments);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("departments");
        }

        [HttpPost]
        public async Task<IActionResult> Add_Employees(Employees employee)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

           if (!ModelState.IsValid)
            {
                ViewBag.departments = _context.departments.ToList(); // لا تنسي هذا السطر
                return View("Employees", _context.employees.Include(e => e.departments).ToList());
            }   

             _context.employees.Add(employee);
             await _context.SaveChangesAsync();
             return RedirectToAction("Employees");
        }

   

       [HttpPost]
        public async Task<IActionResult> Add_ProductDetailes(ProductDetailes productDetailes , IFormFile Imagefile)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";
            if (Imagefile != null)
            {
                var uploadsFloder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads");
                if (!Directory.Exists(uploadsFloder))
                    Directory.CreateDirectory(uploadsFloder);


                var uniqeFileName = Guid.NewGuid().ToString() + Path.GetExtension(Imagefile.FileName);

                var filePath = Path.Combine(uploadsFloder, uniqeFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Imagefile.CopyToAsync(stream);
                }
                productDetailes.Image = "Uploads/" + uniqeFileName;
            }


           // if (ModelState.IsValid)
           // {
              _context.productDetailes.Add(productDetailes);
               await _context.SaveChangesAsync();
          //  }

             return RedirectToAction("ProductDetailes");
        }


        public async Task<IActionResult> DeleteProductDetailes(int id)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            var productDetailes = await _context.productDetailes.FindAsync(id);
            if (productDetailes != null)
            {
                _context.productDetailes.Remove(productDetailes);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ProductDetailes");
        }




        public IActionResult EditProductDetailes(int id)
        {
             TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            //var products = _context.products.ToList();
            //  ViewBag.products = products;
            var productDetailes =  _context.productDetailes.Find(id);
          
            return View(productDetailes);
        }
        


        public async Task<IActionResult> DeleteProducts(int id)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            var products = await _context.products.FindAsync(id);
            if (products != null)
            {
                _context.products.Remove(products);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Products");
        }

        public async Task<IActionResult> DeleteDepartments(int id)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

           var department = await _context.departments.FindAsync(id);

           if (department != null)
         {
        // حذف الموظفين المرتبطين بهذا القسم
           var employeesToDelete = _context.employees.Where(e => e.Dep_id == id);
            _context.employees.RemoveRange(employeesToDelete);

        // حذف القسم
             _context.departments.Remove(department);

        // حفظ التغييرات
              await _context.SaveChangesAsync();
             }

                return RedirectToAction("departments");
           }

        public async Task<IActionResult> DeleteEmployees(int id)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            var employees = await _context.employees.FindAsync(id);
            if (employees != null)
            {
                _context.employees.Remove(employees);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("employees");
        }

        public IActionResult EditDepartments(int id)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            var departments = _context.departments.Find(id);
            return View(departments);
        }

        public IActionResult EditEmployees(int id)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            var Employees = _context.employees.Find(id);
            return View(Employees);
        }


        [HttpGet]
        public IActionResult EditProducts(int id)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            var products = _context.products.Find(id);
            return View(products);
        }



        [HttpPost]
        public async Task<IActionResult> UpdateProductDetailes(ProductDetailes productDetailes)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            if (!ModelState.IsValid)
            {
                return View("EditDepartments", productDetailes);
            }

            var prd = await _context.productDetailes.FindAsync(productDetailes.Id);
            if (prd == null)
            {
                return NotFound();
            }

            prd.Name = productDetailes.Name;
            prd.Color = productDetailes.Color;
            prd.Vat = productDetailes.Vat;

            try
            {
                _context.productDetailes.Update(prd);
                await _context.SaveChangesAsync();
                return RedirectToAction("productDetailes", "DashBoard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "حدث خطأ أثناء تحديث المنتج.");
                return View("EditProductDetailes", productDetailes);
            }
            // if (!ModelState.IsValid)
            {
                //    _context.Update(productDetailes);
                //    await _context.SaveChangesAsync();
                //   }

                //  return RedirectToAction("ProductDetailes");

            }
        }




        [HttpPost]
        public async Task<IActionResult> UpdateDepartments(Departments departments)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            if (!ModelState.IsValid)
            {
                return View("EditDepartments", departments);
            }

            var dep = await _context.departments.FindAsync(departments.Id);
            if (dep == null)
            {
                return NotFound();
            }

            dep.Name = departments.Name;
            dep.Number = departments.Number;
            dep.Description = departments.Description;

            try
            {
                _context.departments.Update(dep);
                await _context.SaveChangesAsync();
                return RedirectToAction("Departments","DashBoard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "حدث خطأ أثناء تحديث المنتج.");
                return View("EditDepartments",departments);
            }

          //  if (ModelState.IsValid)
           // {
              //  _context.Update(departments);
            //    await _context.SaveChangesAsync();

          //  }

          //  return RedirectToAction("departments");



        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployees(Employees employees)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            if (!ModelState.IsValid)
            {
                return View("EditEmployees", employees);
            }

            var emp = await _context.employees.FindAsync(employees.Id);
            if (emp == null)
            {
                return NotFound();
            }

            emp.Name = employees.Name;
            emp.Email = employees.Email;
            emp.Phone = employees.Phone;

            try
            {
                _context.employees.Update(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction("Employees", "DashBoard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "حدث خطأ أثناء تحديث المنتج.");
                return View("EditEmployees", employees);
            }

        }






        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Products products)
        {
            TempData["username"] = User.Identity.IsAuthenticated ? User.Identity.Name : "";

            if (!ModelState.IsValid)
            {
                return View("EditProducts", products);
            }

            var product = await _context.products.FindAsync(products.Id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = products.Name;
            product.Price = products.Price;
            product.Description = products.Description;

            try
            {
                _context.products.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Products","DashBoard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "حدث خطأ أثناء تحديث المنتج.");
                return View("EditProducts",products);
            }
        }



    }
}
