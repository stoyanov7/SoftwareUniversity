CREATE TABLE Manufacturers
(
	ManufacturerID INT IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	EstablishedOn DATE DEFAULT GETDATE(),

	CONSTRAINT PK_Manufacturers
	PRIMARY KEY(ManufacturerID)
)

CREATE TABLE Models
(
	ModelID INT IDENTITY(101, 1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	ManufacturerID INT NOT NULL,

	CONSTRAINT PK_Model
	PRIMARY KEY(ModelID),

	 CONSTRAINT FK_Models_Manufacturers
	 FOREIGN KEY(ManufacturerID) 
	 REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers([Name], EstablishedOn) VALUES
('BMW', '07/03/1916'),
('Tesla', '07/03/1916'),
('Lada', '01/05/1966')

INSERT INTO Models([Name], ManufacturerID) VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3) 

SELECT * FROM Manufacturers

SELECT * FROM Models

SELECT m.[Name],
	   model.[Name] AS ModelName,
	   m.EstablishedOn
	   FROM Manufacturers m
JOIN Models AS model ON model.ManufacturerID = m.ManufacturerID