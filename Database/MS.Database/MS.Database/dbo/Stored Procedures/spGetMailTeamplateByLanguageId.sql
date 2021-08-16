CREATE PROCEDURE [dbo].[spGetMailTeamplateByLanguageId]
	@IdMailTemplate int = 0,
	@LanguageId int = 2
AS
	SELECT T.WithCopy, TL.[Subject], TL.[Text]
	FROM TblMailTemplate T WITH(NOLOCK)
	INNER JOIN TblMailTemplateLanguage TL WITH(NOLOCK) ON TL.MailTemplateId = T.IdMailTemplate
	WHERE T.IdMailTemplate = @IdMailTemplate AND  TL.LanguageId = @IdMailTemplate

