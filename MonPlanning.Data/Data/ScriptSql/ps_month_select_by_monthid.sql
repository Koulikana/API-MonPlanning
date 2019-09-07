CREATE PROCEDURE ps_month_select_by_monthid
(
	@monthID INT
)
AS
BEGIN

SELECT *
FROM Month
WHERE 0=0
AND monthId = @monthID

END