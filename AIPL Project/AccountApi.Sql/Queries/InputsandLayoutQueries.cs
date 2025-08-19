using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
    public static class InputsandLayoutQueries
    {
        public static string AddInputsandLayout =>
    @"INSERT INTO [dbo].[InputsandLayout]
    ([FloatSelection],
     [SiteConditions],
     [Length],
     [Width],
     [WaterBody],
     [MaxWaterDepth],
     [MinWaterDepth],
     [CurrentSpeed],
     [WindVelocity],
     [WaveHeight],
     [DragCoefficientX],
     [DragCoefficientY],
     [ScopeToWaterDepthRatio],
     [TypeOfSoil],
     [MaterialOfAnchor],
     [AdditionalInformation])
     VALUES
    (@FloatSelection,
     @SiteConditions,
     @Length,
     @Width,
     @WaterBody,
     @MaxWaterDepth,
     @MinWaterDepth,
     @CurrentSpeed,
     @WindVelocity,
     @WaveHeight,
     @DragCoefficientX,
     @DragCoefficientY,
     @ScopeToWaterDepthRatio,
     @TypeOfSoil,
     @MaterialOfAnchor,
     @AdditionalInformation)";

        public static string GetAllInputs =>
            @"SELECT * FROM[dbo].[InputsandLayout]";

    }
}
