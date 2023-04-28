CREATE FUNCTION fn_GetDayType (
	@Date DATETIME
)
RETURNS varchar(10)
AS
BEGIN
	DECLARE @return_value varchar(10)
	SELECT @return_value = DATENAME (WEEKDAY, @Date)
	RETURN @return_value
END