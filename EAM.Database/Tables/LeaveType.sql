CREATE TABLE [dbo].[LeaveType] (
    [TypeID]       INT           IDENTITY (1, 1) NOT NULL,
    [Type]         VARCHAR (50)  NULL,
    [Description]  VARCHAR (500) NULL,
    [CreatedDate]  DATE          NULL,
    [ModifiedDate] DATE          NULL,
    CONSTRAINT [PK_LeaveType] PRIMARY KEY CLUSTERED ([TypeID] ASC)
);

