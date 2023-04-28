




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Select data from AdminDB.dbo.Applications table
-- =============================================
CREATE PROCEDURE [dbo].[crud_SelectApplications] 
@ApplicationId int=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @ApplicationId IS NULL
        BEGIN
		SELECT * FROM Applications
		END
	ELSE
		BEGIN 
        SELECT * FROM Applications
        WHERE ApplicationId=@ApplicationId 
        END
END
