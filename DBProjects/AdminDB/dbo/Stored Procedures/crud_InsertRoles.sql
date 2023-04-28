-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Insert data to AdminDB.dbo.Roles table
-- =============================================
CREATE PROCEDURE crud_InsertRoles 
	-- Add the parameters for the stored procedure here
    @RoleTitle varchar(20),
    @UserCreated varchar(20),
    @DateCreated datetime,
    @UserModified varchar(20),
    @DateModified datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Roles
          (RoleTitle,
           UserCreated,
           DateCreated,
           UserModified,
           DateModified)
     VALUES
          (@RoleTitle,
           @UserCreated,
           @DateCreated,
           @UserModified,
           @DateModified)
END
