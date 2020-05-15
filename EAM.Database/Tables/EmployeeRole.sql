CREATE TABLE [dbo].[EmployeeRole] (
    [EmployeeID] INT          NOT NULL,
    [RoleID]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_EmployeeRole] PRIMARY KEY CLUSTERED ([EmployeeID] ASC, [RoleID] ASC)
);

