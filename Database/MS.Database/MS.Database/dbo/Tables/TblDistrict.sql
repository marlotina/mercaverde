CREATE TABLE [dbo].[TblDistrict]
(
	[IdDistrict] INT		    IDENTITY(1,1) NOT NULL, 
    [Name]      NVARCHAR (MAX) NOT NULL,
    [Url]       NVARCHAR (MAX) NULL,
    [Published] BIT            NOT NULL,
    [Latitude]  DECIMAL (18)   NULL,
    [Longitude] DECIMAL (18)   NULL,
    [Zoom]      INT            NULL,
    [CityId] INT            NOT NULL, 
    CONSTRAINT [FK_TblDistrict_ToTblCity] FOREIGN KEY ([CityId]) REFERENCES [TblCity]([IdCity]), 
    CONSTRAINT [PK_TblDistrict] PRIMARY KEY ([IdDistrict]),
)
