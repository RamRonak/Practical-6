using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Category = "Electronics",
                Price = 55000,
                Quantity = 10,
                Description = "High performance laptop"
            },
            new Product
            {
                Id = 2,
                Name = "Smartphone",
                Category = "Electronics",
                Price = 25000,
                Quantity = 20,
                Description = "Latest Android smartphone"
            },
            new Product
            {
                Id = 3,
                Name = "Keyboard",
                Category = "Accessories",
                Price = 1500,
                Quantity = 30,
                Description = "Wireless keyboard"
            }
        };

        public ActionResult Index()
        {
            return View(products);
        }

        public ActionResult Details(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = products.Count == 0 ? 1 : products.Max(p => p.Id) + 1;
                products.Add(product);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult Edit(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                Product existingProduct = products.FirstOrDefault(p => p.Id == product.Id);

                if (existingProduct == null)
                    return HttpNotFound();

                existingProduct.Name = product.Name;
                existingProduct.Category = product.Category;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                existingProduct.Description = product.Description;

                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult Delete(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
                products.Remove(product);

            return RedirectToAction("Index");
        }
    }
}