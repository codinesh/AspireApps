CREATE PROCEDURE [adacitySurvey].[GetSurveys]
AS
BEGIN
	SELECT 
		 [ID]					
		,[age_group]				
		,[employment]			
		,[opinion]				
		,[entertainment_category]
	FROM [adacitySurvey].[adacitySurvey] S
	ORDER BY ID
END