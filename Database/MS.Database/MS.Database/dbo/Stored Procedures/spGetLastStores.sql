CREATE PROCEDURE [dbo].[spGetLastStores]
	@LanguageId int = 1
AS
	SELECT TOP 4 s.IdStore
		, s.Name
		, cl.Name AS CityName
		, (SELECT TOP 1 SI.Url FROM TblStoreImage si WITH(NOLOCK) WHERE si.StoreId = s.IdStore ORDER BY si.[Order] ASC) AS ImageUrl
		, d.Name AS DistrictName
		, d.IdDistrict AS DisctrictId
		, CAST(S.Longitude as nvarchar(20)) AS Longitude
		, CAST(S.Latitude as nvarchar(20)) AS Latitude
		, 4 AS TotalItems
		, SD.ShortDescription AS ShortDescription
	FROM TblStore S WITH(NOLOCK)
	INNER JOIN TblCityLanguage cl WITH(NOLOCK) ON cl.CityId = S.CityId AND CL.LanguageId = @LanguageId
	LEFT JOIN TblDistrict D WITH(NOLOCK) ON D.IdDistrict = S.DistrictId 
	LEFT JOIN TblStoreCategories ST WITH(NOLOCK) ON ST.StoreId = S.IdStore
	LEFT JOIN TblStoreDescription SD WITH(NOLOCK) ON SD.StoreId = S.IdStore AND SD.LanguageId = @LanguageId
	WHERE S.IsPublished = 1
	ORDER BY S.PublishDate DESC