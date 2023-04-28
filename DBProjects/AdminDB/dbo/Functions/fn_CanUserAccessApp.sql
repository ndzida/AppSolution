CREATE FUNCTION [dbo].[fn_CanUserAccessApp] (
	@UserId INT,
	@ApplicationId INT
)
RETURNS BIT AS
BEGIN
	DECLARE @return_value BIT;
	SET @return_value = 0;
    IF ((SELECT COUNT(*)
		 FROM dbo.UserApplications
		 WHERE UserId=@UserId AND ApplicationId=@ApplicationId) > 0)
		SET @return_value = 1;
    RETURN @return_value
END;