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
    
    public partial class OrderPro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderPro()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int MADATHANG { get; set; }
        public Nullable<int> MASP { get; set; }
        public Nullable<System.DateTime> NGAYDAT { get; set; }
        public Nullable<int> MAKH { get; set; }
        public string DIACHIGIAOHANG { get; set; }
        public string PHUONGTHUCTTHANHTOAN { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
