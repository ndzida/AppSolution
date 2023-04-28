CREATE TABLE [dbo].[Employees_History] (
    [EmployeeId]       INT           NOT NULL,
    [Username]         VARCHAR (20)  NOT NULL,
    [Firstname]        VARCHAR (100) NOT NULL,
    [Lastname]         VARCHAR (100) NOT NULL,
    [NationalIdNumber] VARCHAR (20)  NOT NULL,
    [NationalIdType]   INT           NOT NULL,
    [GenderId]         INT           NOT NULL,
    [Birthdate]        DATE          NULL,
    [Address]          VARCHAR (100) NULL,
    [PlaceId]          INT           NOT NULL,
    [CountryId]        INT           NOT NULL,
    [UserCreated]      VARCHAR (20)  NOT NULL,
    [DateCreated]      DATETIME      NOT NULL,
    [UserModified]     VARCHAR (20)  NULL,
    [DateModified]     DATETIME      NULL,
    [ChangeType]       CHAR (1)      NOT NULL
);

