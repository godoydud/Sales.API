using Microsoft.AspNetCore.Http;
using Sales.API.Domain.DTOs.Base;
using Sales.API.Domain.DTOs.Comission;

namespace Sales.API.Test.UnitTest.ComissionTest
{
    class ComissionTestValidData
    {
        public static ComissionDTO Build()
        {
            return new ComissionDTO
            {
                Name = "Comission 1",
                Percentage = 10
            };
        }

        public static ComissionDTO Response()
        {
            return new ComissionDTO
            {
                Name = "Comission 1",
                Percentage = 10
            };
        }
    }

    class ComissionTestInvalidData
    {
        public static ComissionDTO BuildPercentageInvalid()
        {
            return new ComissionDTO
            {
                Id = Guid.NewGuid(),
                Name = "Comission 1",
                Percentage = 0
            };
        }
        
        public static ComissionDTO BuildMaxLength()
        {
            return new ComissionDTO
            {
                Id = Guid.NewGuid(),
                Name = "Comission 1testestestestestestestestestestestestestestestestetestestestestestestestestestestestestestestesteste testestestestestestestestestestestestestestesteste",
                Percentage = 1
            };
        }

        public static ResponseDTO<ComissionDTO> ResponsePercentageInvalid()
        {
            return new ResponseDTO<ComissionDTO>
            {
                StatusCode = StatusCodes.Status400BadRequest,
                ValidationErrors = { "Porcentagem não deve ser menor ou igual a zero." },
            };
        }

        public static ResponseDTO<ComissionDTO> ResponseMaxLength()
        {
            return new ResponseDTO<ComissionDTO>
            {
                StatusCode = StatusCodes.Status400BadRequest,
                ValidationErrors = { "Nome deve conter no máximo 50 caracteres." },

            };
        }
    }   
}
