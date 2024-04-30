using AutoMapper;
using CricketStore.BLL.DTOs.Request;
using CricketStore.BLL.DTOs.Response;
using CricketStore.BLL.services;
using CricketStore.DAL.entities;
using CricketStore.DAL.repositories;

namespace CricketStore.BLL.Services
{
    public interface ICartService : IBaseService<CartRequestDTO, CartResponseDTO>
    {
    }
    public class CartService : ICartService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public CartService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<CartResponseDTO> Add(CartRequestDTO requestDTO)
        {
            var cart = mapper.Map<Cart>(requestDTO);
            var responseCart = await this.repositoryWrapper.CartRepository.CreateAsync(cart);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<CartResponseDTO>(responseCart);
            return result;
        }


        public async Task<IEnumerable<CartResponseDTO>> GetAll()
        {
            var cart = await this.repositoryWrapper.CartRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<CartResponseDTO>>(cart);
            return result;
        }

        public async Task<CartResponseDTO> GetById(int id)
        {
            var cart = await this.repositoryWrapper.CartRepository.GetById(id);
            var result = mapper.Map<CartResponseDTO>(cart);
            return result;
        }

        public async Task<CartResponseDTO> Update(int id, CartRequestDTO requestDTO)
        {
            var f = mapper.Map<Cart>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.CartRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<CartResponseDTO>(v);
            return k;
        }


        public Task<CartResponseDTO> Update(CartRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var itemstodelete = await this.repositoryWrapper.CartRepository.GetById(id);
            if (itemstodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.CartRepository.DeleteAsync(itemstodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }
    }
}
