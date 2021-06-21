namespace ModelEF.Model
{
    using ModelEF.Enum;
    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Web;

    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Image = "~/Content/images/add.jpg";
        }

        [Key]
        [StringLength(10)]
        [DisplayName("Mã sách")]
        public string idProduct { get; set; }

        [StringLength(10)]
        [DisplayName("Mã thể loại")]
        public string idCategory { get; set; }

        [Required(ErrorMessage ="Tên sách phải bắt buộc")]
        [StringLength(100)]
        [DisplayName("Tên sách")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Giá sách phải bắt buộc")]
        [DisplayName("Giá sách")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập giá tiền lớn hơn 0")]
        public decimal? Unicost { get; set; }

        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Số lượng phải bắt buộc")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập số lượng lớn hơn 0")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Hình ảnh phải bắt buộc")]
        [DisplayName("Hình ảnh")]
        [StringLength(200)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Tác giả phải bắt buộc")]
        [DisplayName("Tác giả")]
        [StringLength(100)]
        public string Author { get; set; }


        [Required(ErrorMessage = "Nhà phát hành phải bắt buộc")]
        [DisplayName("Nhà phát hành")]
        [StringLength(100)]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Năm phát hành phải bắt buộc")]
        [Range(1800, int.MaxValue, ErrorMessage = "Năm phát hành phải lớn hơn 1800")]
        [DisplayName("Năm phát hành")]
        public int Year { get; set; }

        [DisplayName("Mô tả")]
        [StringLength(200)]
        public string Description { get; set; }

        [DisplayName("Tình trạng")]
        public bool? Status { get; set; }

        public virtual Category Category { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
