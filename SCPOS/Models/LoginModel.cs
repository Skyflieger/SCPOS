using System.ComponentModel.DataAnnotations;

namespace SCPOS.Models; 

public class LoginModel {
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool RememberLogin { get; set; }

    public string ReturnUrl { get; set; }

    [Required]
    [Display(Name = "Username")]
    public string UserName { get; set; }
}