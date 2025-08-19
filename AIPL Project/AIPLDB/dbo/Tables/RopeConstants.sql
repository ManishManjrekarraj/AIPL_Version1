CREATE TABLE [dbo].[RopeConstants] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [RopeType]         NVARCHAR (MAX)  NOT NULL,
    [TensileStrength]  DECIMAL (18, 2) NULL,
    [KValue]           DECIMAL (18, 2) NOT NULL,
    [RequiredDiameter] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_RopeConstants] PRIMARY KEY CLUSTERED ([Id] ASC)
);

