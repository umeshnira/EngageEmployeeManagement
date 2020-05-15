CREATE TABLE [dbo].[LeaveStatus] (
    [LeaveStatusID] INT           IDENTITY (1, 1) NOT NULL,
    [LeaveStatus]   VARCHAR (50)  NULL,
    [Description]   VARCHAR (MAX) NULL,
    [CreatedDate]   DATE          NULL,
    [ModifiedDate]  DATE          NULL,
    CONSTRAINT [PK_LeaveStatus] PRIMARY KEY CLUSTERED ([LeaveStatusID] ASC)
);

