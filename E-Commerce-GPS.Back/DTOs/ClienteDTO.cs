using System.ComponentModel.DataAnnotations;

namespace EcommerceBackend.DTOs
{
	public class ClienteDTO
	{
		[Required(ErrorMessage = "O nome é obrigatório.")]
		[StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "O CPF é obrigatório.")]
		[StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
		public string CPF { get; set; }
	}
}