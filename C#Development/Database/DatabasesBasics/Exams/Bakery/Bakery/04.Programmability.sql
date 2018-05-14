-- 16. Customers With Countries
CREATE VIEW v_UserWithCountries
AS
     SELECT CONCAT(customer.FirstName+' ', customer.LastName) AS CustomerName,
            customer.Age,
            customer.Gender,
            countries.[Name] AS CountryName
     FROM Customers AS customer
		JOIN Countries AS countries ON countries.Id = customer.CountryId
GO


GO

CREATE FUNCTION udf_GetRating(@productName NVARCHAR(25))
RETURNS VARCHAR(9)
AS 
	BEGIN
		DECLARE @productRate DECIMAL(4, 2) = 
		(
			SELECT AVG(f.Rate)
			FROM Products AS p
				JOIN Feedbacks AS f ON f.ProductId = p.Id
			WHERE p.[Name] = @productName
		);

		IF (@productRate IS NULL)
			BEGIN
				 RETURN 'No rating';
			END
		IF(@productRate < 5)
			BEGIN
                 RETURN 'Bad';
			END
         IF(@productRate <= 8)
			BEGIN
                 RETURN 'Average';
			END
	    RETURN 'Good';
	END
GO

-- 18. Send Feedback
CREATE PROCEDURE usp_SendFeedback(@customerId INT, @productId INT, @rate DECIMAL(4, 2),  @description NVARCHAR(255))
AS
BEGIN
	DECLARE @feedbacksFromThisCustomerForThisProduct INT=
	(
		SELECT COUNT(*)
		FROM Feedbacks
		WHERE CustomerId = @customerId
	);

	IF (@feedbacksFromThisCustomerForThisProduct >= 3)
		BEGIN
			RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1)
		END

	INSERT INTO Feedbacks(CustomerId, ProductId, Rate, [Description])
     VALUES (@customerId, @productId, @rate,@description)
END
GO

EXEC usp_SendFeedback 1, 5, 7.50, 'Average experience'

SELECT COUNT(*)
FROM Feedbacks
WHERE CustomerId = 1 AND ProductId = 5
GO

CREATE TRIGGER tr_DeleteProduct ON Products
INSTEAD OF DELETE
AS
     BEGIN
         DECLARE @productId INT=
         (
             SELECT Id
             FROM Deleted
         );

	    -- Delete Feedbacks
         DELETE FROM Feedbacks
         WHERE ProductId = @productId;

	    -- Delete ProductIngredient relations
         DELETE FROM ProductsIngredients
         WHERE ProductId = @productId;

	    -- Delete Product
         DELETE FROM Products
         WHERE Id = @productId;
END