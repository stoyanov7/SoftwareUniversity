CREATE TABLE Passports
(
	PassportID INT IDENTITY(101, 1) NOT NULL,
	PassportNumber CHAR(8) NOT NULL,

	CONSTRAINT PK_Passports 
	PRIMARY KEY(PassportID)
)

CREATE TABLE Persons 
(
	PersonID INT IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	Salary DECIMAL(10, 2) NOT NULL,
	PassportID INT UNIQUE NOT NULL,

	CONSTRAINT PK_Persons 
	PRIMARY KEY (PersonId),

	CONSTRAINT FK_Persons_Passports
	FOREIGN KEY(PassportID)
	REFERENCES Passports(PassportID)
)

INSERT INTO Passports(PassportNumber) VALUES
('ZE657QP2'),
('K65LO4R7'),
('N34FG21B')

INSERT INTO Persons(FirstName, Salary, PassportID) VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

SELECT * FROM Passports

SELECT * FROM Persons

SELECT p.FirstName,
	   p.Salary,
	   pass.PassportNumber
FROM Persons AS p
JOIN Passports AS pass ON pass.PassportID = p.PassportID