using FriendsTraveling.BusinessLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface ITransportService
    {
        Task<TransportDto> GetTransportById(int id);
        Task<IEnumerable<TransportDto>> GetTransports();
        Task<TransportDto> AddTranspotrt(TransportDto transport);
        Task<TransportDto> UpdateTransport(int id, TransportDto transport);
        Task<bool> DeleteTransport(int id);
    }
}
