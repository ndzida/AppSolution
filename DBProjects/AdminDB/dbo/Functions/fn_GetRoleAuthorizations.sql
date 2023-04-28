
CREATE FUNCTION fn_GetRoleAuthorizations (
	@RoleId INT
)
RETURNS TABLE AS
RETURN
	SELECT *
	FROM dbo.RoleAuthorizations
	WHERE RoleId = @RoleId;