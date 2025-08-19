using AccontApi.Core.Entities;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountApi.Sql.Queries;
using AccountApi.Application.Interfaces;
using AccountApi.Core;

namespace AccountApi.Infrastructure.Repository
{
    public class OutputDetailsRepository : IOutputDetailsRepository
    {
        private readonly IConfiguration configuration;

        public OutputDetailsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<OutputDetails>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<OutputDetails>(OutputDetailsQueries.GetAllOutputDetails);
                return result.ToList();
            }
        }

        public Task<string> AddAsync(OutputDetails entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<OutputDetails> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(OutputDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
