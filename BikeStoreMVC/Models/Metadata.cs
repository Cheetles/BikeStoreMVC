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
    }
}