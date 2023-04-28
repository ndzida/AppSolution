CREATE TABLE [dbo].[Countries_History] (
    [CountryId]    INT          NOT NULL,
    [CountryCode]  CHAR (3)     NULL,
    [CountryTitle] VARCHAR (20) NOT NULL,
    [UserCreated]  VARCHAR (20) NOT NULL,
    [DateCreated]  DATETIME     NOT NULL,
    [UserModified] VARCHAR (20) NULL,
    [DateModified] DATETIME     NULL,
    [ChangeType]   CHAR (1)     NOT NULL
);

