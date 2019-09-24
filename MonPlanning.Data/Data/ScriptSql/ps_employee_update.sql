CREATE PROCEDURE ps_employee_update
(
	@matricule INT,
	@firstName VARCHAR(300),
	@lastName VARCHAR(300),
	@birthDate DATE,
	@email VARCHAR(300),
	@password VARCHAR(300)
)
AS
BEGIN

UPDATE Employee
SET firstName = @firstName,
	lastName = @lastName,
	birthDate = @birthDate,
	email = @email,
	password = @password

WHERE matricule = @matricule

END