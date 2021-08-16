CREATE TABLE [dbo].[TblStoreComment]
(
	[IdStoreComment] INT		    IDENTITY(1,1) NOT NULL,
	[Text] NVARCHAR(500) NOT NULL, 
    [UserId] INT NOT NULL, 
    [CreationDate] DATETIME NOT NULL, 
    [ModificationDate] DATETIME NULL, 
    [Order] INT NOT NULL, 
    [Title] NVARCHAR(100) NULL, 
    [StoreId] INT NOT NULL, 
    CONSTRAINT [FK_TblStoreComment_ToTblUser] FOREIGN KEY ([UserId]) REFERENCES [TblUser]([IdUser]), 
	CONSTRAINT [FK_TblStoreComment_ToTblStore] FOREIGN KEY ([StoreId]) REFERENCES [TblStore]([IdStore]),
    CONSTRAINT [PK_TblStoreComment] PRIMARY KEY ([IdStoreComment])
)
