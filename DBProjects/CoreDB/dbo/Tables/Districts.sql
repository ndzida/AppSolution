CREATE TABLE [dbo].[Districts] (
    [DistrictId]    INT          IDENTITY (1, 1) NOT NULL,
    [RegionId]      INT          NOT NULL,
    [DistrictTitle] VARCHAR (50) NOT NULL,
    [DistrictType]  VARCHAR (20) NOT NULL,
    [UserCreated]   VARCHAR (20) NOT NULL,
    [DateCreated]   DATETIME     NOT NULL,
    [UserModified]  VARCHAR (20) NULL,
    [DateModified]  DATETIME     NULL,
    CONSTRAINT [PK_Districts_1] PRIMARY KEY CLUSTERED ([DistrictId] ASC),
    CONSTRAINT [FK_Districts_Regions] FOREIGN KEY ([RegionId]) REFERENCES [dbo].[Regions] ([RegionId])
);


GO
CREATE TRIGGER dbo.DistrictsChanges
ON dbo.Districts
AFTER UPDATE, DELETE
AS

IF EXISTS (
	SELECT * FROM inserted
)
	-- UPDATE Statement was executed
	INSERT INTO [dbo].[Districts_History]
        ([DistrictId]
        ,[RegionId]
        ,[DistrictTitle]
        ,[DistrictType]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [DistrictId]
        ,[RegionId]
        ,[DistrictTitle]
        ,[DistrictType]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'U'
	FROM deleted
ELSE
	-- DELETE Statement was executed
	INSERT INTO [dbo].[Districts_History]
        ([DistrictId]
        ,[RegionId]
        ,[DistrictTitle]
        ,[DistrictType]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [DistrictId]
        ,[RegionId]
        ,[DistrictTitle]
        ,[DistrictType]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'D'
	FROM deleted	