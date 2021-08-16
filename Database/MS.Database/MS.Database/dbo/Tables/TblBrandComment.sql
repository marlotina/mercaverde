CREATE TABLE [dbo].[TblBrandComment]
(
	[IdBrandComment] INT		    IDENTITY(1,1) NOT NULL,
    [Text] NVARCHAR(500) NOT NULL, 
    [UserId] INT NOT NULL, 
    [CreationDate] DATETIME NOT NULL, 
    [ModificationDate] DATETIME NULL, 
    [Title] NVARCHAR(100) NULL, 
    [BrandId] INT NOT NULL, 
    [LanguageId] INT NOT NULL, 
    CONSTRAINT [FK_TblBrandComment_ToTblUser] FOREIGN KEY ([UserId]) REFERENCES [TblUser]([IdUser]), 
	CONSTRAINT [FK_TblBrandComment_ToTblBrand] FOREIGN KEY ([BrandId]) REFERENCES [TblBrand]([IdBrand]), 
    CONSTRAINT [PK_TblBrandComment] PRIMARY KEY ([IdBrandComment]), 
    CONSTRAINT [FK_TblBrandComment_ToTblLanguage] FOREIGN KEY ([LanguageId]) REFERENCES [TblLanguage]([IdLanguage])
)
