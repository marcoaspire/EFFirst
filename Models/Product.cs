using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFFirst.Models
{
    [Table("Products",Schema ="dbo")]
    public class Product
    {
        [Key]
        public long ProductID { get; set; }
        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }
        [Required]

        public Nullable<decimal> Price { get; set; }
        [Display(Name = "Date Of Purchase")]
        [Column("DateOfPurchase", TypeName="datetime")]
        [Required]

        public Nullable<DateTime> DateOfPurchase { get; set; }
        [Required]
        public string AvailabilityStatus { get; set; }
        [Display(Name = "Category")]
        [Required]
        public Nullable<long> CategoryID { get; set; }
        [Required]
        [Display(Name = "Brand")]
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }


        //many to one
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}