CREATE TABLE [dbo].[TblLabelLanguage]
(
	[LabelId] INT NOT NULL , 
    [LanguageId] INT NOT NULL, 
    [Name] NVARCHAR(150) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    PRIMARY KEY ([LanguageId], [LabelId]), 
    CONSTRAINT [FK_TblLabelLanguage_ToTblLabel] FOREIGN KEY ([LabelId]) REFERENCES [TblLabel]([IdLabel]), 
    CONSTRAINT [FK_TblLabelLanguage_ToTblLanguage] FOREIGN KEY ([LanguageId]) REFERENCES [TblLanguage]([IdLanguage])
)
