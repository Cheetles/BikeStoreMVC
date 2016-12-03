using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BikeStoreMVC.Models
{
    public class productMetadata
    {
        [StringLength(10)]
        [Display(Name = "Product Code")]
        public string productCode;

        [Display(Name = "Product Name")]
        public string productName;

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal price;



        [Display(Name = "Category")]
        public int categoryID;
        [Display(Name = "Sub Category")]
        public int subCategoryID;
        [Display(Name = "Model")]
        public int modelID;
    }

    public class categoryMetadata
    {
        [Display(Name = "Category")]
        public int catID;
    }
}