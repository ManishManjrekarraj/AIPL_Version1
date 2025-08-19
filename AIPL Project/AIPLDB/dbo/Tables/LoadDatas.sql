CREATE TABLE [dbo].[LoadDatas] (
    [ItemNumber]       INT             IDENTITY (1, 1) NOT NULL,
    [LoadName]         NVARCHAR (100)  NOT NULL,
    [LoadType]         NVARCHAR (50)   NOT NULL,
    [LoadValueTonnes]  FLOAT (53)      NOT NULL,
    [LocationX]        DECIMAL (18, 2) NOT NULL,
    [LocationY]        DECIMAL (18, 2) NOT NULL,
    [LocationZ]        DECIMAL (18, 2) NOT NULL,
    [AreaX]            DECIMAL (18, 2) NOT NULL,
    [AreaY]            DECIMAL (18, 2) NOT NULL,
    [DragCoefficients] INT             NOT NULL,
    CONSTRAINT [PK_LoadDatas] PRIMARY KEY CLUSTERED ([ItemNumber] ASC)
);

