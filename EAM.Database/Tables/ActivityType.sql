CREATE TABLE [dbo].[ActivityType] (
    [ActivityTypeID] INT           IDENTITY (1, 1) NOT NULL,
    [ActivityType]   VARCHAR (50)  NULL,
    [Description]    VARCHAR (MAX) NULL,
    [CreatedDate]    DATE          NULL,
    [ModifiedDate]   DATE          NULL,
    CONSTRAINT [PK_ActivityType] PRIMARY KEY CLUSTERED ([ActivityTypeID] ASC)
);

