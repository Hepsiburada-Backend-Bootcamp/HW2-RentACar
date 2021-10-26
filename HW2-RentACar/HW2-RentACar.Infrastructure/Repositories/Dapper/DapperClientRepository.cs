using Dapper;
using HW2_RenACar.Domain.Entities;
using HW2_RenACar.Domain.Repositories.Dapper;
using HW2_RentACar.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Infrastructure.Repositories.Dapper
{
    public class DapperClientRepository : DapperRepository, IDapperClientRepository
    {
        private string Connectionstring = "default";
        private readonly IConfiguration _config;

        public DapperClientRepository(DapperContext context, IConfiguration config) : base(context)
        {
            _config = config;
        }

        public async Task AddClientAsync(Client client)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                
                var clientAddQuery = "Insert into Clients (FirstName, LastName)" +
                $" Values('{client.FirstName}', '{client.LastName}') ";

                await db.QueryAsync(clientAddQuery);
            }
        }

        public async Task<Client> GetByIdAsync(int clientId)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var clientGetByIdQuery = $"Select * from Clients where Id = {clientId}";

                var result = await db.QuerySingleOrDefaultAsync<Client>(clientGetByIdQuery);

                return result;
            }
        }

        public async Task<IEnumerable<Client>> GetAllClientAsync()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var clientGetAllQuery = "Select * from Clients";

                var result = await db.QueryAsync<Client>(clientGetAllQuery);

                return result;
            }
        }

        public void RemoveClient(Client client)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var clientRemoveQuery = $"Delete from clients where Id = {client.Id}";

                db.Query(clientRemoveQuery);

            }
        }

        public Client UpdateClient(Client client)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var clientUpdateQuery = $"Update Clients Set FirstName = '{client.FirstName}', " +
                    $"LastName = '{client.LastName}' where Id = {client.Id}";

                var affectedRows = db.Execute(clientUpdateQuery);

                if (affectedRows == 0)
                {
                    return null;
                }
                else
                {
                    return client;
                }
            }
        }
    }
}
