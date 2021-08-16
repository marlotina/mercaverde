CREATE TABLE [dbo].[TblLanguage] (
    [IdLanguage]  INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Published]   BIT           NULL,
    [Icon]        VARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [URL]         VARCHAR (50)  NULL,
    [Charset]     VARCHAR (50)  COLLATE Modern_Spanish_CI_AI NULL,
    [Order]       SMALLINT      CONSTRAINT [DF_TblLanguage_LanguageOrder] DEFAULT ((255)) NULL,
    [URLFolder]   VARCHAR (10)  NULL,
    [Domain]      VARCHAR (50)  NULL,
    [CultureName] VARCHAR (50)  NULL,
    [Folder]      VARCHAR (10)  NULL,
    CONSTRAINT [PK_TblLanguage] PRIMARY KEY CLUSTERED ([IdLanguage] DESC)
);

