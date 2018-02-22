CREATE DATABASE People
Go

USE People

CREATE TABLE People
(
	Id		  INT UNIQUE IDENTITY NOT NULL,
	Name      NVARCHAR(200) NOT NULL,
	Picture   VARBINARY(MAX),
	Height    NUMERIC(3, 2),
	Weight    NUMERIC(5, 2),
	Gender    CHAR(1) CHECK([Gender] IN('M', 'F')) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

ALTER TABLE People ADD PRIMARY KEY(Id)

ALTER TABLE People ADD CONSTRAINT CH_PictureSize CHECK(DATALENGTH(Picture) <= 2 * 1024 * 1024)

INSERT INTO People(Name, Gender, Birthdate) VALUES
('First Name', 'M', '01-01-2000'),
('Second Name', 'F', '05-03-2001'),
('Third Name', 'F', '07-08-2005'),
('Fourth Name', 'F', '03-05-2007'),
('Fifth Name', 'M', '08-09-2003');