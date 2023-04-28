CREATE TABLE [dbo].[RoleAuthorizations] (
    [RoleId]          INT NOT NULL,
    [AuthorizationId] INT NOT NULL,
    CONSTRAINT [FK_RoleAuthorizations_Authorizations] FOREIGN KEY ([AuthorizationId]) REFERENCES [dbo].[Authorizations] ([AuthorizationId]),
    CONSTRAINT [FK_RoleAuthorizations_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId])
);

