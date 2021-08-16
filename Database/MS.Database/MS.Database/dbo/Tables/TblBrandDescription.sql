CREATE TABLE [dbo].[TblBrandDescription]
(
	[BrandId] INT NOT NULL , 
    [LanguageId] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Title] NVARCHAR(150) NULL, 
    PRIMARY KEY ([LanguageId], [BrandId]), 
    CONSTRAINT [FK_TblBrandDescription_ToTblbrand] FOREIGN KEY ([BrandId]) REFERENCES [TblBrand]([IdBrand]), 
    CONSTRAINT [FK_TblBrandBDescription_ToLanguage] FOREIGN KEY ([LanguageId]) REFERENCES [TblLanguage]([IdLanguage])
)
