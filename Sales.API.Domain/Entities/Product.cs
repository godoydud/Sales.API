using Sales.API.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.API.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome do produto é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preço do produto é obrigatório.")]
        public double Price { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }
        public double ComissionPrice { get; set; }
        
        public Guid ComissionId { get; set; }

        #region [Foreign Key]
        [ForeignKey("ComissionId")]
        public virtual Comission Comission { get; set; }
        #endregion

    }
}
