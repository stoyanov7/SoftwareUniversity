USE [Geography]

-- 12. Highest Peaks in Bulgaria
SELECT c.CountryCode,
       m.MountainRange,
       p.PeakName,
       p.Elevation
FROM Countries AS c
     JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
     JOIN Mountains AS m ON mc.MountainId = m.Id
     JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryName = 'Bulgaria'
      AND p.Elevation > 2835
ORDER BY p.Elevation DESC

-- 13. Count Mountain Ranges
SELECT c.CountryCode,
       COUNT(mc.MountainId) AS MountainRanges
FROM Countries AS c
     JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
GROUP BY mc.CountryCode,
         c.CountryCode,
         CountryName
HAVING c.CountryName IN('United States', 'Russia', 'Bulgaria') 

-- 14. Countries With or Without Rivers
SELECT * FROM CountriesRivers