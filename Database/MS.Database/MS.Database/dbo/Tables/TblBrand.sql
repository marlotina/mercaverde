CREATE TABLE [dbo].[TblBrand]
(
	[IdBrand]      INT		    IDENTITY(1,1) NOT NULL,
	[Name]         NVARCHAR (MAX) NOT NULL,
    [Email]        NVARCHAR (MAX) NOT NULL,
    [Phone]        NVARCHAR (MAX) NOT NULL,
    [PrefixPhone]  NVARCHAR (MAX) NOT NULL,
    [CreationDate] DATETIME       NOT NULL,
    [Published]    BIT            NOT NULL,
    [Validate]     BIT            NOT NULL,
    [LastActivity] DATETIME       NOT NULL,
    [Street]       NVARCHAR (MAX) NULL,
    [PostalCode]   NVARCHAR (MAX) NULL,
    [Number]       NVARCHAR (MAX) NULL,
	[UrlWebSite]       NVARCHAR (250) NULL,
    [CityId]   INT            NULL,
    [DistrictId] INT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_TblBrand_ToTblCity] FOREIGN KEY ([CityId]) REFERENCES [dbo].[TblCity] ([IdCity]), 
    CONSTRAINT [FK_TblBrand_ToTblDistrict] FOREIGN KEY ([DistrictId]) REFERENCES [TblDistrict]([IdDistrict]), 
    CONSTRAINT [PK_TblBrand] PRIMARY KEY ([IdBrand]), 
    CONSTRAINT [FK_TblBrand_ToTblUser] FOREIGN KEY ([UserId]) REFERENCES [Tbluser]([IdUser])
)
