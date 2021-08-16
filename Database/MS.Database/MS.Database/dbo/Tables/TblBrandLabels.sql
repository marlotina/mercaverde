CREATE TABLE [dbo].[TblBrandLabels]
(
	[BrandId] INT NOT NULL , 
    [LabelId] INT NOT NULL , 
    CONSTRAINT [PK_TblBrandLabels] PRIMARY KEY ([BrandId], [LabelId]), 
    CONSTRAINT [FK_TblBrandLabels_ToTblStore] FOREIGN KEY ([BrandId]) REFERENCES [TblBrand]([IdBrand]), 
    CONSTRAINT [FK_TblBrandLabels_ToTblLabel] FOREIGN KEY ([LabelId]) REFERENCES [TblLabel]([IdLabel]) 
)
