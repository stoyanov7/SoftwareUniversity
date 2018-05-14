-- 05. Products By Price
SELECT p.[Name], p.Price, p.[Description]
FROM Products AS p
ORDER BY p.Price DESC,
	    p.[Name]

-- 06. Ingredients
SELECT i.[Name], i.[Description], i.OriginCountryId
FROM Ingredients AS i
WHERE i.OriginCountryId IN (1, 10, 20)
ORDER BY i.Id

-- 07. Ingredients from Bulgaria and Greece
SELECT TOP (15)
	  i.[Name],
	  i.[Description],
	  c.[Name] AS CountryName
FROM Ingredients AS i
	JOIN Countries AS c ON c.Id = i.OriginCountryId
WHERE c.[Name] IN ('Bulgaria', 'Greece')
ORDER BY i.[Name],
	    c.[Name]

-- 08. Best Rated Products
SELECT TOP (10) 
	  p.[Name],
	  p.[Description],
	  AVG(f.Rate) AS AverageRate,
	  COUNT(*) AS FeedbacksAmount
FROM Products AS p
	JOIN Feedbacks AS f ON f.ProductId = p.Id
GROUP BY p.[Name],
	    p.[Description]
ORDER BY AverageRate DESC,
	    FeedbacksAmount DESC

-- 09. Negative Feedback
SELECT f.ProductId, 
	  f.Rate,
	  f.[Description],
	  c.Id AS CustomerId,
	  c.Age,
	  c.Gender
FROM Feedbacks AS f
	JOIN Customers AS c ON c.Id = f.CustomerId
WHERE f.Rate < 5
ORDER BY f.ProductId DESC,
	    f.Rate

-- 10. Customers without Feedback
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
	  c.PhoneNumber,
	  c.Gender
FROM Customers AS c
	LEFT JOIN Feedbacks AS f ON f.CustomerId = c.Id
WHERE f.CustomerId IS NULL
ORDER BY c.Id

-- 11. Honorable Mentions
SELECT f.ProductId,
	  CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
	  f.[Description] AS FeedbackDescription
FROM Feedbacks AS f
	JOIN Customers AS c ON c.Id = f.CustomerId
WHERE f.CustomerId IN
(
	SELECT CustomerId
	FROM Feedbacks
	GROUP BY CustomerId
	HAVING COUNT(*) >= 3
)
ORDER BY f.ProductId,
         CustomerName,
	    f.Id

-- 12. Customers by Criteria
SELECT customer.FirstName,
	  customer.Age,
	  customer.PhoneNumber
FROM Customers AS customer
	 JOIN Countries AS countries ON countries.Id = customer.CountryId
WHERE customer.Age >= 21 AND
	 customer.[FirstName] LIKE '%an%' OR
	 (RIGHT(customer.PhoneNumber, 2) = '38' AND 
	 countries.[Name] != 'Greece')
ORDER BY customer.FirstName,
	    customer.Age DESC

-- 13. Middle Range Distributors
SELECT d.[Name] AS DistributorName,
	  i.[Name] AS IngredientName,
	  p.[Name] AS ProductName,
	  AVG(f.Rate) AS AverageRate
FROM Distributors AS d
	JOIN Ingredients AS i ON i.DistributorId = d.Id
     JOIN ProductsIngredients AS pi ON pi.IngredientId = i.Id
     JOIN Products AS p ON p.Id = pi.ProductId
	JOIN Feedbacks AS f ON f.ProductId = p.Id
GROUP BY d.[Name],
         i.[Name],
	    p.[Name]
HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY DistributorName,
         IngredientName,
	    ProductName

-- 14. The Most Positive Country
SELECT TOP (1) WITH TIES
	  c.[Name] AS CountryName,
	  AVG(f.Rate) AS FeedbackRate
FROM Countries AS c
	JOIN Customers AS customer ON customer.CountryId = c.Id
	JOIN Feedbacks AS f ON f.CustomerId = customer.Id
GROUP BY c.[Name]
ORDER BY FeedbackRate DESC

-- 15. Country Representative
SELECT CountryName,
       DisributorName
FROM
(
	SELECT c.[Name] AS CountryName,
		  d.[Name] AS DisributorName,
		  COUNT(i.DistributorId) AS IngredientsByDistributor,
		  DENSE_RANK() OVER
		  (
			 PARTITION BY c.[Name]
			 ORDER BY COUNT(i.DistributorId) DESC
		  ) AS [Rank]
	FROM Countries AS c
		 LEFT JOIN Distributors AS d ON d.CountryId = c.Id
		 LEFT JOIN Ingredients AS i ON i.DistributorId = d.Id
	GROUP BY c.[Name],
			    d.[Name]
) AS Ranked
WHERE [Rank] = 1
ORDER BY CountryName,
	    DisributorName

-- 20. Products by One Distributor
SELECT p.[Name] AS ProductName,
       AVG(f.Rate) AS ProductAverageRate,
       d.[Name] AS DistributorName,
       c.[Name] AS DistributorCountry
FROM Products AS p
     JOIN Feedbacks AS f ON f.ProductId = p.Id
     JOIN ProductsIngredients AS pi ON pi.ProductId = p.Id
     JOIN Ingredients AS i ON i.Id = pi.IngredientId
     JOIN Distributors AS d ON d.Id = i.DistributorId
     JOIN Countries AS c ON c.Id = d.CountryId
GROUP BY p.[Name],
         p.id,
         d.[Name],
         c.[Name]
HAVING p.Id IN
(
    SELECT p.Id
    FROM Products AS p
         JOIN ProductsIngredients AS pi ON pi.ProductId = p.Id
         JOIN Ingredients AS i ON i.Id = pi.IngredientId
    GROUP BY p.[Name],
             p.Id
    HAVING COUNT(DISTINCT i.DistributorId) = 1
)
ORDER BY p.Id