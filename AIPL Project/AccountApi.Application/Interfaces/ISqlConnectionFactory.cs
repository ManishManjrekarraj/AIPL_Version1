using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Application.Interfaces
{
    public interface ISqlConnectionFactory
    {
        Task<IDbConnection> GetOpenConnectionAsync();
    }
}
