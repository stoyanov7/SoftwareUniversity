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

SELECT * FROM Transactions