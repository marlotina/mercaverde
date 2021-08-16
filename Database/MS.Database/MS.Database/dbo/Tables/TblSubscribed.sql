CREATE TABLE [dbo].[TblSubscribed]
(
    [Email] NVARCHAR(150) NOT NULL PRIMARY KEY, 
    [Type] INT NOT NULL, 
    [LanguageId] INT NOT NULL, 
    [Active] BIT NOT NULL, 
    [CreationDate] DATETIME NOT NULL, 
    [ModificationDate] DATETIME NULL, 
    [UserId] INT NULL, 
    CONSTRAINT [FK_TblSubscribed_ToTblUser] FOREIGN KEY ([UserId]) REFERENCES [Tbluser]([IdUser])
)