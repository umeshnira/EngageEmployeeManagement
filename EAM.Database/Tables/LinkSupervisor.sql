CREATE TABLE [dbo].[LinkSupervisor] (
    [SuperisorID] INT IDENTITY (1, 1) NOT NULL,
    [EmployeeID]  INT NULL,
    [LeaveID]     INT NULL,
    CONSTRAINT [PK_LinkSupervisor] PRIMARY KEY CLUSTERED ([SuperisorID] ASC)
);

