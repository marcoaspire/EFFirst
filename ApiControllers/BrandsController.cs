using EFFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace EFFirst.ApiControllers
{
    //returns only string values or objects => JSON
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BrandsController : ApiController
    {
        //code-first approach
        CompanyDbContext db = new CompanyDbContext();
        public List<Brand> Get()
        {
            //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities(); //dbContext object
            List<Brand> brands = db.Brands.ToList();
            //return JsonConvert.SerializeObject(brands);
            return brands;
        }

        public void Post(Brand b)
        {
            //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities(); //dbContext object
            db.Brands.Add(b);
            db.SaveChanges();
        }

        public void Put(Brand brandData)
        {
            //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities(); //dbContext object
            Brand brand = db.Brands.Where(item => item.BrandID == brandData.BrandID).FirstOrDefault();
            brand.BrandName = brandData.BrandName;
            
            db.SaveChanges();
        }

        [Authorize(Roles = "Admin")]
        public void Delete(Brand brandData)
        {
           //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities(); //dbContext object
            Brand brand = db.Brands.Where(item => item.BrandID == brandData.BrandID).FirstOrDefault();
            db.Brands.Remove(brand);
            db.SaveChanges();

        }
    }
}
