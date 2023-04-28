
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Update data to AdminDB.dbo.Authorizations table
-- =============================================
CREATE PROCEDURE crud_UpdateAuthorizations 
	-- Add the parameters for the stored procedure here
    @AuthorizationTitle varchar(20),
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
	UPDATE Authorizations
    SET	AuthorizationTitle = @AuthorizationTitle,
		UserCreated = @UserCreated,
		DateCreated = @DateCreated,
		UserModified = @UserModified,
		DateModified = @DateModified
END
