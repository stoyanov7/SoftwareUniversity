-- 01. Number of Users for Email Provider
SELECT u.[Email Provider],
       COUNT(u.[Email Provider]) AS [Number Of Users]
FROM 
(
    SELECT SUBSTRING(u1.Email, CHARINDEX('@', u1.Email, 1) + 1,
           LEN(u1.Email) - CHARINDEX('@', u1.Email, 1)) AS [Email Provider]
    FROM Users AS u1
) AS u
GROUP BY u.[Email Provider]
ORDER BY [Number Of Users] DESC,
         u.[Email Provider]

-- 02. All Users in Games
SELECT g.[Name] AS Game,
       gt.[Name] AS [Game Type],
       u.Username,
       ug.[Level],
       ug.Cash,
       c.[Name] AS [Character]
FROM Games AS g
    JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
    JOIN UsersGames AS ug ON ug.GameId = g.Id
    JOIN Users AS u ON u.Id = ug.UserId
    JOIN Characters AS c ON c.Id = ug.CharacterId
ORDER BY ug.[Level] DESC,
         u.Username,
         g.[Name]

-- 03. Users in Games with Their Items
SELECT u.Username,
       g.[Name] AS Game,
       COUNT(i.Id) AS [Items Count],
       SUM(i.Price) AS [Items Price]
FROM Users AS u
     JOIN UsersGames AS ug ON ug.UserId = u.Id
     JOIN Games AS g ON g.Id = ug.GameId
     JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
     JOIN Items AS i ON i.Id = ugi.ItemId
GROUP BY g.[Name],
         u.Username
HAVING COUNT(i.Id) >= 10
ORDER BY [Items Count] DESC,
         [Items Price] DESC,
         u.Username

-- 04. User in Games with Their Statistics
SELECT u.Username,
       g.[Name] AS Game,
       MAX(c.Name) AS [Character],
       SUM(iStat.Strength) + MAX(gtStat.Strength) + MAX(cStat.Strength) AS Strength,
       SUM(iStat.Defence) + MAX(gtStat.Defence) + MAX(cStat.Defence) AS Defence,
       SUM(iStat.Speed) + MAX(gtStat.Speed) + MAX(cStat.Speed) AS Speed,
       SUM(iStat.Mind) + MAX(gtStat.Mind) + MAX(cStat.Mind) AS Mind,
       SUM(iStat.Luck) + MAX(gtStat.Luck) + MAX(cStat.Luck) AS Luck
FROM Users AS u 
    JOIN UsersGames AS ug ON ug.UserId = u.Id
    JOIN Games AS g ON g.Id = ug.GameId
    JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
    JOIN Items AS i ON i.Id = ugi.ItemId
    JOIN [Statistics] AS iStat ON iStat.Id = i.StatisticId
    JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
    JOIN [Statistics] AS gtStat ON gtStat.Id = gt.BonusStatsId
    JOIN Characters AS c ON c.Id = ug.CharacterId
    JOIN [Statistics] AS cStat ON cStat.Id = c.StatisticId 
GROUP BY u.Username,
         g.[Name]
ORDER BY Strength DESC,
         Defence DESC,
         Speed DESC,
         Mind DESC,
         Luck DESC

-- 05. All Items with Greater than Average Statistics
SELECT i.[Name],
       i.Price,
       i.MinLevel,
       s.Strength,
       s.Defence,
       s.Speed,
       s.Luck,
       s.Mind
FROM Items AS i
     JOIN [Statistics] AS s ON s.Id = i.StatisticId
WHERE s.Mind >
(
    SELECT AVG(Mind)
    FROM [Statistics]
)
AND s.Luck >
(
    SELECT AVG(Luck)
    FROM [Statistics]
)
AND s.Speed >
(
    SELECT AVG(Speed)
    FROM [Statistics]
)
ORDER BY i.[Name];

-- 06. Display All Items about Forbidden Game Type
SELECT i.[Name] AS Item,
       i.Price,
       i.MinLevel,
       gt.[Name] AS [Forbidden Game Type]
FROM Items AS i
    LEFT OUTER JOIN GameTypeForbiddenItems AS gtfi ON gtfi.ItemId = i.Id
    LEFT OUTER JOIN GameTypes AS gt ON gt.Id = gtfi.GameTypeId
ORDER BY [Forbidden Game Type] DESC,
         Item

-- 07. Buy Items for User in Game
DECLARE @userId INT =
(
    SELECT Id
    FROM Users
    WHERE Username = 'Alex'
);

DECLARE @gameId INT =
(
    SELECT Id
    FROM Games
    WHERE [Name] = 'Edinburgh'
)

-- Transaction for Blackguard
BEGIN TRANSACTION

DECLARE @itemId INT =
(
    SELECT Id
    FROM Items
    WHERE [Name] = 'Blackguard'
)

-- Get money
UPDATE UsersGames
SET Cash -= 
(
    SELECT Price
    FROM Items
    WHERE Id = @itemId
)
WHERE UserId = @userId
AND GameId = @gameId;

-- Check if Cach is still positive
IF(0 >
  (
      SELECT Cash
      FROM UsersGames
      WHERE UserId = @userId
        AND GameId = @gameId
  ))
BEGIN
	 PRINT 'Cash is not enough!'
     ROLLBACK
END

-- Assign item
INSERT INTO UserGameItems
VALUES
(@itemId,
	 (
		  SELECT Id
		  FROM UsersGames
		  WHERE UserId = @userId
		    AND GameId = @gameId
	 )
);

COMMIT
-- End of transaction

-- Transaction for Bottomless Potion of Amplification
BEGIN TRANSACTION

SET @itemId =
(
    SELECT Id
    FROM Items
    WHERE [Name] = 'Bottomless Potion of Amplification'
);

-- Get money
UPDATE UsersGames
SET Cash -= 
(
    SELECT Price
    FROM Items
    WHERE Id = @itemId
)
WHERE UserId = @userId
  AND GameId = @gameId;

-- Check if Cach is still positive
IF(0 >
  (
      SELECT Cash
      FROM UsersGames
      WHERE UserId = @userId
            AND GameId = @gameId
  ))
BEGIN
	 PRINT 'Cash is not enough!';
     ROLLBACK;
END;

-- Assign item
INSERT INTO UserGameItems
VALUES
(@itemId,
	 (
		  SELECT Id
		  FROM UsersGames
		  WHERE UserId = @userId
		    AND GameId = @gameId
	 )
);

COMMIT;
-- End of transaction

-- Transaction for Eye of Etlich (Diablo III)
BEGIN TRANSACTION;

SET @itemId =
(
    SELECT Id
    FROM Items
    WHERE [Name] = 'Eye of Etlich (Diablo III)'
);

-- Get money
UPDATE UsersGames
SET Cash -= 
(
    SELECT Price
    FROM Items
    WHERE Id = @itemId
)
WHERE UserId = @userId
  AND GameId = @gameId;

-- Check if Cach is still positive
IF(0 >
  (
      SELECT Cash
      FROM UsersGames
      WHERE UserId = @userId
            AND GameId = @gameId
  ))
BEGIN
	 PRINT 'Cash is not enough!';
     ROLLBACK;
END;

-- Assign item
INSERT INTO UserGameItems
VALUES
(@itemId,
	 (
	     SELECT Id
	     FROM UsersGames
	     WHERE UserId = @userId
	       AND GameId = @gameId
	 )
);

COMMIT;
-- End of transaction

-- Transaction for Gem of Efficacious Toxin
BEGIN TRANSACTION;

SET @itemId =
(
    SELECT Id
    FROM Items
    WHERE [Name] = 'Gem of Efficacious Toxin'
);

-- Get money
UPDATE UsersGames
SET Cash -= 
(
    SELECT Price
    FROM Items
    WHERE Id = @itemId
)
WHERE UserId = @userId
  AND GameId = @gameId;

-- Check if Cach is still positive
IF(0 >
  (
      SELECT Cash
      FROM UsersGames
      WHERE UserId = @userId
            AND GameId = @gameId
  ))
BEGIN
	 PRINT 'Cash is not enough!';
	 ROLLBACK;
END;

-- Assign item
INSERT INTO UserGameItems
VALUES
(@itemId,
	 (
	     SELECT Id
	     FROM UsersGames
	     WHERE UserId = @userId
	       AND GameId = @gameId
	 )
)

COMMIT
-- End of transaction

-- Transaction for Golden Gorget of Leoric 
BEGIN TRANSACTION;

SET @itemId =
(
    SELECT Id
    FROM Items
    WHERE [Name] = 'Golden Gorget of Leoric'
)

-- Get money
UPDATE UsersGames
SET Cash -= 
(
    SELECT Price
    FROM Items
    WHERE Id = @itemId
)
WHERE UserId = @userId
  AND GameId = @gameId

-- Check if Cach is still positive
IF(0 >
  (
      SELECT Cash
      FROM UsersGames
      WHERE UserId = @userId
            AND GameId = @gameId
  ))
BEGIN
	 PRINT 'Cash is not enough!'
     ROLLBACK
END

-- Assign item
INSERT INTO UserGameItems
VALUES
(@itemId,
	 (
	     SELECT Id
	     FROM UsersGames
	     WHERE UserId = @userId
	       AND GameId = @gameId
	 )
)

COMMIT
-- End of transaction

-- Transaction for Hellfire Amulet 
BEGIN TRANSACTION

SET @itemId =
(
    SELECT Id
    FROM Items
    WHERE [Name] = 'Hellfire Amulet'
)

-- Get money
UPDATE UsersGames
SET Cash -= 
(
    SELECT Price
    FROM Items
    WHERE Id = @itemId
)
WHERE UserId = @userId
  AND GameId = @gameId;

-- Check if Cach is still positive
IF(0 >
  (
      SELECT Cash
      FROM UsersGames
      WHERE UserId = @userId
        AND GameId = @gameId
  ))
BEGIN
	 PRINT 'Cash is not enough!'
     ROLLBACK
END

-- Assign item
INSERT INTO UserGameItems
VALUES
(@itemId,
	 (
	     SELECT Id
	     FROM UsersGames
	     WHERE UserId = @userId
	       AND GameId = @gameId
	 )
)

COMMIT
-- End of transaction

-- Final Selection
SELECT u.Username,
       g.[Name],
       ug.Cash,
       i.[Name] AS [Item Name]
FROM Users AS u
     JOIN UsersGames AS ug ON ug.UserId = u.Id
     JOIN Games AS g ON g.Id = ug.GameId
     JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
     JOIN Items AS i ON i.Id = ugi.ItemId
WHERE g.Id = @gameId
ORDER BY [Item Name]