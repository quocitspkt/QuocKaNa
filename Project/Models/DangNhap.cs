using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class DangNhap
    {
        public string IsCustomer { get; set; }
        [Required(ErrorMessage = "Không để trống!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email nhập sai. Mời nhập lại! Ví dụ example@gmail.com")]
        public string DiaChiMail { get; set; }
        [Required(ErrorMessage = "Không để trống!")]
        [MinLength(8,ErrorMessage = "Mật khẩu phải ít nhất 8 ký tự!")]
        public string MatKhau { get; set; }
    }
}