using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UglyToad.PdfPig;

namespace ConsoleApp1
{

    public class AppDbContext : DbContext
    {
        // Add to your AppDbContext
        public DbSet<FloatSelectionItem> FloatSelectionItems { get; set; }
        // Add to your AppDbContext
        public DbSet<ChainConstants> ChainConstants { get; set; }
        public DbSet<RopeConstants> RopeConstants { get; set; }
        public DbSet<LoadData> LoadDatas { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=LAPTOP-T0U5FLOV\SQLEXPRESS;Database=AIPL;Trusted_Connection=True;TrustServerCertificate=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FloatSelectionItem>()
                .HasMany(f => f.Parameters)
                .WithOne(p => p.FloatSelectionItem)
                .HasForeignKey(p => p.FloatSelectionItemId);


            // Configure the conversion for double to decimal if needed
            // var doubleToDecimalConverter = new ValueConverter<double, decimal>(
            //     v => (decimal)v,
            //     v => (double)v);

            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.Length_x)
            //     .HasConversion(doubleToDecimalConverter);
            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.Width_y)
            //     .HasConversion(doubleToDecimalConverter);
            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.Height_z)
            //     .HasConversion(doubleToDecimalConverter);
            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.Weight_Tonns)
            //     .HasConversion(doubleToDecimalConverter);
            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.COG_x)
            //     .HasConversion(doubleToDecimalConverter);
            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.COG_y)
            //     .HasConversion(doubleToDecimalConverter);
            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.COG_z)
            //     .HasConversion(doubleToDecimalConverter);
            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.Area)
            //     .HasConversion(doubleToDecimalConverter);
            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.MOI_x_LocalCentroid)
            //     .HasConversion(doubleToDecimalConverter);
            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.MOI_y_LocalCentroid)
            //     .HasConversion(doubleToDecimalConverter);
            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.MOI_z_LocalCentroid)
            //     .HasConversion(doubleToDecimalConverter);
            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.UnitBuoyancy_TonnsPerM2)
            //     .HasConversion(doubleToDecimalConverter);
            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.MinimumFreeboard)
            //     .HasConversion(doubleToDecimalConverter);
            // modelBuilder.Entity<Parameter>()
            //     .Property(p => p.MaximumDraft)
            //     .HasConversion(doubleToDecimalConverter);

            modelBuilder.Entity<ChainConstants>()
            .Property(c => c.ConstantK) // Assuming ConstantK is a decimal
            .HasConversion<double>();
            modelBuilder.Entity<ChainConstants>()
            .Property(c => c.Diameter) // Assuming Diameter is a decimal                    
            .HasConversion<double>();
            modelBuilder.Entity<ChainConstants>()
                .HasKey(c => c.Id); // Ensure Id is the primary key     
            modelBuilder.Entity<ChainConstants>()
                .HasIndex(c => c.ChainGrade)
                .IsUnique(); // Ensure ChainGrade is unique
            modelBuilder.Entity<ChainConstants>()
                .Property(c => c.ChainGrade)
                .IsRequired()
                .HasMaxLength(50);
            // Set a maximum length for ChainGrade
            modelBuilder.Entity<RopeConstants>().HasData(
            new RopeConstants { Id = 1, RopeType = "6×7 FC", TensileStrength = 1770, KValue = 0.345m, RequiredDiameter = 9831.061605m },
            new RopeConstants { Id = 2, RopeType = "6×7 IWRC", TensileStrength = null, KValue = 0.45m, RequiredDiameter = 35.63m },
            new RopeConstants { Id = 3, RopeType = "6×19 Seale FC", TensileStrength = null, KValue = 0.342m, RequiredDiameter = 41.41m },
            new RopeConstants { Id = 4, RopeType = "6×19 Seale IWRC", TensileStrength = null, KValue = 0.462m, RequiredDiameter = 35.32m },
            new RopeConstants { Id = 5, RopeType = "6×36 WS FC", TensileStrength = null, KValue = 0.346m, RequiredDiameter = 41.20m },
            new RopeConstants { Id = 6, RopeType = "6×36 WS IWRC", TensileStrength = null, KValue = 0.47m, RequiredDiameter = 34.61m },
            new RopeConstants { Id = 7, RopeType = "8×19 Seale FC", TensileStrength = null, KValue = 0.32m, RequiredDiameter = 42.16m },
            new RopeConstants { Id = 8, RopeType = "8×19 Seale IWRC", TensileStrength = null, KValue = 0.43m, RequiredDiameter = 36.23m },
            new RopeConstants { Id = 9, RopeType = "8×36 WS FC", TensileStrength = null, KValue = 0.325m, RequiredDiameter = 41.92m },
            new RopeConstants { Id = 10, RopeType = "8×36 WS IWRC", TensileStrength = null, KValue = 0.44m, RequiredDiameter = 35.88m },
            new RopeConstants { Id = 11, RopeType = "35×7 Rotation‑resist IWRC", TensileStrength = null, KValue = 0.46m, RequiredDiameter = 34.90m }
        );

            modelBuilder.Entity<LoadData>().HasData(
                new LoadData { ItemNumber = 1, LoadName = "winch", LoadType = "DL", LoadValueTonnes = 0.1m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 1 },
                new LoadData { ItemNumber = 2, LoadName = "Pump", LoadType = "IL", LoadValueTonnes = 1m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 2 },
                new LoadData { ItemNumber = 3, LoadName = "Passengers", LoadType = "LL", LoadValueTonnes = 0.4m, LocationX = 6, LocationY = 6, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 3 },
                new LoadData { ItemNumber = 4, LoadName = "winch", LoadType = "DL", LoadValueTonnes = 0.8m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 4 },
                new LoadData { ItemNumber = 5, LoadName = "Pump", LoadType = "IL", LoadValueTonnes = 0.95m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 5 },
                new LoadData { ItemNumber = 6, LoadName = "Passengers", LoadType = "LL", LoadValueTonnes = 1.1m, LocationX = 6, LocationY = 6, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 6 },
                new LoadData { ItemNumber = 7, LoadName = "winch", LoadType = "DL", LoadValueTonnes = 1.25m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 7 },
                new LoadData { ItemNumber = 8, LoadName = "Pump", LoadType = "IL", LoadValueTonnes = 1.4m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 8 },
                new LoadData { ItemNumber = 9, LoadName = "Passengers", LoadType = "DL", LoadValueTonnes = 1.55m, LocationX = 6, LocationY = 6, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 9 },
                new LoadData { ItemNumber = 10, LoadName = "winch", LoadType = "IL", LoadValueTonnes = 1.7m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 10 },
                new LoadData { ItemNumber = 11, LoadName = "Pump", LoadType = "LL", LoadValueTonnes = 1.85m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 11 },
                new LoadData { ItemNumber = 12, LoadName = "Passengers", LoadType = "DL", LoadValueTonnes = 2m, LocationX = 6, LocationY = 6, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 12 }
            );

            modelBuilder.Entity<LoadData>()
                .HasKey(ld => ld.ItemNumber); // Ensure ItemNumber is the primary key

            modelBuilder.Entity<LoadData>()
                .Property(ld => ld.LoadName)
                .IsRequired()
                .HasMaxLength(100); // Set a maximum length for LoadName

            modelBuilder.Entity<LoadData>()
                .Property(ld => ld.LoadType)
                .IsRequired()
                .HasMaxLength(50); // Set a maximum length for LoadType

            modelBuilder.Entity<LoadData>()
                .Property(ld => ld.LoadValueTonnes)
                .HasConversion<double>(); // Convert decimal to double for LoadValueTonnes
               
            modelBuilder.Entity<Subscription>()
        .HasMany(s => s.Users)
        .WithOne(u => u.Subscription)
        .HasForeignKey(u => u.SubscriptionId)
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<User>()
        .HasMany(u => u.Projects)
        .WithOne(p => p.User)
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.Restrict); // Prevents multiple cascade paths

    modelBuilder.Entity<Project>()
        .HasOne(p => p.Subscription)
        .WithMany()
        .HasForeignKey(p => p.SubscriptionId)
        .OnDelete(DeleteBehavior.Restrict); 

        }
    }


    static class SeedData
    {
        public static FloatSelectionItem GetModularBargeWithParameters()
        {
            var modularBarge = new FloatSelectionItem
            {
                Name = "MODULAR_BARGE",
                Parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            Name = "MB_3x3x1.2",
                            Length_x = 3,
                            Width_y = 3,
                            Height_z = 1.2M,
                            Weight_Tonns = 1.8M,
                            COG_x = 1.5M,
                            COG_y = 1.5M,
                            COG_z = 0.6M,
                            Area = 9,
                            MOI_x_LocalCentroid = 6.75M,
                            MOI_y_LocalCentroid = 6.75M,
                            MOI_z_LocalCentroid = 0,
                            UnitBuoyancy_TonnsPerM2 = 1,
                            MinimumFreeboard = 0.4M,
                            MaximumDraft = 0.8M
                        },
                        new Parameter
                        {
                            Name = "MB_6x3x1.2",
                            Length_x = 6,
                            Width_y = 3,
                            Height_z = 1.2M,
                            Weight_Tonns = 3.6M,
                            COG_x = 3,
                            COG_y = 1.5M,
                            COG_z = 0.6M,
                            Area = 18,
                            MOI_x_LocalCentroid = 13.5M,
                            MOI_y_LocalCentroid = 54,
                            MOI_z_LocalCentroid = 0,
                            UnitBuoyancy_TonnsPerM2 = 1,
                            MinimumFreeboard = 0.4M,
                            MaximumDraft = 0.8M
                        },
                        new Parameter
                        {
                            Name = "MB_9x3x1.2",
                            Length_x = 9,
                            Width_y = 3,
                            Height_z = 1.2M,
                            Weight_Tonns = 5.4M,
                            COG_x = 4.5M,
                            COG_y = 1.5M,
                            COG_z = 0.6M,
                            Area = 27,
                            MOI_x_LocalCentroid = 20.25M,
                            MOI_y_LocalCentroid = 182.25M,
                            MOI_z_LocalCentroid = 0,
                            UnitBuoyancy_TonnsPerM2 = 1,
                            MinimumFreeboard = 0.4M,
                            MaximumDraft = 0.8M
                        },
                        new Parameter
                        {
                            Name = "MB_12x3x1.2",
                            Length_x = 12,
                            Width_y = 3,
                            Height_z = 1.2M,
                            Weight_Tonns = 7.2M,
                            COG_x = 6,
                            COG_y = 1.5M,
                            COG_z = 0.6M,
                            Area = 36,
                            MOI_x_LocalCentroid = 27,
                            MOI_y_LocalCentroid = 432,
                            MOI_z_LocalCentroid = 0,
                            UnitBuoyancy_TonnsPerM2 = 1,
                            MinimumFreeboard = 0.4M,
                            MaximumDraft = 0.8M
                        }
                    }
            };
            return modularBarge;
        }
        public static List<ChainConstants> GetChainConstantsSeed()
        {
            return new List<ChainConstants>
                {
                    new ChainConstants
                    {
                        ChainGrade = "Chain Grade 1",
                        Notation = "R3",
                        ConstantK = 0.0196m,
                        Diameter = 169.8071307m
                    },
                    new ChainConstants
                    {
                        ChainGrade = "Chain Grade 2",
                        Notation = "R3S",
                        ConstantK = 0.0223m,
                        Diameter = 159.1957714m
                    },
                    new ChainConstants
                    {
                        ChainGrade = "Chain Grade 3",
                        Notation = "R4",
                        ConstantK = 0.0248m,
                        Diameter = 150.9586902m
                    },
                    new ChainConstants
                    {
                        ChainGrade = "Chain Grade 4",
                        Notation = "R4S",
                        ConstantK = 0.0272m,
                        Diameter = 144.144975m
                    },
                    new ChainConstants
                    {
                        ChainGrade = "Chain Grade 5",
                        Notation = "R5",
                        ConstantK = 0.03m,
                        Diameter = 137.2534697m
                    }
                };
        }

        public static List<RopeConstants> GetRopeConstantsSeed()
        {
            return new List<RopeConstants>
        {
            new RopeConstants { RopeType = "6×7 FC", TensileStrength = 1770, KValue = 0.345m, RequiredDiameter = 9831.061605m },
            new RopeConstants { RopeType = "6×7 IWRC", TensileStrength = null, KValue = 0.45m, RequiredDiameter = 35.63m },
            new RopeConstants { RopeType = "6×19 Seale FC", TensileStrength = null, KValue = 0.342m, RequiredDiameter = 41.41m },
            new RopeConstants { RopeType = "6×19 Seale IWRC", TensileStrength = null, KValue = 0.462m, RequiredDiameter = 35.32m },
            new RopeConstants { RopeType = "6×36 WS FC", TensileStrength = null, KValue = 0.346m, RequiredDiameter = 41.20m },
            new RopeConstants { RopeType = "6×36 WS IWRC", TensileStrength = null, KValue = 0.47m, RequiredDiameter = 34.61m },
            new RopeConstants { RopeType = "8×19 Seale FC", TensileStrength = null, KValue = 0.32m, RequiredDiameter = 42.16m },
            new RopeConstants { RopeType = "8×19 Seale IWRC", TensileStrength = null, KValue = 0.43m, RequiredDiameter = 36.23m },
            new RopeConstants { RopeType = "8×36 WS FC", TensileStrength = null, KValue = 0.325m, RequiredDiameter = 41.92m },
            new RopeConstants { RopeType = "8×36 WS IWRC", TensileStrength = null, KValue = 0.44m, RequiredDiameter = 35.88m },
            new RopeConstants { RopeType = "35×7 Rotation‑resist IWRC", TensileStrength = null, KValue = 0.46m, RequiredDiameter = 34.90m }
        };
        }
     
     public static List<LoadData> GetLoadData()
    {
        return new List<LoadData>
        {
            new LoadData { ItemNumber = 1, LoadName = "winch", LoadType = "DL", LoadValueTonnes = 0.1m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 1 },
            new LoadData { ItemNumber = 2, LoadName = "Pump", LoadType = "IL", LoadValueTonnes = 1m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 2 },
            new LoadData { ItemNumber = 3, LoadName = "Passengers", LoadType = "LL", LoadValueTonnes = 0.4m, LocationX = 6, LocationY = 6, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 3 },
            new LoadData { ItemNumber = 4, LoadName = "winch", LoadType = "DL", LoadValueTonnes = 0.8m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 4 },
            new LoadData { ItemNumber = 5, LoadName = "Pump", LoadType = "IL", LoadValueTonnes = 0.95m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 5 },
            new LoadData { ItemNumber = 6, LoadName = "Passengers", LoadType = "LL", LoadValueTonnes = 1.1m, LocationX = 6, LocationY = 6, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 6 },
            new LoadData { ItemNumber = 7, LoadName = "winch", LoadType = "DL", LoadValueTonnes = 1.25m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 7 },
            new LoadData { ItemNumber = 8, LoadName = "Pump", LoadType = "IL", LoadValueTonnes = 1.4m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 8 },
            new LoadData { ItemNumber = 9, LoadName = "Passengers", LoadType = "DL", LoadValueTonnes = 1.55m, LocationX = 6, LocationY = 6, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 9 },
            new LoadData { ItemNumber = 10, LoadName = "winch", LoadType = "IL", LoadValueTonnes = 1.7m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 10 },
            new LoadData { ItemNumber = 11, LoadName = "Pump", LoadType = "LL", LoadValueTonnes = 1.85m, LocationX = 3, LocationY = 3, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 11 },
            new LoadData { ItemNumber = 12, LoadName = "Passengers", LoadType = "DL", LoadValueTonnes = 2m, LocationX = 6, LocationY = 6, LocationZ = 1.2m, AreaX = 1, AreaY = 2, DragCoefficients = 12 }
        };
    }


    }

    class Program
    {
        public static void ParsePdf(string filePath)
        {
            using (var pdf = UglyToad.PdfPig.PdfDocument.Open(filePath))
            {
                foreach (var page in pdf.GetPages())
                {
                    string text = page.Text;
                    Console.WriteLine(text);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Jai Sree Ram, Jai Hanuman, Jai Bajrang Bali, Jai Shree Krishna, Jai Maa Durga, Jai Maa Kali, Jai Maa Saraswati, Jai Maa Lakshmi, Jai Maa Gayatri, Jai Maa Santoshi, Jai Maa Bhadrakali, Jai Maa Kamakhya, Jai Maa Chhinnamasta, Jai Maa Dhumavati, Jai Maa Baglamukhi, Jai Maa Matangi, Jai Maa Kamala");
            Console.WriteLine("Vineet Bhai, Rohit bhai");
            ParsePdf(@"C:\Users\Manish raj\OneDrive\Desktop\\Office Broker Business Plan.pdf");

            using (var db = new AppDbContext())
            {
                #region Database 
                // Creation and Seeding
                //      db.Database.EnsureCreated();
                //     // Get the modular barge with parameters
                //     // Check if modularBarge already exists
                //     #region ModularBarge Seeding

                //     var modularBargeName = "MODULAR_BARGE";
                //     var modularBargeExists = db.FloatSelectionItems.Any(f => f.Name == modularBargeName);
                //     if (!modularBargeExists)
                //     {
                //         var modularBarge = SeedData.GetModularBargeWithParameters();
                //         _ = db.FloatSelectionItems.Add(modularBarge);
                //         db.SaveChanges();

                //         // Now assign the correct FloatSelectionItemId to each parameter
                //         foreach (var p in modularBarge.Parameters)
                //         {
                //             p.FloatSelectionItemId = modularBarge.Id;
                //         }
                //         db.Parameters.AddRange(modularBarge.Parameters);
                //         db.SaveChanges();
                //         Console.WriteLine("Modular barge seeded successfully!");
                //     }
                //     else
                //     {
                //         Console.WriteLine("Modular barge already exists, skipping seeding.");
                //     }
                //     #endregion

                //     #region ChainConstants Seeding


                //     // Check if ChainConstants already exist to avoid duplicate seeding
                //     if (!db.ChainConstants.Any())
                //     {
                //         db.ChainConstants.AddRange(SeedData.GetChainConstantsSeed());
                //         db.SaveChanges();
                //         Console.WriteLine("ChainConstants seeded successfully!");
                //     }
                //     else
                //     {
                //         Console.WriteLine("ChainConstants already exist, skipping seeding.");
                //     }
                //     #endregion

                //     #region RopeConstants Seeding


                //     if (!db.RopeConstants.Any())
                //     {
                //         db.RopeConstants.AddRange(SeedData.GetRopeConstantsSeed());
                //         db.SaveChanges();
                //         Console.WriteLine("RopeConstants seeded successfully!");
                //     }
                //     else
                //     {
                //         Console.WriteLine("RopeConstants already exist, skipping seeding.");
                //     }
                //     Console.WriteLine("Database created and ready!");
                //     #endregion

                //    #region LoadData Seeding
                //     if (!db.LoadDatas.Any())
                //     {
                //         db.LoadDatas.AddRange(SeedData.GetLoadData());
                //         db.SaveChanges();
                //         Console.WriteLine("LoadData seeded successfully!");
                //     }
                //     else
                //     {
                //         Console.WriteLine("LoadData already exist, skipping seeding.");
                //     }
                //     Console.WriteLine("Database created and ready!");
                //     #endregion

                // var obj = db.FloatSelectionItems.Select(p => p).ToList();
                // System.Console.WriteLine(obj);
                // var objParameters = db.Parameters.Select(p => p).ToList();
                // System.Console.WriteLine(objParameters);
                // // wrote a simple query to fetch all FloatSelectionItems and their parameters
                #endregion


                //Todo: Note:- this values would be coming from the UI
                var floatSelectionItemsWithParameters = db.FloatSelectionItems
                    .Include(f => f.Parameters)
                    .ToList();
                System.Console.WriteLine(floatSelectionItemsWithParameters);

                //-----Step 1 USer Selection is done like Project Selection in UI
                InputsAndLayout inputsAndLayout = new InputsAndLayout();
                List<LocalValues> localValuesList = new List<LocalValues>();
                var Outputs = new Outputs();


                //Todo: Note:- this values would be coming from the UI
                //float size layout will be filled with the data from UI OBJECT 
                //FILLED WITH AS PER THE EXCEL GIVEN BY BUSUINESS
                var floatSizeLayout = new List<FloatSizeLayout>
                {
                    new() {
                        FloatSize = "MB_3x3x1.2",
                        XCordinate = 1.5M,
                        YCordinate = 1.5M
                    },
                   new() {
                        FloatSize = "MB_6x3x1.2",
                        XCordinate = 4.5M,
                        YCordinate = 1.5M
                    },
                   new FloatSizeLayout
                    {
                        FloatSize = "MB_9x3x1.2",
                        XCordinate = 3,
                        YCordinate = 4.5M
                    }
                };

                //loop the floatSizeLayout to get the parameters from the FloatSelectionItems and match the float size with parameters which need to pulled from database by db.Parameters where condition will be what is selected by user in project selection
                var selectedParameters = db.Parameters
                    .Include(p => p.FloatSelectionItem)
                    .Where(p => p.FloatSelectionItemId.Equals(1))
                    .ToList();

                //ToDo: Need to pass to tables data , Parameters and List of FloatSizeLayout
                Calculate_InputsAndLayout(floatSizeLayout, selectedParameters, Outputs);


                List<Hydrostatics> hydrostaticLoads = SetHydroStaticLoads(db);

                Calculate_DesignCalculations(inputsAndLayout, selectedParameters, Outputs, hydrostaticLoads);


            }
        }

        private static List<Hydrostatics> SetHydroStaticLoads(AppDbContext db)
        {
            List<LoadData> loadData = [.. db.LoadDatas];
            //Map the loadData to HydrostaticLoad
            var hydrostaticLoads = new List<Hydrostatics>();
            foreach (var load in loadData)
            {
                hydrostaticLoads.Add(new Hydrostatics
                {
                    ItemNumber = load.ItemNumber,
                    LoadName = load.LoadName,
                    LoadType = load.LoadType,
                    LoadValue = load.LoadValueTonnes,
                    LocationX = load.LocationX,
                    LocationY = load.LocationY,
                    LocationZ = load.LocationZ,
                    AreaX = load.AreaX,
                    AreaY = load.AreaY,
                    DragCoefficients = load.DragCoefficients
                });
            }

            return hydrostaticLoads;
        }

        private static void Calculate_DesignCalculations(InputsAndLayout inputsAndLayout, List<Parameter> selectedParameters, Outputs Outputs, List<Hydrostatics> hydrostaticLoads)
        {

            HydrostaticCalculations hydrostaticCalculations = new HydrostaticCalculations();

            PONTOONANDSITEDATA pontoonsiteData = Calculate_Pontoonandsitedata(inputsAndLayout, Outputs);
            Calculate_Hydrostatics(hydrostaticLoads, hydrostaticCalculations, pontoonsiteData);

            var buoyancyCalculations = Calculate_BoyancyAndStability(hydrostaticLoads, hydrostaticCalculations, pontoonsiteData);

            Calculate_StabilityAboutX(hydrostaticLoads, hydrostaticCalculations, pontoonsiteData, buoyancyCalculations);

            Calculate_StabilityAboutY(hydrostaticLoads, hydrostaticCalculations, pontoonsiteData, buoyancyCalculations);
            var windPressureCalculations = Calculate_Moring_WindPressureCalculations(inputsAndLayout);
            var windLoadCalculations =Calculate_WindLoadCalculations(windPressureCalculations, buoyancyCalculations, pontoonsiteData, hydrostaticLoads, hydrostaticCalculations);

            var dragForceCalLoadCalculations = Calculate_DragForceCalculations(inputsAndLayout, pontoonsiteData, buoyancyCalculations);

            var waveForceCalculations = CalCulate_WaveForceCalculations(inputsAndLayout, pontoonsiteData);



            var angleTwoCalculations = Calculate_AngleTwoCalculations();
            Calculate_DEAD_WEIGHT_ANCHOR_AND_MOORING_CALCULATION(waveForceCalculations, dragForceCalLoadCalculations, pontoonsiteData, windLoadCalculations, inputsAndLayout,angleTwoCalculations);
            
            // hydrostaticCalculations.TotalLoadValue = hydrostaticLoads.Sum(e => e.LoadValue);
            // hydrostaticCalculations.TotalLoadValue = hydrostaticLoads.Sum(e => e.LoadValue);
            // hydrostaticCalculations.TotalLoadValue = hydrostaticLoads.Sum(e => e.LoadValue);
            // hydrostaticCalculations.TotalLoadValue = hydrostaticLoads.Sum(e => e.LoadValue);
            // hydrostaticCalculations.TotalLoadValue = hydrostaticLoads.Sum(e => e.LoadValue);
            // hydrostaticCalculations.TotalLoadValue = hydrostaticLoads.Sum(e => e.LoadValue);



        }

        private static AngleTwoCalculations Calculate_AngleTwoCalculations()
        {
            AngleTwoCalculations angleTwoCalculations = new AngleTwoCalculations
            {
                noofmooringlineinx = 2,
                noofmooringlineiny = 2,
                Angle2_of_x = 60,
                Angle2_of_y = 60,
            };

            return angleTwoCalculations;
        }

        private static void Calculate_DEAD_WEIGHT_ANCHOR_AND_MOORING_CALCULATION(List<WaveForceCalculations> waveForceCalculations, List<DragForceCalculations> dragForceCalLoadCalculations, PONTOONANDSITEDATA pontoonsiteData, List<WindLoadcalculation> windLoadCalculations, InputsAndLayout inputsAndLayout,
        AngleTwoCalculations angleTwoCalculations)
        {

           List<DeadweightAnchorAndMooringCalculation> deadweightAnchorAndMooringCalculations = new List<DeadweightAnchorAndMooringCalculation>();

            for (int i = 1; i <= 21; i++)
            {
                var deadweightAnchorAndMooringCal = new DeadweightAnchorAndMooringCalculation();
                if (i == 1)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Wind load";
                    deadweightAnchorAndMooringCal.Unit = "kg";
                    // deadweightAnchorAndMooringCal.AlongXDirection = waveForceCalculations[5].X * 1000;
                    deadweightAnchorAndMooringCal.AlongXDirection = windLoadCalculations[5].X * 1000;
                    // deadweightAnchorAndMooringCal.AlongYDirection = waveForceCalculations[5].Y * 1000;
                    deadweightAnchorAndMooringCal.AlongYDirection = windLoadCalculations[5].Y * 1000;
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                if (i == 2)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Drag load due to current";
                    deadweightAnchorAndMooringCal.Unit = "kg";
                    deadweightAnchorAndMooringCal.AlongXDirection = dragForceCalLoadCalculations[4].X * 1000;
                    deadweightAnchorAndMooringCal.AlongYDirection = dragForceCalLoadCalculations[4].Y * 1000;
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                if (i == 3)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Wave Drift Load";
                    deadweightAnchorAndMooringCal.Unit = "tonnes";
                    deadweightAnchorAndMooringCal.AlongXDirection = waveForceCalculations[1].X * 1000;
                    deadweightAnchorAndMooringCal.AlongYDirection = waveForceCalculations[1].Y * 1000;
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                if (i == 4)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Load Factor";
                    deadweightAnchorAndMooringCal.Unit = "";
                    deadweightAnchorAndMooringCal.AlongXDirection = 1;
                    deadweightAnchorAndMooringCal.AlongYDirection = 1;
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                if (i == 5)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Total design load ";
                    deadweightAnchorAndMooringCal.Unit = "kg";
                    deadweightAnchorAndMooringCal.AlongXDirection =
                        (deadweightAnchorAndMooringCalculations[0].AlongXDirection
                        + deadweightAnchorAndMooringCalculations[1].AlongXDirection
                        + deadweightAnchorAndMooringCalculations[2].AlongXDirection)
                        * deadweightAnchorAndMooringCalculations[3].AlongXDirection;

                    deadweightAnchorAndMooringCal.AlongYDirection =
                        (deadweightAnchorAndMooringCalculations[0].AlongYDirection
                        + deadweightAnchorAndMooringCalculations[1].AlongYDirection
                        + deadweightAnchorAndMooringCalculations[2].AlongYDirection)
                        * deadweightAnchorAndMooringCalculations[3].AlongYDirection;

                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                if (i == 6)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "No. of  load-bearing mooring line ";
                    deadweightAnchorAndMooringCal.Unit = "";
                    deadweightAnchorAndMooringCal.AlongXDirection = angleTwoCalculations.noofmooringlineinx;
                    deadweightAnchorAndMooringCal.AlongYDirection = angleTwoCalculations.noofmooringlineiny;
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                if (i == 7)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Design horizontal load on each mooring line";
                    deadweightAnchorAndMooringCal.Unit = "kg";
                    // deadweightAnchorAndMooringCal.AlongXDirection = deadweightAnchorAndMooringCalculations[5].AlongXDirection / deadweightAnchorAndMooringCalculations[6].AlongXDirection;
                    deadweightAnchorAndMooringCal.AlongXDirection = deadweightAnchorAndMooringCalculations[4].AlongXDirection / deadweightAnchorAndMooringCalculations[5].AlongXDirection;

                    // deadweightAnchorAndMooringCal.AlongYDirection = deadweightAnchorAndMooringCalculations[5].AlongYDirection / deadweightAnchorAndMooringCalculations[6].AlongYDirection;
                    deadweightAnchorAndMooringCal.AlongYDirection = deadweightAnchorAndMooringCalculations[4].AlongYDirection / deadweightAnchorAndMooringCalculations[5].AlongYDirection;
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                if (i == 8)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Water depth";
                    deadweightAnchorAndMooringCal.Unit = "kg";
                    deadweightAnchorAndMooringCal.AlongXDirection = pontoonsiteData.WaterDepth;
                    deadweightAnchorAndMooringCal.AlongYDirection = pontoonsiteData.WaterDepth;
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                if (i == 9)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Scope to water depth ratio";
                    deadweightAnchorAndMooringCal.Unit = "m";
                    deadweightAnchorAndMooringCal.AlongXDirection = pontoonsiteData.ScopeToWaterDepthRatio;
                    deadweightAnchorAndMooringCal.AlongYDirection = pontoonsiteData.ScopeToWaterDepthRatio;
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                if (i == 10)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Scope of anchor cable";
                    deadweightAnchorAndMooringCal.Unit = "m";
                    deadweightAnchorAndMooringCal.AlongXDirection = deadweightAnchorAndMooringCalculations[7].AlongXDirection * deadweightAnchorAndMooringCalculations[8].AlongXDirection;

                    deadweightAnchorAndMooringCal.AlongYDirection = deadweightAnchorAndMooringCalculations[7].AlongYDirection * deadweightAnchorAndMooringCalculations[8].AlongYDirection;
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                if (i == 11)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Angle one";
                    deadweightAnchorAndMooringCal.Unit = "degree";
                    deadweightAnchorAndMooringCal.AlongXDirection = (decimal)(Math.Asin((double)(deadweightAnchorAndMooringCalculations[7].AlongXDirection / (deadweightAnchorAndMooringCalculations[9].AlongXDirection))) * (180.0 / Math.PI));

                    deadweightAnchorAndMooringCal.AlongYDirection = (decimal)(Math.Asin((double)(deadweightAnchorAndMooringCalculations[7].AlongYDirection / (deadweightAnchorAndMooringCalculations[9].AlongYDirection))) * (180.0 / Math.PI));
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                if (i == 12)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Angle two";
                    deadweightAnchorAndMooringCal.Unit = "degree";
                    deadweightAnchorAndMooringCal.AlongXDirection = angleTwoCalculations.Angle2_of_x;

                    deadweightAnchorAndMooringCal.AlongYDirection = angleTwoCalculations.Angle2_of_y;
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                if (i == 13)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Tension in the mooring line";
                    deadweightAnchorAndMooringCal.Unit = "kg";
                    decimal result = deadweightAnchorAndMooringCalculations[6].AlongXDirection /
                        ((decimal)Math.Cos((double)deadweightAnchorAndMooringCalculations[10].AlongXDirection * (Math.PI / 180.0)) *
                         (decimal)Math.Cos((double)deadweightAnchorAndMooringCalculations[11].AlongXDirection * (Math.PI / 180.0)));

                    deadweightAnchorAndMooringCal.AlongXDirection = result;

                    deadweightAnchorAndMooringCal.AlongYDirection = deadweightAnchorAndMooringCalculations[6].AlongYDirection /
                        ((decimal)Math.Cos((double)deadweightAnchorAndMooringCalculations[10].AlongYDirection * (Math.PI / 180.0)) *
                         (decimal)Math.Cos((double)deadweightAnchorAndMooringCalculations[11].AlongYDirection * (Math.PI / 180.0)));
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                if (i == 14)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Vertical pull of mooring line";
                    deadweightAnchorAndMooringCal.Unit = "kg";


                    deadweightAnchorAndMooringCal.AlongXDirection = deadweightAnchorAndMooringCalculations[12].AlongXDirection * (decimal)Math.Sin((double)deadweightAnchorAndMooringCalculations[10].AlongXDirection * (Math.PI / 180.0));

                    deadweightAnchorAndMooringCal.AlongYDirection = deadweightAnchorAndMooringCalculations[12].AlongYDirection * (decimal)Math.Sin((double)deadweightAnchorAndMooringCalculations[10].AlongYDirection * (Math.PI / 180.0));
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }

                if (i == 15)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Horizontal pull of mooring line";
                    deadweightAnchorAndMooringCal.Unit = "kg";


                    deadweightAnchorAndMooringCal.AlongXDirection = deadweightAnchorAndMooringCalculations[12].AlongXDirection * (decimal)Math.Cos((double)deadweightAnchorAndMooringCalculations[10].AlongXDirection * (Math.PI / 180.0));

                    deadweightAnchorAndMooringCal.AlongYDirection = deadweightAnchorAndMooringCalculations[12].AlongYDirection * (decimal)Math.Cos((double)deadweightAnchorAndMooringCalculations[10].AlongYDirection * (Math.PI / 180.0));
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }

                if (i == 16)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Holding capacity of anchor";
                    deadweightAnchorAndMooringCal.Unit = "kg";


                    deadweightAnchorAndMooringCal.AlongXDirection = deadweightAnchorAndMooringCalculations[14].AlongXDirection;

                    deadweightAnchorAndMooringCal.AlongYDirection = deadweightAnchorAndMooringCalculations[14].AlongYDirection;
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }

                if (i == 17)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Coefficient b/w anchor and soil";
                    deadweightAnchorAndMooringCal.Unit = "";

                    // need to revisit
                    // temp values for calculation
                    deadweightAnchorAndMooringCal.AlongXDirection = 0.27m;
                    deadweightAnchorAndMooringCal.AlongYDirection = 0.27m;

                    // deadweightAnchorAndMooringCal.AlongXDirection = deadweightAnchorAndMooringCalculations[14].AlongXDirection;

                    // deadweightAnchorAndMooringCal.AlongYDirection = deadweightAnchorAndMooringCalculations[14].AlongYDirection;
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }

                if (i == 18)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Weight of anchor in water";
                    deadweightAnchorAndMooringCal.Unit = "kg";

                    deadweightAnchorAndMooringCal.AlongXDirection = deadweightAnchorAndMooringCalculations[14].AlongXDirection / deadweightAnchorAndMooringCalculations[16].AlongXDirection + deadweightAnchorAndMooringCalculations[13].AlongXDirection;

                    deadweightAnchorAndMooringCal.AlongYDirection = (deadweightAnchorAndMooringCalculations[14].AlongYDirection / deadweightAnchorAndMooringCalculations[16].AlongYDirection) + (deadweightAnchorAndMooringCalculations[13].AlongYDirection);

                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }

                if (i == 19)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Minimum dry weight of anchor";
                    deadweightAnchorAndMooringCal.Unit = "kg";

                    deadweightAnchorAndMooringCal.AlongXDirection = (deadweightAnchorAndMooringCalculations[17].AlongXDirection) / (1 - (1 / (decimal)2.4));

                    deadweightAnchorAndMooringCal.AlongYDirection = (deadweightAnchorAndMooringCalculations[17].AlongYDirection) / (1 - (1 / (decimal)2.4));

                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }

                if (i == 20)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Factor safety";
                    deadweightAnchorAndMooringCal.Unit = "";

                    deadweightAnchorAndMooringCal.AlongXDirection = 1.2m;
                    deadweightAnchorAndMooringCal.AlongYDirection = 1.2m;

                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                
                if (i == 21)
                {
                    deadweightAnchorAndMooringCal.SNo = i;
                    deadweightAnchorAndMooringCal.Description = "Dry weight of anchor";
                    deadweightAnchorAndMooringCal.Unit = "kg";

                    deadweightAnchorAndMooringCal.AlongXDirection = (deadweightAnchorAndMooringCalculations[18].AlongXDirection * deadweightAnchorAndMooringCalculations[19].AlongXDirection);
                    deadweightAnchorAndMooringCal.AlongYDirection = (deadweightAnchorAndMooringCalculations[18].AlongYDirection * deadweightAnchorAndMooringCalculations[19].AlongYDirection);
                    
                    deadweightAnchorAndMooringCalculations.Add(deadweightAnchorAndMooringCal);
                }
                

            }
        }

        private static List<WaveForceCalculations> CalCulate_WaveForceCalculations(InputsAndLayout inputsAndLayout, PONTOONANDSITEDATA pontoonsiteData)
        {
            List<WaveForceCalculations> waveForceCalculations = new List<WaveForceCalculations>();

            for (int i = 1; i <= 6; i++)
            {
                var waveForceCal = new WaveForceCalculations();
                if (i == 1)
                {
                    waveForceCal.SNo = i;
                    waveForceCal.Description = "Wave height";
                    waveForceCal.Unit = "m";
                    waveForceCal.X = inputsAndLayout.WaveHeight;
                    waveForceCal.Y = inputsAndLayout.WaveHeight;
                    waveForceCalculations.Add(waveForceCal);
                }
                if (i == 2)
                {
                    waveForceCal.SNo = i;
                    waveForceCal.Description = "Total Wave Drift Load";
                    waveForceCal.Unit = "tonnes";
                    waveForceCal.X = ((0.5m * 1000m * 9.81m * pontoonsiteData.VesselWidth * waveForceCalculations[0].X * waveForceCalculations[0].X) / (9.81m * 1000m));
                    waveForceCal.Y = ((0.5m * 1000m * 9.81m * pontoonsiteData.VesselLength * waveForceCalculations[0].Y * waveForceCalculations[0].Y) / (9.81m * 1000m));
                    waveForceCalculations.Add(waveForceCal);
                }
            }
            return waveForceCalculations;
           
        }

        private static List<DragForceCalculations> Calculate_DragForceCalculations(InputsAndLayout inputsAndLayout, PONTOONANDSITEDATA pontoonsiteData, BuoyancyCalculations buoyancyCalculations)
        {
            List<DragForceCalculations> dragForceCalLoadCalculations = new List<DragForceCalculations>();

            for (int i = 1; i <= 5; i++)
            {
                var dragForcecal = new DragForceCalculations();
                // Assuming a default value, this can
                if (i == 1)
                {
                    dragForcecal.SNo = i;
                    dragForcecal.Description = "Current velocity";
                    dragForcecal.Unit = "m/s";
                    dragForcecal.X = inputsAndLayout.CurrentSpeed;
                    dragForcecal.Y = inputsAndLayout.CurrentSpeed;
                    dragForceCalLoadCalculations.Add(dragForcecal);
                }
                if (i == 2)
                {
                    dragForcecal.SNo = i;
                    dragForcecal.Description = "Drag coefficient";
                    dragForcecal.Unit = "";
                    dragForcecal.X = pontoonsiteData.DragCoefficientX;
                    dragForcecal.Y = pontoonsiteData.DragCoefficientY;
                    dragForceCalLoadCalculations.Add(dragForcecal);
                }
                if (i == 3)
                {
                    dragForcecal.SNo = i;
                    dragForcecal.Description = "Drag force per unit area";
                    dragForcecal.Unit = "tonne/sq.m";
                    dragForcecal.X = 52 * dragForceCalLoadCalculations[1].X * (decimal)Math.Pow((double)dragForceCalLoadCalculations[0].X, 2) / 1000;

                    dragForcecal.Y = 52 * dragForceCalLoadCalculations[1].Y * (decimal)Math.Pow((double)dragForceCalLoadCalculations[0].Y, 2) / 1000;
                    dragForceCalLoadCalculations.Add(dragForcecal);
                }
                if (i == 4)
                {
                    dragForcecal.SNo = i;
                    dragForcecal.Description = "Projected area";
                    dragForcecal.Unit = "sq.m";
                    dragForcecal.X = buoyancyCalculations.Draft * pontoonsiteData.VesselWidth;
                    dragForcecal.Y = buoyancyCalculations.Draft * pontoonsiteData.VesselLength;
                    dragForceCalLoadCalculations.Add(dragForcecal);
                }
                if (i == 5)
                {
                    dragForcecal.SNo = i;
                    dragForcecal.Description = "Total drag force";
                    dragForcecal.Unit = "tonnes";
                    dragForcecal.X = dragForceCalLoadCalculations[2].X * dragForceCalLoadCalculations[3].X;
                    dragForcecal.Y = dragForceCalLoadCalculations[2].Y * dragForceCalLoadCalculations[3].Y;
                    dragForceCalLoadCalculations.Add(dragForcecal);
                }

            }
            return dragForceCalLoadCalculations;
            
        }

        private static List<WindLoadcalculation> Calculate_WindLoadCalculations(WindPressurecalculation windPressureCalculations, BuoyancyCalculations buoyancyCalculations, PONTOONANDSITEDATA pontoonsiteData, List<Hydrostatics> hydrostaticLoads, HydrostaticCalculations hydrostaticCalculations)
        {
            List<WindLoadcalculation> windLoadCalculations = new List<WindLoadcalculation>();

            for (int i = 1; i <= 6; i++)
            {
                var windcal = new WindLoadcalculation();
                // Assuming a default value, this can
                if (i == 1)
                {
                    windcal.SNo = i;
                    windcal.Description = "Wind pressure";
                    windcal.Unit = "tonnes/sq.m";
                    windcal.X = windPressureCalculations.Windpressure;
                    windcal.Y = windPressureCalculations.Windpressure;
                    windLoadCalculations.Add(windcal);
                }
                if (i == 2)
                {
                    windcal.SNo = i;
                    windcal.Description = "Exposed area (float)";
                    windcal.Unit = "sq.m";
                    windcal.X = buoyancyCalculations.Freeboard * pontoonsiteData.VesselWidth;
                    windcal.Y = buoyancyCalculations.Freeboard * pontoonsiteData.VesselLength;
                    windLoadCalculations.Add(windcal);
                }
                if (i == 3)
                {
                    windcal.SNo = i;
                    windcal.Description = "Drag coefficient (jetty)";
                    windcal.Unit = "";// ToDo : no data mentioned in Excel provided by Business
                    windcal.X = pontoonsiteData.DragCoefficientX;
                    windcal.Y = pontoonsiteData.DragCoefficientY;
                    windLoadCalculations.Add(windcal);
                }
                if (i == 4)
                {
                    windcal.SNo = i;
                    windcal.Description = "Exposed area (pump)";
                    windcal.Unit = "sq.m";
                    windcal.X = hydrostaticCalculations.TotalAreax;
                    windcal.Y = hydrostaticCalculations.TotalAreay;
                    windLoadCalculations.Add(windcal);
                }
                if (i == 5)
                {
                    windcal.SNo = i;
                    windcal.Description = "Drag coefficient (pump)";
                    windcal.Unit = "";
                    var totalsumValueX = 0m;
                    foreach (var load in hydrostaticLoads)
                    {
                        totalsumValueX += load.DragCoefficients * load.AreaX;
                    }
                    totalsumValueX = totalsumValueX / hydrostaticCalculations.TotalAreax;
                    windcal.X = totalsumValueX;

                    var totalsumValueY = 0m;
                    foreach (var load in hydrostaticLoads)
                    {
                        totalsumValueY += load.DragCoefficients * load.AreaY;
                    }
                    totalsumValueY = totalsumValueY / hydrostaticCalculations.TotalAreay;
                    windcal.Y = totalsumValueY;
                    windLoadCalculations.Add(windcal);
                }
                if (i == 6)
                {
                    windcal.SNo = i;
                    windcal.Description = "Total wind load";
                    windcal.Unit = "tonnes";
                    windcal.X = windLoadCalculations[0].X * (windLoadCalculations[1].X * windLoadCalculations[2].X + windLoadCalculations[3].X * windLoadCalculations[4].X);

                    windcal.Y = windLoadCalculations[0].Y * (windLoadCalculations[1].Y * windLoadCalculations[2].Y + windLoadCalculations[3].Y * windLoadCalculations[4].Y);
                    windLoadCalculations.Add(windcal);
                }


            }
            return windLoadCalculations;
            
        }

        private static WindPressurecalculation Calculate_Moring_WindPressureCalculations(InputsAndLayout inputsAndLayout)
        {
            var windPressurecalculation = new WindPressurecalculation
            {
                DesignwindspeedVz = inputsAndLayout.WindVelocity,
                Windpressure = (0.6m * inputsAndLayout.WindVelocity) * (inputsAndLayout.WindVelocity / 10000)
            };

            return windPressurecalculation;
            
        }

        private static void Calculate_StabilityAboutX(List<Hydrostatics> hydrostaticLoads, HydrostaticCalculations hydrostaticCalculations, PONTOONANDSITEDATA  PontoonAndSiteData, BuoyancyCalculations buoyancyCalculations)
        {
            var maximumTiltAngleX = (decimal)(Math.Atan(
                    (double)(buoyancyCalculations.Freeboard - PontoonAndSiteData.MinimumFreeboard) /
                    ((double)PontoonAndSiteData.VesselWidth / 2)
                ) * (180 / Math.PI));
            var gM_X = (PontoonAndSiteData.MoiX / hydrostaticCalculations.IncludingVessel_loadValue) - (hydrostaticCalculations.IncludingVessel_locationz - buoyancyCalculations.Draft / 2);

            StabilityAboutX stabilityAboutX = new StabilityAboutX
            {
                COB = buoyancyCalculations.Draft / 2,
                COG_Z = hydrostaticCalculations.IncludingVessel_locationz,
                BM_IV_X = PontoonAndSiteData.MoiX / hydrostaticCalculations.IncludingVessel_loadValue,
                BG = hydrostaticCalculations.IncludingVessel_locationz - buoyancyCalculations.Draft / 2,
                GM_X = gM_X,

                MaximumTiltAngleX = maximumTiltAngleX,

                MaxRightningMomentX = hydrostaticCalculations.IncludingVessel_loadValue * gM_X *
                  (decimal)Math.Sin(Math.PI * (double)maximumTiltAngleX / 180.0),

                MaxHeelingMomentX = hydrostaticCalculations.TotalMomentx,
                 TiltAngleX = (decimal)(Math.Asin((double)(hydrostaticCalculations.TotalMomentx / (hydrostaticCalculations.IncludingVessel_loadValue * gM_X))) * (180.0 / Math.PI)),
                  
               
            };
            
        }

        private static void Calculate_StabilityAboutY(List<Hydrostatics> hydrostaticLoads, HydrostaticCalculations hydrostaticCalculations, PONTOONANDSITEDATA  PontoonAndSiteData, BuoyancyCalculations buoyancyCalculations)
        {
            var maximumTiltAngleY = (decimal)(Math.Atan(
                    (double)(buoyancyCalculations.Freeboard - PontoonAndSiteData.MinimumFreeboard) /
                    ((double)PontoonAndSiteData.VesselLength / 2)
                ) * (180 / Math.PI));
            var gM_Y = ((PontoonAndSiteData.MoiY / hydrostaticCalculations.IncludingVessel_loadValue) -
                       (hydrostaticCalculations.IncludingVessel_locationz - buoyancyCalculations.Draft / 2));

            StabilityAboutY stabilityAboutY = new StabilityAboutY
            {
                COB = buoyancyCalculations.Draft / 2,
                COG_Z = hydrostaticCalculations.IncludingVessel_locationz,
                BM_IV_Y = PontoonAndSiteData.MoiY / hydrostaticCalculations.IncludingVessel_loadValue,

                BG = hydrostaticCalculations.IncludingVessel_locationz - buoyancyCalculations.Draft / 2,

                GM_Y = ((PontoonAndSiteData.MoiY / hydrostaticCalculations.IncludingVessel_loadValue) -
                       (hydrostaticCalculations.IncludingVessel_locationz - buoyancyCalculations.Draft / 2)),

                MaximumTiltAngleY = maximumTiltAngleY,

                MaxRightningMomentY = hydrostaticCalculations.IncludingVessel_loadValue * gM_Y *
                  (decimal)Math.Sin(Math.PI * (double)maximumTiltAngleY / 180.0),

                MaxHeelingMomentY = hydrostaticCalculations.TotalMomenty,

                 TiltAngleY = (decimal)(Math.Asin((double)(hydrostaticCalculations.TotalMomenty / (hydrostaticCalculations.IncludingVessel_loadValue * gM_Y))) * (180.0 / Math.PI)),
               
            };
            
        }

        private static BuoyancyCalculations Calculate_BoyancyAndStability(List<Hydrostatics> hydrostaticLoads, HydrostaticCalculations hydrostaticCalculations, PONTOONANDSITEDATA PoontoonSiteData)
        {
            var draft = (hydrostaticCalculations.IncludingVessel_loadValue / (PoontoonSiteData.VesselBuoyancy * PoontoonSiteData.VesselDepth * PoontoonSiteData.TotalArea)) * PoontoonSiteData.VesselDepth;

            BuoyancyCalculations buoyancyCalculations = new BuoyancyCalculations
            {
                TotalBuoyancy = PoontoonSiteData.VesselBuoyancy * PoontoonSiteData.VesselDepth * PoontoonSiteData.TotalArea,
                ReservedBuoyancy = (PoontoonSiteData.VesselBuoyancy * PoontoonSiteData.VesselDepth * PoontoonSiteData.TotalArea) -
                hydrostaticCalculations.IncludingVessel_loadValue,

                Draft = draft,

                Freeboard = PoontoonSiteData.VesselDepth - draft
            };
            return buoyancyCalculations;
        }

        private static void Calculate_Hydrostatics(List<Hydrostatics> hydrostaticLoads, HydrostaticCalculations hydrostaticCalculations, PONTOONANDSITEDATA siteData)
        {
            // Caluculating TotalLoadValue
            hydrostaticCalculations.TotalLoadValue = hydrostaticLoads.Sum(e => e.LoadValue);
            foreach (var load in hydrostaticLoads)
            {
                hydrostaticCalculations.TotalLocationx += load.LoadValue * load.LocationX;
            }

            // Caluculating TotalLocationx            
            hydrostaticCalculations.TotalLocationx = hydrostaticCalculations.TotalLocationx / hydrostaticCalculations.TotalLoadValue;

            // Caluculating IncludingVessel_loadValue
            hydrostaticCalculations.IncludingVessel_loadValue = hydrostaticCalculations.TotalLoadValue + siteData.VesselWeight;

            // Caluculating IncludingVessel_TotalLocationx
            hydrostaticCalculations.IncludingVessel_locationx = ((hydrostaticCalculations.TotalLocationx * hydrostaticCalculations.TotalLoadValue) + (siteData.VesselWeight * siteData.VesselCogX)) / hydrostaticCalculations.IncludingVessel_loadValue;



            // Caluculating TotalLocationy 
            foreach (var load in hydrostaticLoads)
            {
                hydrostaticCalculations.TotalLocationy += load.LoadValue * load.LocationY;
            }

            // Caluculating TotalLocationy 
            hydrostaticCalculations.TotalLocationy = hydrostaticCalculations.TotalLocationy / hydrostaticCalculations.TotalLoadValue;
            // Caluculating IncludingVessel_TotalLocationy
            hydrostaticCalculations.IncludingVessel_locationy = ((hydrostaticCalculations.TotalLocationy * hydrostaticCalculations.TotalLoadValue) + (siteData.VesselWeight * siteData.VesselCogY)) / hydrostaticCalculations.IncludingVessel_loadValue;





            // Caluculating TotalLocationz 
            foreach (var load in hydrostaticLoads)
            {
                hydrostaticCalculations.TotalLocationz += load.LoadValue * load.LocationZ;
            }

            hydrostaticCalculations.TotalLocationz = hydrostaticCalculations.TotalLocationz / hydrostaticCalculations.TotalLoadValue;
            // Caluculating IncludingVessel_TotalLocationz
            hydrostaticCalculations.IncludingVessel_locationz = ((hydrostaticCalculations.TotalLocationz * hydrostaticCalculations.TotalLoadValue) + (siteData.VesselWeight * siteData.VesselCogZ)) / hydrostaticCalculations.IncludingVessel_loadValue;





            hydrostaticCalculations.TotalAreax = hydrostaticLoads.Sum(e => e.AreaX);
            hydrostaticCalculations.TotalAreay = hydrostaticLoads.Sum(e => e.AreaY);

            // Caluculating Momentx 
            foreach (var load in hydrostaticLoads)
            {
                load.MomentX = load.LoadValue * (load.LocationY - hydrostaticCalculations.IncludingVessel_locationy);
            }
            hydrostaticCalculations.TotalMomentx = hydrostaticLoads.Sum(e => e.MomentX);


            // Caluculating Momentx 
            foreach (var load in hydrostaticLoads)
            {
                load.MomentY = load.LoadValue * (load.LocationX - hydrostaticCalculations.IncludingVessel_locationx);
            }
            hydrostaticCalculations.TotalMomenty = hydrostaticLoads.Sum(e => e.MomentY);
        }

        private static PONTOONANDSITEDATA Calculate_Pontoonandsitedata(InputsAndLayout inputsAndLayout, Outputs Outputs)
        {
            PONTOONANDSITEDATA siteData = new()
            {
                VesselLength = inputsAndLayout.Length,
                VesselWidth = inputsAndLayout.Width,
                VesselDepth = 1.2m , //todo need to revist the value //inputsAndLayout.Depth,
                WindSpeed = inputsAndLayout.WindVelocity,
                CurrentSpeed = inputsAndLayout.CurrentSpeed,
                WaveHeight = inputsAndLayout.WaveHeight,
                VesselWeight = Outputs.TotalWeight,
                VesselCogX = Outputs.GlobalCGX,
                VesselCogY = Outputs.GlobalCGY,
                VesselCogZ = Outputs.GlobalCGZ,
                MoiX = Outputs.GlobalMx,
                MoiY = Outputs.GlobalMy,
                VesselBuoyancy = 1M, //todo need to revisit the value //Outputs.UnitBuoyancyCapacity,
                TotalArea = Outputs.TotalArea,
                MinimumFreeboard = 0.4M, //todo need to revist the value
                MaximumDraft =0.8M , //todo need to revist the value
                DragCoefficientX = inputsAndLayout.DragCoefficientX,
                DragCoefficientY = inputsAndLayout.DragCoefficientY,
                WaterDepth = inputsAndLayout.MaxWaterDepth,
                ScopeToWaterDepthRatio = inputsAndLayout.ScopeToWaterDepthRatio

            };
            return siteData;
        }

        private static void Calculate_InputsAndLayout(List<FloatSizeLayout> floatSizeLayout, List<Parameter> selectedParameters, Outputs Outputs)
        {
            //Step 2 User selection Math applied with other values to Calculate the LocalValues
            //Note: LocalValues Calculation is done in the below loop
            foreach (var floatSize in floatSizeLayout)
            {
                selectedParameters.Where(e => e.Name == floatSize.FloatSize)
                    .ToList()
                    .ForEach(p =>
                    {

                        floatSize.WeightTonns = p.Weight_Tonns;
                        floatSize.COGx = p.COG_x;
                        floatSize.COGy = p.COG_y;
                        floatSize.COGz = p.COG_z;
                        floatSize.Area = p.Area;
                        floatSize.MOIxLocalCentroid = p.MOI_x_LocalCentroid;
                        floatSize.MOIyLocalCentroid = p.MOI_y_LocalCentroid;

                    });
            }

            foreach (var floatSize in floatSizeLayout)
            {
                floatSize.WeighedX = floatSize.XCordinate * floatSize.WeightTonns;
            }
            foreach (var floatSize in floatSizeLayout)
            {
                floatSize.WeighedY = floatSize.YCordinate * floatSize.WeightTonns;
            }
            foreach (var floatSize in floatSizeLayout)
            {
                floatSize.WeighedZ = floatSize.COGz * floatSize.WeightTonns;
            }


            // //outputs
            Outputs.TotalWeight = floatSizeLayout.Sum(e => e.WeightTonns);
            Outputs.GlobalCGX = floatSizeLayout.Sum(e => e.WeighedX) / floatSizeLayout.Sum(e => e.WeightTonns);
            Outputs.GlobalCGY = floatSizeLayout.Sum(e => e.WeighedY) / floatSizeLayout.Sum(e => e.WeightTonns);
            Outputs.GlobalCGZ = floatSizeLayout.Sum(e => e.WeighedZ) / floatSizeLayout.Sum(e => e.WeightTonns);

            // var Outputs = new Outputs
            // {
            //     TotalWeight = floatSizeLayout.Sum(e => e.WeightTonns),//selectedParameters.Sum(e => e.Weight_Tonns),
            //     GlobalCGX = floatSizeLayout.Sum(e => e.WeighedX) / floatSizeLayout.Sum(e => e.WeightTonns),
            //     GlobalCGY = floatSizeLayout.Sum(e => e.WeighedY) / floatSizeLayout.Sum(e => e.WeightTonns),
            //     GlobalCGZ = floatSizeLayout.Sum(e => e.WeighedZ) / floatSizeLayout.Sum(e => e.WeightTonns),

            // };

            foreach (var floatSize in floatSizeLayout)
            {
                //Step 3 Gobal Calculations
                floatSize.MOIx = floatSize.MOIxLocalCentroid + floatSize.Area * (decimal)Math.Pow((double)(Outputs.GlobalCGY - floatSize.YCordinate), 2);

                floatSize.MOIy = floatSize.MOIyLocalCentroid + floatSize.Area * (decimal)Math.Pow((double)(Outputs.GlobalCGX - floatSize.XCordinate), 2);

            }

            Outputs.GlobalMx = floatSizeLayout.Sum(e => e.MOIx);
            Outputs.GlobalMy = floatSizeLayout.Sum(e => e.MOIy);
            Outputs.TotalArea = floatSizeLayout.Sum(e => e.Area);
        }
    }
    public class ChainConstants
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Add this for EF Core seeding
        public string ChainGrade { get; set; }
        public string Notation { get; set; }
        public decimal ConstantK { get; set; }
        public decimal Diameter { get; set; }
    }
    public class RopeConstants
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary key for EF Core
        public string RopeType { get; set; }
        public decimal? TensileStrength { get; set; }
        public decimal KValue { get; set; }
        public decimal RequiredDiameter { get; set; }
    }

    public class FloatSelectionItem
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } // e.g., "MODULAR_BARGE"
        public virtual ICollection<Parameter> Parameters { get; set; }
    }
    public class Parameter
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Length_x { get; set; }
        public decimal Width_y { get; set; }
        public decimal Height_z { get; set; }
        public decimal Weight_Tonns { get; set; }
        public decimal COG_x { get; set; }
        public decimal COG_y { get; set; }
        public decimal COG_z { get; set; }
        public decimal Area { get; set; }
        public decimal MOI_x_LocalCentroid { get; set; }
        public decimal MOI_y_LocalCentroid { get; set; }
        public decimal MOI_z_LocalCentroid { get; set; }
        public decimal UnitBuoyancy_TonnsPerM2 { get; set; }
        public decimal MinimumFreeboard { get; set; }
        public decimal MaximumDraft { get; set; }

        public int FloatSelectionItemId { get; set; }
        public virtual FloatSelectionItem? FloatSelectionItem { get; set; }
    }
    public class LoadData
        {
            public int ItemNumber { get; set; }
            public string LoadName { get; set; }
            public string LoadType { get; set; }
            public decimal LoadValueTonnes { get; set; }
            public decimal LocationX { get; set; }
            public decimal LocationY { get; set; }
            public decimal LocationZ { get; set; }
            public decimal AreaX { get; set; }
            public decimal AreaY { get; set; }
            public int DragCoefficients { get; set; }
        }
}

      
    
          


        



        

