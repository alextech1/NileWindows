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

DELETE FROM Products
INSERT INTO Products (Name, UnitPrice, Discontinued) VALUES
('Product A', 15.25, 0),
('Product B', 45, 0),
('Product C', 85.50, 1),
('Product D', 150, 1),
('Product E', 50.75, 0)

DELETE FROM Customers
INSERT INTO Customers (FirstName, LastName) VALUES
('Peter', 'Parker'),
('Sue', 'Storm'),
('Tony', 'Stark'),
('Natasha', 'Romanova')

GO
