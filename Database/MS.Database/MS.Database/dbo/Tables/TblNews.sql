﻿CREATE TABLE [dbo].[TblNews]
(
	[IdNews] INT		    IDENTITY(1,1) NOT NULL,
    [Title] NVARCHAR(100) NOT NULL, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [UserId] INT NOT NULL, 
    [CreationDate] DATETIME NOT NULL, 
    [ModificationDate] DATETIME NOT NULL, 
    [LanguageId] INT NOT NULL, 
    [HasRevised] BIT NOT NULL, 
    [IsPublished] BIT NOT NULL, 
    [Deleted] BIT NOT NULL, 
    [PublishDate] DATETIME NULL, 
    CONSTRAINT [FK_TblNews_ToTblUser] FOREIGN KEY ([UserId]) REFERENCES [TblUser]([IdUser]), 
    CONSTRAINT [PK_TblNews] PRIMARY KEY ([IdNews]), 
    CONSTRAINT [FK_TblNews_ToTblLanguage] FOREIGN KEY ([LanguageId]) REFERENCES [TblLanguage]([IdLanguage])
)
