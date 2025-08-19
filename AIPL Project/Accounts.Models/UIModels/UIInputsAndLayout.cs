using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Models.UIModels
{
    public class UIInputsAndLayout
    {
        public string FloatSelection {  get; set; }
        public string? SiteConditions { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public WaterBody WaterBody { get; set; }
        public int MaxWaterDepth { get; set; }
        public int MinWaterDepth { get; set; }
        public int CurrentSpeed { get; set; }
        public decimal WindVelocity { get; set; }
        public decimal WaveHeight { get; set; }
        public int DragCoefficientX { get; set; }
        public int DragCoefficientY { get; set; }
        public int ScopeToWaterDepthRatio { get; set; }
        public TypeOfSoil TypeOfSoil { get; set; }
        public MaterialOfAnchor MaterialOfAnchor { get; set; }
        public string? AdditionalInformation { get; set; }
        public Guid ProjectId { get; set; }

    }

    public enum WaterBody
    {
        Ocean,
        Lake,
        Reservoir,
        River
    }

    public enum TypeOfSoil
    {
        Quartz,
        Coralline,
        Oolitic,
        ForamSilt
    }

    public enum MaterialOfAnchor
    {
        SmoothSteel,
        RoughSteel,
        SmoothConcrete,
        RoughConcrete,
        TrappedSoil
    }

    public class UIFloatSizeLayout
    {
        public int FloatSizeId { get; set; }
        public string FloatSize { get; set; }
        public decimal XCordinate { get; set; }

        public decimal YCordinate { get; set; }
        //public LocalValues LocalValues { get; set; }
        public decimal WeightTonns { get; set; }
        public decimal COGx { get; set; }
        public decimal COGy { get; set; }
        public decimal COGz { get; set; }
        public decimal Area { get; set; }
        public decimal MOIxLocalCentroid { get; set; }
        public decimal MOIyLocalCentroid { get; set; }
        //public GobalCalculations GobalCalculations { get; set; }
        public decimal WeighedX { get; set; }
        public decimal WeighedY { get; set; }
        public decimal WeighedZ { get; set; }
        public decimal MOIx { get; set; }
        public decimal MOIy { get; set; }
        public Guid ProjectId { get; set; }
        // public Outputs Outputs { get; set; }

    }

    public class UIInputLayoutMaster
    {
        public Guid Project_Id { get; set; }
        public UIInputsAndLayout InputsAndLayout { get; set; } = new UIInputsAndLayout();
        //public UIFloatSizeLayout FloatSizeLayout { get; set; } = new UIFloatSizeLayout();
        public List<UIFloatSizeLayout> FloatSizeLayoutList { get; set; } = new List<UIFloatSizeLayout>();

        public UIOutputDetails OutputDetails { get; set; }
    }

    //public class Outputs
    //{
    //    public decimal TotalWeight { get; set; }
    //    public decimal GlobalCGX { get; set; }
    //    public decimal GlobalCGY { get; set; }
    //    public decimal GlobalCGZ { get; set; }
    //    public decimal GlobalMx { get; set; }
    //    public decimal GlobalMy { get; set; }
    //    public decimal TotalArea { get; set; }
    //    public decimal UnitBuoyancyCapacity { get; set; }
    //}
}
