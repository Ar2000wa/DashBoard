using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsDashBoard.Data;
using ProductsDashBoard.Models;




namespace MtApp.Namespace
{ 
       public class ShopController : Controller
{
    private readonly AppDbContext _context;

    public ShopController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        // HttpContext.Session.SetString("example", "ABCD");
        //HttpContext.Session.SetInt32("total", 1000);
        //ViewBag.getval = HttpContext.Session.GetString("example");
        //ViewBag.val = HttpContext.Session.GetInt32("total");
        ViewBag.counter = Request.Cookies["counter"];
        var products = _context.products.ToList();
        return View(products);
    }

    public async Task<IActionResult> Details(int ProductId)
    {
        var productDetailesWithProduct = _context.productDetailes.Include(s => s.products).FirstOrDefault(p => p.ProductId == ProductId);


        if (productDetailesWithProduct != null)
        {
            return View(productDetailesWithProduct);
        }

        return RedirectToAction("Index");

    }

    public async Task<IActionResult> Add_To_Cart(int itemid)
    {

        var cartItem = await _context.cart.FirstOrDefaultAsync(p => p.ProductId == itemid);

        if (cartItem != null)
        {
            cartItem.Qty++;
            _context.Update(cartItem);
        }
        else
        {
            var cart = new Cart
            {
                ProductId = itemid,
                Qty = 1,
                CreatedAt = DateTime.Now
            };

            _context.Add(cart);


        }


        await _context.SaveChangesAsync();

        var total = await _context.cart.SumAsync(c => c.Qty);
        // TempData["total"] = total;
        CookieOptions cookie = new CookieOptions();
        cookie.Expires = DateTime.Now.AddMinutes(60);
        Response.Cookies.Append("counter", total.ToString(), cookie);
        var productDetailes = await _context.productDetailes.Include(s => s.products).FirstOrDefaultAsync(p => p.Id == itemid);
        return View("Details", productDetailes);



    }
}
}



 




    
    
