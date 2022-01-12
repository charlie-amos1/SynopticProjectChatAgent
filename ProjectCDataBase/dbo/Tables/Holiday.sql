CREATE TABLE [dbo].[Holiday] (
    [HolidayReference] VARCHAR (16) NOT NULL,
    [HotelName]        VARCHAR (14) NOT NULL,
    [City]             VARCHAR (13) NULL,
    [Continent]        VARCHAR (13) NOT NULL,
    [Country]          VARCHAR (16) NOT NULL,
    [Category]         VARCHAR (8)  NOT NULL,
    [StarRating]       INT          NULL,
    [TempRating]       VARCHAR (10) NOT NULL,
    [Location]         VARCHAR (8)  NOT NULL,
    [PricePerNight]    VARCHAR (16) NOT NULL,
    PRIMARY KEY CLUSTERED ([HolidayReference] ASC)
);

