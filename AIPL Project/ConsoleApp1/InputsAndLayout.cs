public class InputsAndLayout
{
    public string FloatSelection { get; set; } = "MODULAR_BARGE";
    public string SiteConditions { get; set; } = "";
    public decimal Length { get; set; } = 6;
    public decimal Width { get; set; } = 6;
    public string WaterBody { get; set; } = "Ocean";
    public decimal MaxWaterDepth { get; set; } = 10;
    public decimal MinWaterDepth { get; set; } = 2;
    public decimal CurrentSpeed { get; set; } = 1;
    public decimal WindVelocity { get; set; } = 41.73m;
    public decimal WaveHeight { get; set; } = 0.6m;
    public decimal DragCoefficientX { get; set; } = 1;
    public decimal DragCoefficientY { get; set; } = 2;
    public decimal ScopeToWaterDepthRatio { get; set; } = 4;
    public string TypeOfSoil { get; set; } = "Quartz";
    public string MaterialOfAnchor { get; set; } = "smooth steel";
    public string AdditionalInformation { get; set; } = "";
}
public class FloatSizeLayout
{
    public string? FloatSize { get; set; }
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
    // public Outputs Outputs { get; set; }



}

public class LocalValues
{
    public decimal WeightTonns { get; set; }
    public decimal COGx { get; set; }
    public decimal COGy { get; set; }
    public decimal COGz { get; set; }
    public decimal Area { get; set; }
    public decimal MOIxLocalCentroid { get; set; }
    public decimal MOIyLocalCentroid { get; set; }
}
public class GobalCalculations
{
    public decimal WeighedX { get; set; }
    public decimal WeighedY { get; set; }
    public decimal WeighedZ { get; set; }
    public decimal MOIx { get; set; }
    public decimal MOIy { get; set; }
}

public class Outputs
{
    public decimal TotalWeight { get; set; }
    public decimal GlobalCGX { get; set; }
    public decimal GlobalCGY { get; set; }
    public decimal GlobalCGZ { get; set; }
    public decimal GlobalMx { get; set; }
    public decimal GlobalMy { get; set; }
    public decimal TotalArea { get; set; }
    public decimal UnitBuoyancyCapacity { get; set; }
}

public class Mooringlayout
{
    public int NoOfMooringLine { get; set; }
    public decimal AngleDegreesWithXAxis { get; set; }
    public decimal AngleInRadians { get; set; }
    public decimal CosComponent { get; set; }
    public decimal SinComponent { get; set; }
}

public class Subscription
{
    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    // Add other subscription-related properties as needed
    public ICollection<User> Users { get; set; }
}
public class User
{
    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string UserName { get; set; }
    public int SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }
    public ICollection<Project> Projects { get; set; }
}
public class Project
{
    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public string CompanyName { get; set; }
    public string ClientName { get; set; }
    public string MoblieNumber { get; set; }
    public string EmailID { get; set; }
    public string Domain { get; set; }
    public string ProjectDescription { get; set; }
    public string AttachFile { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }
}