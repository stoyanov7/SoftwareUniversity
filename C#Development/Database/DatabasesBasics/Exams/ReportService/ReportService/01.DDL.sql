CREATE DATABASE ReportService
GO

USE ReportService

CREATE TABLE Users
(
	Id INT IDENTITY NOT NULL,
	Username NVARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	Gender CHAR(1) CHECK([Gender] IN('M', 'F')),
	BirthDate DATE,
	Age INT,
	Email NVARCHAR(50) NOT NULL,

	CONSTRAINT PK_Users
	PRIMARY KEY (ID)
)

CREATE TABLE Departments
(
	Id INT IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,

	CONSTRAINT PK_Departments
	PRIMARY KEY(Id)
)

CREATE TABLE Employees
(
	Id INT IDENTITY NOT NULL,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR(1) CHECK([Gender] IN('M', 'F')),
	BirthDate DATE,
	Age INT,
	DepartmentId INT NOT NULL,

	CONSTRAINT PK_Employees
	PRIMARY KEY (Id),

	CONSTRAINT FK_Employees_Departments
	FOREIGN KEY(DepartmentId)
	REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT,

	CONSTRAINT PK_Categories
	PRIMARY KEY (Id),

	CONSTRAINT FK_Categories_Departments
	FOREIGN KEY (DepartmentId)
	REFERENCES Departments(Id)
)

CREATE TABLE Status 
(
	Id INT IDENTITY NOT NULL,
	Label VARCHAR(30) NOT NULL,

	CONSTRAINT PK_Status
	PRIMARY KEY (Id)
)

CREATE TABLE Reports
(
	Id INT IDENTITY NOT NULL,
	CategoryId INT NOT NULL,
	StatusId INT NOT NULL,
	OpenDate DATE NOT NULL,
	CloseDate DATE,
	Description VARCHAR(200),
	UserId INT NOT NULL,
	EmployeeId INT,

	CONSTRAINT PK_Reposts
	PRIMARY KEY(Id),

	CONSTRAINT FK_Reports_Category
	FOREIGN KEY (CategoryId)
	REFERENCES Categories(Id),

	CONSTRAINT FK_Reports_Status
	FOREIGN KEY (StatusId)
	REFERENCES Status(Id),

	CONSTRAINT FK_Reports_Users
	FOREIGN KEY (UserId)
	REFERENCES Users(Id),

	CONSTRAINT FK_Reports_Employees
	FOREIGN KEY (EmployeeId)
	REFERENCES Employees(Id)
)