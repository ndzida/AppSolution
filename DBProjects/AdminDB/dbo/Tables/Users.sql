CREATE TABLE [dbo].[Users] (
    [UserId]       INT           IDENTITY (1, 1) NOT NULL,
    [Username]     VARCHAR (100) NOT NULL,
    [Email]        VARCHAR (255) NOT NULL,
    [PasswordHash] VARCHAR (200) NOT NULL,
    [IsActive]     BIT           NOT NULL,
    [IsRegistered] BIT           NOT NULL,
    [UserCreated]  VARCHAR (20)  NOT NULL,
    [DateCreated]  DATETIME      NOT NULL,
    [UserModified] VARCHAR (20)  NULL,
    [DateModified] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);


GO
CREATE TRIGGER dbo.UsersChanges
ON dbo.Users
AFTER UPDATE, DELETE
AS

IF EXISTS (
	SELECT * FROM inserted
)
	-- UPDATE Statement was executed
	INSERT INTO	Users_History
        ([UserId]
        ,[Username]
        ,[Email]
        ,[PasswordHash]
        ,[IsActive]
        ,[IsRegistered]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [UserId]
        ,[Username]
        ,[Email]
        ,[PasswordHash]
        ,[IsActive]
        ,[IsRegistered]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'U'
	FROM deleted
ELSE
	-- DELETE Statement was executed
	INSERT INTO	Users_History
        ([UserId]
        ,[Username]
        ,[Email]
        ,[PasswordHash]
        ,[IsActive]
        ,[IsRegistered]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [UserId]
        ,[Username]
        ,[Email]
        ,[PasswordHash]
        ,[IsActive]
        ,[IsRegistered]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'D'
	FROM deleted	