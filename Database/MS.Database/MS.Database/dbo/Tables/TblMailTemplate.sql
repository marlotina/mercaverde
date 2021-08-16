CREATE TABLE [dbo].[TblMailTemplate]
(
	[IdMailTemplate] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(150) NOT NULL, 
    [Description] NVARCHAR(250) NULL, 
    [WithCopy] NVARCHAR(250) NULL
)
