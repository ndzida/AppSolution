CREATE TABLE [dbo].[Districts_History] (
    [DistrictId]    INT          NOT NULL,
    [RegionId]      INT          NOT NULL,
    [DistrictTitle] VARCHAR (50) NOT NULL,
    [DistrictType]  VARCHAR (20) NOT NULL,
    [UserCreated]   VARCHAR (20) NOT NULL,
    [DateCreated]   DATETIME     NOT NULL,
    [UserModified]  VARCHAR (20) NULL,
    [DateModified]  DATETIME     NULL,
    [ChangeType]    CHAR (1)     NOT NULL
);

