﻿
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Update data to AdminDB.dbo.Applications table
-- =============================================
CREATE PROCEDURE [dbo].[crud_UpdateApplications] 
	-- Add the parameters for the stored procedure here
    @ApplicationTitle varchar(20),
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
	UPDATE Applications
    SET	ApplicationTitle = @ApplicationTitle,
		UserCreated = 	@UserCreated,
		DateCreated = 	@DateCreated,
		UserModified = 	@UserModified,
		DateModified =	@DateModified
END