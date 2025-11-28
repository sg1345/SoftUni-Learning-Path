CREATE DATABASE Accounting

GO

USE Accounting

GO

/* SECTION 1 */
	/* PROBLEM 1 */
CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(20) NOT NULL,
	StreetNumber INT NULL,
	PostCode INT NOT NULL,
	City VARCHAR(25) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Vendors(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Clients(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Products(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(35) NOT NULL,
	Price DECIMAL(18,2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(Id) NOT NULL
)

CREATE TABLE Invoices(
	Id INT PRIMARY KEY IDENTITY,
	Number INT UNIQUE NOT NULL,
	IssueDate DATETIME2 NOT NULL,
	DueDate DATETIME2 NOT NULL,
	Amount DECIMAL(18,2) NOT NULL,
	Currency VARCHAR(5) NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
)

CREATE TABLE ProductsClients(
	ProductId INT FOREIGN KEY REFERENCES Products(Id) NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL,
	PRIMARY KEY (ClientId, ProductId)
)

/* SECTION 2 */
	/* PROBLEM 2 */
BEGIN TRANSACTION

INSERT INTO Products (Name, Price, CategoryId, VendorId)
VALUES
    ('SCANIA Oil Filter XD01', 78.69, 1, 1),
    ('MAN Air Filter XD01', 97.38, 1, 5),
    ('DAF Light Bulb 05FG87', 55.00, 2, 13),
    ('ADR Shoes 47-47.5', 49.85, 3, 5),
    ('Anti-slip pads S', 5.87, 5, 7)

INSERT INTO Invoices (Number, IssueDate, DueDate, Amount, Currency, ClientId)
VALUES
    (1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
    (1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
    (1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19)


ROLLBACK
COMMIT
	/* PROBLEM 3 */
BEGIN TRANSACTION

UPDATE Invoices
   SET DueDate = '2023-04-01 00:00:00.0000000'
  FROM Invoices
 WHERE YEAR(IssueDate) = 2022 AND MONTH(IssueDate) = 11 

UPDATE Clients
   SET AddressId = (
						SELECT a.Id
						  FROM Addresses AS a
						  JOIN Countries AS c ON a.CountryId = c.Id
						 WHERE a.StreetName = 'Industriestr' AND a.StreetNumber = 79 AND a.City = 'Guntramsdorf' AND c.[Name] = 'Austria' 
				   )
  FROM Clients AS cl
 WHERE cl.[Name] LIKE '%CO%'

 SELECT *
   FROM Invoices
 WHERE YEAR(IssueDate) = 2022 AND MONTH(IssueDate) = 11 
ROLLBACK
COMMIT
	/* PROBLEM 4 */
BEGIN TRANSACTION

DELETE Invoices
  FROM Clients AS cl
  JOIN Invoices AS i ON cl.Id = i.ClientId
 WHERE cl.NumberVAT LIKE '%IT%'

DELETE ProductsClients
  FROM Clients AS cl
  JOIN ProductsClients AS pc ON cl.Id = pc.ClientId
 WHERE cl.NumberVAT LIKE '%IT%'

 DELETE Clients
  FROM Clients AS cl
 WHERE cl.NumberVAT LIKE '%IT%'

ROLLBACK
COMMIT
/* SECTION 3 */
	/* PROBLEM 5 */
	SELECT Number,
		   Currency
	  FROM Invoices
  ORDER BY Amount DESC,
		   DueDate ASC

GO

	/* PROBLEM 6 */
	SELECT p.Id,
		   p.[Name],
		   p.Price,
		   c.[Name] AS CategoryName
	  FROM Products AS p
	  JOIN Categories AS c ON p.CategoryId = c.Id
	 WHERE c.[Name] LIKE '%ADR%' OR c.[Name] LIKE '%Others%'
  ORDER BY p.Price DESC

  GO

	/* PROBLEM 7 */
	SELECT cl.Id,
		   cl.[Name] AS [Client],
		   CONCAT(a.StreetName, ' ', a.StreetNumber, ', ', a.City, ', ', a.PostCode, ', ', c.[Name]) AS [Address]
	  FROM Clients AS cl
 LEFT JOIN ProductsClients AS pc ON cl.Id = pc.ClientId
 LEFT JOIN Products AS p ON pc.ProductId = p.Id
	  JOIN Addresses AS a ON cl.AddressId = a.Id
	  JOIN Countries AS c ON a.CountryId = c.Id
     WHERE p.Id IS NULL
  ORDER BY cl.[Name]

  GO
	/* PROBLEM 8 */
	SELECT TOP(7)
		   i.Number,
		   i.Amount,
		   cl.[Name] AS [Client]
	  FROM Invoices AS i
	  JOIN Clients AS cl ON i.ClientId = cl.Id
	 WHERE (i.IssueDate < '2023-01-01 00:00:00.0000000' AND i.Currency = 'EUR')
		OR (i.Amount > 500 AND cl.NumberVAT LIKE 'DE%')
  ORDER BY i.Number ASC,
		   i.Amount DESC

 GO
	/* PROBLEM 9 */
	SELECT cl.[Name] AS [Client],
		   MAX(p.Price) AS [Price],
		   cl.NumberVAT AS [VAT Number]
	  FROM Clients AS cl
	  JOIN ProductsClients AS pc ON cl.Id = pc.ClientId
	  JOIN Products AS p ON pc.ProductId = p.Id
	 WHERE cl.[Name] NOT LIKE '%KG'
  GROUP BY cl.[Name], cl.NumberVAT
  ORDER BY MAX(p.Price) DESC

  GO

	/* PROBLEM 10 */
	SELECT cl.[Name], 
		   FLOOR(AVG(p.Price)) AS [Average Price]
	  FROM Clients AS cl
	  JOIN ProductsClients AS pc ON cl.Id = pc.ClientId
	  JOIN Products AS p ON pc.ProductId = p.Id
	  JOIN Vendors AS v ON p.VendorId = v.Id
	 WHERE v.NumberVAT LIKE '%FR%'
  GROUP BY cl.[Name]
  ORDER BY FLOOR(AVG(p.Price)) ASC,
           cl.[Name] DESC

GO

/* SECTION 4 */
	/* PROBLEM 11 */
CREATE FUNCTION udf_ProductWithClients(@name NVARCHAR(35))
RETURNS INT
AS
BEGIN
	
RETURN (
		SELECT COUNT(*)
		  FROM Clients AS cl
		  JOIN ProductsClients AS pc ON cl.Id = pc.ClientId
		  JOIN Products AS p ON pc.ProductId = p.Id
		 WHERE p.[Name] = @name
		)

END

GO

	/* PROBLEM 12 */
CREATE PROCEDURE usp_SearchByCountry(@country VARCHAR(10)) 
AS
BEGIN
	SELECT v.[Name] AS [Vendor],
		   v.NumberVAT AS VAT,
		   CONCAT_WS(' ', a.StreetName, a.StreetNumber) AS [Street Info],
		   CONCAT_WS(' ', a.City, a.PostCode) AS [City Info]
	  FROM Vendors AS v
	  JOIN Addresses AS a ON v.AddressId = a.Id
	  JOIN Countries AS c ON a.CountryId = c.Id
	 WHERE c.[Name] = @country
  ORDER BY v.[Name], a.City 
END