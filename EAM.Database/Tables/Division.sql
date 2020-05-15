CREATE TABLE [dbo].[Division] (
    [DivisionID] INT          IDENTITY (1, 1) NOT NULL,
    [Division]   VARCHAR (50) NULL,
    CONSTRAINT [PK_Division] PRIMARY KEY CLUSTERED ([DivisionID] ASC)
);

