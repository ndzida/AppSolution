
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Delete data from AdminDB.dbo.UserApplications table
-- =============================================
CREATE PROCEDURE crud_DeleteUserApplications 
	-- Add the parameters for the stored procedure here
    @UserId int,
	@ApplicationId int,
	@RoleId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM UserApplications
	WHERE UserId = @UserId AND ApplicationId = @ApplicationId AND RoleId = @RoleId
END
