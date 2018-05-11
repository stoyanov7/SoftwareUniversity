--Task 17 - UDF GetReportsCount 
CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS
BEGIN
    DECLARE @num INT = (SELECT COUNT(*)
                       FROM reports
                       WHERE EmployeeId = @employeeId
                             AND StatusId = @statusId);
    RETURN @num;
END;
GO

SELECT Id,
       Firstname,
       Lastname,
       dbo.udf_GetReportsCount(Id, 2)
FROM Employees
GO

--Task 18 - Transaction - Assign Employee
CREATE PROC usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
BEGIN
    BEGIN TRAN
		DECLARE @categoryId INT= 
		(
			SELECT Categoryid
			FROM Reports
			WHERE Id = @reportId
		);

		DECLARE @employeeDepId INT= 
		(
			SELECT DepartmentId
			FROM Employees
			WHERE Id = @employeeId
		);

		DECLARE @categoryDepId INT= 
		(
			SELECT Departmentid
			FROM Categories
			WHERE Id = @categoryId
		);

		UPDATE Reports
		SET EmployeeId = @employeeId
		WHERE Id = @reportId

		IF @employeeId IS NOT NULL
		   AND @categoryDepId <> @employeeDepId
		BEGIN 
			ROLLBACK;
			THROW 50013,'Employee doesn''t belong to the appropriate department!', 1;
		END;   
    COMMIT; 
END;

EXEC usp_AssignEmployeeToReport 17, 2;
SELECT EmployeeId
FROM Reports
WHERE id = 17
GO

--Task 19 - Trigger - Close Reports
CREATE TRIGGER T_CloseReport ON Reports
AFTER UPDATE
AS
BEGIN
	UPDATE Reports
	SET StatusId =
	(
		SELECT Id
		FROM [Status]
		WHERE Label = 'completed'
	)
	WHERE Id IN 
	(
		SELECT Id
		FROM inserted
		WHERE Id IN
		(
			SELECT Id
			FROM deleted
			WHERE CloseDate IS NULL
		)
		AND CloseDate IS NOT NULL
	)   
END;

UPDATE Reports
SET CloseDate = GETDATE()
WHERE EmployeeId = 5;