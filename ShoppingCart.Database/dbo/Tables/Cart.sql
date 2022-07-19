CREATE TABLE [dbo].[Cart] (
    [CartId]      INT           IDENTITY (1, 1) NOT NULL,
    [Status]      CHAR (1)      NOT NULL,
    [TimeCreated] DATETIME      NOT NULL,
    [TimeUpdated] DATETIME      NOT NULL,
    [CreatedBy]   VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED ([CartId] ASC)
);

