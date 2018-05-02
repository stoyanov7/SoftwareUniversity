CREATE DATABASE RelationsDemo
GO

USE RelationsDemo
GO

CREATE TABLE Mountains
(
	Id INT IDENTITY,
	[Name] VARCHAR(50) NOT NULL,

	CONSTRAINT PK_Mountains 
	PRIMARY KEY (Id)
)

CREATE TABLE Peaks(
	Id INT IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	MountainId INT NOT NULL,

	CONSTRAINT PK_Peaks
	PRIMARY KEY (Id),

	CONSTRAINT FK_Peaks_Mountains 
	FOREIGN KEY (MountainId)
	REFERENCES Mountains(Id)
)

INSERT INTO Mountains ([Name]) VALUES
('Rila'),
('Pirin')

INSERT INTO Peaks ([Name], MountainId) VALUES
('Musala', 1),
('Malyovitsa', 1),
('Vihren', 2),
('Kutelo', 2)

SELECT * FROM Peaks