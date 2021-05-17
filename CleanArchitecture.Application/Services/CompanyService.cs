using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infrastructure.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Z.Dapper.Plus;

namespace CleanArchitecture.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly string _connectionString;


        public CompanyService(UniDbContext dbContext) =>
            _connectionString = dbContext.Database.GetDbConnection().ConnectionString;

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            const string query = @"SELECT * FROM ""Companies"" c left join ""Markets""
                                        on ""Markets"".""Id"" = c.""Id""
                                        ORDER BY c.""Time"" DESC ";
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var results = await db.QueryAsync<Company,Market, Company>(query,(company, market) => {
                company.Market = market;
                return company;
            }, splitOn: "id");

            return results;
        }

        public async Task<int> CompanyRegister(Company model)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);

            var sqlQuery = $@"Select * From Company where CompanyName like ""{model.CompanyName}""";

            var companies = await db.QueryAsync<Company>(sqlQuery);

            if (companies.Any())
                throw new Exception("ესეთი კომპანია უკვე არსებობს");

            sqlQuery = $@"Insert Into Company (CompanyName) Values({model.CompanyName})";
            return await db.ExecuteAsync(sqlQuery, model);
        }

        public async Task<Company> GetCompanyById(int id)
        {
            var sqlQuery = $@"Select * From ""Companies"" where ""Id"" = {id}";
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            return await db.QueryFirstOrDefaultAsync<Company>(sqlQuery);
        }


        public async Task<int> AddCompanyInMarket(Company model)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);

            var sqlQuery = $@"Select * From Market where CompanyName like ""{model.CompanyName}""";

            var companies = await db.QueryAsync<Company>(sqlQuery);

            if (companies.Any())
                throw new Exception("კომპანია უკვე არსებობს მარკეტზე!!!");

            var res = db.BulkInsert(model, model => model.Market);
            return model.Id;
        }

        public async Task<int> ChangeCompanyPriceOnMarket(Company model)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);

            var sqlQuery = $@"UPDATE Market set FirstName='{model.Market.Price
            }' WHERE Id=" + model.Market.Id;

            return await db.ExecuteAsync(sqlQuery);
        }

        public async Task<IEnumerable<Company>> GetAllPagedAsync(int limit, int offset)
        {
            // var tableName = typeof(T).Name;
            // assuming here you want the newest rows first, and column name is "created_date"
            // may also wish to specify the exact columns needed, rather than *
            const string query = "SELECT * FROM Company ORDER BY created_date DESC Limit @Limit Offset @Offset";
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var results = await db.QueryAsync<Company>(query, new {Limit = limit, Offset = offset});
            return results;
        }
    }
}