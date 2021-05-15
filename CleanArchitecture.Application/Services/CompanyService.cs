using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infrastructure.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Z.Dapper.Plus;
namespace CleanArchitecture.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly string _connectionString;


        public CompanyService(IRepository<Company> companyRepository, UniDbContext dbContext)
        {
            _companyRepository = companyRepository;

            _connectionString = dbContext.Database.GetDbConnection().ConnectionString;
        }

        public async Task<IEnumerable<Company>> GetCompanies(PageFilter filter)
        {

            const string query = "SELECT * FROM Company ORDER BY created_date DESC Limit @Limit Offset @Offset";
            using IDbConnection db = new SqlConnection(_connectionString);
            var results = await db.QueryAsync<Company>(query, new { Limit = filter.PageSize, Offset = filter.PageIndex });

            return results;


        }

        public async Task<int> CompanyRegister(Company model)
        {

            using IDbConnection db = new SqlConnection(_connectionString);

            var sqlQuery = $@"Select * From Company where CompanyName like ""{model.CompanyName}""";

            var companies = await db.QueryAsync<Company>(sqlQuery);

            if (companies.Any())
                throw new Exception("ესეთი კომპანია უკვე არსებობს");

            sqlQuery = $@"Insert Into Company (CompanyName) Values({model.CompanyName})";
            return await db.ExecuteAsync(sqlQuery, model);

        }
        public async Task<Company> GetCompanyById(int id)
        {
            var sqlQuery = $@"Select * From Company where Id = ""{id}""";
            using IDbConnection db = new SqlConnection(_connectionString);
            return await db.QueryFirstOrDefaultAsync<Company>(sqlQuery);
        }
        public async Task<IEnumerable<Company>> GetAllPagedAsync(int limit, int offset)
        {
            // var tableName = typeof(T).Name;
            // assuming here you want the newest rows first, and column name is "created_date"
            // may also wish to specify the exact columns needed, rather than *
            const string query = "SELECT * FROM Company ORDER BY created_date DESC Limit @Limit Offset @Offset";
            using IDbConnection db = new SqlConnection(_connectionString);
            var results = await db.QueryAsync<Company>(query, new { Limit = limit, Offset = offset });
            return results;
        }


        public async Task<int> AddCompanyInMarket(Company model)
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            var sqlQuery = $@"Select * From Market where CompanyName like ""{model.CompanyName}""";

            var companies = await db.QueryAsync<Company>(sqlQuery);

            if (companies.Any())
                throw new Exception("კომპანია უკვე არსებობს მარკეტზე!!!");

            var res = db.BulkInsert(model, model => model.Market);
            return model.Id;

        }
        public async Task<int> ChangeCompanyPriceOnMarket(Company model)
        {

            using IDbConnection db = new SqlConnection(_connectionString);

            var sqlQuery = $@"UPDATE Market set FirstName='{model.Market.Price
            }' WHERE Id=" + model.Market.Id;

            return await db.ExecuteAsync(sqlQuery);

        }


    }

}