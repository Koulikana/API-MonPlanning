CREATE PROCEDURE ps_employee_insert
(
	@firstName VARCHAR(300),
	@lastName VARCHAR(300),
	@birthDate DATE,
	@email VARCHAR(300),
	@password VARCHAR(300)
)
AS
BEGIN

INSERT INTO Employee(firstName,
					 lastName,
					 birthDate,
					 email,
					 password)
VALUES(@firstName,
	   @lastName,
	   @birthDate,
	   @email,
	   @password)
END