CREATE TABLE [dbo].[Genders] (
    [GenderId]     INT            IDENTITY (1, 1) NOT NULL,
    [GenderShort]  NVARCHAR (255) NULL,
    [GenderTitle]  VARCHAR (20)   NOT NULL,
    [UserCreated]  VARCHAR (20)   NOT NULL,
    [DateCreated]  DATETIME       NOT NULL,
    [UserModified] VARCHAR (20)   NULL,
    [DateModified] DATETIME       NULL,
    CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED ([GenderId] ASC)
);


GO
CREATE TRIGGER dbo.GendersChanges
ON dbo.Genders
AFTER UPDATE, DELETE
AS

IF EXISTS (
	SELECT * FROM inserted
)
	-- UPDATE Statement was executed
	INSERT INTO [dbo].[Genders_History]
        ([GenderId]
        ,[GenderShort]
        ,[GenderTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [GenderId]
        ,[GenderShort]
        ,[GenderTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'U'
	FROM deleted
ELSE
	-- DELETE Statement was executed
	INSERT INTO [dbo].[Genders_History]
        ([GenderId]
        ,[GenderShort]
        ,[GenderTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [GenderId]
        ,[GenderShort]
        ,[GenderTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'D'
	FROM deleted	