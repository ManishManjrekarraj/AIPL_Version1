CREATE TABLE [dbo].[Projects] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [ProjectName]        NVARCHAR (MAX) NOT NULL,
    [CompanyName]        NVARCHAR (MAX) NOT NULL,
    [ClientName]         NVARCHAR (MAX) NOT NULL,
    [MoblieNumber]       NVARCHAR (MAX) NOT NULL,
    [EmailID]            NVARCHAR (MAX) NOT NULL,
    [Domain]             NVARCHAR (MAX) NOT NULL,
    [ProjectDescription] NVARCHAR (MAX) NOT NULL,
    [AttachFile]         NVARCHAR (MAX) NOT NULL,
    [UserId]             INT            NOT NULL,
    [SubscriptionId]     INT            NOT NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Projects_Subscriptions_SubscriptionId] FOREIGN KEY ([SubscriptionId]) REFERENCES [dbo].[Subscriptions] ([Id]),
    CONSTRAINT [FK_Projects_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Projects_SubscriptionId]
    ON [dbo].[Projects]([SubscriptionId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Projects_UserId]
    ON [dbo].[Projects]([UserId] ASC);

