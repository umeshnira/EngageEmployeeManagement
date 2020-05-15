CREATE TABLE [dbo].[PermissionGroup] (
    [GroupID]     VARCHAR (50)   NOT NULL,
    [Description] NVARCHAR (255) NULL,
    CONSTRAINT [PK_PermissionGroup] PRIMARY KEY CLUSTERED ([GroupID] ASC)
);

