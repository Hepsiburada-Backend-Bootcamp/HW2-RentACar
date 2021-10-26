using AutoMapper;
using HW2_RenACar.Domain.Entities;
using HW2_RenACar.Domain.Repositories.Dapper;
using HW2_RentACar.Application.DTOs;
using HW2_RentACar.Application.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IDapperClientRepository _dapperClientRepository;
        private readonly IMapper _mapper;

        public ClientService(IDapperClientRepository dapperClientRepository, IMapper mapper)
        {
            _dapperClientRepository = dapperClientRepository;
            _mapper = mapper;
        }

        public async Task AddClientAsync(ClientDto client)
        {
            await _dapperClientRepository.AddClientAsync(_mapper.Map<Client>(client));
        }

        public async Task<IEnumerable<ClientDto>> GetAllClientAsync()
        {
            return _mapper.Map<IEnumerable<ClientDto>>(await _dapperClientRepository.GetAllClientAsync());
        }

        public async Task<ClientDto> GetByIdAsync(int clientId)
        {
            return _mapper.Map<ClientDto>(await _dapperClientRepository.GetByIdAsync(clientId));
        }

        public void RemoveClient(ClientDto client)
        {
            _dapperClientRepository.RemoveClient(_mapper.Map<Client>(client));
        }

        public ClientDto UpdateClinet(ClientDto client)
        {
            var result = _dapperClientRepository.UpdateClient(_mapper.Map<Client>(client));
            return _mapper.Map<ClientDto>(result);
        }
    }
}
