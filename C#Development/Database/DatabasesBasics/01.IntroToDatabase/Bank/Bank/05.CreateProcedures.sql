USE Bank
GO

CREATE PROC p_AddAccount @ClientId INT, @AccountTypeId INT AS
BEGIN
	INSERT INTO Accounts(ClientId, AccounttypeId)
	VALUES(@ClientId, @AccountTypeId);
END
GO


p_AddAccount 2, 2;
GO

SELECT * FROM Accounts
GO

-- Deposit Procedure
CREATE PROC p_Deposit  @AccountId INT, @Amount DECIMAL(15, 2) AS
BEGIN
	UPDATE Accounts SET Balance += @Amount WHERE Id=@AccountId
END
GO

-- Withdraw Procedure
CREATE PROC p_Withdraw @AccointId INT, @Amount DECIMAL(15, 2) AS
BEGIN
	DECLARE @OldBalance DECIMAL(15, 2)	
	SELECT @OldBalance = Balance FROM Accounts WHERE Id = @AccointId
	IF (@OldBalance - @Amount = 0)
	BEGIN
		UPDATE Accounts
		SET Balance -= @Amount
		WHERE Id = @AccointId
	END
	ELSE
	BEGIN
		RAISERROR('Insufficient funds', 10, 1)
	END
END