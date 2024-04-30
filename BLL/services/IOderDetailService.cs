using CricketStore.BLL.DTOs.Request;
using CricketStore.BLL.DTOs.Response;
using AutoMapper;
using CricketStore.BLL.services;
using CricketStore.DAL.entities;
using CricketStore.DAL.repositories;

namespace CricketStore.BLL.Services
{
    public interface IOderDetailService : IBaseService<OderDetailRequestDTO, OderDetailResponseDTO>
    {
    }
    public class OderDetailService : IOderDetailService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public OderDetailService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<OderDetailResponseDTO> Add(OderDetailRequestDTO requestDTO)
        {
            var oderdetail = mapper.Map<OderDetail>(requestDTO);
            var responseOderDetail = await this.repositoryWrapper.OderDetailRepository.CreateAsync(oderdetail);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<OderDetailResponseDTO>(responseOderDetail);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var oderdetailtodelete = await this.repositoryWrapper.OderDetailRepository.GetById(id);
            if (oderdetailtodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.OderDetailRepository.DeleteAsync(oderdetailtodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<OderDetailResponseDTO>> GetAll()
        {
            var orderdetail = await this.repositoryWrapper.OderDetailRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<OderDetailResponseDTO>>(orderdetail);
            return result;
        }

        public async Task<OderDetailResponseDTO> GetById(int id)
        {
            var oderdetail = await this.repositoryWrapper.OderDetailRepository.GetById(id);
            var result = mapper.Map<OderDetailResponseDTO>(oderdetail);
            return result;
        }


        public async Task<OderDetailResponseDTO> Update(int id, OderDetailRequestDTO requestDTO)
        {
            var f = mapper.Map<OderDetail>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.OderDetailRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<OderDetailResponseDTO>(v);
            return k;
        }

        public Task<OderDetailResponseDTO> Update(OderDetailRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
