CREATE TABLE [dbo].[TblTaskProcess]
(
	[IdTaskProcess] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TaskProcessType] INT NOT NULL, 
    [Status] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [UpdateDate] DATETIME NOT NULL, 
    [Attempts] INT NULL, 
    CONSTRAINT [FK_TblTaskProcess_ToTblUser] FOREIGN KEY ([UserId]) REFERENCES [TblUser]([IdUser])
)
