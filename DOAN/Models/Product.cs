//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DOAN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.Payments = new HashSet<Payment>();
            HINHSP = "~/Content/img/suada/jpg";
        }
    
        public int MASP { get; set; }
        public string TENSP { get; set; }
        public Nullable<int> MALOAIHANG { get; set; }
        public Nullable<double> GIa { get; set; }
        public string HINHSP { get; set; }
        public string MOTA { get; set; }
        public Nullable<int> MATOP { get; set; }
        public Nullable<int> MASIZE { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual size size { get; set; }
        public virtual Topping Topping { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
    }
}
