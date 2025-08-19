namespace AccountApi.Sql.Queries
{
    public static class ParametersQueries
    {

        public static string GetAllParameters => "SELECT Id\r\n      ,Name\r\n      ,Length_x\r\n      ,Width_y\r\n      ,Height_z\r\n      ,Weight_Tonns\r\n      ,COG_x\r\n      ,COG_y\r\n      ,COG_z\r\n      ,Area\r\n      ,MOI_x_LocalCentroid\r\n      ,MOI_y_LocalCentroid\r\n      ,MOI_z_LocalCentroid\r\n      ,UnitBuoyancy_TonnsPerM2\r\n      ,MinimumFreeboard\r\n      ,MaximumDraft\r\n      ,FloatCategoryId\r\n  FROM dbo.Parameters";
    }
}
