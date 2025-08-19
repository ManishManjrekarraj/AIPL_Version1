using AccontApi.Core.Entities;
using AccountApi.Application.Interfaces;
using AccountApi.Sql.Queries;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace AccountApi.Infrastructure.Repository
{
    public class ParametersRepository : IParametersRepository
    {

        private readonly IConfiguration _configuration;

        public ParametersRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<string> AddAsync(Parameters entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Parameters>> GetAllAsync()
        {
            List<Parameters> parametersList = new List<Parameters>();
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync(ParametersQueries.GetAllParameters);
                if (result == null || !result.Any())
                {
                    return new List<Parameters>();
                }

                foreach (var item in result)
                {
                    // Assuming item is a dynamic object, you may need to map it to Parameters
                    // If Parameters has properties that match the result columns, you can do this directly
                    // Otherwise, you may need to create a new instance of Parameters and set its properties

                    // For example: 
                    var parameter = new Parameters
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Area = item.Area,
                        COGx = item["COGx"],
                        COGy = item["COGy"],
                        COGz = item["COGz"],
                        LengthX = item.LengthX,
                        WidthY = item.WidthY,
                        HeightZ = item.HeightZ,
                        WeightTonns = item.WeightTonns,
                        MOIxLocalCentroid = item.MOIxLocalCentroid,
                        MOIyLocalCentroid = item.MOIyLocalCentroid,
                        MOIzLocalCentroid = item.MOIzLocalCentroid,
                        UnitBuoyancyTonnsPerM2 = item.UnitBuoyancyTonnsPerM2,

                        // Map other properties as needed
                    };
                    parametersList.Add(parameter);
                }

                // Assuming Parameters is a class that matches the structure of the result
                // If the result is a dynamic object, you may need to map it to Parameters
                // For example, if Parameters has properties that match the result columns:
                // 
                return parametersList;
            }
        }

        public Task<Parameters> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(Parameters entity)
        {
            throw new NotImplementedException();
        }
    }
}
