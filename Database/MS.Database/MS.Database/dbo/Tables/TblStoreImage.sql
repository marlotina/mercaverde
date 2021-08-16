CREATE TABLE [dbo].[TblStoreImage]
(
	[IdStoreImage] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StoreId] INT NOT NULL, 
    [Url] NVARCHAR(500) NOT NULL, 
    [Order] INT NOT NULL, 
    [IsMain] BIT NOT NULL, 
    CONSTRAINT [FK_TblStoreImage_ToTblStore] FOREIGN KEY ([StoreId]) REFERENCES [TblStore]([IdStore])
)
