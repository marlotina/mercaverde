CREATE TABLE [dbo].[TblCountryLanguage]
(
	[CountryId] INT NOT NULL , 
    [LanguageId] INT NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    PRIMARY KEY ([LanguageId], [CountryId]), 
    CONSTRAINT [FK_TblCountryLanguage_TblLanguage] FOREIGN KEY ([LanguageId]) REFERENCES [TblLanguage]([IdLanguage]), 
    CONSTRAINT [FK_TblCountryLanguage_TblCountry] FOREIGN KEY ([CountryId]) REFERENCES [TblCountry]([IdCountry])
)
