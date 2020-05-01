using System.ComponentModel.DataAnnotations;

namespace SwaggerApiNetCore31.ViewModels
{
    public class UsuarioBaseVm
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o nome.")]
        [MinLength(3, ErrorMessage = "O nome deve ter um tamanho mínimo de 3 caracteres.")]
        public string Name { get; set; }

        /// <summary>
        /// O e-mail deve ser válido, será necessário confirmá-lo posteriormente.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o e-mail.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; }
    }
}
