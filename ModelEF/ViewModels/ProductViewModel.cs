using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ModelEF.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [StringLength(10)]
        public string idProduct { get; set; }

        [StringLength(10)]
        public string idCategory { get; set; }

        [Required]
        [StringLength(100)]
        public string NameProduct { get; set; }

        [Required]
        [StringLength(100)]
        public string NameCategory { get; set; }

        public decimal? Unicost { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập số lượng lớn hơn 0")]
        public int Amount { get; set; }

        public string Image { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        [StringLength(100)]
        public string Publisher { get; set; }

        public int Year { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public bool? Status { get; set; }

    }
}
