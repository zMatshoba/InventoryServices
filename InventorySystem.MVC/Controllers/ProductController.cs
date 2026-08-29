using InventorySystem.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventorySystem.MVC.Controllers
{
    public class ProductController(IProductService productService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProductsAsync();

            return View(products);
        }
    }
}
