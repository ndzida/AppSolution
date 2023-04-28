
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Delete data from AdminDB.dbo.Applications table
-- =============================================
CREATE PROCEDURE crud_DeleteApplications 
	-- Add the parameters for the stored procedure here
    @ApplicationId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Applications
	WHERE ApplicationId = @ApplicationId
END
