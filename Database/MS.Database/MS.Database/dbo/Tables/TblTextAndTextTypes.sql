CREATE TABLE [dbo].[TblTextAndTextTypes]
(
	[TextId] INT NOT NULL ,
    [IdTextType]       INT           NOT NULL, 
    PRIMARY KEY ([TextId], [IdTextType]),
    CONSTRAINT [FK_TblText_TblTextType] FOREIGN KEY ([IdTextType]) REFERENCES [dbo].[TblTextType] ([IdTextType])
)
