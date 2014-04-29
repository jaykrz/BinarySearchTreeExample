CREATE TABLE [dbo].[Tree](
	[Id] [uniqueidentifier] NOT NULL,
	[Version] [int] NOT NULL,
	[Root_Id] [uniqueidentifier] NULL,
    CONSTRAINT [PK_dbo.Tree] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Tree_dbo.Node_Root_Id] FOREIGN KEY ([Root_Id]) REFERENCES [dbo].[Node] ([Id])
);
GO

CREATE NONCLUSTERED INDEX [IX_Root_Id]
    ON [dbo].[Tree]([Root_Id] ASC);
GO
