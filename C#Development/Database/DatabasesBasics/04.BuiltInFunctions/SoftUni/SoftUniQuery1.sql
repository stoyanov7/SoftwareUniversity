-- 01. Find Names of All Employees by First Name
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

-- 02. Find Names of All Employees by Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

-- 03. Find First Names of All Employess
SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3, 10)
	AND (SELECT YEAR(HireDate))>= 1995 
	AND (SELECT YEAR(HireDate)) <= 2005

-- 04. Find All Employees Except Engineers
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

-- 05. Find Towns with Name Length
SELECT [Name] 
FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]

-- 06. Find Towns Starting With
SELECT * 
FROM Towns
WHERE LEFT([Name], 1) IN ('M','K','B','E')
ORDER BY [Name]

-- 07. Find Towns Not Starting With
SELECT *
FROM Towns
WHERE NOT LEFT([Name], 1) IN ('R', 'B', 'D')
ORDER BY [Name]
GO

-- 08. Create View Employees Hired After
CREATE VIEW	V_EmployeesHiredAfter2000 AS
	SELECT e.FirstName, e.LastName
	FROM Employees e
	WHERE (SELECT YEAR(e.HireDate)) > 2000
GO

SELECT *
FROM V_EmployeesHiredAfter2000

-- 09. Length of Last Name
SELECT e.FirstName, e.LastName
FROM Employees e
WHERE LEN(e.LastName) = 5