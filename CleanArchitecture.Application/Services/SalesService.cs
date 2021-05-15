using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infrastructure.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Services
{
    public class SalesService : ISalesService
    {

        private readonly string _connectionString;


        public SalesService(UniDbContext dbContext)
        {

            _connectionString = dbContext.Database.GetDbConnection().ConnectionString;
        }


        public async Task<IEnumerable<Market>> GetCompanyByMarket(Market model)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = $@"Select * From Market where Id = ""{model.Id}""";
            return db.Query<Market>(sqlQuery);
        }
    }
}