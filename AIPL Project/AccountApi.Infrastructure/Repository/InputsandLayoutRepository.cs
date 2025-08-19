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
    public class InputsandLayoutRepository : IInputsandLayoutRepository
    {
        private readonly IConfiguration configuration;

        public InputsandLayoutRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> AddAsync(InputsandLayout entity)
        {
            try
            {

                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(InputsandLayoutQueries.AddInputsandLayout, entity);
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

        public async Task<IReadOnlyList<InputsandLayout>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<InputsandLayout>(InputsandLayoutQueries.GetAllInputs);
                return result.ToList();
            }
        }

        public Task<InputsandLayout> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(InputsandLayout entity)
        {
            throw new NotImplementedException();
        }
    }
}
