CREATE TABLE Drivers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DriverId INT FOREIGN KEY REFERENCES Drivers(Id)
)

CREATE TABLE DriversWithCars
(
	DriverId INT,
	CarId INT

	CONSTRAINT PK_DriversWithCars
	PRIMARY KEY (DriverId, CarId),

	CONSTRAINT FK_DriversWithCars_Drivers
	FOREIGN KEY (DriverId)
	REFERENCES Drivers(Id),

	CONSTRAINT FK_DriversWithCars_Cars
	FOREIGN KEY (CarId)
	REFERENCES Cars(Id)
)

INSERT INTO Drivers ([Name]) VALUES
('Gosho Goshov'),
('Ivan Ivanov')

INSERT INTO Cars ([Name]) VALUES
('Mercedes-Benz'),
('BMW')

INSERT INTO DriversWithCars (DriverId, CarId) VALUES
(1, 1),
(2, 2)

SELECT d.[Name] AS DriverName,
	   c.[Name] AS CarName
FROM Drivers AS d
JOIN DriversWithCars AS dc ON dc.DriverID = d.Id
JOIN Cars AS c ON c.Id = dc.CarId