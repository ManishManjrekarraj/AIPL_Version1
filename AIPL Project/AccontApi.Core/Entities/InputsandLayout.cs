using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccontApi.Core.Entities
{
    public class InputsandLayout
    {
        public int Id { get; set; }
        public string FloatSelection { get; set; }
        public string SiteConditions { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public string WaterBody { get; set; }
        public int MaxWaterDepth { get; set; }
        public int MinWaterDepth { get; set; }
        public int CurrentSpeed { get; set; }
        public decimal WindVelocity { get; set; }
        public decimal WaveHeight { get; set; }
        public int DragCoefficientX { get; set; }
        public int DragCoefficientY { get; set; }
        public int ScopeToWaterDepthRatio { get; set; }
        public string TypeOfSoil { get; set; }
        public string MaterialOfAnchor { get; set; }
        public string AdditionalInformation { get; set; }
        public Guid ProjectId { get; set; }
    }
}
