using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
    public static class FloatSelectionQueries
    {
        public static string AddFloatSelection =>
            @"INSERT INTO [dbo].[FloatCategoryItems]
       ([ItemName1],
        [ItemName2], 
        [ItemName3],
        [ItemName4],
        [CategoryId])
        VALUES
       (@ItemName1,
        @ItemName2,
        @ItemName3,
        @ItemName4,
        @CategoryId)";

        public static string GetAllFloatSelection => "SELECT * FROM [dbo].[FloatCategoryItems]";

    }
}
