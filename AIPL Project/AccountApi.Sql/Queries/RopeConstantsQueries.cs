using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
    public static class RopeConstantsQueries
    {
        public static string AddRopeConstants =>
            @"INSERT INTO [dbo].[RopeConstants]
       ([RopeType]
       ,[TensileStrength]
       ,[KValue]
       ,[RequiredDiameter])
        VALUES
       (@RopeType
       ,@TensileStrength
       ,@KValue
       ,@RequiredDiameter)";
        public static string GetAllRopeConstants => "SELECT * FROM [dbo].[RopeConstants]";

    }
}
