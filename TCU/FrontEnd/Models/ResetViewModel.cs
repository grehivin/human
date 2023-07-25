using bend.bil;
using bend.dal.entities;
using System.ComponentModel.DataAnnotations;

namespace fend.Models
{
    public class ResetViewModel
    {
        [Display(Name = "Código de verificación")]
        public string VerificationCode { get; set; }
        [Required(ErrorMessage = "Debe ingresar el código de verificación igual al que se muestra de lo contrario no se podrá actualizar su contraseña.")]
        [Compare(nameof(VerificationCode), ErrorMessage = "El código de verificación ingresado no coincide con el indicado.")]
        [Display(Name = "Confirmación del código de verificación")]
        public string CodeConfirmation { get; set; }
        [Required(ErrorMessage = "El correo electrónico es necesario para cambiar su contraseña")]
        [Display(Name = "Correo electrónico")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Debe ingresar la misma contraseña para confirmarla")]
        [Compare(nameof(Password), ErrorMessage = "La contraseña no coincide con la ingresada")]
        [Display(Name = "Confirmación de contraseña")]
        public string PasswordConfirmation { get; set; }

        public ResetViewModel()
        {
            VerificationCode = new Security().GenerateVerificationCode(12);
            CodeConfirmation = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            PasswordConfirmation = string.Empty;
        }
    }
}
