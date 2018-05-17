CREATE DATABASE WMS
GO

USE WMS
GO

CREATE TABLE Clients
(
	 ClientId INT IDENTITY NOT NULL,
	 FirstName VARCHAR(50) NOT NULL,
	 LastName VARCHAR(50) NOT NULL,
	 Phone CHAR(12) NOT NULL,

	 CONSTRAINT PK_Clients
	 PRIMARY KEY (ClientId)
)

CREATE TABLE Mechanics
(
	 MechanicId INT IDENTITY NOT NULL,
	 FirstName VARCHAR(50) NOT NULL,
	 LastName VARCHAR(50) NOT NULL,
	 [Address] VARCHAR(255) NOT NULL,

	 CONSTRAINT PK_Mechanics
	 PRIMARY KEY (MechanicId)
)

CREATE TABLE Models
(
	 ModelId INT IDENTITY NOT NULL,
	 [Name] VARCHAR(50) UNIQUE NOT NULL,

	 CONSTRAINT PK_Models
	 PRIMARY KEY (ModelId)
)

CREATE TABLE Jobs
(
	 JobId INT IDENTITY NOT NULL,
	 ModelId INT NOT NULL,
	 [Status] VARCHAR(11) NOT NULL
	                        DEFAULT 'Pending'
	                        CHECK([Status] IN('Pending', 'In Progress', 'Finished')),
	 ClientId INT NOT NULL,
	 MechanicId INT NULL,	                
	 IssueDate  DATETIME2 NOT NULL,
	 FinishDate DATETIME2

	 CONSTRAINT PK_Jobs
	 PRIMARY KEY (JobId),

	 CONSTRAINT FK_Jobs_Models
	 FOREIGN KEY (ModelId)
	 REFERENCES Models(ModelId),

	 CONSTRAINT FK_Jobs_Clients
	 FOREIGN KEY (ClientId)
	 REFERENCES Clients(ClientId),

	 CONSTRAINT FK_Jobs_Mechanics
	 FOREIGN KEY (MechanicId)
	 REFERENCES Mechanics(MechanicId)
)

CREATE TABLE Orders
(
	 OrderId INT IDENTITY NOT NULL,
	 JobId INT NOT NULL,
	 IssueDate DATETIME2,
	 Delivered BIT DEFAULT 0 NOT NULL,

	 CONSTRAINT PK_Orders
	 PRIMARY KEY (OrderId),

	 CONSTRAINT FK_Orders_Jobs
	 FOREIGN KEY (JobId)
	 REFERENCES Jobs(JobId)
)

CREATE TABLE Vendors
(
	 VendorId INT IDENTITY NOT NULL,
     [Name] VARCHAR(50) UNIQUE NOT NULL,

	 CONSTRAINT PK_Vendors
	 PRIMARY KEY (VendorId)
)

CREATE TABLE Parts
(
	 PartId INT IDENTITY NOT NULL,
	 SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	 [Description]  VARCHAR(255),
	 Price DECIMAL(6, 2) CHECK(Price > 0) NOT NULL,
	 VendorId INT NOT NULL,
	 StockQty INT DEFAULT 0 CHECK(StockQty >= 0) NOT NULL,

	 CONSTRAINT PK_Parts
	 PRIMARY KEY (PartId),

	 CONSTRAINT FK_Parts_Vendors
	 FOREIGN KEY (VendorId)
	 REFERENCES Vendors(VendorId)
)

CREATE TABLE OrderParts
(
	 OrderId INT NOT NULL,
	 PartId INT NOT NULL,	              
	 Quantity INT DEFAULT 1 CHECK(Quantity > 0) NOT NULL,

     CONSTRAINT PK_OrderParts
	 PRIMARY KEY(OrderId, PartId),

	 CONSTRAINT FK_PK_OrderParts_Orders
	 FOREIGN KEY (OrderId)
	 REFERENCES Orders(OrderId),

	 CONSTRAINT FK_OrderParts_Parts
	 FOREIGN KEY (PartId)
	 REFERENCES Parts(PartId),
)

CREATE TABLE PartsNeeded
(
	 JobId INT NOT NULL,	              
	 PartId INT NOT NULL,
	 Quantity INT DEFAULT 1 CHECK(Quantity > 0) NOT NULL,

	 CONSTRAINT PK_PartsNeeded
	 PRIMARY KEY(JobId, PartId),

	 CONSTRAINT FK_PartsNeeded_Jobs
	 FOREIGN KEY (JobId)
	 REFERENCES Jobs(JobId),

	 CONSTRAINT FK_PartsNeeded_Parts
	 FOREIGN KEY (PartId)
	 REFERENCES Parts(PartId),
)