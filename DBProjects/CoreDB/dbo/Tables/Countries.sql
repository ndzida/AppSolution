CREATE TABLE [dbo].[Countries] (
    [CountryId]    INT          IDENTITY (1, 1) NOT NULL,
    [CountryCode]  CHAR (3)     NULL,
    [CountryTitle] VARCHAR (50) NOT NULL,
    [UserCreated]  VARCHAR (20) NOT NULL,
    [DateCreated]  DATETIME     NOT NULL,
    [UserModified] VARCHAR (20) NULL,
    [DateModified] DATETIME     NULL,
    CONSTRAINT [PK_Countries_1] PRIMARY KEY CLUSTERED ([CountryId] ASC)
);


GO
CREATE TRIGGER dbo.CountriesChanges
ON dbo.Countries
AFTER UPDATE, DELETE
AS

IF EXISTS (
	SELECT * FROM inserted
)
	-- UPDATE Statement was executed
	INSERT INTO [dbo].[Countries_History]
        ([CountryId]
        ,[CountryCode]
        ,[CountryTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [CountryId]
        ,[CountryCode]
        ,[CountryTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'U'
	FROM deleted
ELSE
	-- DELETE Statement was executed
	INSERT INTO [dbo].[Countries_History]
        ([CountryId]
        ,[CountryCode]
        ,[CountryTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [CountryId]
        ,[CountryCode]
        ,[CountryTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'D'
	FROM deleted	