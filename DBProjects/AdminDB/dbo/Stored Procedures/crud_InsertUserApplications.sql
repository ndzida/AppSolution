-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Insert data to AdminDB.dbo.UserApplications table
-- =============================================
CREATE PROCEDURE crud_InsertUserApplications 
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
	INSERT INTO UserApplications
          (UserId,
           ApplicationId,
		   RoleId)
     VALUES
          (@UserId,
		   @ApplicationId,
		   @RoleId)
END
