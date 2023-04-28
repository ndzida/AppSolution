
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Delete data from AdminDB.dbo.Roles table
-- =============================================
CREATE PROCEDURE crud_DeleteRoles 
	-- Add the parameters for the stored procedure here
    @RoleId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Roles
	WHERE RoleId = @RoleId
END
