using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;

namespace DOAN.Models
{
    public class ProductMetadata
    {
        [Display(Name = "Đường dẫn ảnh sản phẩm")]
        [DefaultValue("~/Content/img/suada.jpg")]
        public string HINHSP { get; set; }
        public int MASP { get; set; }
        [Required(ErrorMessage ="Tên sản phẩm bắt buộc !")]
        [Display(Name = "Tên sản phẩm")]
        
        public string TENSP { get; set; }
        public Nullable<int> MALOAIHANG { get; set; }
        [Display(Name = "Mô tả sản phẩm")]
        public string MOTA { get; set; }
        [Display(Name = "Giá")]
        public Nullable<decimal> GIA { get; set; }
    }
    public class CategoryMetadata
    {
        [Display(Name = "Mã loại hàng")]
        public int MALOAIHANG { get; set; }
        [Display(Name ="Tên loại hàng")]
        [Required(ErrorMessage = "Tên sản phẩm bắt buộc !")]
        public string TENLOAIHANG { get; set; }
    }
    public class ProductsDetailMetadata
    {
        public int ID { get; set; }
        [Display(Name = "Mã loại hàng")]
        public Nullable<int> MALOAIHANG { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public Nullable<int> MASP { get; set; }
        [Display(Name = "Kích cỡ")]
        public Nullable<bool> KICHCO { get; set; }
        public string TOPPING { get; set; }
        [Display(Name = "Giá topping")]
        public Nullable<decimal> GIATOPPING { get; set; }
    }
    public class AdminUserMetadata
    {
        public int ID { get; set; }
        public string NameUser { get; set; }
        public string RoleUser { get; set; }
        public string PasswordUser { get; set; }
    }
    public class CustomerMetadata
    {
        [Display(Name = "Mã khác hàng")]
        public int MAKH { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string TENKH { get; set; }
        [Display(Name = "Sô điện thoại")]
        public string SDT { get; set; }
        [Display(Name = "Email")]
        public string EMAIL { get; set; }
    }
    public class OrderDetailMetadata
    {
        [Display(Name = "Mã chi tiết")]
        public int MACHITIET { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public Nullable<int> MASP { get; set; }
        [Display(Name = "Mã đặt hàng")]
        public Nullable<int> MADH { get; set; }
        [Display(Name = "Số lượng")]
        public Nullable<int> SOLUONG { get; set; }
        [Display(Name = "Đơn giá")]
        public Nullable<double> DONGIA { get; set; }
    }
    public class OrderProMetadata
    {
        [Display(Name = "Mã đặt hàng")]
        public int MADATHANG { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public Nullable<int> MASP { get; set; }
        [Display(Name = "Tên loại hàng")]
        public Nullable<System.DateTime> NGAYDAT { get; set; }
        public Nullable<int> MAKH { get; set; }
        [Display(Name = "Địa chỉ giao hàng")]
        public string DIACHIGIAOHANG { get; set; }
        [Display(Name = "Mã thanh toán")]
        public string MATHANHTOAN { get; set; }
        [Display(Name = "Phương thức thanh toán")]
        public string PHUONGTHUCTTHANHTOAN { get; set; }
    }
}