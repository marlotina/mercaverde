CREATE TABLE [dbo].[TblBrandImage]
(
	[IdBrandImage] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BrandId] INT NOT NULL, 
    [Url] NVARCHAR(50) NOT NULL, 
    [Name] NVARCHAR(20) NOT NULL, 
    [Order] INT NOT NULL, 
    CONSTRAINT [FK_TblBrandImage_ToTblBrand] FOREIGN KEY ([BrandId]) REFERENCES [TblBrand]([IdBrand])
)
