CREATE PROCEDURE [dbo].[spWebSearchMapFull]
	@IdLocation int = 0,
	@districtsList nvarchar(100),
	@categoryList nvarchar(100)
AS

	SELECT s.IdStore AS IdStore
		, CAST(S.Longitude as nvarchar(20)) AS Longitude
		, CAST(S.Latitude as nvarchar(20)) AS Latitude
	FROM TblStore S WITH(NOLOCK)
	LEFT JOIN TblStoreCategories ST WITH(NOLOCK) ON ST.StoreId = S.IdStore
	WHERE S.CityId = @IdLocation 
		AND (@districtsList = '' OR S.DistrictId IN (SELECT * FROM dbo.CustomSplit(@districtsList, ',')))
		AND (@categoryList = '' OR ST.CategoryId IN (SELECT * FROM dbo.CustomSplit(@categoryList, ',')))
	ORDER BY s.Name DESC