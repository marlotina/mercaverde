CREATE PROCEDURE [dbo].[spEventsWebSearchList]
		@startDate datetime,
		@endDate datetime
AS
	SELECT E.IdEvent,
		E.Title, 
		SUBSTRING (E.[Text] ,0 , 250 ) AS [Text],
		U.Name AS UserName,
		CONVERT(VARCHAR(10), E.StartDate, 126) AS StartDate,
		CONVERT(VARCHAR(10), E.EndDate, 126) AS EndDate,
		E.LanguageId,
		E.PublishDate
	FROM TblEvent E
	INNER JOIN TblUser U ON U.IdUser = E.UserId
	WHERE E.IsPublished = 1 
		AND E.StartDate >=  @startDate		
		OR (E.EndDate >=  @endDate AND E.EndDate <=  @endDate)
	ORDER BY E.PublishDate DESC


