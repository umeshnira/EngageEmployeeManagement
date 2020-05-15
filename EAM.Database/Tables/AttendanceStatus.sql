CREATE TABLE [dbo].[AttendanceStatus] (
    [AttendanceStatusID] INT           IDENTITY (1, 1) NOT NULL,
    [AttendanceStatus]   VARCHAR (50)  NULL,
    [Description]        VARCHAR (MAX) NULL,
    [CreatedDate]        DATE          NULL,
    [ModifiedDate]       DATE          NULL,
    CONSTRAINT [PK_AttendanceStatus] PRIMARY KEY CLUSTERED ([AttendanceStatusID] ASC)
);

