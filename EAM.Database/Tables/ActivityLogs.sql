CREATE TABLE [dbo].[ActivityLogs] (
    [ActivityLogID]  INT             IDENTITY (1, 1) NOT NULL,
    [EmployeeID]     INT             NULL,
    [InTime]         TIME (7)        NULL,
    [OutTime]        TIME (7)        NULL,
    [ActivityTypeID] INT             NULL,
    [Latitude]       DECIMAL (10, 8) NULL,
    [Logitude]       DECIMAL (11, 8) NULL,
    [Location]       VARCHAR (100)   NULL,
    [Image]          IMAGE           NULL,
    [CreatedDate]    DATE            NULL,
    [ModifiedDate]   DATE            NULL,
    CONSTRAINT [PK_ActivityLogs] PRIMARY KEY CLUSTERED ([ActivityLogID] ASC),
    CONSTRAINT [FK_ActivityLogs_ActivityType] FOREIGN KEY ([ActivityTypeID]) REFERENCES [dbo].[ActivityType] ([ActivityTypeID]),
    CONSTRAINT [FK_ActivityLogs_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])
);

