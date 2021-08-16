CREATE PROCEDURE [dbo].[spWebSearchMap]
	@IdLocation int = 0,
	@LanguageId int = 1,
	@districtsList nvarchar(100),
	@categoryList nvarchar(100),
	@startItem int,
	@numItems int,
	@order int,
	@labelList nvarchar(100)
AS

	SELECT s.IdStore
		, s.Name
		, cl.Name AS CityName
		, (SELECT TOP 1 SI.Url FROM TblStoreImage si WITH(NOLOCK) WHERE si.StoreId = s.IdStore ORDER BY si.[Order] ASC) AS ImageUrl
		, d.Name AS DistrictName
		, d.IdDistrict AS DisctrictId
		, CAST(S.Longitude as nvarchar(20)) AS Longitude
		, CAST(S.Latitude as nvarchar(20)) AS Latitude
		, SD.ShortDescription AS ShortDescription
	FROM TblStore S WITH(NOLOCK)
	INNER JOIN TblCityLanguage cl WITH(NOLOCK) ON cl.CityId = @IdLocation AND CL.LanguageId = @LanguageId
	LEFT JOIN TblDistrict D WITH(NOLOCK) ON D.IdDistrict = S.DistrictId 
	LEFT JOIN TblStoreCategories ST WITH(NOLOCK) ON ST.StoreId = S.IdStore
	LEFT JOIN TblStoreDescription SD WITH(NOLOCK) ON SD.StoreId = S.IdStore AND SD.LanguageId = @LanguageId
	LEFT JOIN TblStoreLabels SL WITH(NOLOCK) ON SL.StoreId = S.IdStore
	WHERE S.CityId = @IdLocation 
		AND (@districtsList = '' OR S.DistrictId IN (SELECT * FROM dbo.CustomSplit(@districtsList, ',')))
		AND (@categoryList = '' OR ST.CategoryId IN (SELECT * FROM dbo.CustomSplit(@categoryList, ',')))
		AND (@labelList = '' OR SL.LabelId IN (SELECT * FROM dbo.CustomSplit(@labelList, ',')))
	ORDER BY 
	CASE WHEN @order = 1 THEN s.Name END ASC,
	CASE WHEN @order = 2 THEN s.Name END DESC, 
	CASE WHEN @order = 3 THEN d.Name END ASC,
	CASE WHEN @order = 4 THEN d.Name END DESC
	OFFSET @startItem ROWS
	FETCH NEXT @numItems ROWS ONLY

