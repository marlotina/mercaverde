CREATE PROCEDURE spGetTasksToProcess
AS

DECLARE @IdTaskList TABLE(Id INT)

INSERT INTO @IdTaskList
SELECT T.IdTaskProcess
FROM TblTaskProcess T
WHERE T.[Status] = 1
ORDER BY T.CreateDate

UPDATE TblTaskProcess SET [Status] = 2, UpdateDate = GETDATE(), Attempts = Attempts + 1 WHERE IdTaskProcess IN (SELECT Id FROM @IdTaskList)
  
SELECT T.IdTaskProcess, T.TaskProcessType, T.UserId, T.Attempts
FROM TblTaskProcess T WITH(NOLOCK)
WHERE T.IdTaskProcess IN (SELECT Id FROM @IdTaskList)