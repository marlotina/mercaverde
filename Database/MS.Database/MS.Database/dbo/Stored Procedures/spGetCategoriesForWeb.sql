CREATE PROCEDURE [dbo].[spGetCategoriesForWeb]
	@languageId int
AS
	SELECT C.IdCategory,
		C.ParentCategoryId,
		CL.[Description] AS Name
	FROM TblCategory C
	INNER JOIN TblCategoryLanguage CL ON CL.CategoryId = C.IdCategory
	WHERE CL.LanguageId = @languageId
