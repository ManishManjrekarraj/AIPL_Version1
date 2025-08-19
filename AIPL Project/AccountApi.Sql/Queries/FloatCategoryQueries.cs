using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
    public static class FloatCategoryQueries
    {
        public static string AddFloatCategory =>
            @"INSERT INTO [dbo].[FloatCategory]
       ([FloatCategory])
        VALUES
       (@FloatCategory)";

        public static string GetAllCategories => "SELECT [FloatcategoryId], [Floatcategory] FROM [dbo].[FloatCategory]";
    }
}
