-- 01. Create tables
CREATE TABLE Clinents
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL
)

CREATE TABLE AccountTypes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	AccounttypeId INT FOREIGN KEY REFERENCES AccountTypes(Id),
	Balance DECIMAL(15, 2) NOT NULL DEFAULT 0,
    ClientId INT FOREIGN KEY REFERENCES Clients(Id)
)

-- 02. Insert Sample Data
INSERT INTO Clients(FirstName, LastName) VALUES
('Georgi', 'Stoyanov'),
('Pesho', 'Petrov'),
('Ivan', 'Iliev'),
('Merry', 'Ivanova');

INSERT INTO AccountTypes(Name) VALUES
('Checking'),
('Savings');

INSERT INTO Accounts(ClientId, AccounttypeId, Balance) VALUES
(1, 1, 175),
(2, 1, 275.56),
(3, 1, 138.01),
(4, 1, 40.30),
(4, 2, 375.50);
GO

-- 03. Create a View
CREATE VIEW v_ClientBalances AS
	SELECT(FirstName + ' ' + LastName) AS [Name],
		(AccountTypes.Name) AS [Account Type],
        Balance
    FROM Clients
          JOIN Accounts ON Clients.Id = Accounts.ClientId
          JOIN AccountTypes ON AccountTypes.Id = Accounts.AccounttypeId;
GO

SELECT * FROM v_ClientBalances;
Go

-- 04 Create a function
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
GO 

-- 05. CreateProcedures
CREATE PROC p_AddAccount @ClientId INT, @AccountTypeId INT AS
BEGIN
	INSERT INTO Accounts(ClientId, AccounttypeId)
	VALUES(@ClientId, @AccountTypeId);
END
GO

p_AddAccount 2, 2;
GO

SELECT *
FROM Accounts
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

-- 06. Create transactions table
CREATE TABLE Transactions
(
	Id INT PRIMARY KEY IDENTITY,
	AccountId  INT FOREIGN KEY REFERENCES Accounts(Id),
	OldBalance DECIMAL(15, 2) NOT NULL,
	NewBalance DECIMAL(15, 2) NOT NULL,
	Amount AS NewBalance - OldBalance,
	[DateTime] DATETIME2
)
GO

-- 07. Create triger
CREATE TRIGGER tr_Transaction ON Accounts AFTER UPDATE AS
	INSERT INTO Transactions(AccountId, OldBalance, NewBalance, [DateTime]                             )
    SELECT inserted.Id, deleted.Balance, inserted.Balance, GETDATE()
    FROM inserted
	JOIN deleted ON inserted.Id = deleted.Id;

GO

p_Deposit 1, 25.00
GO

p_Deposit 1, 40.00
GO

p_Withdraw 2, 200.00
GO

p_Withdraw 4, 180.00;
GO

SELECT * 
FROM Transactions