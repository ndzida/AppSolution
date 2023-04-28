CREATE TABLE [dbo].[NationalIdTypes] (
    [NationalIdTypeId]    INT           IDENTITY (1, 1) NOT NULL,
    [NationalIdTypeTitle] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_NationalIdTypes] PRIMARY KEY CLUSTERED ([NationalIdTypeId] ASC)
);

