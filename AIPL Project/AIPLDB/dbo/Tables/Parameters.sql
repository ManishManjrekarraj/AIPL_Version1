CREATE TABLE [dbo].[Parameters] (
    [Id]                      INT             IDENTITY (1, 1) NOT NULL,
    [Name]                    NVARCHAR (MAX)  NOT NULL,
    [Length_x]                DECIMAL (18, 2) NOT NULL,
    [Width_y]                 DECIMAL (18, 2) NOT NULL,
    [Height_z]                DECIMAL (18, 2) NOT NULL,
    [Weight_Tonns]            DECIMAL (18, 2) NOT NULL,
    [COG_x]                   DECIMAL (18, 2) NOT NULL,
    [COG_y]                   DECIMAL (18, 2) NOT NULL,
    [COG_z]                   DECIMAL (18, 2) NOT NULL,
    [Area]                    DECIMAL (18, 2) NOT NULL,
    [MOI_x_LocalCentroid]     DECIMAL (18, 2) NOT NULL,
    [MOI_y_LocalCentroid]     DECIMAL (18, 2) NOT NULL,
    [MOI_z_LocalCentroid]     DECIMAL (18, 2) NOT NULL,
    [UnitBuoyancy_TonnsPerM2] DECIMAL (18, 2) NOT NULL,
    [MinimumFreeboard]        DECIMAL (18, 2) NOT NULL,
    [MaximumDraft]            DECIMAL (18, 2) NOT NULL,
    [FloatSelectionItemId]    INT             NOT NULL,
    CONSTRAINT [PK_Parameters] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Parameters_FloatSelectionItems_FloatSelectionItemId] FOREIGN KEY ([FloatSelectionItemId]) REFERENCES [dbo].[FloatSelectionItems] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Parameters_FloatSelectionItemId]
    ON [dbo].[Parameters]([FloatSelectionItemId] ASC);

