CREATE TABLE [dbo].[TblCategory]
(
	[IdCategory] INT		    IDENTITY(1,1) NOT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [ParentCategoryId] INT NULL, 
    CONSTRAINT [PK_TblCategory] PRIMARY KEY ([IdCategory]), 
    CONSTRAINT [FK_TblCategory_ToTblCategory] FOREIGN KEY ([ParentCategoryId]) REFERENCES [TblCategory]([IdCategory])
)
