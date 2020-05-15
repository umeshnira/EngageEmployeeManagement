CREATE TABLE [dbo].[Employee] (
    [EmployeeID]    INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]     VARCHAR (100) NULL,
    [LastName]      VARCHAR (100) NULL,
    [EmailID]       VARCHAR (50)  NULL,
    [Phone]         VARCHAR (50)  NULL,
    [DateOfJoining] DATE          NULL,
    [Division]      INT           NULL,
    [Department]    INT           NULL,
    [Designation]   INT           NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    CONSTRAINT [FK_Employee_Department] FOREIGN KEY ([Department]) REFERENCES [dbo].[Department] ([DepartmentID]),
    CONSTRAINT [FK_Employee_Designation] FOREIGN KEY ([Designation]) REFERENCES [dbo].[Designation] ([DesignationID]),
    CONSTRAINT [FK_Employee_Division] FOREIGN KEY ([Division]) REFERENCES [dbo].[Division] ([DivisionID])
);

