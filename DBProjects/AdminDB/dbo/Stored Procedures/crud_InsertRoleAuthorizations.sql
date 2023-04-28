-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Insert data to AdminDB.dbo.RoleAuthorizations table
-- =============================================
CREATE PROCEDURE crud_InsertRoleAuthorizations 
	-- Add the parameters for the stored procedure here
    @RoleId int,
	@AuthorizationId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO RoleAuthorizations
          (RoleId,
           AuthorizationId)
     VALUES
          (@RoleId,
		   @AuthorizationId)
END
