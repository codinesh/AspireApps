CREATE PROCEDURE [adacitySurvey].[SaveSurvey]
	@AgeGroup NVARCHAR(10)
	,@Employment NVARCHAR(50)
	,@Option NVARCHAR(200)
	,@EntertainmentCategory NVARCHAR(50)
AS
BEGIN
	INSERT INTO adacitySurvey.adacitySurvey (age_group, employment, opinion, entertainment_category) 
	VALUES (
		 @AgeGroup
		,@Employment
		,@Option
		,@EntertainmentCategory
	)
	RETURN 1
END