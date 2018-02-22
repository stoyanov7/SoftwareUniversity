CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(50)NOT NULL
)

CREATE TABLE Addresses 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
    [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50),
	JobTitle NVARCHAR(100) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE,
	Salary DECIMAL(10, 2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

BACKUP DATABASE SoftUni TO DISK = 'C:\softuni-backup.bak'

INSERT INTO Towns(Name) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas');

INSERT INTO Departments(Name) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance');

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
('Ivan','Ivanov', 'Ivanov', '.NET Developer', 4, CONVERT(DATE, '02/03/2004', 103), 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, CONVERT(DATE, '02/03/2004', 103), 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, CONVERT(DATE, '28/08/2016', 103), 525.25),
('Georgi', 'Teziev ', 'Ivanov', 'CEO', 2, CONVERT(DATE, '09/12/2007', 103), 3000.00),
('Peter', 'Pan ', 'Pan', 'Intern', 3, CONVERT(DATE, '28/08/2016', 103), 599.88)