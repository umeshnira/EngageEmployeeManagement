/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET IDENTITY_INSERT Empolyee ON
GO
INSERT INTO Employee (EmployeeID, FirstName, LastName, EmailID)
VALUES (1, 'Admin', '', 'kurianpridcey@nirasystems.com');
GO
SET IDENTITY_INSERT Employee OFF
GO
INSERT INTO Login (EmployeeID, [Password]) VALUES (1, NULL);
GO