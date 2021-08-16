CREATE TABLE [dbo].[TblCityLanguage]
(
	[CityId] INT NOT NULL , 
    [LanguageId] INT NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    PRIMARY KEY ([LanguageId], [CityId]), 
    CONSTRAINT [FK_TblCityLanguage_ToTblCity] FOREIGN KEY ([CityId]) REFERENCES [TblCity]([IdCity]), 
    CONSTRAINT [FK_TblCityLanguage_TblLanguage] FOREIGN KEY ([LanguageId]) REFERENCES [TblLanguage]([IdLanguage])
)
