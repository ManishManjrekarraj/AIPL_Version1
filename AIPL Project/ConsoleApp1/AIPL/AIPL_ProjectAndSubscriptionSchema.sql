USE [AIPLCOPY]
GO
/****** Object:  Table [dbo].[ChainConstants]    Script Date: 21-06-2025 18:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChainConstants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChainGrade] [nvarchar](50) NOT NULL,
	[Notation] [nvarchar](max) NOT NULL,
	[ConstantK] [float] NOT NULL,
	[Diameter] [float] NOT NULL,
 CONSTRAINT [PK_ChainConstants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FloatSelectionItems]    Script Date: 21-06-2025 18:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FloatSelectionItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_FloatSelectionItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoadDatas]    Script Date: 21-06-2025 18:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoadDatas](
	[ItemNumber] [int] IDENTITY(1,1) NOT NULL,
	[LoadName] [nvarchar](100) NOT NULL,
	[LoadType] [nvarchar](50) NOT NULL,
	[LoadValueTonnes] [float] NOT NULL,
	[LocationX] [decimal](18, 2) NOT NULL,
	[LocationY] [decimal](18, 2) NOT NULL,
	[LocationZ] [decimal](18, 2) NOT NULL,
	[AreaX] [decimal](18, 2) NOT NULL,
	[AreaY] [decimal](18, 2) NOT NULL,
	[DragCoefficients] [int] NOT NULL,
 CONSTRAINT [PK_LoadDatas] PRIMARY KEY CLUSTERED 
(
	[ItemNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parameters]    Script Date: 21-06-2025 18:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parameters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Length_x] [decimal](18, 2) NOT NULL,
	[Width_y] [decimal](18, 2) NOT NULL,
	[Height_z] [decimal](18, 2) NOT NULL,
	[Weight_Tonns] [decimal](18, 2) NOT NULL,
	[COG_x] [decimal](18, 2) NOT NULL,
	[COG_y] [decimal](18, 2) NOT NULL,
	[COG_z] [decimal](18, 2) NOT NULL,
	[Area] [decimal](18, 2) NOT NULL,
	[MOI_x_LocalCentroid] [decimal](18, 2) NOT NULL,
	[MOI_y_LocalCentroid] [decimal](18, 2) NOT NULL,
	[MOI_z_LocalCentroid] [decimal](18, 2) NOT NULL,
	[UnitBuoyancy_TonnsPerM2] [decimal](18, 2) NOT NULL,
	[MinimumFreeboard] [decimal](18, 2) NOT NULL,
	[MaximumDraft] [decimal](18, 2) NOT NULL,
	[FloatSelectionItemId] [int] NOT NULL,
 CONSTRAINT [PK_Parameters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 21-06-2025 18:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](max) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[ClientName] [nvarchar](max) NOT NULL,
	[MoblieNumber] [nvarchar](max) NOT NULL,
	[EmailID] [nvarchar](max) NOT NULL,
	[Domain] [nvarchar](max) NOT NULL,
	[ProjectDescription] [nvarchar](max) NOT NULL,
	[AttachFile] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
	[SubscriptionId] [int] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RopeConstants]    Script Date: 21-06-2025 18:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RopeConstants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RopeType] [nvarchar](max) NOT NULL,
	[TensileStrength] [decimal](18, 2) NULL,
	[KValue] [decimal](18, 2) NOT NULL,
	[RequiredDiameter] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_RopeConstants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscriptions]    Script Date: 21-06-2025 18:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscriptions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Subscriptions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21-06-2025 18:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[SubscriptionId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChainConstants] ON 
GO
INSERT [dbo].[ChainConstants] ([Id], [ChainGrade], [Notation], [ConstantK], [Diameter]) VALUES (1, N'Chain Grade 1', N'R3', 0.0196, 169.8071307)
GO
INSERT [dbo].[ChainConstants] ([Id], [ChainGrade], [Notation], [ConstantK], [Diameter]) VALUES (2, N'Chain Grade 2', N'R3S', 0.0223, 159.1957714)
GO
INSERT [dbo].[ChainConstants] ([Id], [ChainGrade], [Notation], [ConstantK], [Diameter]) VALUES (3, N'Chain Grade 3', N'R4', 0.0248, 150.9586902)
GO
INSERT [dbo].[ChainConstants] ([Id], [ChainGrade], [Notation], [ConstantK], [Diameter]) VALUES (4, N'Chain Grade 4', N'R4S', 0.0272, 144.144975)
GO
INSERT [dbo].[ChainConstants] ([Id], [ChainGrade], [Notation], [ConstantK], [Diameter]) VALUES (5, N'Chain Grade 5', N'R5', 0.03, 137.2534697)
GO
SET IDENTITY_INSERT [dbo].[ChainConstants] OFF
GO
SET IDENTITY_INSERT [dbo].[FloatSelectionItems] ON 
GO
INSERT [dbo].[FloatSelectionItems] ([Id], [Name]) VALUES (1, N'MODULAR_BARGE')
GO
SET IDENTITY_INSERT [dbo].[FloatSelectionItems] OFF
GO
SET IDENTITY_INSERT [dbo].[LoadDatas] ON 
GO
INSERT [dbo].[LoadDatas] ([ItemNumber], [LoadName], [LoadType], [LoadValueTonnes], [LocationX], [LocationY], [LocationZ], [AreaX], [AreaY], [DragCoefficients]) VALUES (1, N'winch', N'DL', 0.1, CAST(3.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[LoadDatas] ([ItemNumber], [LoadName], [LoadType], [LoadValueTonnes], [LocationX], [LocationY], [LocationZ], [AreaX], [AreaY], [DragCoefficients]) VALUES (2, N'Pump', N'IL', 1, CAST(3.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 2)
GO
INSERT [dbo].[LoadDatas] ([ItemNumber], [LoadName], [LoadType], [LoadValueTonnes], [LocationX], [LocationY], [LocationZ], [AreaX], [AreaY], [DragCoefficients]) VALUES (3, N'Passengers', N'LL', 0.4, CAST(6.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 3)
GO
INSERT [dbo].[LoadDatas] ([ItemNumber], [LoadName], [LoadType], [LoadValueTonnes], [LocationX], [LocationY], [LocationZ], [AreaX], [AreaY], [DragCoefficients]) VALUES (4, N'winch', N'DL', 0.8, CAST(3.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 4)
GO
INSERT [dbo].[LoadDatas] ([ItemNumber], [LoadName], [LoadType], [LoadValueTonnes], [LocationX], [LocationY], [LocationZ], [AreaX], [AreaY], [DragCoefficients]) VALUES (5, N'Pump', N'IL', 0.95, CAST(3.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 5)
GO
INSERT [dbo].[LoadDatas] ([ItemNumber], [LoadName], [LoadType], [LoadValueTonnes], [LocationX], [LocationY], [LocationZ], [AreaX], [AreaY], [DragCoefficients]) VALUES (6, N'Passengers', N'LL', 1.1, CAST(6.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 6)
GO
INSERT [dbo].[LoadDatas] ([ItemNumber], [LoadName], [LoadType], [LoadValueTonnes], [LocationX], [LocationY], [LocationZ], [AreaX], [AreaY], [DragCoefficients]) VALUES (7, N'winch', N'DL', 1.25, CAST(3.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 7)
GO
INSERT [dbo].[LoadDatas] ([ItemNumber], [LoadName], [LoadType], [LoadValueTonnes], [LocationX], [LocationY], [LocationZ], [AreaX], [AreaY], [DragCoefficients]) VALUES (8, N'Pump', N'IL', 1.4, CAST(3.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 8)
GO
INSERT [dbo].[LoadDatas] ([ItemNumber], [LoadName], [LoadType], [LoadValueTonnes], [LocationX], [LocationY], [LocationZ], [AreaX], [AreaY], [DragCoefficients]) VALUES (9, N'Passengers', N'DL', 1.55, CAST(6.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 9)
GO
INSERT [dbo].[LoadDatas] ([ItemNumber], [LoadName], [LoadType], [LoadValueTonnes], [LocationX], [LocationY], [LocationZ], [AreaX], [AreaY], [DragCoefficients]) VALUES (10, N'winch', N'IL', 1.7, CAST(3.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 10)
GO
INSERT [dbo].[LoadDatas] ([ItemNumber], [LoadName], [LoadType], [LoadValueTonnes], [LocationX], [LocationY], [LocationZ], [AreaX], [AreaY], [DragCoefficients]) VALUES (11, N'Pump', N'LL', 1.85, CAST(3.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 11)
GO
INSERT [dbo].[LoadDatas] ([ItemNumber], [LoadName], [LoadType], [LoadValueTonnes], [LocationX], [LocationY], [LocationZ], [AreaX], [AreaY], [DragCoefficients]) VALUES (12, N'Passengers', N'DL', 2, CAST(6.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 12)
GO
SET IDENTITY_INSERT [dbo].[LoadDatas] OFF
GO
SET IDENTITY_INSERT [dbo].[Parameters] ON 
GO
INSERT [dbo].[Parameters] ([Id], [Name], [Length_x], [Width_y], [Height_z], [Weight_Tonns], [COG_x], [COG_y], [COG_z], [Area], [MOI_x_LocalCentroid], [MOI_y_LocalCentroid], [MOI_z_LocalCentroid], [UnitBuoyancy_TonnsPerM2], [MinimumFreeboard], [MaximumDraft], [FloatSelectionItemId]) VALUES (1, N'MB_3x3x1.2', CAST(3.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(1.80 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), CAST(0.60 AS Decimal(18, 2)), CAST(9.00 AS Decimal(18, 2)), CAST(6.75 AS Decimal(18, 2)), CAST(6.75 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(0.40 AS Decimal(18, 2)), CAST(0.80 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Parameters] ([Id], [Name], [Length_x], [Width_y], [Height_z], [Weight_Tonns], [COG_x], [COG_y], [COG_z], [Area], [MOI_x_LocalCentroid], [MOI_y_LocalCentroid], [MOI_z_LocalCentroid], [UnitBuoyancy_TonnsPerM2], [MinimumFreeboard], [MaximumDraft], [FloatSelectionItemId]) VALUES (2, N'MB_6x3x1.2', CAST(6.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(3.60 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), CAST(0.60 AS Decimal(18, 2)), CAST(18.00 AS Decimal(18, 2)), CAST(13.50 AS Decimal(18, 2)), CAST(54.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(0.40 AS Decimal(18, 2)), CAST(0.80 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Parameters] ([Id], [Name], [Length_x], [Width_y], [Height_z], [Weight_Tonns], [COG_x], [COG_y], [COG_z], [Area], [MOI_x_LocalCentroid], [MOI_y_LocalCentroid], [MOI_z_LocalCentroid], [UnitBuoyancy_TonnsPerM2], [MinimumFreeboard], [MaximumDraft], [FloatSelectionItemId]) VALUES (3, N'MB_9x3x1.2', CAST(9.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(5.40 AS Decimal(18, 2)), CAST(4.50 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), CAST(0.60 AS Decimal(18, 2)), CAST(27.00 AS Decimal(18, 2)), CAST(20.25 AS Decimal(18, 2)), CAST(182.25 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(0.40 AS Decimal(18, 2)), CAST(0.80 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Parameters] ([Id], [Name], [Length_x], [Width_y], [Height_z], [Weight_Tonns], [COG_x], [COG_y], [COG_z], [Area], [MOI_x_LocalCentroid], [MOI_y_LocalCentroid], [MOI_z_LocalCentroid], [UnitBuoyancy_TonnsPerM2], [MinimumFreeboard], [MaximumDraft], [FloatSelectionItemId]) VALUES (4, N'MB_12x3x1.2', CAST(12.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)), CAST(7.20 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), CAST(0.60 AS Decimal(18, 2)), CAST(36.00 AS Decimal(18, 2)), CAST(27.00 AS Decimal(18, 2)), CAST(432.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(0.40 AS Decimal(18, 2)), CAST(0.80 AS Decimal(18, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[Parameters] OFF
GO
SET IDENTITY_INSERT [dbo].[RopeConstants] ON 
GO
INSERT [dbo].[RopeConstants] ([Id], [RopeType], [TensileStrength], [KValue], [RequiredDiameter]) VALUES (1, N'6×7 FC', CAST(1770.00 AS Decimal(18, 2)), CAST(0.35 AS Decimal(18, 2)), CAST(9831.06 AS Decimal(18, 2)))
GO
INSERT [dbo].[RopeConstants] ([Id], [RopeType], [TensileStrength], [KValue], [RequiredDiameter]) VALUES (2, N'6×7 IWRC', NULL, CAST(0.45 AS Decimal(18, 2)), CAST(35.63 AS Decimal(18, 2)))
GO
INSERT [dbo].[RopeConstants] ([Id], [RopeType], [TensileStrength], [KValue], [RequiredDiameter]) VALUES (3, N'6×19 Seale FC', NULL, CAST(0.34 AS Decimal(18, 2)), CAST(41.41 AS Decimal(18, 2)))
GO
INSERT [dbo].[RopeConstants] ([Id], [RopeType], [TensileStrength], [KValue], [RequiredDiameter]) VALUES (4, N'6×19 Seale IWRC', NULL, CAST(0.46 AS Decimal(18, 2)), CAST(35.32 AS Decimal(18, 2)))
GO
INSERT [dbo].[RopeConstants] ([Id], [RopeType], [TensileStrength], [KValue], [RequiredDiameter]) VALUES (5, N'6×36 WS FC', NULL, CAST(0.35 AS Decimal(18, 2)), CAST(41.20 AS Decimal(18, 2)))
GO
INSERT [dbo].[RopeConstants] ([Id], [RopeType], [TensileStrength], [KValue], [RequiredDiameter]) VALUES (6, N'6×36 WS IWRC', NULL, CAST(0.47 AS Decimal(18, 2)), CAST(34.61 AS Decimal(18, 2)))
GO
INSERT [dbo].[RopeConstants] ([Id], [RopeType], [TensileStrength], [KValue], [RequiredDiameter]) VALUES (7, N'8×19 Seale FC', NULL, CAST(0.32 AS Decimal(18, 2)), CAST(42.16 AS Decimal(18, 2)))
GO
INSERT [dbo].[RopeConstants] ([Id], [RopeType], [TensileStrength], [KValue], [RequiredDiameter]) VALUES (8, N'8×19 Seale IWRC', NULL, CAST(0.43 AS Decimal(18, 2)), CAST(36.23 AS Decimal(18, 2)))
GO
INSERT [dbo].[RopeConstants] ([Id], [RopeType], [TensileStrength], [KValue], [RequiredDiameter]) VALUES (9, N'8×36 WS FC', NULL, CAST(0.33 AS Decimal(18, 2)), CAST(41.92 AS Decimal(18, 2)))
GO
INSERT [dbo].[RopeConstants] ([Id], [RopeType], [TensileStrength], [KValue], [RequiredDiameter]) VALUES (10, N'8×36 WS IWRC', NULL, CAST(0.44 AS Decimal(18, 2)), CAST(35.88 AS Decimal(18, 2)))
GO
INSERT [dbo].[RopeConstants] ([Id], [RopeType], [TensileStrength], [KValue], [RequiredDiameter]) VALUES (11, N'35×7 Rotation‑resist IWRC', NULL, CAST(0.46 AS Decimal(18, 2)), CAST(34.90 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[RopeConstants] OFF
GO
ALTER TABLE [dbo].[Parameters]  WITH CHECK ADD  CONSTRAINT [FK_Parameters_FloatSelectionItems_FloatSelectionItemId] FOREIGN KEY([FloatSelectionItemId])
REFERENCES [dbo].[FloatSelectionItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parameters] CHECK CONSTRAINT [FK_Parameters_FloatSelectionItems_FloatSelectionItemId]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Subscriptions_SubscriptionId] FOREIGN KEY([SubscriptionId])
REFERENCES [dbo].[Subscriptions] ([Id])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Subscriptions_SubscriptionId]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Subscriptions_SubscriptionId] FOREIGN KEY([SubscriptionId])
REFERENCES [dbo].[Subscriptions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Subscriptions_SubscriptionId]
GO
