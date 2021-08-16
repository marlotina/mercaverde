CREATE TABLE [dbo].[TblTextType] (
    [IdTextType] INT		   IDENTITY(1,1) NOT NULL,
    [IdPage]     INT           NULL,
    [Name]       VARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_TblTextType] PRIMARY KEY CLUSTERED ([IdTextType] ASC)
);

