CREATE TABLE [dbo].[Login] (
    [EmployeeID]               INT             NOT NULL,
    [Password]                 VARBINARY (500) NULL,
    [ForgotPasswordLink]       VARCHAR (500)   NULL,
    [ForgotPasswordExpireDate] DATETIME        NULL,
    [LoginActive]              BIT             CONSTRAINT [DF_Login_LoginActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);

