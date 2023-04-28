CREATE TABLE [dbo].[Users_History] (
    [UserId]       INT           NOT NULL,
    [Username]     VARCHAR (100) NOT NULL,
    [Email]        VARCHAR (255) NOT NULL,
    [PasswordHash] VARCHAR (200) NOT NULL,
    [IsActive]     BIT           NOT NULL,
    [IsRegistered] BIT           NOT NULL,
    [UserCreated]  VARCHAR (20)  NOT NULL,
    [DateCreated]  DATETIME      NOT NULL,
    [UserModified] VARCHAR (20)  NULL,
    [DateModified] DATETIME      NULL,
    [ChangeType]   CHAR (1)      NOT NULL
);

