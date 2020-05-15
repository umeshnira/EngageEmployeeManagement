CREATE TABLE [dbo].[Permission] (
    [PermissionID] VARCHAR (100)  NOT NULL,
    [Description]  NVARCHAR (500) NULL,
    [GroupID]      VARCHAR (100)  NULL,
    CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED ([PermissionID] ASC)
);



