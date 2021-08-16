CREATE TABLE [dbo].[TblStore] (
    [IdStore]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [Email]        NVARCHAR (MAX) NULL,
    [Phone]        NVARCHAR (50) NULL,
    [PrefixPhone]  NVARCHAR (10) NULL,
    [CreationDate] DATETIME       NOT NULL,
	[UrlWebSite]       NVARCHAR (250) NULL,
    [Validate]     BIT            NULL,
    [LastActivity] DATETIME       NOT NULL,
    [Street]       NVARCHAR (250) NOT NULL,
    [PostalCode]   NVARCHAR (150) NOT NULL,
    [Number]       NVARCHAR (10) NOT NULL,
    [CityId]   INT            NULL,
    [DistrictId] INT NULL, 
    [TimeTable] NVARCHAR(150) NULL, 
    [UserId] INT NOT NULL, 
    [Latitude] NVARCHAR(50) NULL  , 
    [Longitude] NVARCHAR(50) NULL  , 
    [IsPublished] BIT NULL, 
    [Neighborhood] NVARCHAR(150) NULL, 
    [StreetComplete] NVARCHAR(250) NULL, 
    [MobilePhone] NVARCHAR(150) NULL, 
    [Deleted] BIT NULL, 
    [IsRevised] BIT NULL, 
    [PublishDate] DATETIME NULL, 
    [RevisedDate] DATETIME NULL, 
    [OnlineShopUrl] NVARCHAR(50) NULL, 
    [IsOnlineShop] BIT NULL, 
    [Delivery] BIT NULL, 
    CONSTRAINT [PK_Locals] PRIMARY KEY CLUSTERED ([IdStore] ASC),
    CONSTRAINT [FK_TblStore_ToTblCity] FOREIGN KEY ([CityId]) REFERENCES [dbo].[TblCity] ([IdCity]), 
    CONSTRAINT [FK_TblStore_ToTblDistrict] FOREIGN KEY ([DistrictId]) REFERENCES [TblDistrict]([IdDistrict]),
	CONSTRAINT [FK_TblStore_ToTbUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[TblUser] ([IdUser])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_LocalCity]
    ON [dbo].[TblStore]([CityId] ASC);
