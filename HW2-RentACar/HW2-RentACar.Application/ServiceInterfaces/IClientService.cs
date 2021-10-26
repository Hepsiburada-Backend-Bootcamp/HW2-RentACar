using HW2_RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Application.ServiceInterfaces
{
    public interface IClientService
    {
        Task AddClientAsync(ClientDto client);
        Task<IEnumerable<ClientDto>> GetAllClientAsync();
        Task<ClientDto> GetByIdAsync(int clientId);
        void RemoveClient(ClientDto client);
        ClientDto UpdateClinet(ClientDto client);
    }
}
