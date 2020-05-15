CREATE TABLE [dbo].[Attendance] (
    [AttendanceID]       INT           IDENTITY (1, 1) NOT NULL,
    [AttendanceTypeID]   INT           NULL,
    [AttendanceStatusID] INT           NULL,
    [HoursPresent]       INT           NULL,
    [Date]               DATE          NULL,
    [Remark]             VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED ([AttendanceID] ASC),
    CONSTRAINT [FK_Attendance_AttendanceStatus] FOREIGN KEY ([AttendanceStatusID]) REFERENCES [dbo].[AttendanceStatus] ([AttendanceStatusID]),
    CONSTRAINT [FK_Attendance_AttendanceType] FOREIGN KEY ([AttendanceTypeID]) REFERENCES [dbo].[AttendanceType] ([AttendanceTypeID])
);

