CREATE TABLE [dbo].[TblPostComment]
(
	[IdPostComment] INT		    IDENTITY(1,1) NOT NULL, 
    [Text] NVARCHAR(500) NOT NULL, 
    [UserId] INT NOT NULL, 
    [CreationDate] DATETIME NOT NULL, 
    [ModificationDate] DATETIME NULL, 
    [Order] INT NOT NULL, 
    [Title] NVARCHAR(100) NULL, 
    [PostId] INT NOT NULL, 
    CONSTRAINT [FK_TblPostComment_ToTblUser] FOREIGN KEY ([UserId]) REFERENCES [TblUser]([IdUser]), 
    CONSTRAINT [PK_TblPostComment] PRIMARY KEY ([IdPostComment]), 
    CONSTRAINT [FK_TblPostComment_TblPost] FOREIGN KEY ([PostId]) REFERENCES [TblPost]([IdPost])
)
