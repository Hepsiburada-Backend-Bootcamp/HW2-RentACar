using Dapper;
using HW2_RenACar.Domain.Entities;
using HW2_RenACar.Domain.Repositories;
using HW2_RenACar.Domain.Repositories.Dapper;
using HW2_RentACar.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Infrastructure.Repositories.Dapper
{
    public class DapperRentRepository : DapperRepository, IDapperRentRepository
    {
        private string Connectionstring = "default";
        private readonly IConfiguration _config;

        public DapperRentRepository(DapperContext context, IConfiguration config) : base(context)
        {
            _config = config;
        }

        public async Task AddRentAsync(Rent rent)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {

                var rentAddQuery = "Insert into Rents (CreatedAt, RentingDayDuration, TotalPrice, ClientId, CarId)" +
                $" Values(GETDATE(), {rent.RentingDayDuration}, " +
                $"{rent.TotalPrice}, {rent.ClientId}, {rent.CarId} ) select CAST(SCOPE_IDENTITY() AS INT)";

                await db.QueryAsync(rentAddQuery);
            }
        }

        public async Task<Rent> GetByIdAsync(int rentId)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var rentGetByIdQuery = $"Select * from Rents where Id = {rentId}";

                var result = await db.QuerySingleOrDefaultAsync<Rent>(rentGetByIdQuery);

                return result;
            }
        }
        //--------------------------
        public async Task<IEnumerable<Rent>> GetAllRentAsync()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var rentGetAllQuery = "Select * from Rents";

                var result = await db.QueryAsync<Rent>(rentGetAllQuery);

                return result;
            }
        }

        public void RemoveRent(Rent rent)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var rentRemoveQuery = $"Delete from rents where Id = {rent.Id}";

                db.Query(rentRemoveQuery);

            }
        }

        public Rent UpdateRent(Rent rent)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var rentUpdateQuery = $"Update Rents Set CreatedAt = GETDATE(), RentingDayDuration = {rent.RentingDayDuration}, TotalPrice = {rent.TotalPrice}, " +
                    $"ClientId = {rent.ClientId}, CarId = {rent.CarId} where Id = {rent.Id}";
                
                //var affectedRows = db.Query(rentUpdateQuery);
                var affectedRows = db.Execute(rentUpdateQuery);
                if(affectedRows == 0)
                {
                    return null;
                } 
                else
                {
                    return rent;
                }      
            }
        }
    }
}
