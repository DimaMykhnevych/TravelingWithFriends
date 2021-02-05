using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
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

        public async Task<TransportDto> AddTranspotrt(TransportDto transportDTO)
        {
            Transport transport = _mapper.Map<Transport>(transportDTO);
            await _transportRepository.Insert(transport);
            await _transportRepository.Save();

            return _mapper.Map<TransportDto>(transport);
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

        public async Task<TransportDto> GetTransportById(int id)
        {
            Transport transport = await _transportRepository.Get(id);
            return _mapper.Map<TransportDto>(transport);
        }

        public async Task<IEnumerable<TransportDto>> GetTransports()
        {
            IEnumerable<Transport> transports = await _transportRepository.GetAll();
            return _mapper.Map<IEnumerable<TransportDto>>(transports);
        }

        public async Task<TransportDto> UpdateTransport(int id, TransportDto transportDTO)
        {
            Transport transport = _mapper.Map<Transport>(transportDTO);
            transport.Id = id;
            await _transportRepository.Update(transport);
            return _mapper.Map<TransportDto>(transport);
        }
    }
}
