CREATE TABLE [dbo].[Applications] (
    [ApplicationId]    INT          IDENTITY (1, 1) NOT NULL,
    [ApplicationTitle] VARCHAR (20) NOT NULL,
    [UserCreated]      VARCHAR (20) NOT NULL,
    [DateCreated]      DATETIME     NOT NULL,
    [UserModified]     VARCHAR (20) NULL,
    [DateModified]     DATETIME     NULL,
    CONSTRAINT [PK_Aplications] PRIMARY KEY CLUSTERED ([ApplicationId] ASC)
);


GO
CREATE TRIGGER dbo.ApplicationsChanges
ON dbo.Applications
AFTER UPDATE, DELETE
AS

IF EXISTS (
	SELECT * FROM inserted
)
	-- UPDATE Statement was executed
	INSERT INTO [dbo].[Applications_History]
        ([ApplicationId]
        ,[ApplicationTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [ApplicationId]
        ,[ApplicationTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'U'
	FROM deleted
ELSE
	-- DELETE Statement was executed
	INSERT INTO [dbo].[Applications_History]
        ([ApplicationId]
        ,[ApplicationTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [ApplicationId]
        ,[ApplicationTitle]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'D'
	FROM deleted	