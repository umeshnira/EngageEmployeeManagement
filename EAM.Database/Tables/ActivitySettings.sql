CREATE TABLE [dbo].[ActivitySettings] (
    [ActivitySettingsID] INT IDENTITY (1, 1) NOT NULL,
    [NeedImageCapture]   BIT NULL,
    [TimeInterval]       INT NULL,
    [ImageCaptureSize]   INT NULL,
    CONSTRAINT [PK_ActivitySettings] PRIMARY KEY CLUSTERED ([ActivitySettingsID] ASC)
);

