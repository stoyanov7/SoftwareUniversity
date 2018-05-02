USE Geography

SELECT MountainRange,
       PeakName,
       Elevation
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId = m.Id
WHERE p.MountainId =
(
    SELECT Id
    FROM Mountains
    WHERE MountainRange = 'Rila'
)
ORDER BY p.Elevation DESC