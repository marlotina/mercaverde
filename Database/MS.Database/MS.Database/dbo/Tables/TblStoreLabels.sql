CREATE TABLE [dbo].[TblStoreLabels]
(
	[StoreId] INT NOT NULL , 
    [LabelId] INT NOT NULL, 
    CONSTRAINT [PK_TblStoreLabels] PRIMARY KEY ([StoreId], [LabelId]), 
    CONSTRAINT [FK_TblStoreLabels_ToTblStore] FOREIGN KEY ([StoreId]) REFERENCES [TblStore]([IdStore]), 
    CONSTRAINT [FK_TblStoreLabels_ToTblLabel] FOREIGN KEY ([LabelId]) REFERENCES [TblLabel]([IdLabel]) 
)
