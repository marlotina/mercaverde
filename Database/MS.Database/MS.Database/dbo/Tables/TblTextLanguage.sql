CREATE TABLE [dbo].[TblTextLanguage] (
    [TextId]      INT           NOT NULL,
    [LanguageId]  INT           NOT NULL,
    [Translation] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_TblTextLanguage] PRIMARY KEY CLUSTERED ([TextId] ASC, [LanguageId] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_TblTextLanguage_TblText] FOREIGN KEY ([TextId]) REFERENCES [dbo].[TblText] ([IdText]), 
    CONSTRAINT [FK_TblTextLanguage_TblLanguage] FOREIGN KEY ([LanguageId]) REFERENCES [TblLanguage]([IdLanguage])
);

