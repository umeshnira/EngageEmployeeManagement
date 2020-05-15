CREATE TABLE [dbo].[RolePermission] (
    [RoleID]       VARCHAR (50)  NOT NULL,
    [PermissionID] VARCHAR (100) NOT NULL,
    [ReadFlag]     BIT           CONSTRAINT [DF_Table_1_Read] DEFAULT ((0)) NOT NULL,
    [WriteFlag]    BIT           CONSTRAINT [DF_RolePermission_WriteFlag] DEFAULT ((0)) NOT NULL,
    [ExecuteFlag]  BIT           CONSTRAINT [DF_RolePermission_ExecuteFlag] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED ([RoleID] ASC, [PermissionID] ASC)
);

