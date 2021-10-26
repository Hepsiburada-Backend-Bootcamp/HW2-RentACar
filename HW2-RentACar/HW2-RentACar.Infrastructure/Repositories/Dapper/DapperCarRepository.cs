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
    public class DapperCarRepository : DapperRepository, IDapperCarRepository
    {
        private string Connectionstring = "default";
        private readonly IConfiguration _config;

        public DapperCarRepository(DapperContext context, IConfiguration config) : base(context)
        {
            _config = config;
        }
        public async Task AddCarAsync(Car car)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {

                var rentAddQuery = "Insert into Cars (Name, ModelYear, Price)" +
                $" Values('{car.Name}', {car.ModelYear}, " +
                $"{car.Price} ) select CAST(SCOPE_IDENTITY() AS INT)";

                await db.ExecuteAsync(rentAddQuery);
            }
        }

        public async Task<IEnumerable<Car>> GetAllCarAsync()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var carGetAllQuery = "Select * from cars";

                var result = await db.QueryAsync<Car>(carGetAllQuery);

                return result;
            }
        }

        public async Task<Car> GetByIdCarAsync(int id)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var carGetAllQuery = $"Select * from cars where Id = {id}";

                var result = await db.QuerySingleOrDefaultAsync<Car>(carGetAllQuery);

                return result;
            }
        }

        public void RemoveCar(Car car)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var carRemoveQuery = $"Delete from cars where Id = {car.Id}";

                db.Execute(carRemoveQuery);
                
            }
        }

        public Car UpdateCar(Car car)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var carUpdateQuery = $"Update Cars Set Name = '{car.Name}', " +
                    $"Modelyear = {car.ModelYear}, Price = {car.Price} where Id = {car.Id}";

                var affectedRows = db.Execute(carUpdateQuery);
                
                if (affectedRows == 0)
                {
                    return null;
                }
                else
                {
                    return car;
                }
            }
        }
    }
}
