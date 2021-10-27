using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class NhanVienDTO
    {

        [Display(Name = "Mã nhân viên")]
        public int Id { get; set; }

        [Display(Name = "Password")]
        public string PasswordNV { get; set; }

        [RegularExpression(@"^[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ]*((-|\s)*[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ])*$",
        ErrorMessage = "Ký tự không được cho phép.")]
        [Display(Name = "Họ nhân viên")]
        public string HoNV { get; set; }

        [RegularExpression(@"^[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ]*((-|\s)*[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ])*$",
        ErrorMessage = "Ký tự không được cho phép.")]
        [Display(Name = "Tên nhân viên")]
        public string TenNV { get; set; }

        [Required(ErrorMessage = "Ngày tháng năm sinh")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh nhân viên")]
        public DateTime DoBNV { set; get; }

        [RegularExpression(@"^[0-9]{10}$",
         ErrorMessage = "Chỉ sử dụng số và tối đa 10 ký tự.")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Email nhân viên")]
        public string Email { get; set; }


        [Display(Name = "Địa chỉ nhân viên")]
        public string DiaChiNV { get; set; }

        public List<UserClaim> UserClaims { get; set; }
        public Role Role { get; set; }

        public NhanVienDTO()
        {
            UserClaims = new List<UserClaim>();
        }
    }
}
