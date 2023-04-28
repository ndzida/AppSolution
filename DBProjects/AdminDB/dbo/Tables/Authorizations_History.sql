CREATE TABLE [dbo].[Authorizations_History] (
    [AuthorizationId]    INT          NOT NULL,
    [AuthorizationTitle] VARCHAR (20) NOT NULL,
    [UserCreated]        VARCHAR (20) NOT NULL,
    [DateCreated]        DATETIME     NOT NULL,
    [UserModified]       VARCHAR (20) NULL,
    [DateModified]       DATETIME     NULL,
    [ChangeType]         CHAR (1)     NOT NULL
);

