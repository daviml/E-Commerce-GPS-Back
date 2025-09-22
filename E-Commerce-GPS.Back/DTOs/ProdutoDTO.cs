using System.ComponentModel.DataAnnotations;

namespace EcommerceBackend.DTOs
{
	public class ProdutoDTO
	{
		[Required(ErrorMessage = "O nome é obrigatório.")]
		[StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
		public string Nome { get; set; }

		[Range(0.01, 100000.00, ErrorMessage = "O preço deve estar entre R$0,01 e R$100.000,00.")]
		public decimal Preco { get; set; }
	}
}