using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BikeStoreMVC.Models
{
    [MetadataType(typeof(productMetadata))]
    public partial class tbl_product
    {
    }

    [MetadataType(typeof(categoryMetadata))]
    public partial class tbl_category
    { }

    [MetadataType(typeof(colourMetadata))]
    public partial class tbl_colour
    { }

    [MetadataType(typeof(modelMetadata))]
    public partial class tbl_model
    { }

    [MetadataType(typeof(subcategoryMetadata))]
    public partial class tbl_sub_category
    {
    }

    [MetadataType(typeof(sizeMetadata))]
    public partial class tbl_size
    {
    }
}