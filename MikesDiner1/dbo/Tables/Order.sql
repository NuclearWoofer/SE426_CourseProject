CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderName] NVARCHAR(50) NOT NULL, 
    [OrderDate] DATETIME2 NOT NULL, 
    [FoodId] NCHAR(10) NOT NULL, 
    [Total] FLOAT NOT NULL, 
    [Quantity] INT NOT NULL
)
