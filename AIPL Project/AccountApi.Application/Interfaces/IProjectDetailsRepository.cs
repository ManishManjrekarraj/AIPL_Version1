using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccontApi.Core.Entities;

namespace AccountApi.Application.Interfaces
{
    public interface IProjectDetailsRepository : IRepository<ProjectDetails>
    {
        Task<Guid> PostAsyncProjectDetails(ProjectDetails entity);
    }
}
