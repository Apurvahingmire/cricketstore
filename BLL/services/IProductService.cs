using AutoMapper;
using CricketStore.BLL.DTOs.Request;
using CricketStore.BLL.DTOs.Response;
using CricketStore.BLL.services;
using CricketStore.DAL.entities;
using CricketStore.DAL.repositories;
namespace CricketStore.BLL.Services
{

    public interface IProductService : IBaseService<ProductRequestDTO, ProductResponseDTO>
    {
        Task<IEnumerable<ProductResponseDTO>> GetByBrandId(int brandId);
    }


    public class ProductService : IProductService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public ProductService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<ProductResponseDTO> Add(ProductRequestDTO requestDTO)
        {
            var product = mapper.Map<Product>(requestDTO);
            var responseProduct = await this.repositoryWrapper.ProductRepository.CreateAsync(product);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<ProductResponseDTO>(responseProduct);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var producttodelete = await this.repositoryWrapper.ProductRepository.GetById(id);
            if (producttodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.ProductRepository.DeleteAsync(producttodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAll()
        {
            var product = await this.repositoryWrapper.ProductRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<ProductResponseDTO>>(product);
            return result;
        }

        public async Task<ProductResponseDTO> GetById(int id)
        {
            var product = await this.repositoryWrapper.ProductRepository.GetById(id);
            var result = mapper.Map<ProductResponseDTO>(product);
            return result;
        }

        public async Task<ProductResponseDTO> Update(int id, ProductRequestDTO requestDTO)
        {
            var f = mapper.Map<Product>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.ProductRepository.UpdateAsync(id,f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<ProductResponseDTO>(v);
            return k;
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetByBrandId(int brandId)
        {
            var products = await this.repositoryWrapper.ProductRepository.GetProductsByBrandId(brandId);
            var response = mapper.Map<IEnumerable<ProductResponseDTO>>(products);
            return response;


        }
    }
}