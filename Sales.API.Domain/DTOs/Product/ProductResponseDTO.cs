using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.API.Domain.DTOs.Product
{
    public class ProductResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }
        public double ComissionPrice { get; set; }
        public Guid ComissionId { get; set; }
    }
}
