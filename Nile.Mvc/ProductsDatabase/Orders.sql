CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT NOT NULL, 
    [OrderDate] DATETIME NOT NULL DEFAULT getdate(), 
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY (CustomerId) REFERENCES [Customers]
)
