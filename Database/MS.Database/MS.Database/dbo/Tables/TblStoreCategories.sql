CREATE TABLE [dbo].[TblStoreCategories]
(
	[StoreId] INT NOT NULL , 
    [CategoryId] INT NOT NULL , 
    CONSTRAINT [PK_TblStoreCategories] PRIMARY KEY ([StoreId], [CategoryId]), 
    CONSTRAINT [FK_TblStoreCategories_ToTblStore] FOREIGN KEY ([StoreId]) REFERENCES [TblStore]([IdStore]), 
    CONSTRAINT [FK_TblStoreCategories_ToTblCategory] FOREIGN KEY ([CategoryId]) REFERENCES [TblCategory]([IdCategory]) 
)
