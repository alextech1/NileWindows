CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FIrstName] VARCHAR(100) NOT NULL, 
    [LastName] VARCHAR(100) NOT NULL, 
    CONSTRAINT [AK_Customers_Name] UNIQUE ([FIrstName], [LastName])
)
