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
    
    public partial class Payment
    {
        public Nullable<int> MASP { get; set; }
        public string MAKH { get; set; }
        public string GHICHU { get; set; }
        public Nullable<System.DateTime> NGAYTHANHTOAN { get; set; }
        public string MATHANHTOAN { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
