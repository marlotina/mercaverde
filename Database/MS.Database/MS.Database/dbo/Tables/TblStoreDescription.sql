CREATE TABLE [dbo].[TblStoreDescription]
(
	[StoreId] INT NOT NULL , 
    [LanguageId] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Title] NVARCHAR(150) NULL, 
    [ShortDescription] NVARCHAR(300) NULL, 
    PRIMARY KEY ([LanguageId], [StoreId]), 
    CONSTRAINT [FK_TblStoreDescription_ToTblStore] FOREIGN KEY ([StoreId]) REFERENCES [TblStore]([IdStore]), 
    CONSTRAINT [FK_TblStoreDescription_ToLanguage] FOREIGN KEY ([LanguageId]) REFERENCES [TblLanguage]([IdLanguage])
)
