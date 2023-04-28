CREATE TABLE [dbo].[Employees] (
    [EmployeeId]       INT           IDENTITY (1, 1) NOT NULL,
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
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC),
    CONSTRAINT [FK_Employees_Countries] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([CountryId]),
    CONSTRAINT [FK_Employees_Genders] FOREIGN KEY ([GenderId]) REFERENCES [dbo].[Genders] ([GenderId]),
    CONSTRAINT [FK_Employees_NationalIdTypes] FOREIGN KEY ([NationalIdType]) REFERENCES [dbo].[NationalIdTypes] ([NationalIdTypeId]),
    CONSTRAINT [FK_Employees_Places] FOREIGN KEY ([PlaceId]) REFERENCES [dbo].[Places] ([PlaceId])
);


GO
CREATE TRIGGER dbo.EmployeesChanges
ON dbo.Employees
AFTER UPDATE, DELETE
AS

IF EXISTS (
	SELECT * FROM inserted
)
	-- UPDATE Statement was executed
	INSERT INTO [dbo].[Employees_History]
        ([EmployeeId]
        ,[Username]
        ,[Firstname]
        ,[Lastname]
        ,[NationalIdNumber]
        ,[NationalIdType]
        ,[GenderId]
        ,[Birthdate]
        ,[Address]
        ,[PlaceId]
        ,[CountryId]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [EmployeeId]
        ,[Username]
        ,[Firstname]
        ,[Lastname]
        ,[NationalIdNumber]
        ,[NationalIdType]
        ,[GenderId]
        ,[Birthdate]
        ,[Address]
        ,[PlaceId]
        ,[CountryId]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'U'
	FROM deleted
ELSE
	-- DELETE Statement was executed
	INSERT INTO [dbo].[Employees_History]
        ([EmployeeId]
        ,[Username]
        ,[Firstname]
        ,[Lastname]
        ,[NationalIdNumber]
        ,[NationalIdType]
        ,[GenderId]
        ,[Birthdate]
        ,[Address]
        ,[PlaceId]
        ,[CountryId]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,[ChangeType])
	SELECT
		 [EmployeeId]
        ,[Username]
        ,[Firstname]
        ,[Lastname]
        ,[NationalIdNumber]
        ,[NationalIdType]
        ,[GenderId]
        ,[Birthdate]
        ,[Address]
        ,[PlaceId]
        ,[CountryId]
        ,[UserCreated]
        ,[DateCreated]
        ,[UserModified]
        ,[DateModified]
        ,'D'
	FROM deleted	