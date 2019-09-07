CREATE PROCEDURE ps_employee_delete
(
	@matricule int
)
AS
BEGIN

DELETE
FROM Employee
WHERE 0 = 0
AND matricule = @matricule

END