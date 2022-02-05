using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppWeb.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "بريد إلكتروني")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "رمز")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "تذكر هذا المتصفح؟")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "بريد إلكتروني")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [Display(Name = "تذكرنى؟")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "بريد إلكتروني")]
        public string Email { get; set; }  
        [Required]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }    
        [Required]
        [Display(Name = "الاسم الكامل")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "حي")]
        public string District { get; set; }
        [Required]
        [Display(Name = "المدينة")]
        public string City { get; set; }
   
 
        [Required]
        [Display(Name = "شارع")]
        public string Street { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "يجب ألا يقل طول {0} عن {2} من الأحرف.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور")]
        [Compare("Password", ErrorMessage = "كلمة المرور وكلمة المرور التأكيدية غير متطابقتين.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Phone]
        [Display(Name = "رقم جوال")]
        public string PhoneNumber { get;  set; }  

        [Display(Name = "موقع")]
        public string Location { get;  set; }


    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "بريد إلكتروني")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "يجب ألا يقل طول {0} عن {2} من الأحرف.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور")]
        [Compare("Password", ErrorMessage = "كلمة المرور وكلمة المرور التأكيدية غير متطابقتين.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "بريد إلكتروني")]
        public string Email { get; set; }
    }
}
