-- 08. Peaks and Mountains 
SELECT p.PeakName,
       m.MountainRange AS Mountain,
       p.Elevation
FROM Peaks AS p 
    JOIN Mountains AS m ON m.Id = p.MountainId
ORDER BY p.Elevation DESC,
         p.PeakName

-- 09. Peaks with Mountain, Country and Continent 
SELECT p.PeakName,
       m.MountainRange AS Mountain,
       c.CountryName,
       ct.ContinentName
FROM Peaks AS p 
    JOIN Mountains AS m ON m.Id = p.MountainId
    JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
    JOIN Countries AS c ON c.CountryCode = mc.CountryCode
    JOIN Continents AS ct ON ct.ContinentCode = c.ContinentCode
WHERE
(
    SELECT COUNT(ssmc.MountainId)
    FROM MountainsCountries AS ssmc
    WHERE ssmc.MountainId = mc.MountainId 
) > 1
ORDER BY p.PeakName,
         c.CountryName

-- 10. Rivers by Country 
SELECT c.CountryName,
       ct.ContinentName,
       COUNT(r.Id) AS RiversCount,
       ISNULL(SUM(r.Length), 0) AS TotalLength
FROM Countries AS c
     JOIN Continents AS ct ON ct.ContinentCode = c.ContinentCode
     LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
     LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName,
         ct.ContinentName
ORDER BY RiversCount DESC,
         TotalLength DESC,
         CountryName

-- 11. Count of Countries by Currency 
SELECT currencies.CurrencyCode,
       currencies.[Description] AS Currency,
       COUNT(countries.CountryCode) AS NumberOfCountries
FROM Currencies AS currencies 
    LEFT JOIN Countries AS countries ON currencies.CurrencyCode = countries.CurrencyCode
GROUP BY currencies.CurrencyCode,
         currencies.[Description] 
ORDER BY NumberOfCountries DESC,
         Currency

-- 12. Population and Area by Continent 
SELECT continents.ContinentName,
       SUM(CAST(cntr.AreaInSqKm AS BIGINT)) AS CountriesArea,
       SUM(CAST(cntr.[Population] AS BIGINT)) AS CountriesPopulation
FROM Continents AS continents
     JOIN Countries AS cntr ON cntr.ContinentCode = continents.ContinentCode
GROUP BY continents.ContinentName
ORDER BY CountriesPopulation DESC

-- 13. Monasteries by Country
CREATE TABLE Monasteries
(
    Id INT IDENTITY NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    CountryCode CHAR(2) NOT NULL,
    CONSTRAINT PK_Monasteries
    PRIMARY KEY(Id),

    CONSTRAINT FK_Monasteries_Countries 
    FOREIGN KEY(CountryCode) 
    REFERENCES Countries(CountryCode)
)

INSERT INTO Monasteries([Name], CountryCode)
VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

ALTER TABLE Countries
ADD IsDeleted BIT DEFAULT 0

UPDATE Countries
SET IsDeleted = 0

UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN
(
    SELECT c.CountryCode
    FROM Countries AS c
         JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
    GROUP BY c.CountryCode
    HAVING COUNT(cr.RiverId) > 3
)

SELECT m.[Name] AS Monastery,
       c.CountryName AS Country
FROM Monasteries AS m
     JOIN Countries AS c ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
ORDER BY Monastery

-- 14. Monasteries by Continents and Countries 
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

DECLARE @TanzaniaCountryCode INT = 
(
    SELECT CountryCode 
    FROM Countries
    WHERE CountryName = 'Tanzania'
)

DECLARE @MyanmarCountryCode INT = 
(
    SELECT CountryCode
    FROM Countries
    WHERE CountryName = 'Myanmar'
)

INSERT INTO Monasteries
VALUES
('Hanga Abbey', @TanzaniaCountryCode),
('Myin-Tin-Daik', @MyanmarCountryCode)

SELECT cnt.ContinentName,
       cntr.CountryName,
       COUNT(m.Id) AS MonasteriesCount
FROM Continents AS cnt
     LEFT OUTER JOIN Countries AS cntr ON cntr.ContinentCode = cnt.ContinentCode
     LEFT OUTER JOIN Monasteries AS m ON m.CountryCode = cntr.CountryCode
WHERE cntr.IsDeleted = 0
GROUP BY cnt.ContinentName,
         cntr.CountryName
ORDER BY MonasteriesCount DESC,
         CountryName