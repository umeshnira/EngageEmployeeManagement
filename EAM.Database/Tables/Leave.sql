CREATE TABLE [dbo].[Leave] (
    [LeaveID]          INT            NOT NULL,
    [EmployeeID]       INT            NULL,
    [LeaveTypeID]      INT            NULL,
    [Reason]           VARCHAR (5000) NULL,
    [StartDate]        DATE           NULL,
    [EndDate]          DATE           NULL,
    [LeaveStatusID]    INT            NULL,
    [DayType]          VARCHAR (50)   NULL,
    [Team]             VARCHAR (50)   NULL,
    [Peer]             INT            NULL,
    [ReportingManager] INT            NULL,
    [ContactNumber]    VARCHAR (50)   NULL,
    [Attachment]       IMAGE          NULL,
    CONSTRAINT [PK_Leave] PRIMARY KEY CLUSTERED ([LeaveID] ASC),
    CONSTRAINT [FK_Leave_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [FK_Leave_LeaveStatus] FOREIGN KEY ([LeaveStatusID]) REFERENCES [dbo].[LeaveStatus] ([LeaveStatusID]),
    CONSTRAINT [FK_Leave_LeaveType] FOREIGN KEY ([LeaveTypeID]) REFERENCES [dbo].[LeaveType] ([TypeID])
);

