CREATE TABLE [adacitysurvey].[adacitySurvey] (
    [ID]					INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [age_group]				NVARCHAR (10)  NULL,
    [employment]			NVARCHAR (50)  NULL,
    [opinion]				NVARCHAR (200) NULL,
    [entertainment_category] NVARCHAR (50)  NULL
);