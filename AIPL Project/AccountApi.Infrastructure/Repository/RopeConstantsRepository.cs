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
    public class RopeConstantsRepository : IRopeConstantsRepository
    {
        private readonly IConfiguration configuration;

        public RopeConstantsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> AddAsync(RopeConstants entity)
        {
            try
            {

                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(RopeConstantsQueries.AddRopeConstants, entity);
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

        public async Task<IReadOnlyList<RopeConstants>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<RopeConstants>(RopeConstantsQueries.GetAllRopeConstants);
                return result.ToList();
            }
        }

        public Task<RopeConstants> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(RopeConstants entity)
        {
            throw new NotImplementedException();
        }
    }
}
