CREATE TABLE [dbo].[TblSuggestingClients]
(
	[IdSuggesting] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] NVARCHAR(150) NULL, 
    [Text] NVARCHAR(MAX) NULL, 
    [Subject] NVARCHAR(250) NULL, 
    [UserId] INT NULL, 
    [CreateDate] DATETIME NULL, 
    [ResponseDate] DATETIME NULL, 
    [Revised] BIT NULL, 
    CONSTRAINT [FK_TblSuggestingClients_ToTblUser] FOREIGN KEY ([UserId]) REFERENCES [TblUser]([IdUser])
)
