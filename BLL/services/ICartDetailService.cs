using AutoMapper;
using CricketStore.BLL.DTOs.Request;
using CricketStore.BLL.DTOs.Response;
using CricketStore.BLL.services;
using CricketStore.DAL.entities;
using CricketStore.DAL.repositories;

namespace CricketStore.BLL.Services
{
    public interface ICartDetailService : IBaseService<CartDetailRequestDTO, CartDetailResponseDTO>
    {
    }
    public class CartDetailService : ICartDetailService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public CartDetailService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<CartDetailResponseDTO> Add(CartDetailRequestDTO requestDTO)
        {
            var cartdetail = mapper.Map<CartDetail>(requestDTO);
            var responseCartDetail = await this.repositoryWrapper.CartDetailRepository.CreateAsync(cartdetail);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<CartDetailResponseDTO>(responseCartDetail);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var cartdetailtodelete = await this.repositoryWrapper.CartDetailRepository.GetById(id);
            if (cartdetailtodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.CartDetailRepository.DeleteAsync(cartdetailtodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<CartDetailResponseDTO>> GetAll()
        {
            var cartdetail = await this.repositoryWrapper.CartDetailRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<CartDetailResponseDTO>>(cartdetail);
            return result;
        }

        public async Task<CartDetailResponseDTO> GetById(int id)
        {
            var cartdetail = await this.repositoryWrapper.CartDetailRepository.GetById(id);
            var result = mapper.Map<CartDetailResponseDTO>(cartdetail);
            return result;
        }


        public async Task<CartDetailResponseDTO> Update(int id, CartDetailRequestDTO requestDTO)
        {
            var f = mapper.Map<CartDetail>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.CartDetailRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<CartDetailResponseDTO>(v);
            return k;
        }
        public Task<CartDetailResponseDTO> Update(CartDetailRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
    }
}