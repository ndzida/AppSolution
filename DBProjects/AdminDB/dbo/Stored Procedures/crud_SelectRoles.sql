

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Select data from AdminDB.dbo.Roles table
-- =============================================
CREATE PROCEDURE [dbo].[crud_SelectRoles] 
@RoleId int=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @RoleId IS NULL
        BEGIN
		SELECT * FROM Roles
		END
	ELSE
		BEGIN 
        SELECT * FROM Roles
        WHERE RoleId=@RoleId 
        END
END
