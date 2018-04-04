Use People
GO 

CREATE TABLE Users
(
	Id BIGINT UNIQUE IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime  DATETIME2,
    IsDeleted BIT DEFAULT(0) NOT NULL
)

ALTER TABLE Users ADD CONSTRAINT PK_Users PRIMARY KEY(ID)

ALTER TABLE Users ADD CONSTRAINT CH_ProfilePicture CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024)

INSERT INTO Users(Username, Password) VALUES
('First', 'FpAsS'),
('Second', 'SpAsS'),
('Third', 'TpAsS'),
('Fourth', 'FpbsS'),
('Fifth', 'FfTpAsS')

ALTER TABLE Users DROP CONSTRAINT PK_Users;

ALTER TABLE Users ADD CONSTRAINT PK_Users PRIMARY KEY(Id, Username);

ALTER TABLE Users ADD CONSTRAINT Password CHECK(LEN(Password) >= 5);

ALTER TABLE Users ADD CONSTRAINT DF_Users DEFAULT GETDATE() FOR LastLoginTime;

ALTER TABLE Users DROP CONSTRAINT PK_Users;

ALTER TABLE Users ADD CONSTRAINT PK_Person PRIMARY KEY(Id);

ALTER TABLE Users ADD CONSTRAINT UC_Users UNIQUE(Username);

ALTER TABLE Users ADD CONSTRAINT CHK_Users CHECK(LEN(Password) >= 3);
