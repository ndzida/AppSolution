
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Delete data from AdminDB.dbo.RoleAuthorizations table
-- =============================================
CREATE PROCEDURE crud_DeleteRoleAuthorizations 
	-- Add the parameters for the stored procedure here
    @RoleId int,
	@AuthorizationId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM RoleAuthorizations
	WHERE RoleId = @RoleId AND AuthorizationId = @AuthorizationId
END
