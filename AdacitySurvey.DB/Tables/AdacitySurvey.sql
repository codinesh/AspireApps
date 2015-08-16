CREATE TABLE [adacitysurvey].[adacitySurvey] (
    [ID]                  INT            IDENTITY (1, 1) NOT NULL,
    [age_group]           NVARCHAR (10)  NULL,
    [employment]          NVARCHAR (50)  NULL,
    [opinion]             NVARCHAR (200) NULL,
    [employment_category] NVARCHAR (50)  NULL
);