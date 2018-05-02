CREATE DATABASE RelationsDemo
GO

USE RelationsDemo
GO

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Projects 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE EmployeesProjects
(
	EmployeeId INT,
	ProjectId INT,

	CONSTRAINT PK_EmployeesProjects
	PRIMARY KEY (EmployeeId, ProjectId),

	CONSTRAINT FK_EmployeesProjects_Employees
	FOREIGN KEY (EmployeeId)
	REFERENCES Employees(Id),

	CONSTRAINT FK_EmployeesProjects_Projects
	FOREIGN KEY (ProjectId)
	REFERENCES Projects(Id)
)

INSERT INTO Employees ([Name]) VALUES 
('Bay Ivan'),
('Gosho Ivanov'),
('Ivan Goshov')

INSERT INTO Projects ([Name]) VALUES
('MySql Project'),
('Super Java Project'),
('Microsoft Project')

SELECT * FROM Employees

SELECT * FROM Projects

INSERT INTO EmployeesProjects (EmployeeId, ProjectId) VALUES
(1, 2),
(1, 1),
(3, 3),
(2, 1)

SELECT e.[Name] As EmployeeName,
	   p.[Name] AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeId = e.Id
JOIn Projects AS p ON p.Id = ep.ProjectId 