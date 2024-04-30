using AutoMapper;
using CricketStore.BLL.DTOs.Request;
using CricketStore.BLL.DTOs.Response;
using CricketStore.BLL.services;
using CricketStore.DAL.entities;
using CricketStore.DAL.repositories;

namespace CricketStore.BLL.Services
{
    public interface IRoleService : IBaseService<RoleRequestDTO, RoleResponseDTO>
    {
    }
    public class RoleService : IRoleService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public RoleService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<RoleResponseDTO> Add(RoleRequestDTO requestDTO)
        {
            var role = mapper.Map<Role>(requestDTO);
            var responseRole = await this.repositoryWrapper.RoleRepository.CreateAsync(role);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<RoleResponseDTO>(responseRole);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var roletodelete = await this.repositoryWrapper.RoleRepository.GetById(id);
            if (roletodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.RoleRepository.DeleteAsync(roletodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<RoleResponseDTO>> GetAll()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
        {
            var res = await this.repositoryWrapper.RoleRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<RoleResponseDTO>>(res);
            return result;
        }

        public async Task<RoleResponseDTO> GetById(int id)
        {
            var res = await this.repositoryWrapper.RoleRepository.GetById(id);
            var result = mapper.Map<RoleResponseDTO>(res);
            return result;
        }


        public async Task<RoleResponseDTO> Update(int id, RoleRequestDTO requestDTO)
        {
            var f = mapper.Map<Role>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.RoleRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<RoleResponseDTO>(v);
            return k;
        }


    }
}