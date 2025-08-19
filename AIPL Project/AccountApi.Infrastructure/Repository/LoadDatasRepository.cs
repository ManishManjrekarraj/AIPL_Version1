using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccontApi.Core.Entities;
using AccountApi.Application.Interfaces;
using AccountApi.Sql.Queries;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace AccountApi.Infrastructure.Repository
{
    public class LoadDatasRepository : ILoadDatasRepository
    {
        private readonly IConfiguration configuration;

        public LoadDatasRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<IReadOnlyList<LoadDatas>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<LoadDatas>(LoadDatasQueries.GetAllLoadDatas);
                return result.ToList();
            }
        }

        public Task<string> AddAsync(LoadDatas entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<LoadDatas> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(LoadDatas entity)
        {
            throw new NotImplementedException();
        }
    }
}
