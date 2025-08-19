public class PONTOONANDSITEDATA
{
    public decimal VesselLength { get; set; }
    public decimal VesselWidth { get; set; }
    public decimal VesselDepth { get; set; }
    public decimal WindSpeed { get; set; }
    public decimal CurrentSpeed { get; set; }
    public decimal WaveHeight { get; set; }
    public decimal VesselWeight { get; set; }
    public decimal VesselCogX { get; set; }
    public decimal VesselCogY { get; set; }
    public decimal VesselCogZ { get; set; }
    public decimal MoiX { get; set; }
    public decimal MoiY { get; set; }
    public decimal VesselBuoyancy { get; set; }
    public decimal TotalArea { get; set; }
    public decimal MinimumFreeboard { get; set; }
    public decimal MaximumDraft { get; set; }
    public decimal DragCoefficientX { get; set; }
    public decimal DragCoefficientY { get; set; }
    public decimal WaterDepth { get; set; }
    public decimal ScopeToWaterDepthRatio{ get; set; }
    
    }
public class Hydrostatics
{
    public int ItemNumber { get; set; }
    public string LoadName { get; set; }
    public string LoadType { get; set; }
    public decimal LoadValue { get; set; }
    public decimal LocationX { get; set; }
    public decimal LocationY { get; set; }
    public decimal LocationZ { get; set; }
    public decimal AreaX { get; set; }
    public decimal AreaY { get; set; }
    public int DragCoefficients { get; set; }
    public decimal ForceX { get; set; }
    public decimal ForceY { get; set; }
    public decimal ForceZ { get; set; }
    public decimal MomentX { get; set; }
    public decimal MomentY { get; set; }
    public decimal MomentZ { get; set; }
}

public class HydrostaticCalculations
{
    public decimal TotalLoadValue { get; set; }
    public decimal TotalLocationx { get; set; }
    public decimal TotalLocationy { get; set; }
    public decimal TotalLocationz { get; set; }
    public decimal TotalAreax { get; set; }
    public decimal TotalAreay { get; set; }
    public decimal TotalForcex { get; set; }

    public decimal TotalForcey { get; set; }
    public decimal TotalForcez { get; set; }
    public decimal TotalMomentx { get; set; }
    public decimal TotalMomenty { get; set; }
    public decimal TotalMomentz { get; set; }

    public decimal IncludingVessel_loadValue { get; set; }
    public decimal IncludingVessel_locationx { get; set; }
    public decimal IncludingVessel_locationy{ get; set; }

    public decimal IncludingVessel_locationz { get; set; }




}

public class BuoyancyCalculations
{
    public decimal TotalBuoyancy { get; set; }
    public decimal ReservedBuoyancy { get; set; }
    public decimal Draft { get; set; }
    public decimal Freeboard { get; set; }
}
public class StabilityAboutX
{
    public decimal COB { get; set; }
    public decimal COG_Z { get; set; }
    public decimal BM_IV_X { get; set; }
    public decimal BG { get; set; }
    public decimal GM_X { get; set; }
    public decimal MaximumTiltAngleX { get; set; }
    public decimal MaxRightningMomentX { get; set; }
    public decimal MaxHeelingMomentX { get; set; }
    public decimal TiltAngleX { get; set; }
}

public class StabilityAboutY
{
    public decimal COB { get; set; }
    public decimal COG_Z { get; set; }
    public decimal BM_IV_Y  { get; set; }

    public decimal BG { get; set; }
    public decimal GM_Y { get; set; }
    public decimal MaximumTiltAngleY { get; set; }
    public decimal MaxRightningMomentY { get; set; }
    public decimal MaxHeelingMomentY { get; set; }
    public decimal TiltAngleY { get; set; }
}

public class WindPressurecalculation
{
    public decimal DesignwindspeedVz { get; set; }
    public decimal Windpressure { get; set; }
}

public class WindLoadcalculation
{
    public int SNo { get; set; }
    public string Description { get; set; }
    public string Unit { get; set; }
    public decimal X { get; set; }
    public decimal Y { get; set; }
}

public class DragForceCalculations
{
    public int SNo { get; set; }
    public string Description { get; set; }
    public string Unit { get; set; }
    public decimal X { get; set; }
    public decimal Y { get; set; }
}

public class WaveForceCalculations
{
    public int SNo { get; set; }
    public string Description { get; set; }
    public string Unit { get; set; }
    public decimal X { get; set; }
    public decimal Y { get; set; }
}

public class DeadweightAnchorAndMooringCalculation
{
    public int SNo { get; set; }
    public string Description { get; set; }
    public string Unit { get; set; }
    public decimal AlongXDirection { get; set; }
    public decimal AlongYDirection { get; set; }
    public string Note { get; set; }
}
public class AngleTwoCalculations
{
    public decimal noofmooringlineinx { get; set; }
    public decimal noofmooringlineiny { get; set; }
    
    public decimal Angle2_of_x { get; set; }
    public decimal Angle2_of_y { get; set; }
   

}

public class AnchorAndMooringDesignUsingDragAnchorCalculation
{
    public int SNo { get; set; }
    public string Description { get; set; }
    public string Unit { get; set; }
    public decimal AlongXDirection { get; set; }
    public decimal AlongYDirection { get; set; }
    public string Note { get; set; }
}

public class Results
{
    public int SNo { get; set; }
    public string Description { get; set; }
    public string Unit { get; set; }
}
public class DiameterOfMooringLine
{
    public int SNo { get; set; }
    public string Description { get; set; }
    public string Unit { get; set; }
    public decimal Value { get; set; }
}
