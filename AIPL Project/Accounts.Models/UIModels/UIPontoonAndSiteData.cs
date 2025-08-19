using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Models.UIModels
{
    public class UIPontoonAndSiteData
    {
        public int VesselLength { get; set; }
        public int VesselWidth { get; set; }
        public decimal VesselDepth { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal CurrentSpeed { get; set; }
        public decimal WaveHeight { get; set; }
        public decimal VesselWeight { get; set; }
        public decimal VesselCOGX { get; set; }
        public decimal VesselCOGY { get; set; }
        public decimal VesselCOGZ { get; set; }
        public decimal MOIX { get; set; }
        public decimal MOIY { get; set; }
        public decimal VesselBuoyancy { get; set; }
        public decimal TotalArea { get; set; }
        public decimal MinimumFreeBoard { get; set; }
        public decimal MaximumDraft { get; set; }
        public decimal DragCoefficientX { get; set; }
        public decimal DragCoefficientY { get; set; }
        public decimal WaterDepth { get; set; }
        public decimal ScopeToWaterDepthRatio { get; set; }
        public Guid ProjectId { get; set; }
    }

    public class UIHydrostatics
    {
        public int ItemNumber { get; set; }
        public string? LoadName { get; set; }
        public string? LoadType { get; set; }
        public decimal LoadValue { get; set; }

        public decimal LocationX { get; set; }
        public decimal LocationY { get; set; }
        public decimal LocationZ { get; set; }

        public decimal AreaX { get; set; }
        public decimal AreaY { get; set; }

        public decimal DragCoefficients { get; set; }

        public decimal ForceX { get; set; }
        public decimal ForceY { get; set; }
        public decimal ForceZ { get; set; }

        public decimal MomentX { get; set; }
        public decimal MomentY { get; set; }
        public decimal MomentZ { get; set; }
        public Guid ProjectId { get; set; }
    }

    public class UIBuoyancyCalculations
    {
        public decimal TotalBuoyancy { get; set; }
        public decimal ReservedBuoyancy { get; set; }
        public decimal Draft { get; set; }
        public decimal Freeboard { get; set; }
        public Guid ProjectId { get; set; }
    }

    public class UIStabilityAboutX
    {
        public decimal COB { get; set; }
        public decimal COGZ { get; set; }
        public decimal BMIVX { get; set; } // BM, I/V, X
        public decimal BG { get; set; }
        public decimal GMX { get; set; }   // GM, X

        public decimal MaxTiltAngleX { get; set; }
        public decimal MaxRightningMomentX { get; set; }
        public decimal MaxHeelingMomentX { get; set; }
        public decimal TiltAngleX { get; set; }
        public Guid ProjectId { get; set; }
    }

    public class UIStabilityAboutY
    {
        public decimal COB { get; set; }
        public decimal COGZ { get; set; }
        public decimal BMIVY { get; set; } // BM, I/V, Y
        public decimal BG { get; set; }
        public decimal GMY { get; set; }   // GM,Y

        public decimal MaximumTiltAngleY { get; set; }
        public decimal MaxRightningMomentY { get; set; }
        public decimal MaxHeelingMomentY { get; set; }
        public decimal TiltAngleY { get; set; }
        public Guid ProjectId { get; set; }
    }

    public class UIWindPressureCalculation
    {
        public string Description { get; set; }
        public string Units { get; set; }
        public decimal Value { get; set; }
        public Guid ProjectId { get; set; }
    }

    public class UIWindLoadCalculation
    {
        public int SNo { get; set; }
        public string Description { get; set; }
        public string Units { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public Guid ProjectId { get; set; }
    }

    public class UIDragForceCalculations
    {
        public int SNo { get; set; }
        public string Description { get; set; }
        public string Units { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public Guid ProjectId { get; set; }
    }

    public class UIWaveForceCalculation
    {
        public int SNo { get; set; }
        public string Description { get; set; }
        public string Units { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public Guid ProjectId { get; set; }
    }

    public class UIDeadWeightAnchorAndMooringCalculation
    {
        public int SNo { get; set; }
        public string Description { get; set; }
        public string Units { get; set; }
        public decimal  AlongXDirection { get; set; }
        public decimal AlongYDirection { get; set;}
        public Guid ProjectId { get; set; }
    }
}
