using AutoMapper;
using CricketStore.BLL.DTOs.Request;
using CricketStore.BLL.DTOs.Response;
using CricketStore.DAL.entities;
using CricketStore.DAL.repositories;

namespace CricketStore.BLL.Services
{
    public interface ILogInService
    {
        Task<LogInResponseDTO?> IsValidUser(LogInRequestDTO LogInRequestDTO);
    }
    public class LogInService : ILogInService
    {

        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public LogInService(IRepositoryWrapper repositoryWrapper, IConfiguration configuration, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.configuration = configuration;
            this.mapper = mapper;
        }


        public async Task<LogInResponseDTO?> IsValidUser(LogInRequestDTO LogInRequestDTO)
        {
            var user = await this.repositoryWrapper.LogInRepository.ValidateUser(LogInRequestDTO.Email, LogInRequestDTO.PasswordHash);
            if (user is not null)
            {
                return new LogInResponseDTO
                {
                    Id = user.Id,
                    Firstname = user.Firstname,
                    LastName = user.LastName,
                    Username = user.Username,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    PhoneNo = user.PhoneNo,
                    Dob = user.Dob,
                    RoleId=user.RoleId,
                    Gender=user.Gender,
                    Address=user.Address,


                };
            }
            return null;
        }
    }


}