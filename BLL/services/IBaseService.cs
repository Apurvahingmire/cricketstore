namespace CricketStore.BLL.services
{
    public interface IBaseService<TRequestDTO, TResponseDTO>
    {

        Task<IEnumerable<TResponseDTO>> GetAll();
        Task<TResponseDTO> GetById(int id);
        Task<TResponseDTO> Add(TRequestDTO requestDTO);
        Task<bool> Delete(int id);
        Task<TResponseDTO> Update(int id, TRequestDTO requestDTO);
    }
}
