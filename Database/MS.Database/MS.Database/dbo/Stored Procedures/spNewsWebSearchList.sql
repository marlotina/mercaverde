CREATE PROCEDURE [dbo].[spNewsWebSearchList]
	@startItem int = 0,
	@numItems int
AS
	DECLARE @totalItems INT

	SELECT @totalItems = COUNT(*) FROM TblNews N WHERE N.IsPublished = 1

	SELECT N.IdNews AS IdItem,
		N.Title, 
		SUBSTRING ( N.[Text] ,0 , 250 ) AS [Text],
		U.Name AS UserName,
		N.LanguageId,
		N.PublishDate,
		@totalItems AS TotalItems
	FROM TblNews N
	INNER JOIN TblUser U ON U.IdUser = N.UserId
	WHERE N.IsPublished = 1
	ORDER BY N.PublishDate DESC
	OFFSET @startItem ROWS
	FETCH NEXT @numItems ROWS ONLY
