CREATE FUNCTION fn_GetUserApplications (
	@UserId INT
)
RETURNS TABLE AS
RETURN
	SELECT *
	FROM dbo.UserApplications
	WHERE UserId = @UserId