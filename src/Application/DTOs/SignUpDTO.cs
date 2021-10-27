using Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class SignUpDTO
    {
        [Required(ErrorMessage = "Họ và tên lót")]
        [RegularExpression(@"^[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ]*((-|\s)*[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ])*$",
        ErrorMessage = "Ký tự không được cho phép.")]
        [Display(Name = "Họ và tên lót")]
        public string HoNV { get; set; }

        [Required(ErrorMessage = "Tên")]
        [RegularExpression(@"^[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ]*((-|\s)*[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ])*$",
        ErrorMessage = "Ký tự không được cho phép.")]
        [Display(Name = "Tên")]
        public string TenNV { get; set; }

        [Required(ErrorMessage = "Date of birth")]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DoBNV { get; set; }

        [Required(ErrorMessage = "Hãy nhập số điện thoại")]
        [RegularExpression(@"^[0-9]{10}$",
         ErrorMessage = "Chỉ sử dụng số và tối đa 10 ký tự.")]
        [Display(Name = "Số điện thoại")]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Hãy nhập địa chỉ email của bạn")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hãy nhập mật khẩu của bạn")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Hãy nhập lại mật khẩu của bạn")]
        [Display(Name = "Nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        public string ComfirmPassword { get; set; }

        [Required(ErrorMessage = "Hãy chọn role cho người dùng")]
        public Role Role { get; set; }
    }
}