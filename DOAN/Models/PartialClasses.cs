using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.IO;
using System.ComponentModel;

namespace DOAN.Models
{
    public class PartialClasses
    {
        [MetadataType(typeof(ProductMetadata))]
        public partial class Product
        {
            [NotMapped]
            public HttpPostedFileBase UploadImage { get; set; }
           
        }

        [MetadataType(typeof(CategoryMetadata))]
        public partial class Category
        {
            [NotMapped]
            public List<Category> ListCate { get; set; }
        }
        [MetadataType(typeof(CustomerMetadata))]
        public partial class Customer
        {
            [NotMapped]
            [Compare("PASSWORD")]
            [DisplayName("Nhập lại mật khẩu")]
            public string ConfirmPass { get; set; }
        }
    }
}