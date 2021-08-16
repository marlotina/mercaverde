CREATE TABLE [dbo].[TblCategoryLanguage]
(
	[CategoryId] INT NOT NULL , 
    [LanguageId] INT NOT NULL, 
    [Name] NVARCHAR(150) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    PRIMARY KEY ([LanguageId], [CategoryId]), 
    CONSTRAINT [FK_TblCategoryLanguage_ToTblCategory] FOREIGN KEY ([CategoryId]) REFERENCES [TblCategory]([IdCategory]), 
    CONSTRAINT [FK_TblCategoryLanguage_ToTblLanguage] FOREIGN KEY ([LanguageId]) REFERENCES [TblLanguage]([IdLanguage])
)
