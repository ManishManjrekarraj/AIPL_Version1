CREATE TABLE [dbo].[Users] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [UserName]       NVARCHAR (MAX) NOT NULL,
    [SubscriptionId] INT            NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Subscriptions_SubscriptionId] FOREIGN KEY ([SubscriptionId]) REFERENCES [dbo].[Subscriptions] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_SubscriptionId]
    ON [dbo].[Users]([SubscriptionId] ASC);

