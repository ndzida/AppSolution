CREATE TABLE [dbo].[Places] (
    [PlaceId]           INT           IDENTITY (1, 1) NOT NULL,
    [PlaceNationalCode] VARCHAR (20)  NOT NULL,
    [PlaceTitle]        VARCHAR (255) NOT NULL,
    [DistrictId]        INT           NOT NULL,
    [RegionId]          INT           NOT NULL,
    [UserCreated]       VARCHAR (20)  NOT NULL,
    [DateCreated]       DATETIME      NOT NULL,
    [UserModified]      VARCHAR (20)  NULL,
    [DateModified]      DATETIME      NULL,
    CONSTRAINT [PK_Places_1] PRIMARY KEY CLUSTERED ([PlaceId] ASC),
    CONSTRAINT [FK_Places_Districts] FOREIGN KEY ([DistrictId]) REFERENCES [dbo].[Districts] ([DistrictId]),
    CONSTRAINT [FK_Places_Regions] FOREIGN KEY ([RegionId]) REFERENCES [dbo].[Regions] ([RegionId])
);


GO
CREATE TRIGGER dbo.PlacesChanges
ON dbo.Places
AFTER UPDATE, DELETE
AS

IF EXISTS (
	SELECT * FROM inserted
)
	-- UPDATE Statement was executed
	INSERT INTO [dbo].[Places_History]
        ([PlaceId]
        ,[PlaceNationalCode]
        ,[PlaceTitle]
        ,[DistrictId]
        ,[RegionId]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [PlaceId]
        ,[PlaceNationalCode]
        ,[PlaceTitle]
        ,[DistrictId]
        ,[RegionId]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'U'
	FROM deleted
ELSE
	-- DELETE Statement was executed
	INSERT INTO [dbo].[Places_History]
        ([PlaceId]
        ,[PlaceNationalCode]
        ,[PlaceTitle]
        ,[DistrictId]
        ,[RegionId]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [PlaceId]
        ,[PlaceNationalCode]
        ,[PlaceTitle]
        ,[DistrictId]
        ,[RegionId]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'D'
	FROM deleted	