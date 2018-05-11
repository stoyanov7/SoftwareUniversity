--  05. Users by Age
SELECT u.Username, u.Age
FROM Users AS u
ORDER BY u.Age,
		 u.Username DESC

-- 06. Unassigned Reports
SELECT r.[Description], r.OpenDate
FROM Reports AS r
WHERE r.EmployeeId IS NULL
ORDER BY r.OpenDate,
		 r.[Description]

-- 07. Employees & Reports
SELECT e.Firstname,
       e.Lastname,
       r.[Description],
       FORMAT(r.Opendate, 'yyyy-MM-dd') AS OpenDate
FROM Employees AS e
	JOIN Reports AS r ON r.EmployeeId = e.Id
ORDER BY e.Id,
		 r.OpenDate

-- 08. Most Reported Category
SELECT c.[Name] AS CategoryName,
	  COUNT(*) AS ReportsNumber
FROM Categories AS c
	JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC,
		 CategoryName

-- 09. Employees in Category
SELECT c.[Name],
	  COUNT(c.Id) AS NumberEmployees
FROM Categories  AS c
	 JOIN Departments AS d ON d.Id = c.DepartmentId
	 JOIN Employees AS E ON e.DepartmentId = d.Id
GROUP BY c.[Name]

-- 10. Users per Employee
SELECT CONCAT(e.FirstName, ' ' ,e.LastName) AS FullName,
	  COUNT(DISTINCT r.UserId) AS UsersCount
FROM Employees AS e
	LEFT JOIN Reports AS r ON r.EmployeeId = e.Id
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY UsersCount DESC,
		 FullName

-- 11. Emergency Patrol
SELECT r.OpenDate,
	  r.[Description],
       u.Email AS [Reporter Email]
FROM Reports AS r
	JOIN Users AS u ON u.Id = r.UserId
	JOIN Categories c ON c.Id = r.CategoryId
	JOIN Departments d ON d.Id = c.DepartmentId
WHERE r.CloseDate IS NULL AND
	 r.[Description] LIKE '%str%' AND
	 d.Id IN (1, 4, 5)
ORDER BY r.OpenDate,
	    [Reporter Email]

-- 13. Numbers Coincidence
SELECT DISTINCT u.Username
FROM Users AS u
	 JOIN Reports AS r ON r.UserId = u.Id
	 JOIN Categories AS c ON c.Id = r.CategoryId
WHERE (Username LIKE '[0-9]_%' AND CAST(c.Id AS VARCHAR) = LEFT(u.Username, 1)) OR
      (Username LIKE '%_[0-9]' AND CAST(c.Id AS VARCHAR) = RIGHT(u.Username, 1))

-- 14. Open/Closed Statistics
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName, 
	  ISNULL(CONVERT(VARCHAR, cc.ReportSum), '0') + '/' +        
       ISNULL(CONVERT(VARCHAR, oc.ReportSum), '0') AS [Stats]
FROM Employees AS e
JOIN (SELECT EmployeeId, COUNT(1) AS ReportSum
	  FROM Reports r
	  WHERE  YEAR(OpenDate) = 2016
	  GROUP BY EmployeeId) AS oc ON oc.EmployeeId = e.Id
LEFT JOIN (SELECT EmployeeId, COUNT(1) AS ReportSum
	       FROM Reports AS r
	       WHERE YEAR(CloseDate) = 2016
	       GROUP BY EmployeeId) AS cc ON cc.Employeeid = e.Id
ORDER BY FullName

-- 15. Average Closing Time
SELECT d.[Name] AS Departmentname,
       ISNULL(CONVERT(VARCHAR, AVG(DATEDIFF(DAY, R.Opendate, R.Closedate))), 'no info') AS AverageTime
FROM Departments AS d
     JOIN Categories AS c ON c.DepartmentId = d.Id
     LEFT JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY d.[Name]
ORDER BY d.[Name]

-- 16. Favorite Categories
SELECT Department, Category, [Percentage]
FROM 
(
	SELECT d.[Name] AS Department,
		    c.[Name] AS Category,
		    CAST(
			     ROUND(
				       COUNT(1) OVER(PARTITION BY c.Id) * 100.00 / COUNT(1) OVER(PARTITION BY d.Id), 0
					  ) AS INT
				) AS [Percentage]
     FROM Categories AS c
		  JOIN Reports AS r ON r.Categoryid = c.Id
		  JOIN Departments AS d ON d.Id = c.Departmentid
) AS [Stats]
GROUP BY Department,
         Category,
         [Percentage]
ORDER BY Department,
         Category,
         [Percentage]