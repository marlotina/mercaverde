CREATE TABLE [dbo].[TblLabel]
(
	[IdLabel] INT		    IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(100) NULL, 
    [ParentLabelId] INT NULL, 
    CONSTRAINT [PK_TblLabel] PRIMARY KEY ([IdLabel]), 
    CONSTRAINT [FK_TblLabel_ToTblLabel] FOREIGN KEY ([ParentLabelId]) REFERENCES [TblLabel]([IdLabel])
)
