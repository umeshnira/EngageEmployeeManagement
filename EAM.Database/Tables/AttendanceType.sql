CREATE TABLE [dbo].[AttendanceType] (
    [AttendanceTypeID] INT           IDENTITY (1, 1) NOT NULL,
    [AttendanceType]   VARCHAR (50)  NULL,
    [Description]      VARCHAR (MAX) NULL,
    [CreatedDate]      DATE          NULL,
    [ModifiedDate]     DATE          NULL,
    CONSTRAINT [PK_AttendanceType] PRIMARY KEY CLUSTERED ([AttendanceTypeID] ASC)
);

