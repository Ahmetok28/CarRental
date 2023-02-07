CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[BrandId] INT ,
	[ColorId] INT,
	[CarName] NVARCHAR(20),
	[ModelYear] DATE,
	[DailyPrice] DECIMAL,
	[Description] NVARCHAR(40)

)
