CREATE TABLE [dbo].[TblCountry]
(
	[IdCountry] INT		    IDENTITY(1,1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [Url]       NVARCHAR (MAX) NOT NULL,
    [Published] BIT            NOT NULL,
    [Latitude]  DECIMAL (18)   NOT NULL,
    [Longitude] DECIMAL (18)   NOT NULL,
    [Zoom]      INT            NOT NULL, 
    CONSTRAINT [PK_TblCountry] PRIMARY KEY ([IdCountry])
)
