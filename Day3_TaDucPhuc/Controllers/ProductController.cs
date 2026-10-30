using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day3_TaDucPhuc.Models;

namespace Day3_TaDucPhuc.Controllers
{
    public class ProductController : Controller
    {
        //gialapcsdl
        public static List<Product> _products = new List<Product>()
        {
            new Product(){Id=1, Name="Product 1", Price=10.0m, Description="Description 1", CategoryId=1},  
            new Product(){Id=2, Name="Product 2", Price=20.0m, Description="Description 2", CategoryId=2},
            new Product(){Id=3, Name="Product 3", Price=30.0m, Description="Description 3", CategoryId=3},
        };  
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(product => product.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                int newId =_products.Any()? _products.Max(p => p.Id) + 1 : 1;
                product.Id = newId;
                _products.Add(product);
                return RedirectToAction(nameof(Index));

            } 
                return View(product);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit([FromRoute] int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.CategoryId = product.CategoryId;
                return RedirectToAction(nameof(Index));
            }

            return View(product);
            
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) {
                return NotFound();
            }  
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComfirmed(int id, IFormCollection collection)
        {   
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }   
            _products.Remove(product);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
