CREATE TABLE [dbo].[Department] (
    [DepartmentID] INT          IDENTITY (1, 1) NOT NULL,
    [Department]   VARCHAR (50) NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([DepartmentID] ASC)
);

