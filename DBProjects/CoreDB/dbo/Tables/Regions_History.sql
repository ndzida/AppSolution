CREATE TABLE [dbo].[Regions_History] (
    [RegionId]     INT          NOT NULL,
    [RegionTitle]  VARCHAR (50) NOT NULL,
    [CountryId]    INT          NOT NULL,
    [UserCreated]  VARCHAR (20) NOT NULL,
    [DateCreated]  DATETIME     NOT NULL,
    [UserModified] VARCHAR (20) NULL,
    [DateModified] DATETIME     NULL,
    [ChangeType]   CHAR (1)     NOT NULL
);

