using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class NhaXuatBanDTO
    {
        [Display(Name = "Mã nhà xuất bản")]
        public int MaNXB { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ]*((-|\s)*[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ])*$",
        ErrorMessage = "Ký tự không được cho phép.")]
        [Display(Name = "Tên nhà xuất bản")]
        public string TenNXB { get; set; }
    }
}