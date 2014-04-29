CREATE TABLE [dbo].[EventLog] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [AggregateName] NVARCHAR (MAX)   NULL,
    [AggregateId]   UNIQUEIDENTIFIER NOT NULL,
    [Date]          DATETIME         NOT NULL,
    [EventName]     NVARCHAR (MAX)   NULL,
    [Data]          NVARCHAR (MAX)   NULL,
    [Version]       INT              NOT NULL,
    CONSTRAINT [PK_dbo.EventLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
