using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class DocGiaDTO
    {
        [Required(ErrorMessage = "Mã độc giả")]
        [Display(Name = "Mã độc giả")]
        public int MaDG { set; get; }
        [Required(ErrorMessage = "Họ độc giả")]
        [RegularExpression(@"^[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ]*((-|\s)*[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ])*$",
        ErrorMessage = "Ký tự không được cho phép.")]
        [Display(Name = "Họ độc giả")]
        public string HoDG { set; get; }
        [Required(ErrorMessage = "Tên độc giả")]
        [RegularExpression(@"^[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ]*((-|\s)*[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ])*$",
        ErrorMessage = "Ký tự không được cho phép.")]
        [Display(Name = "Tên độc giả")]
        public string TenDG { set; get; }
        [Required(ErrorMessage = "Ngày tháng năm sinh")]
        [DataType(DataType.Date)]
        public DateTime DoBDG { set; get; }
        [Required(ErrorMessage = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailDG { set; get; }
        [Required(ErrorMessage = "Địa chỉ")]
        public string DiaChiDG { set; get; }
        [Required(ErrorMessage = "Ngày đăng ký")]
        [DataType(DataType.Date)]
        public DateTime NgayDK { set; get; }
        [Required(ErrorMessage = "Ngày hết hạn")]
        [DataType(DataType.Date)]
        public DateTime NgayHetHanDK { set; get; }
    }
}