-- 05. Clients by Name
SELECT c.FirstName,
	   c.LastName,
	   c.Phone
FROM Clients AS c
ORDER BY c.LastName,
	     c.ClientId

-- 06. Job Status
SELECT j.[Status],
	   j.IssueDate
FROM Jobs AS j
WHERE j.[Status] = 'In Progress' OR
      j.[Status] = 'Pending'
ORDER BY j.IssueDate,
	     j.JobId

-- 07. Mechanic Assignments
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	   j.[Status],
	   j.IssueDate
FROM Jobs AS j
	 JOIN Mechanics AS m ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId,
		 j.IssueDate,
		 j.JobId

-- 08. Current Clients
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client,
	   DATEDIFF(DAY, IssueDate, '24 April 2017') AS [Days going],
	   j.[Status]
FROM Jobs AS j
	 JOIN Clients AS c ON c.ClientId = j.ClientId
WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC,
	 c.ClientId

-- 09. Mechanic Performance
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	   CEILING(AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate))) AS [Average Days]
FROM Jobs AS j
	 JOIN Mechanics AS m ON m.MechanicId = j.MechanicId
GROUP BY CONCAT(m.FirstName, ' ', m.LastName),
	     m.MechanicId
ORDER BY m.MechanicId

-- 10. Hard Earners
SELECT TOP (3) WITH TIES CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
						 COUNT(j.JobId) AS Jobs
FROM Jobs AS j
	 JOIN Mechanics AS m ON m.MechanicId = j.MechanicId
WHERE j.[Status] != 'Finished'
GROUP BY CONCAT(m.FirstName, ' ', m.LastName),
	     m.MechanicId
HAVING COUNT(j.JobId) > 1
ORDER BY Jobs DESC,
	 m.MechanicId

-- 11. Available Mechanics
SELECT CONCAT(FirstName, ' ', LastName) AS Available
FROM Mechanics
WHERE MechanicId NOT IN
(
    SELECT DISTINCT
           m.MechanicId
    FROM Mechanics AS m
         JOIN Jobs AS j ON j.MechanicId = m.MechanicId
    WHERE j.[Status] != 'Finished'
)
ORDER BY MechanicId

-- 12. Parts Cost
SELECT ISNULL(SUM(Price * Quantity), 0) AS [Parts Total]
FROM
(
    SELECT p.Price,
           op.Quantity,
		   DATEDIFF(WEEK, o.IssueDate, '24 April 2017') AS Weeks
    FROM Parts AS p
         JOIN OrderParts AS op ON op.PartId = p.PartId
         JOIN Orders AS o ON o.OrderId = op.OrderId
) AS WeeksAndPrices
WHERE Weeks <= 3

-- 13. Past Expenses
SELECT j.JobId,
	   ISNULL(SUM(p.Price * op.Quantity), 0.00) AS Total
FROM Jobs AS j
	 LEFT JOIN Orders AS o ON o.JobId = j.JobId
     LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
	 LEFT JOIN Parts AS p ON p.PartId = op.PartId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC,
	     j.JobId

-- 14. Model Repair Time
SELECT m.ModelId,
	   m.[Name],
	   CONCAT(CEILING(AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate))), ' days') AS [Average Service Time]
FROM Jobs AS j
	 JOIN Models AS m ON m.ModelId = j.ModelId
GROUP BY m.ModelId,
	     m.[Name]
ORDER BY CEILING(AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)))

-- 15. Faultiest Model
SELECT TOP (1) 
WITH TIES m.[Name] AS Model,
          COUNT(*) AS [Times Serviced],
		  (
		      SELECT ISNULL(SUM(p.Price * op.Quantity), 0) AS [Parts Total]
		      FROM Parts AS p
		           JOIN OrderParts AS op ON op.PartId = p.PartId
		           JOIN Orders AS o ON o.OrderId = op.OrderId
		           JOIN Jobs AS j ON j.JobId = o.JobId
		      WHERE j.ModelId = m.ModelId
		  ) AS [Parts Total]
FROM Models AS m
     JOIN Jobs AS j ON j.ModelId = m.ModelId
GROUP BY m.ModelId,
         m.[Name]
ORDER BY COUNT(*) DESC

-- 16. Missing Parts
SELECT p.PartId,
       p.[Description],
       ISNULL(pn.Quantity, 0) AS [Required],
       ISNULL(p.StockQty, 0) AS [In Stock],
       ISNULL(CASE
                  WHEN o.Delivered = 0
                  THEN op.Quantity
                  ELSE 0
              END, 0) AS Ordered
FROM Parts AS p
     JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
     LEFT JOIN OrderParts AS op ON op.PartId = p.PartId
     JOIN Jobs AS j ON j.JobId = pn.JobId
     LEFT JOIN Orders AS o ON o.JobId = j.JobId
WHERE pn.Quantity > ISNULL(p.StockQty + CASE
                                            WHEN o.Delivered = 0
                                            THEN op.Quantity
                                            ELSE 0
                                        END, 0)
      AND j.[Status] != 'Finished'
ORDER BY p.PartId