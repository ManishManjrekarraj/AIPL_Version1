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
    public class ProjectDetailsRepository : IProjectDetailsRepository
    {
        private readonly IConfiguration configuration;

        public ProjectDetailsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Guid> PostAsyncProjectDetails(ProjectDetails entity)
        {
            try
            {

                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    dynamic result = await connection.ExecuteAsync(ProjectDetailsQueries.AddProjectDetails, entity);
                    var data = await connection.QueryFirstOrDefaultAsync<Guid>(ProjectDetailsQueries.GetProjectId, new { ProjectName = entity.ProjectName });
                    //return result.ToString();
                    return data;
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

        public async Task<IReadOnlyList<ProjectDetails>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDetails> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(ProjectDetails entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddAsync(ProjectDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
