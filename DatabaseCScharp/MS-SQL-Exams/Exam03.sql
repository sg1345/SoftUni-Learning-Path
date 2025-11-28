CREATE DATABASE ShoesApplicationDatabase

GO

USE ShoesApplicationDatabase

GO

/* SECTION 1 */
	/* PROBLEM 1 */
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(50) UNIQUE NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	PhoneNumber NVARCHAR(15) NULL,
	Email NVARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE Brands(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Sizes(
	Id INT PRIMARY KEY IDENTITY,
	EU DECIMAL(5,2) NOT NULL,
	US DECIMAL(5,2) NOT NULL,
	UK DECIMAL(5,2) NOT NULL,
	CM DECIMAL(5,2) NOT NULL,
	[IN] DECIMAL(5,2) NOT NULL
)

CREATE TABLE Shoes(
	Id INT PRIMARY KEY IDENTITY,
	Model NVARCHAR(30) NOT NULL,
	Price DECIMAL(10,2) NOT NULL,
	BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL
)

CREATE TABLE Orders(
	Id INT PRIMARY KEY IDENTITY,
	ShoeId INT FOREIGN KEY REFERENCES Shoes(Id) NOT NULL,
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE ShoesSizes(
	ShoeId INT FOREIGN KEY REFERENCES Shoes(Id) NOT NULL,
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
	PRIMARY KEY (ShoeId,SizeId)
)

GO

/* SECTION 2 */
	/* PROBLEM 2 */
INSERT INTO Brands (Name)
VALUES 
    ('Timberland'),
    ('Birkenstock')

INSERT INTO Shoes (Model, Price, BrandId)
VALUES 
    ('Reaxion Pro', 150.00, 12),
    ('Laurel Cort Lace-Up', 160.00, 12),
    ('Perkins Row Sandal', 170.00, 12),
    ('Arizona', 80.00, 13),
    ('Ben Mid Dip', 85.00, 13),
    ('Gizeh', 90.00, 13)

INSERT INTO ShoesSizes (ShoeId, SizeId)
VALUES 
    (70, 1),
    (70, 2),
    (70, 3),
    (71, 2),
    (71, 3),
    (71, 4),
    (72, 4),
    (72, 5),
    (72, 6),
    (73, 1),
    (73, 3),
    (73, 5),
    (74, 2),
    (74, 4),
    (74, 6),
    (75, 1),
    (75, 2),
    (75, 3)

INSERT INTO Orders (ShoeId, SizeId, UserId)
VALUES 
    (70, 2, 15),
    (71, 3, 17),
    (72, 6, 18),
    (73, 5, 4),
    (74, 4, 7),
    (75, 1, 11)

GO

	/* PROBLEM 3 */
UPDATE Shoes
   SET Price = Price + (Price * 0.15)
 WHERE BrandId = (
					SELECT Id
					  FROM Brands
					 WHERE [Name] = 'Nike'
 )

GO
	/* PROBLEM 4 */
DELETE Orders
  FROM Orders AS o
  JOIN Shoes AS s ON o.ShoeId = s.Id
 WHERE s.Model = 'Joyride Run Flyknit'

DELETE ShoesSizes
  FROM ShoesSizes AS ss
  JOIN Shoes AS s ON ss.ShoeId = s.Id
 WHERE s.Model = 'Joyride Run Flyknit'

DELETE Shoes
  FROM Shoes
 WHERE Model = 'Joyride Run Flyknit'

GO

/* SECTION 3 */
	/* PROBLEM 5 */
	SELECT s.Model AS [ShoeModel],
		   s.Price AS [Price]
	  FROM Orders AS o
	  JOIN Shoes AS s ON o.ShoeId = s.Id
  ORDER BY s.Price DESC,
		   s.Model ASC

GO

	/* PROBLEM 6 */
	SELECT b.[Name] AS [BrandName],
		   s.Model AS [ShoesCount]
	  FROM Shoes AS s
	  JOIN Brands AS b ON s.BrandId = b.Id
  ORDER BY b.[Name],
		   s.Model

GO

	/* PROBLEM 7 */
	SELECT TOP(10)
		   u.Id,
		   u.FullName,
		   uts.TotalSpent
	  FROM Users AS u
	  JOIN (
				SELECT u.Id,
					   SUM(s.Price) AS [TotalSpent]
				  FROM Users AS u
				  JOIN Orders AS o ON u.Id = o.UserId
				  JOIN Shoes AS s ON o.ShoeId = s.Id
			  GROUP BY u.Id
		   ) AS uts ON u.Id = uts.Id
  ORDER BY uts.TotalSpent DESC,
		   u.FullName ASC

GO

	/* PROBLEM 8 */
	SELECT u.Username,
		   u.Email,
		   CAST(ROUND(AVG(s.Price), 2) AS decimal(10,2)) AS [AvgPrice]
	  FROM Users AS u
	  JOIN Orders AS o ON u.Id = o.UserId
	  JOIN Shoes AS s ON o.ShoeId = s.Id
  GROUP BY u.Username, u.Email
    HAVING COUNT(*) > 2
  ORDER BY CAST(AVG(s.Price) AS decimal(10,2)) DESC

GO

	/* PROBLEM 9 */
	SELECT b.[Name] AS [BrandName], 
		   tt.ModelsCount, 
		   tt.TotalDistinctSizesAcrossModels,
		   STRING_AGG(s.Model,', ') WITHIN GROUP (ORDER BY s.Model ASC) AS [Models]
	  FROM (
				SELECT b.[Name],
					   COUNT(DISTINCT s.Model) AS [ModelsCount],
					   COUNT(s.Model) AS [TotalDistinctSizesAcrossModels]
				  FROM Shoes AS s
				  JOIN Brands AS b ON s.BrandId = b.Id
				  JOIN ShoesSizes AS ss ON s.Id = ss.ShoeId
				  JOIN Sizes AS z ON ss.SizeId = z.Id
				 WHERE s.Model LIKE '%Run%' 
			  GROUP BY b.[Name]
				HAVING COUNT(z.Id) > 3
		   ) AS tt
	  JOIN Brands AS b ON tt.[Name] = b.[Name]
	  JOIN Shoes AS s ON b.Id = s.BrandId
	 WHERE s.Model LIKE '%Run%' 
  GROUP BY b.[Name], tt.ModelsCount, tt.TotalDistinctSizesAcrossModels

GO

	/* PROBLEM 10 */
	SELECT u.FullName,
		   u.PhoneNumber,
		   s.Price AS [OrderPrice],
		   o.ShoeId,
		   s.BrandId,
		   CONCAT(z.EU, 'EU', '/', z.US, 'US', '/', z.UK, 'UK')
	  FROM Users AS u
	  JOIN Orders AS o ON u.Id = o.UserId
	  JOIN Shoes AS s ON o.ShoeId = s.Id
	  JOIN Sizes AS z ON o.SizeId = z.Id
	 WHERE u.PhoneNumber LIKE '%345%'
  ORDER BY s.Model

GO

/* SECTION 4 */
	/* PROBLEM 11 */
CREATE FUNCTION udf_OrdersByEmail(@email NVARCHAR(100))
RETURNS INT
AS
BEGIN
	
RETURN (
		SELECT COUNT(*)
		  FROM Users AS u
		  JOIN Orders AS o ON u.Id = o.UserId
		 WHERE u.Email = @email
	   )

END

GO
	/* PROBLEM 12 */
CREATE PROCEDURE usp_SearchByShoeSize @shoeSize DECIMAL(5,2), @brandName NVARCHAR(50) = NULL
AS
BEGIN
	SELECT s.Model AS [ModelName],
		   u.FullName AS [UserFullName],
		   CASE
				WHEN s.Price < 100 THEN 'Low'
				WHEN s.Price > 200 THEN 'High'
				WHEN s.Price >=100 OR s.Price <= 200 THEN 'Medium'
				ELSE NULL
		   END AS [PriceLevel],
		   b.[Name] AS [BrandName],
		   z.EU AS [SizeEU]
	  FROM Orders AS o
	  JOIN Shoes AS s ON o.ShoeId = s.Id
	  JOIN Users AS u ON o.UserId = u.Id
	  JOIN Brands AS b ON s.BrandId = b.Id
	  JOIN Sizes AS z ON o.SizeId = z.Id
	 WHERE z.EU = @shoeSize AND (@brandName IS NULL OR b.[Name] = @brandName)
  ORDER BY b.[Name],
           u.FullName
END

GO