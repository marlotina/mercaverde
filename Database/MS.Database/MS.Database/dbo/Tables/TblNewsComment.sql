CREATE TABLE [dbo].[TblNewsComment]
(
	[IdNewsComment] INT		    IDENTITY(1,1) NOT NULL, 
    [Text] NVARCHAR(500) NOT NULL, 
    [UserId] INT NOT NULL, 
    [CreationDate] DATETIME NOT NULL, 
    [ModificationDate] DATETIME NULL, 
    [Order] INT NOT NULL, 
    [Title] NVARCHAR(100) NULL, 
    [NewsId] INT NOT NULL, 
    CONSTRAINT [FK_TblNewsComment_ToTblUser] FOREIGN KEY ([UserId]) REFERENCES [TblUser]([IdUser]), 
    CONSTRAINT [PK_TblNewsComment] PRIMARY KEY ([IdNewsComment]), 
    CONSTRAINT [FK_TblNewsComment_TblNews] FOREIGN KEY ([NewsId]) REFERENCES [TblNews]([IdNews])
)
