using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
    public static class ChainConstantsQueries
    {
        public static string AddChainConstants =>
            @"INSERT INTO [dbo].[ChainConstants]
       ([ChainGrade]
       ,[Notation]
       ,[ConstantK]
       ,[Diameter])
        VALUES
       (@ChainGrade
       ,@Notation
       ,@ConstantK
       ,@Diameter)";


        public static string GetAllChainConstants => "SELECT * FROM [dbo].[ChainConstants]";

    }
}
