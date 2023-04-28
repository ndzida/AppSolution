CREATE TABLE [dbo].[UserApplications] (
    [UserId]        INT NOT NULL,
    [ApplicationId] INT NOT NULL,
    [RoleId]        INT NOT NULL,
    CONSTRAINT [FK_UserApplications_Applications] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[Applications] ([ApplicationId]),
    CONSTRAINT [FK_UserApplications_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId]),
    CONSTRAINT [FK_UserApplications_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

