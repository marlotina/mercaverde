CREATE PROCEDURE [dbo].[spGetStoreDetail]
	@storeId int = 0,
	@languageId int
AS

	SELECT S.IdStore,
		S.Name ,
		S.Email , 
		S.Phone ,
		S.PrefixPhone ,
		S.MobilePhone ,
		S.UrlWebSite ,
		S.Street ,
		S.StreetComplete ,
		S.PostalCode ,
		S.Number ,
		S.CityId ,
		S.DistrictId ,
		S.TimeTable ,
		S.UserId ,
		S.Latitude ,
		S.Longitude ,
		CL.Name AS CityName ,
		D.Name AS DistrictName,
		SD.Title AS Title,
		SD.[Description] AS StoreDescription
	FROM TblStore S
	LEFT JOIN TblStoreDescription SD WITH(NOLOCK) ON SD.StoreId = S.IdStore AND SD.LanguageId = @languageId
	LEFT JOIN TblDistrict D WITH(NOLOCK) ON D.IdDistrict = S.DistrictId
	INNER JOIN TblCity C WITH(NOLOCK) ON C.IdCity = s.CityId
	INNER JOIN TblCityLanguage CL WITH(NOLOCK) ON CL.CityId = C.IdCity AND CL.LanguageId = @languageId
	WHERE S.IdStore = @storeId



