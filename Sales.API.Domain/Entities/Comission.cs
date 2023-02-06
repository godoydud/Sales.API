using System.ComponentModel.DataAnnotations;

namespace Sales.API.Domain.Entities
{
    public class Comission
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome da comissão é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Valor de comissão é obrigatório.")]
        public int Percentage { get; set; }
    }
}
