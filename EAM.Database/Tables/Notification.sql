CREATE TABLE [dbo].[Notification] (
    [NotificationID] BIGINT          NOT NULL,
    [Title]          NVARCHAR (500)  NULL,
    [Description]    NVARCHAR (1000) NULL,
    [CreatedDate]    DATETIME        NULL,
    [CreatedBy]      INT             NULL,
    [Deleted]        BIT             DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED ([NotificationID] ASC)
);

