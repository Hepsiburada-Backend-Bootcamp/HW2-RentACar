using HW2_RenACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RenACar.Domain.Repositories.Dapper
{
    public interface IDapperClientRepository : IDapperRepository
    {
        Task<IEnumerable<Client>> GetAllClientAsync();
        Task AddClientAsync(Client client);
        void RemoveClient(Client client);
        Client UpdateClient(Client client);
        Task<Client> GetByIdAsync(int clientId);
    }
}
