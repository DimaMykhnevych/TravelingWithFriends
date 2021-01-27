using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs.TransportDTOs;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.TransportRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.TransportService
{
    public class TransportService : ITransportService
    {
        private readonly ITransportRepository _transportRepository;
        private readonly IMapper _mapper;

        public TransportService(ITransportRepository transportRepository, IMapper mapper)
        {
            _transportRepository = transportRepository;
            _mapper = mapper;
        }

        public async Task<TransportDTO> AddTranspotrt(TransportDTO transportDTO)
        {
            Transport transport = _mapper.Map<Transport>(transportDTO);
            await _transportRepository.Insert(transport);
            await _transportRepository.Save();

            return _mapper.Map<TransportDTO>(transport);
        }

        public async Task<bool> DeleteTransport(int id)
        {
            Transport transportToDelete = await _transportRepository.Get(id);
            if (transportToDelete == null)
                return false;
            await _transportRepository.Delete(transportToDelete);
            await _transportRepository.Save();
            return true;
        }

        public async Task<TransportDTO> GetTransportById(int id)
        {
            Transport transport = await _transportRepository.Get(id);
            return _mapper.Map<TransportDTO>(transport);
        }

        public async Task<IEnumerable<TransportDTO>> GetTransports()
        {
            IEnumerable<Transport> transports = await _transportRepository.GetAll();
            return _mapper.Map<IEnumerable<TransportDTO>>(transports);
        }

        public async Task<TransportDTO> UpdateTransport(int id, TransportDTO transportDTO)
        {
            Transport transport = _mapper.Map<Transport>(transportDTO);
            transport.Id = id;
            await _transportRepository.Update(transport);
            return _mapper.Map<TransportDTO>(transport);
        }
    }
}
