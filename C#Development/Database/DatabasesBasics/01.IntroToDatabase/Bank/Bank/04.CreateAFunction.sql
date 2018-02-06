USE Bank
GO

CREATE FUNCTION f_CalculateTotalBalance(@clientId INT) RETURNS DECIMAL(15, 2)
	BEGIN
		DECLARE @result AS DECIMAL(15, 2)=
        (
			SELECT SUM(Balance)
			FROM Accounts
			WHERE ClientId = @clientId
        );
        RETURN @result;
    END;
GO

SELECT dbo.f_CalculateTotalBalance(4) AS Balance;