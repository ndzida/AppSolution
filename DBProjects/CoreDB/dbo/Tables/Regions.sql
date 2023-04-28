CREATE TABLE [dbo].[Regions] (
    [RegionId]     INT          IDENTITY (1, 1) NOT NULL,
    [RegionTitle]  VARCHAR (50) NOT NULL,
    [CountryId]    INT          NOT NULL,
    [UserCreated]  VARCHAR (20) NOT NULL,
    [DateCreated]  DATETIME     NOT NULL,
    [UserModified] VARCHAR (20) NULL,
    [DateModified] DATETIME     NULL,
    CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED ([RegionId] ASC),
    CONSTRAINT [FK_Regions_Countries] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([CountryId])
);


GO
CREATE TRIGGER dbo.RegionsChanges
ON dbo.Regions
AFTER UPDATE, DELETE
AS

IF EXISTS (
	SELECT * FROM inserted
)
	-- UPDATE Statement was executed
	INSERT INTO [dbo].[Regions_History]
        ([RegionId]
        ,[RegionTitle]
        ,[CountryId]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [RegionId]
        ,[RegionTitle]
        ,[CountryId]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'U'
	FROM deleted
ELSE
	-- DELETE Statement was executed
	INSERT INTO [dbo].[Regions_History]
        ([RegionId]
        ,[RegionTitle]
        ,[CountryId]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [RegionId]
        ,[RegionTitle]
        ,[CountryId]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'D'
	FROM deleted	