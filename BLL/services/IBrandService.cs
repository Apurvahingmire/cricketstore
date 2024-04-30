using AutoMapper;
using CricketStore.BLL.DTOs.Request;
using CricketStore.BLL.DTOs.Response;
using CricketStore.DAL.entities;
using CricketStore.DAL.repositories;
using CricketStore.BLL.services;
using System.Net;


namespace CricketStore.BLL.Services
{


    public interface IBrandService : IBaseService<BrandRequestDTO, BrandResponseDTO>
    {
    }

    public class BrandService : IBrandService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public BrandService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<BrandResponseDTO> Add(BrandRequestDTO requestDTO)
        {
            var brand = mapper.Map<Brand>(requestDTO);
            var responseBrand = await this.repositoryWrapper.BrandRepository.CreateAsync(brand);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<BrandResponseDTO>(responseBrand);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var brandtodelete = await this.repositoryWrapper.BrandRepository.GetById(id);
            if (brandtodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.BrandRepository.DeleteAsync(brandtodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<BrandResponseDTO>> GetAll()
        {
            var brand = await this.repositoryWrapper.BrandRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<BrandResponseDTO>>(brand);
            return result;
        }

        public async Task<BrandResponseDTO> GetById(int id)
        {
            var brand = await this.repositoryWrapper.BrandRepository.GetById(id);
            var result = mapper.Map<BrandResponseDTO>(brand);
            return result;
        }



        public async Task<BrandResponseDTO> Update(int id, BrandRequestDTO requestDTO)
        {
            var f = mapper.Map<Brand>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.BrandRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<BrandResponseDTO>(v);
            return k;
        }

        public Task<BrandResponseDTO> Update(BrandRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
    }


}