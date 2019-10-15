using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Project.Models
{
    public class DangKy
    {
        [Required(ErrorMessage="Không để trống!")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Không để trống!")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Không để trống!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage ="Email nhập sai. Mời nhập lại! Ví dụ example@gmail.com")]
        public string DiaChiMail { get; set; }
        [MinLength(8, ErrorMessage ="Mật khẩu phải ít nhất 8 ký tự!")]
        [Required(ErrorMessage = "Không để trống!")]
        public string MatKhau { get; set; }
        [Required(ErrorMessage = "Không để trống!")]
        [Compare("MatKhau", ErrorMessage ="Mật khẩu không trùng khớp. Mời nhập lại!")]
        public string NhapLaiMatKhau { get; set; }
    }
}