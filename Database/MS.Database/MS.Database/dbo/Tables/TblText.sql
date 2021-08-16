CREATE TABLE [dbo].[TblText] (
    [IdText]          INT		   IDENTITY(1,1) NOT NULL,
    [Name]            VARCHAR (300) NULL,
    [Label]           VARCHAR (300) NULL,
    [String]           VARCHAR (100) NULL,
    [Description] VARCHAR (200) NULL,
    CONSTRAINT [PK_TblText] PRIMARY KEY CLUSTERED ([IdText] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [IX_TblText] UNIQUE NONCLUSTERED ([IdText] ASC) WITH (FILLFACTOR = 90)
);

