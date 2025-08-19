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
    public class ChainConstantsRepository : IChainConstantsRepository
    {
        private readonly IConfiguration configuration;

        public ChainConstantsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> AddAsync(ChainConstants entity)
        {
            try
            {

                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(ChainConstantsQueries.AddChainConstants, entity);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<ChainConstants>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ChainConstants>(ChainConstantsQueries.GetAllChainConstants);
                return result.ToList();
            }
        }

        public Task<ChainConstants> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(ChainConstants entity)
        {
            throw new NotImplementedException();
        }

    }
}
