USE SoftUni

-- 01. Employee Address
SELECT TOP(5) e.EmployeeID, 
	 e.JobTitle,
	 e.AddressId,
	 a.AddressText
FROM Employees AS e
	 JOIN Addresses AS a ON a.AddressID = e.AddressId
ORDER BY e.AddressId

-- 02. Addresses with Towns
SELECT TOP(50) e.FirstName,
	   e.LastName,
	   t.[Name] AS Town,
	   a.AddressText
FROM Employees AS e
	 JOIN Addresses AS a ON a.AddressID = e.AddressID
	 JOIN Towns AS t on t.TownID = a.TownID
ORDER BY e.FirstName,
	     e.LastName

-- 03. Sales Employees
SELECT e.EmployeeId,
	   e.FirstName,
	   e.LastName,
	   d.[Name] AS DepartmentName
FROM Employees AS e
	 JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeId	 

-- 04. Employee Departments
SELECT TOP(5) e.EmployeeID,
	   e.FirstName,
	   e.Salary,
	   d.[Name] AS DepartmentName
FROM Employees AS e
	 JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

-- 05. Employees Without Projects
SELECT TOP (3) e.EmployeeID,
               e.FirstName
FROM Employees AS e
     LEFT OUTER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID

-- 06. Employees Hired After
SELECT e.FirstName,
	   e.LastName,
	   e.HireDate,
	   d.[Name] AS DeptName
FROM Employees AS e
	 JOIN Departments AS d ON d.DepartmentId = e.DepartmentId
WHERE e.HireDate > '1999-1-1' AND
	 d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate

-- 07. Employees With Project
SELECT TOP(5) e.EmployeeID,
			  e.FirstName,
			  p.[Name] AS ProjectName
FROM EmployeesProjects AS ep
	 JOIN Employees AS e ON e.EmployeeId = ep.EmployeeID
	 JOIN Projects AS p ON p.ProjectId = ep.ProjectId
WHERE p.StartDate > '2002-08-13' AND
	  p.EndDate IS NULL
ORDER BY e.EmployeeId

-- 08. Employee 24
SELECT e.EmployeeID,
	   e.FirstName,
	   CASE
		  WHEN p.StartDate > '2005'
		  THEN NULL
		  ELSE p.[Name]
	   END 
	   AS ProjectName
FROM EmployeesProjects AS ep
	 JOIN Employees AS e ON e.EmployeeId = ep.EmployeeID
	 JOIN Projects AS p ON p.ProjectId = ep.ProjectId
WHERE e.EmployeeID = 24

-- 09. Employee Manager
SELECT e.EmployeeID,
       e.FirstName,
       e.ManagerID,
       m.FirstName AS ManagerName
FROM Employees AS e
     JOIN Employees AS m ON m.EmployeeID = e.ManagerID 
WHERE e.ManagerID IN(3, 7)
ORDER BY e.EmployeeID

-- 10. Employees Summary
SELECT TOP(50) e.EmployeeID,
	   CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	   CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	   d.[Name] AS DepartmentName
FROM Employees AS e
	 JOIN Employees AS m ON m.EmployeeID = e.ManagerID 
	 JOIN Departments AS d ON d.DepartmentId = e.DepartmentID
ORDER BY e.EmployeeID

-- 11. Min Average Salary
SELECT MIN(a.AverageSalary)
FROM
(
    SELECT AVG(Salary) AS AverageSalary
    FROM Employees
    GROUP BY DepartmentID
) AS a