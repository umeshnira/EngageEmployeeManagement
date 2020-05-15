CREATE TABLE [dbo].[NotificationSent] (
    [NotificationSentID] BIGINT   NOT NULL,
    [NotificationID]     BIGINT   NOT NULL,
    [SentTo]             INT      NOT NULL,
    [ViewDate]           DATETIME NULL,
    [Status]             INT      NOT NULL,
    [Deleted]            BIT      DEFAULT ((0)) NOT NULL
);

