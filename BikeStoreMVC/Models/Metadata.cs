using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BikeStoreMVC.Models
{
    public class productMetadata
    {
        [StringLength(10, ErrorMessage = "The product code cannot exceed 10 characters. ")]
        [Display(Name = "Product Code")]
        public string productCode;

        [StringLength(50, ErrorMessage = "The product name cannot exceed 50 characters. ")]
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

        [Display(Name = "Colour")]
        public int colourID;

        [Display(Name = "Size")]
        public int sizeID;

        [StringLength(250, ErrorMessage = "The description cannot exceed 250 characters. ")]
        [Display(Name = "Description")]
        public string description;
    }

    public class categoryMetadata
    {
        [Display(Name = "Category")]
        public int catID;

        [StringLength(30, ErrorMessage = "The category name cannot exceed 15 characters. ")]
        [Display(Name = "Category")]
        public string category;
    }

    public class colourMetadata
    {
        [Display(Name = "Colour")]
        [StringLength(15, ErrorMessage = "The colour cannot exceed 15 characters. ")]
        public string colour;
    }

    public class modelMetadata
    {
        [Display(Name = "Model")]
        [StringLength(30, ErrorMessage = "The model cannot exceed 30 characters. ")]
        public string model;
    }

    public class subcategoryMetadata
    {
        [Display(Name = "Category")]
        public int catID;

        [Display(Name = "Sub Category")]
        public int subID;

        [StringLength(30, ErrorMessage = "The sub category name cannot exceed 30 characters. ")]
        [Display(Name = "Sub Category")]
        public string subcategory; 
    }

    public class sizeMetadata
    {
        [StringLength(2, ErrorMessage = "The size cannot exceed 2 characters. ")]
        [Display(Name = "Size")]
        public string size;
    }
}