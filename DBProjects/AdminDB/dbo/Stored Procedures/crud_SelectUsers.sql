

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Select data from AdminDB.dbo.Users table
-- =============================================
CREATE PROCEDURE [dbo].[crud_SelectUsers] 
@UserId int=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @UserId IS NULL
        BEGIN
		SELECT * FROM Users
		END
	ELSE
		BEGIN 
        SELECT * FROM Users
        WHERE UserId=@UserId 
        END
END
