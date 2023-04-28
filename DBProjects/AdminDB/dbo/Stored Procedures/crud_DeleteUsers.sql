
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Delete data from AdminDB.dbo.Users table
-- =============================================
CREATE PROCEDURE crud_DeleteUsers 
	-- Add the parameters for the stored procedure here
    @UserId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Users
	WHERE UserId = @UserId
END
