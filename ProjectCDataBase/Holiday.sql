CREATE TABLE [dbo].[Holiday]
(
	[HolidayReference] INT NOT NULL PRIMARY KEY, 
    [HotelName] VARCHAR(50) NULL, 
    [City] NCHAR(10) NULL, 
    [Continent] NCHAR(10) NULL, 
    [Country] NCHAR(10) NULL, 
    [Category] NCHAR(10) NULL, 
    [StarRating] INT NULL, 
    [TempRating] NCHAR(10) NULL, 
    [Location] NCHAR(10) NULL, 
    [PricePerNight] DECIMAL NULL
)
