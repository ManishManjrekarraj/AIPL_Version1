using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
    public static class LoadDatasQueries
    {
        public static string GetAllLoadDatas => "SELECT * FROM [dbo].[LoadDatas]";
    }
}
