using System;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly ILogger _logger;
        public CompanyService(IRepository<Company> companyRepository, ILogger logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }


        public async Task<PagedResult<Company>> GetCompanies(PageFilter filter)
        {
            try
            {
              var query = !string.IsNullOrEmpty(filter?.PersonNumber)
                    ? _companyRepository.SearchFor(i => i.CompanyName == filter.PersonNumber)
                    : _companyRepository.GetAll();

                return query.Result
                    .GetPaged(filter.PageIndex, filter.PageSize);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return new PagedResult<Company>();
            }
        }
        public Task<PagedResult<Company>> GetCompanies() =>
            _companyRepository.GetAll();
        public async Task<int> CompanyRegister(Company model)
        {
            if (_companyRepository.GetAll().Result.Results.Any(i => i.CompanyName == model.CompanyName))
                throw new Exception("ესეთი სტუდენტი უკვე არსებობს");

            await _companyRepository.Add(model);
            return model.Id;
        }
        public Task<Company> GetCompanyById(int id) =>
            _companyRepository.GetById(id);

    }
}