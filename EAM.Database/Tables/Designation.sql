CREATE TABLE [dbo].[Designation] (
    [DesignationID] INT          IDENTITY (1, 1) NOT NULL,
    [Designation]   VARCHAR (50) NULL,
    CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED ([DesignationID] ASC)
);

