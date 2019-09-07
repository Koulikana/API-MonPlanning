CREATE PROCEDURE ps_employee_select_by_matricule
(
	@matricule INT
)

AS
BEGIN

SELECT *
FROM Employee
WHERE 0=0
AND matricule = @matricule

END