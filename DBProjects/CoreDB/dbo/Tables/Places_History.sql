CREATE TABLE [dbo].[Places_History] (
    [PlaceId]           INT           NOT NULL,
    [PlaceNationalCode] VARCHAR (20)  NOT NULL,
    [PlaceTitle]        VARCHAR (255) NOT NULL,
    [DistrictId]        INT           NOT NULL,
    [RegionId]          INT           NOT NULL,
    [UserCreated]       VARCHAR (20)  NOT NULL,
    [DateCreated]       DATETIME      NOT NULL,
    [UserModified]      VARCHAR (20)  NULL,
    [DateModified]      DATETIME      NULL,
    [ChangeType]        CHAR (1)      NOT NULL
);

