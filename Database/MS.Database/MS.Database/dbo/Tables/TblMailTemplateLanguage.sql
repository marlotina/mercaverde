CREATE TABLE [dbo].[TblMailTemplateLanguage]
(
	[MailTemplateId] INT NOT NULL, 
    [LanguageId] INT NOT NULL, 
    [Text] NVARCHAR(MAX) NULL, 
    [Subject] NCHAR(250) NULL, 
    CONSTRAINT [FK_TblMailTemplateLanguage_ToTblLanguage] FOREIGN KEY ([LanguageId]) REFERENCES [TblLanguage]([IdLanguage]), 
    CONSTRAINT [FK_TblMailTemplateLanguage_ToTblMailTemplate] FOREIGN KEY ([MailTemplateId]) REFERENCES [TblMailTemplate]([IdMailTemplate]), 
    PRIMARY KEY ([MailTemplateId], [LanguageId])
)
