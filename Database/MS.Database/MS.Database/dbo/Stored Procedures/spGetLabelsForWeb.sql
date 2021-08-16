CREATE PROCEDURE [dbo].[spGetLabelsForWeb]
	@languageId int
AS
	SELECT C.IdLabel,
		C.ParentLabelId,
		CL.[Description] AS Name
	FROM TblLabel C
	INNER JOIN TblLabelLanguage CL ON CL.LabelId = C.IdLabel
	WHERE CL.LanguageId = @languageId
