using AutoMapper;
using CricketStore.BLL.DTOs.Request;
using CricketStore.BLL.DTOs.Response;
using CricketStore.BLL.services;
using CricketStore.DAL.entities;
using CricketStore.DAL.repositories;

namespace CricketStore.BLL.Services
{
    public interface IUserService : IBaseService<UserRequestDTO, UserResponseDTO>
    {
    }
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public UserService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<UserResponseDTO> Add(UserRequestDTO requestDTO)
        {
            var user = mapper.Map<User>(requestDTO);
            var responseUser = await this.repositoryWrapper.UserRepository.CreateAsync(user);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<UserResponseDTO>(responseUser);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var usertodelete = await this.repositoryWrapper.UserRepository.GetById(id);
            if (usertodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.UserRepository.DeleteAsync(usertodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAll()
        {
            var user = await this.repositoryWrapper.UserRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<UserResponseDTO>>(user);
            return result;
        }

        public async Task<UserResponseDTO> GetById(int id)
        {
            var user = await this.repositoryWrapper.UserRepository.GetById(id);
            var result = mapper.Map<UserResponseDTO>(user);
            return result;
        }


        public async Task<UserResponseDTO> Update(int id, UserRequestDTO requestDTO)
        {
            var f = mapper.Map<User>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.UserRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<UserResponseDTO>(v);
            return k;
        }


    }
}