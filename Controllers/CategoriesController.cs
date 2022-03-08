using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EFFirst.Models;
namespace EFFirst.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories/Index
        public ActionResult Index()
        {
            //get all categories
            //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities(); //dbContext object
            //code-first approach
            CompanyDbContext db = new CompanyDbContext();
            List<Category> categories=db.Categories.ToList();
            return View(categories);
        }
    }
}