CREATE TABLE [dbo].[LineItems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [FK_LineItems_Orders] FOREIGN KEY (OrderId) REFERENCES Orders(Id), 
    CONSTRAINT [FK_LineItems_Products] FOREIGN KEY (ProductId) REFERENCES Products(Id), 
    CONSTRAINT [CK_LineItems_Quantity] CHECK (Quantity > 0)
)
