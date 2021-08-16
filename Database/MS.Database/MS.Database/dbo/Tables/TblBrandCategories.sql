CREATE TABLE [dbo].[TblBrandCategories]
(
	[BrandId] INT NOT NULL , 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [PK_TblBrandCategories] PRIMARY KEY ([BrandId], [CategoryId]), 
    CONSTRAINT [FK_TblBrandCategories_ToTblBrand] FOREIGN KEY ([BrandId]) REFERENCES [TblBrand]([IdBrand]), 
    CONSTRAINT [FK_TblBrandCategories_ToTblCategory] FOREIGN KEY ([CategoryId]) REFERENCES [TblCategory]([IdCategory]) 
)
