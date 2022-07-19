CREATE TABLE [dbo].[CartItem] (
    [CartItemId]  INT             IDENTITY (1, 1) NOT NULL,
    [CartId]      INT             NOT NULL,
    [Name]        VARCHAR (100)   NOT NULL,
    [Description] VARCHAR (200)   NULL,
    [Amount]      DECIMAL (10, 2) NOT NULL,
    [TimeCreated] DATETIME        NOT NULL,
    [TimeUpdated] DATETIME        NOT NULL,
    [CreatedBy]   VARCHAR (100)   NOT NULL,
    PRIMARY KEY CLUSTERED ([CartItemId] ASC, [CartId] ASC),
    CONSTRAINT [FK_CartItem_Cart] FOREIGN KEY ([CartId]) REFERENCES [dbo].[Cart] ([CartId])
);

