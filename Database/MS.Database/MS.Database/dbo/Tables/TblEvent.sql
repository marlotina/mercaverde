CREATE TABLE [dbo].[TblEvent]
(
	[IdEvent] INT		    IDENTITY(1,1) NOT NULL,
    [Title] NVARCHAR(100) NOT NULL, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [UserId] INT NOT NULL, 
    [CreationDate] DATETIME NOT NULL, 
    [ModificationDate] DATETIME NOT NULL, 
	[StartDate] DATETIME NOT NULL,
	[EndDate] DATETIME NOT NULL, 
    [Latitude] NVARCHAR(50) NULL, 
    [Longitude] NVARCHAR(50) NULL, 
	[Image] NVARCHAR(350) NULL, 
    [LanguageId] INT NOT NULL, 
    [HasRevised] BIT NOT NULL, 
    [IsPublished] BIT NOT NULL, 
    [Deleted] BIT NOT NULL, 
    [PublishDate] DATETIME NULL, 
    CONSTRAINT [FK_TblEvent_ToTblUser] FOREIGN KEY ([UserId]) REFERENCES [TblUser]([IdUser]), 
    CONSTRAINT [PK_TblEvent] PRIMARY KEY ([IdEvent]), 
    CONSTRAINT [FK_TblEvent_ToTblLanguage] FOREIGN KEY ([LanguageId]) REFERENCES [TblLanguage]([IdLanguage])
)
