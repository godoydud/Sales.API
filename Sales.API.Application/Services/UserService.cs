using AutoMapper;
using Sales.API.Domain.DTOs.Base;
using Sales.API.Domain.DTOs.User;
using Sales.API.Domain.Entities;
using Sales.API.Domain.Interfaces.Repositories;
using Sales.API.Domain.Interfaces.Services;
using System.Text;
using System.Security.Cryptography;
using System.Text;

namespace Sales.API.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDapperRepository _userDapperRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUserDapperRepository userDapperRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _userDapperRepository = userDapperRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<UserDTO>> CreateAsync(UserDTO userDTO)
        {
            try
            {
                List<string> errors = ValidateUser(userDTO);
                if (errors.Any())
                    return new ResponseDTO<UserDTO>(400, errors);

                var user = _mapper.Map<User>(userDTO);
                user.Password = EncryptPassword(user.Password);
                await _userDapperRepository.CreateAsync(user);
                return new ResponseDTO<UserDTO>(201);
            }
            catch (Exception ex)
            {
                return new ResponseDTO<UserDTO>(500, ex.Message);
            }
        }

        public bool Login(string username, string password)
        {
            var users = GetAllAsync();
            var user = users.Result.Where(x => x.UserName == username).FirstOrDefault();
            if (user != null)
                if (user.Password.Equals(EncryptPassword(password)))
                    return true;

            return false;
        }

        public async Task<ICollection<UserDTO>> GetAllAsync()
        {
            var users = await _userDapperRepository.GetAllAsync();
            return _mapper.Map<ICollection<UserDTO>>(users);
        }

        public List<string> ValidateUser(UserDTO userDTO)
        {
            List<string> errors = new List<string>();
            if (!userDTO.Password.Equals(userDTO.ConfirmPassword))
                errors.Add("As senhas não conferem!");
            if (userDTO.UserName.Length > 20)
                errors.Add("Nome não deve ultrapassar 20 caracteres.");
            if (userDTO.Password.Length < 8)
                errors.Add("Senha deve possuir no mínimo 8 caracteres.");

            return errors;
        }

        public async Task<UserDTO> GetUserByIdAsync(Guid id)
        {
            var result = await _userDapperRepository.GetUserByIdAsync(id);
            var mapResult = _mapper.Map<UserDTO>(result);
            return mapResult;
        }

        public string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
