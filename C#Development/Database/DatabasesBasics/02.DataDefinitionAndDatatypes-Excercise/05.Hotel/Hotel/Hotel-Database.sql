CREATE DATABASE Hotel
Go

USE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(255) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customer 
(
	AccountNumber INT PRIMARY KEY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(50),
	EmergencyName   NVARCHAR(50) NOT NULL,
    EmergencyNumber INT NOT NULL,
	Notes NVARCHAR(50)
)

CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
) 

CREATE TABLE RoomTypes
(
	RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
    Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes
(
	BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType NVARCHAR(50) NOT NULL,
	BedType NVARCHAR(50) NOT NULL,
	Rate DECIMAL(10, 2) NOT NULL,
	RoomStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY NOT NULL,
	EmployeeId INT NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(10, 2) NOT NULL,
	TaxRate DECIMAL(10, 2) NOT NULL,
	TaxAmount DECIMAL(10, 2) NOT NULL,
	PaymentTotal DECIMAL(10, 2) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY NOT NULL,
	EmployeeId INT NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied DECIMAL(10, 2),
	PhoneCharge VARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

ALTER TABLE Payments
ADD CONSTRAINT CK_TotalDays CHECK(DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied) = TotalDays)

ALTER TABLE Payments
ADD CONSTRAINT CK_TaxAmount CHECK(TaxAmount = TotalDays * TaxRate)

INSERT INTO Employees(Id, FirstName, LastName, Title) VALUES
(1, 'First', 'Employee', 'Manager'),
(2, 'Second', 'Employee', 'Manager'),
(3, 'Third', 'Employee', 'Manager')

INSERT INTO Customer(AccountNumber, FirstName, LastName, EmergencyName, EmergencyNumber) VALUES
(1, 'First', 'Last', 'Em1', 11111),
(2, 'Second', 'Lasst', 'Em2', 22222),
(3, 'Third', 'Lassst', 'Em3', 33333)

INSERT INTO RoomStatus(RoomStatus) VALUES
('Free'),
('In use'),
('Reserved')

INSERT INTO RoomTypes(RoomType) VALUES
('Luxory'),
('Casual'),
('Misery')

INSERT INTO BedTypes(BedType) VALUES
('Single'),
('Double'),
('King')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus) VALUES
(1, 'Luxory', 'King', 100, 'Reserved'),
(2, 'Casual', 'Double', 50, 'In use'),
(3, 'Misery', 'Single', 19, 'Free')

INSERT INTO Payments(Id,
                     EmployeeId,
                     PaymentDate,
                     AccountNumber,
                     FirstDateOccupied,
                     LastDateOccupied,
                     TotalDays,
                     AmountCharged,
                     TaxRate,
                     TaxAmount,
                     PaymentTotal
                    ) 
VALUES
(1, 1, '10-05-2015', 1, '10-05-2015', '10-10-2015', 5, 75, 50, 250, 75),
(2, 3, '10-11-2015', 1, '12-15-2015', '12-25-2015', 10, 100, 50, 500, 100),
(3, 2, '12-23-2015', 1, '12-23-2015', '12-24-2015', 1, 75, 75, 75, 75)

INSERT INTO Occupancies(Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, PhoneCharge) VALUES
(1, 2, '08-24-2012', 3, 1, '088 88 888 888'),
(2, 3, '06-15-2015', 2, 3, '088 88 555 555'),
(3, 1, '05-12-1016', 1, 2, '088 88 555 333')