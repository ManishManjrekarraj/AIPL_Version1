CREATE TABLE [dbo].[ChainConstants] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [ChainGrade] NVARCHAR (50)  NOT NULL,
    [Notation]   NVARCHAR (MAX) NOT NULL,
    [ConstantK]  FLOAT (53)     NOT NULL,
    [Diameter]   FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_ChainConstants] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ChainConstants_ChainGrade]
    ON [dbo].[ChainConstants]([ChainGrade] ASC);

