using System.ComponentModel.DataAnnotations;

namespace Sales.API.Domain.DTOs.Comission
{
    public class ComissionDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Percentage { get; set; }
    }
}