CREATE TABLE [dbo].[Genders_History] (
    [GenderId]     INT            NOT NULL,
    [GenderShort]  NVARCHAR (255) NULL,
    [GenderTitle]  VARCHAR (20)   NOT NULL,
    [UserCreated]  VARCHAR (20)   NOT NULL,
    [DateCreated]  DATETIME       NOT NULL,
    [UserModified] VARCHAR (20)   NULL,
    [DateModified] DATETIME       NULL,
    [ChangeType]   CHAR (1)       NOT NULL
);

