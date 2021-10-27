using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class TacGiaDTO
    {
        [Display(Name = "Mã tác giả")]
        public int MaTG { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ]*((-|\s)*[A-Za-zÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰĐÝỲỶỸỴáàảãạâấầẩẫậăắằẳẵặéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựđýỳỷỹỵ])*$",
        ErrorMessage = "Ký tự không được cho phép.")]
        [Display(Name = "Tên tác giả")]
        public string TenTG { get; set; }
    }
}