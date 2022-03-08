using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

//Code-first approach
namespace EFFirst.Models
{
    public class Brand
    {
        [Key]
        public long BrandID { get; set; }
        public string BrandName { get; set; }

    }
}