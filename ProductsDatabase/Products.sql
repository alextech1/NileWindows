CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(100) NOT NULL, 
    [Discontinued] BIT NOT NULL DEFAULT 0, 
    [UnitPrice] DECIMAL NOT NULL, 
    CONSTRAINT [AK_Products_Name] UNIQUE ([Name]), 
    CONSTRAINT [CK_Products_UnitPrice] CHECK (UnitPrice > 0) 
)

GO
