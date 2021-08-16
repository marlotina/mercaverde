CREATE TABLE [dbo].[TblCity] (
    [IdCity]    INT NOT NULL IDENTITY,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [Url]       NVARCHAR (MAX) NOT NULL,
    [Published] BIT            NOT NULL,
    [Latitude]  NVARCHAR(50)   NULL,
    [Longitude] NVARCHAR(50)   NULL,
    [Zoom]      INT            NOT NULL,
    [CountryId] INT            NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([IdCity] ASC), 
    CONSTRAINT [FK_TblCity_TblCountry] FOREIGN KEY ([CountryId]) REFERENCES [TblCountry]([IdCountry])
);

