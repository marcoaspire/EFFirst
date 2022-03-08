using EFFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFFirst.Filters;
namespace EFFirst.Controllers
{
    public class ProductsController : Controller
    {
        //code-first approach
        CompanyDbContext db = new CompanyDbContext();
        // GET: Products
        [MyAuthFilter]
        public ActionResult Index(string search = "", string SortColumn = "ProductName", string IconClass = "bi bi-arrow-down",int PageNo=1)
        {
            //get all categories
            //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities(); //dbContext object
            
            List<Product> products = db.Products.ToList();
            //List<Product> products = db.Products.Where(item => item.CategoryID==1 && item.Price<50000).ToList();
            ViewBag.search = search;
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "bi bi-arrow-down")
                {

                    products = products.OrderBy(product => product.ProductName).ToList();
                }
                else
                {
                    products = products.OrderByDescending(product => product.ProductName).ToList();
                }
            }

            products=paginate(products, PageNo);
            return View(products);
        }

        private List<Product> paginate(List<Product> products, int PageNo)
        {
            int noOfRecordPerPage = 5;
            int noOfPages = (int)Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(noOfRecordPerPage));
            int noOfRecordsToSkip = (PageNo - 1) * noOfRecordPerPage;

            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = noOfPages;

            products=products.Skip(noOfRecordsToSkip).Take(noOfRecordPerPage).ToList();
            return products;
        }

        public ActionResult Search(string search="", string SortColumn="ProductName", string IconClass= "bi bi-arrow-down")
        {
            //get all categories
            //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities(); //dbContext object
            List<Product> products = db.Products.Where(item => item.ProductName.Contains(search)).ToList();
            products=paginate(products, 1);

            return View("Index", products);
        }

        public ActionResult Details(int id)
        {
            //get all categories
            //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities(); //dbContext object
            Product product =db.Products.Where(item => item.ProductID == id).FirstOrDefault();
            
            return View(product);
        }

        public ActionResult Create()
        {
            getDataForm();
            return View();
        }

        [HttpPost] 
        public ActionResult Save([Bind(Include = "ProductID,ProductName,Price,DateOfPurchase,AvailabilityStatus,CategoryID,BrandID,Active")]Product p)
        {
            //verify whether properties are valid or invalid, server side
            if (ModelState.IsValid)
            {
                db.Products.Add(p);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                getDataForm();
                return View("Create");
            }
            /*
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var 
            }
            */
            //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities(); //dbContext object
            

        }

        public ActionResult Edit(int id)
        {
            //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities(); //dbContext object
            Product product = db.Products.Where(item => item.ProductID == id).FirstOrDefault();
            getDataForm();

            return View(product);
        }

        [HttpPost]
        public ActionResult Update(Product p)
        {
            //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities(); //dbContext object
            Product product = db.Products.Where(item => item.ProductID == p.ProductID).FirstOrDefault();
            product.Price = p.Price;
            product.ProductName = p.ProductName;
            product.DateOfPurchase = p.DateOfPurchase;
            product.CategoryID = p.CategoryID;
            product.BrandID = p.BrandID;
            product.AvailabilityStatus = p.AvailabilityStatus;
            product.Active = p.Active;
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities(); //dbContext object
            Product product = db.Products.Where(item => item.ProductID == id).FirstOrDefault();
            db.Products.Remove(product);

            db.SaveChanges();

            return RedirectToAction("Index");

        }

        private void getDataForm()
        {

            List<SelectListItem> options = new List<SelectListItem>()
            {
                new SelectListItem{ Text="In stock", Value="InStock" },
                new SelectListItem{ Text="Out of stock", Value="OutOfStock" }
            };
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();

            ViewBag.Options = options;
        }

    }
}