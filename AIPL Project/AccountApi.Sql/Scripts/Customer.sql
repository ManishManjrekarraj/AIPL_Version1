USE [AccountDB]
GO

/****** Object:  Table [dbo].[Customer] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName]    NVARCHAR (MAX)   NULL,
    [MiddleName]   NVARCHAR (MAX)   NULL,
    [NickName]     NVARCHAR (MAX)   NULL,
    [LastName]     NVARCHAR (MAX)   NULL,
    [Mobile]       NVARCHAR (50)    NULL,
    [ReferredBy]   NVARCHAR (MAX)   NULL,
    [CreatedBy]    NVARCHAR (500)   NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_Customer_modifiedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedDate]  DATETIME         CONSTRAINT [DF_Customer_modifiedDate1] DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]   NVARCHAR (500)   NULL,
    [Url]          NVARCHAR (500)   NULL,
    [IsActive]     BIT              CONSTRAINT [DF_Customer_IsActive] DEFAULT ((1)) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO