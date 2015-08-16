CREATE PROCEDURE [adacitySurvey].[SaveSurvey]
	@AgeGroup NVARCHAR(10)
	,@Employment NVARCHAR(50)
	,@Option NVARCHAR(200)
	,@EmploymentCategory NVARCHAR(50)
AS
BEGIN
	INSERT INTO adacitySurvey.adacitySurvey (age_group, employment, opinion, employment_category) 
	VALUES (
		 @AgeGroup
		,@Employment
		,@Option
		,@EmploymentCategory
	)
	RETURN 1
END