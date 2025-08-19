using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccontApi.Core.Entities;
using AccountApi.Sql.Queries;
using Microsoft.Extensions.Configuration;
using AccountApi.Application.Interfaces;
using Dapper;

namespace AccountApi.Infrastructure.Repository
{
    public class FloatSelectionRepository : IFloatSelectionRepository
    {
        private readonly IConfiguration configuration;

        public FloatSelectionRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> AddAsync(FloatSelection entity)
        {
            try
            {

                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(FloatSelectionQueries.AddFloatSelection, entity);
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

        public async Task<IReadOnlyList<FloatSelection>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<FloatSelection>(FloatSelectionQueries.GetAllFloatSelection);
                return result.ToList();
            }
        }

        public Task<FloatSelection> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(FloatSelection entity)
        {
            throw new NotImplementedException();
        }
    }
}
