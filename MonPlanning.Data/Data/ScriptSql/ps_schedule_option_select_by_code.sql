CREATE PROCEDURE ps_schedule_option_select_by_code
(
	@code VARCHAR(30)
)
AS
BEGIN

SELECT *
FROM ScheduleOption
WHERE 0=0
AND code = @code

END