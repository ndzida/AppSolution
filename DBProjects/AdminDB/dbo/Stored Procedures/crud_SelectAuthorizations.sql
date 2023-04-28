

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Select data from AdminDB.dbo.Authorizations table
-- =============================================
CREATE PROCEDURE [dbo].[crud_SelectAuthorizations] 
@AuthorizationId int=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @AuthorizationId IS NULL
        BEGIN
		SELECT * FROM Authorizations
		END
	ELSE
		BEGIN 
        SELECT * FROM Authorizations
        WHERE AuthorizationId=@AuthorizationId 
        END
END
