using FriendsTraveling.BusinessLayer.DTOs.TransportDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.TransportService
{
    public interface ITransportService
    {
        Task<TransportDTO> GetTransportById(int id);
        Task<IEnumerable<TransportDTO>> GetTransports();
        Task<TransportDTO> AddTranspotrt(TransportDTO transport);
        Task<TransportDTO> UpdateTransport(int id, TransportDTO transport);
        Task<bool> DeleteTransport(int id);
    }
}
