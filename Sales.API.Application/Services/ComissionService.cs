using AutoMapper;
using Sales.API.Domain.DTOs;
using Sales.API.Domain.DTOs.Base;
using Sales.API.Domain.Entities;
using Sales.API.Domain.Interfaces.Repositories;
using Sales.API.Domain.Interfaces.Services;

namespace Sales.API.Application.Services
{
    public class ComissionService : IComissionService
    {
        private readonly IComissionRepository _comissionRepository;
        private readonly IMapper _mapper;

        public ComissionService(IComissionRepository comissionRepository, IMapper mapper)
        {
            _comissionRepository = comissionRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<ComissionDTO>> CreateAsync(ComissionDTO comissionDTO)
        {
            try
            {
                List<string> errors = Validate(comissionDTO);
                if (errors.Count > 0)
                    return new ResponseDTO<ComissionDTO>(400, errors);

                var comission = _mapper.Map<Comission>(comissionDTO);
                await _comissionRepository.CreateAsync(comission);
                return new ResponseDTO<ComissionDTO>(201, comissionDTO);
            }catch (Exception ex)
            {
                return new ResponseDTO<ComissionDTO>(500, ex.Message);
            }
        }

        public async Task DeleteAsync(Guid id)
        {

            await _comissionRepository.DeleteAsync(id);
        }
        public async Task<ICollection<ComissionDTO>> GetAllAsync()
        {
            var comissions = await _comissionRepository.GetAllAsync();
            return _mapper.Map<ICollection<ComissionDTO>>(comissions);

        }

        public async Task<ComissionDTO> GetByIdAsync(Guid id)
        {
            var comission = await _comissionRepository.GetByIdAsync(id);
            return _mapper.Map<ComissionDTO>(comission);
        }

        public async Task<ComissionDTO> UpdateAsync(ComissionDTO comissionDTO)
        {
            var comission = _mapper.Map<Comission>(comissionDTO);
            await _comissionRepository.EditAsync(comission);

            var result = _mapper.Map<ComissionDTO>(comission);
            return result;
        }

        public List<string> Validate(ComissionDTO comissionDTO)
        {
            List<string> errors = new List<string>();
            if (comissionDTO.Name.Length > 50)
                errors.Add("Nome deve conter no máximo 50 caracteres.");
            if (comissionDTO.Percentage <= 0)
                errors.Add("Porcentagem não deve ser menor ou igual a zero.");

            return errors;
        }
    }

}
