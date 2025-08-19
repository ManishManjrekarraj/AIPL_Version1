using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
    public static class OutputDetailsQueries
    {
        public static string GetAllOutputDetails => "SELECT * FROM [dbo].[OutputDetails]";
    }
}
