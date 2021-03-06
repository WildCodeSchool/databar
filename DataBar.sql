DROP DATABASE IF EXISTS DataBar 
GO

CREATE DATABASE DataBar
GO

USE DataBar
CREATE TABLE Category (
	CategoryId INT PRIMARY KEY IDENTITY(1, 1),
	CategoryName VARCHAR(100) NOT NULL,
)

CREATE TABLE [Table] (
	TableId INT PRIMARY KEY IDENTITY(1, 1),
	TableNumber INT NOT NULL
)
GO

CREATE TABLE Invoice (
	InvoiceId INT PRIMARY KEY IDENTITY(1, 1),
	InvoiceDate DATETIME NOT NULL,
	FK_TableId INT FOREIGN KEY REFERENCES [Table](TableId) NOT NULL
)

CREATE TABLE Drink (
	DrinkId INT PRIMARY KEY IDENTITY(1, 1),
	DrinkName VARCHAR(100) NOT NULL,
	DrinkPrice DECIMAL NOT NULL,
	DrinkQuantity INT NOT NULL,
	FK_CategoryId INT FOREIGN KEY REFERENCES Category(CategoryId) NOT NULL
)
GO

CREATE TABLE DrinkInvoice (
	DrinkInvoiceId INT PRIMARY KEY IDENTITY(1, 1),
	FK_InvoiceId INT FOREIGN KEY REFERENCES Invoice(InvoiceId) NOT NULL,
	FK_DrinkId INT FOREIGN KEY REFERENCES Drink(DrinkId) NOT NULL
)
GO

INSERT INTO Category (CategoryName)
	VALUES ('Rhum')
GO

INSERT INTO Drink (DrinkName, DrinkPrice, DrinkQuantity, FK_CategoryId)
	VALUES ('Diplomatico', 8.0, 5, 1)
GO

INSERT INTO [Table] (TableNumber) VALUES (1) 
GO

INSERT INTO Invoice (InvoiceDate, FK_TableId)
	VALUES(GETDATE(), 1)
GO

INSERT INTO DrinkInvoice (FK_DrinkId, FK_InvoiceId)
	VALUES(1, 1)
GO

SELECT * FROM DrinkInvoice;
