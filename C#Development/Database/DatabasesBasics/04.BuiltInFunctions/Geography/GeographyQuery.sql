-- 10. Countries Holding 'A'
SELECT c.CountryName AS [Country Name],
	   c.IsoCode AS [Iso Code]
FROM Countries c
WHERE LEN(CountryName) - LEN(REPLACE(c.CountryName,'a','')) >=3
ORDER BY c.IsoCode

-- 11. Mix of Peak and River Names
SELECT p.PeakName,
	   r.RiverName,
	   LOWER(CONCAT(PeakName, '', SUBSTRING(RiverName, 2, LEN(RiverName) - 1))) AS Mix 
FROM Peaks p, Rivers r 
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix