using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infrastructure.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
namespace CleanArchitecture.Application.Services
{
    public class SalesService : ISalesService
    {

        private readonly string _connectionString;


        public SalesService(UniDbContext dbContext) =>
            _connectionString = dbContext.Database.GetDbConnection().ConnectionString;


        public async Task<IEnumerable<Market>> GetCompanyByMarket(Market model)
        {
            using IDbConnection db = new NpgsqlConnection
                (_connectionString);
            var sqlQuery = $@"Select * From Market where Id = ""{model.Id}""";
            return db.Query<Market>(sqlQuery);
        }
    }
}