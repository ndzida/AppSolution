CREATE TABLE [dbo].[Authorizations] (
    [AuthorizationId]    INT          IDENTITY (1, 1) NOT NULL,
    [AuthorizationTitle] VARCHAR (20) NOT NULL,
    [UserCreated]        VARCHAR (20) NOT NULL,
    [DateCreated]        DATETIME     NOT NULL,
    [UserModified]       VARCHAR (20) NULL,
    [DateModified]       DATETIME     NULL,
    CONSTRAINT [PK_Authorizations] PRIMARY KEY CLUSTERED ([AuthorizationId] ASC)
);


GO
CREATE TRIGGER dbo.AuthorizationsChanges
ON dbo.Authorizations
AFTER UPDATE, DELETE
AS

IF EXISTS (
	SELECT * FROM inserted
)
	-- UPDATE Statement was executed
	INSERT INTO [dbo].[Authorizations_History]
        ([AuthorizationId]
        ,[AuthorizationTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [AuthorizationId]
        ,[AuthorizationTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'U'
	FROM deleted
ELSE
	-- DELETE Statement was executed
	INSERT INTO [dbo].[Authorizations_History]
        ([AuthorizationId]
        ,[AuthorizationTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [AuthorizationId]
        ,[AuthorizationTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'D'
	FROM deleted	