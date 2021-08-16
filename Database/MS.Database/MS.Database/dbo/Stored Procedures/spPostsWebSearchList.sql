CREATE PROCEDURE [dbo].[spPostsWebSearchList]
	@startItem int = 0,
	@numItems int
AS
	DECLARE @totalItems INT

	SELECT @totalItems = COUNT(*) FROM TblPost P WHERE P.IsPublished = 1

	SELECT P.IdPost AS IdItem,
		P.Title, 
		SUBSTRING ( P.[Text] ,0 , 250 ) AS [Text],
		U.Name AS UserName,
		P.LanguageId,
		P.PublishDate,
		@totalItems AS TotalItems
	FROM TblPost P
	INNER JOIN TblUser U ON U.IdUser = P.UserId
	WHERE P.IsPublished = 1
	ORDER BY P.PublishDate DESC
	OFFSET @startItem ROWS
	FETCH NEXT @numItems ROWS ONLY
