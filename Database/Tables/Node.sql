CREATE TABLE [dbo].[Node](
	[Id] [uniqueidentifier] NOT NULL,
	[Value] [int] NOT NULL,
	[Parent_Id] [uniqueidentifier] NULL,
	[LeftChild_Id] [uniqueidentifier] NULL,
	[RightChild_Id] [uniqueidentifier] NULL,
    CONSTRAINT [PK_dbo.Node] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Node_dbo.Node_LeftChild_Id] FOREIGN KEY ([LeftChild_Id]) REFERENCES [dbo].[Node] ([Id]),
    CONSTRAINT [FK_dbo.Node_dbo.Node_Parent_Id] FOREIGN KEY ([Parent_Id]) REFERENCES [dbo].[Node] ([Id]),
    CONSTRAINT [FK_dbo.Node_dbo.Node_RightChild_Id] FOREIGN KEY ([RightChild_Id]) REFERENCES [dbo].[Node] ([Id])
);
GO

CREATE NONCLUSTERED INDEX [IX_LeftChild_Id]
    ON [dbo].[Node]([LeftChild_Id] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Parent_Id]
    ON [dbo].[Node]([Parent_Id] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_RightChild_Id]
    ON [dbo].[Node]([RightChild_Id] ASC);
GO

