using FirstMVCProject.Models;
using FirstMVCProject.Repositories;
using FirstMVCProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FirstMVCProject.Controllers
{
    public class ShopController : Controller
    {
        SalesRepository salesRepository = new();
        ProductRepository productRepository = new();

        UserRepository userRepository = new();

        public IActionResult Buy(int id)
        {
            var data= productRepository.Get(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Buy(ShopVM model, Product product, int id)
        {
            var data = productRepository.Get(id);
            var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("username"));

            model.BuyerId = sessionUser.Userid;
            model.SellerId = product.Userid;
            model.ProductId = id;
            model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Sale newSale = new()
            {
                BuyerId = model.BuyerId,
                SellerId = data.Userid,
                ProductID= model.ProductId,
                Date = model.Date
            };

            if (sessionUser.Budget >= data.Price)
            {
                sessionUser.Budget -= data.Price;

                var sellerUser = userRepository.Get(data.Userid);
                sellerUser.Budget += data.Price;

                userRepository.Update(sessionUser);
                userRepository.Update(sellerUser);
                salesRepository.Add(newSale);
            }

            return RedirectToAction("Index", "Product");
        }


    }
}
