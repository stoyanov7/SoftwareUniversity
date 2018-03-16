-- 12. Games From 2011 and 2012 Year
SELECT TOP 50 g.[Name],
			  FORMAT(g.[Start],'yyyy-MM-dd') AS [Start Date] 
FROM Games g
WHERE (SELECT YEAR(g.[Start])) IN (2011,2012)
ORDER BY [Start Date], g.[Name]

-- 13. User Email Providers
SELECT u.Username, 
	   SUBSTRING(Email, CHARINDEX('@',Email) + 1, LEN(Email)) AS[Email Provider] 
FROM Users u
ORDER BY [Email Provider],
		 u.Username

-- 14. Get Users with IPAddress Like Pattern
SELECT u.Username, u.IpAddress 
FROM Users u
WHERE u.IpAddress LIKE '___.1%.%.___'
ORDER BY u.Username