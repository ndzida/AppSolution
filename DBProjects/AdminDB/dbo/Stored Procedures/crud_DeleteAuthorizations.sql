
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Delete data from AdminDB.dbo.Authorizations table
-- =============================================
CREATE PROCEDURE crud_DeleteAuthorizations 
	-- Add the parameters for the stored procedure here
    @AuthorizationId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Authorizations
	WHERE AuthorizationId = @AuthorizationId
END
