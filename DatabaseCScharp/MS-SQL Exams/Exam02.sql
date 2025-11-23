CREATE DATABASE TouristAgency

GO

USE TouristAgency

GO

/* SECTION 1 */
	/* PROBLEM 1 */
CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Destinations(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Rooms(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(40) NOT NULL,
	Price DECIMAL(18,2) NOT NULL,
	BedCount INT CHECK (BedCount > 0 AND BedCount <= 10) NOT NULL,
)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DestinationId INT FOREIGN KEY REFERENCES Destinations(Id) NOT NULL
)

CREATE TABLE Tourists(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Email VARCHAR(80) NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Bookings(
	Id INT PRIMARY KEY IDENTITY,
	ArrivalDate DATETIME2 NOT NULL,
	DepartureDate DATETIME2 NOT NULL,
	AdultsCount INT CHECK (AdultsCount >= 1 AND AdultsCount <= 10) NOT NULL,
	ChildrenCount INT CHECK (ChildrenCount >= 0 AND ChildrenCount <= 9) NOT NULL,
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
)

CREATE TABLE HotelsRooms(
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	PRIMARY KEY (RoomId,HotelId)
)

GO

/* SECTION 2 */
	/* PROBLEM 2 */
INSERT INTO Tourists([Name], PhoneNumber, Email, CountryId)
VALUES
    ('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
    ('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
    ('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
    ('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
    ('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6)

INSERT INTO Bookings (ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
VALUES
    ('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
    ('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
    ('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
    ('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
    ('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6)


	/* PROBLEM 3 */
UPDATE Bookings
   SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
 WHERE MONTH(ArrivalDate) = 12 AND YEAR(ArrivalDate) = 2023

UPDATE Tourists
   SET Email = NULL
 WHERE CHARINDEX('MA', [Name]) > 0

GO
	/* PROBLEM 4 */
BEGIN TRANSACTION

DELETE 
  FROM Bookings
 WHERE TouristId IN (
							SELECT Id
							  FROM Tourists
							 WHERE CHARINDEX('Smith', [Name]) > 0
					)
 

DELETE FROM Tourists
 WHERE CHARINDEX('Smith', [Name]) > 0

ROLLBACK

	SELECT *
	  FROM Tourists
     WHERE CHARINDEX('Smith', [Name]) > 0

/* SECTION 3 */
	/* PROBLEM 5 */
	SELECT FORMAT(b.ArrivalDate, 'yyyy-MM-dd'),
		   b.AdultsCount,
		   b.ChildrenCount
	  FROM Bookings AS b
	  JOIN Rooms AS r ON b.RoomId = r.Id
  ORDER BY r.Price DESC,
		   b.ArrivalDate ASC

GO

	/* PROBLEM 6 */
	SELECT h.Id,
		   h.[Name]
	  FROM (
			  SELECT h.Id,
					 COUNT(h.Id) AS [CountHotels]
				FROM Hotels AS h
				JOIN HotelsRooms AS hr ON h.Id = hr.HotelId 
				JOIN Rooms AS r ON hr.RoomId = r.Id
				JOIN Bookings AS b ON h.Id = b.HotelId
				WHERE r.Type = 'VIP Apartment'
			GROUP BY h.Id
		   ) AS hc
      JOIN Hotels AS h ON hc.Id = h.Id
  ORDER BY hc.CountHotels DESC
  GO

  	SELECT h.Id,
		   h.[Name]
	  FROM (
				SELECT COUNT(hc.Id) AS [CountHotels],
					   hc.Id
				  FROM (
						  SELECT DISTINCT h.Id
							FROM Hotels AS h
							JOIN HotelsRooms AS hr ON h.Id = hr.HotelId 
							JOIN Rooms AS r ON hr.RoomId = r.Id
							JOIN Bookings AS b ON h.Id = b.HotelId
							WHERE r.Type = 'VIP Apartment'
					   ) AS hc
				  JOIN Bookings AS b ON hc.Id = b.HotelId
			  GROUP BY hc.Id
		   ) AS ch
      JOIN Hotels AS h ON ch.Id = h.Id
  ORDER BY ch.CountHotels DESC


		GO

	/* PROBLEM 7 */
	SELECT t.Id,
		   t.[Name],
		   t.PhoneNumber
	  FROM Tourists AS t
 LEFT JOIN Bookings AS b ON t.Id = b.TouristId
     WHERE b.Id IS NULL
  ORDER BY t.[Name] ASC

  GO

	/* PROBLEM 8 */
	SELECT TOP(10)
		   h.[Name] AS [HotelName],
		   d.[Name] AS [DestinationName],
		   c.[Name] AS [CountryName]
	  FROM Bookings AS b
	  JOIN Hotels AS h ON b.HotelId = h.Id
	  JOIN Destinations AS d ON h.DestinationId = d.Id
	  JOIN Countries AS c ON d.CountryId = c.Id
	 WHERE b.ArrivalDate < '2023-12-31' AND h.Id % 2 = 1
  ORDER BY c.[Name],
		   b.ArrivalDate

GO
	/* PROBLEM 9 */
	SELECT h.[Name] AS [HotelName],
		   r.Price AS [RoomPrice]
	  FROM Tourists AS t
	  JOIN Bookings AS b ON t.Id = b.TouristId
	  JOIN Hotels AS h ON b.HotelId = h.Id
	  JOIN Rooms AS r ON b.RoomId = r.Id
	 WHERE t.[Name] NOT LIKE '%EZ'
  ORDER BY r.Price DESC

  GO

	/* PROBLEM 10 */
	SELECT h.[Name] AS [HotelName],
		   SUM(r.Price * DATEDIFF(DAY,b.ArrivalDate,b.DepartureDate)) AS [HotelRevenue]
	  FROM Bookings AS b
	  JOIN Hotels AS h ON b.HotelId = h.Id
	  JOIN Rooms AS r ON b.RoomId = r.Id
  GROUP BY h.[Name]
  ORDER BY SUM(r.Price * DATEDIFF(DAY,b.ArrivalDate,b.DepartureDate)) DESC

  GO

/* SECTION 4 */
	/* PROBLEM 11 */
CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR(40))
RETURNS INT
AS
BEGIN
	RETURN (
				SELECT SUM(b.AdultsCount + b.ChildrenCount)
				  FROM Bookings AS b
				  JOIN Rooms AS r ON b.RoomId = r.Id
				  WHERE r.[Type] = @name
			   GROUP BY r.[Type]	
			)
END

GO

	/* PROBLEM 12 */
CREATE PROCEDURE usp_SearchByCountry @country NVARCHAR(50)
AS
BEGIN
	SELECT t.[Name],
		   t.PhoneNumber,
		   t.Email,
		   cb.CountOfBookings
	  FROM Tourists AS t
	  JOIN Countries AS c ON t.CountryId = c.Id
	  JOIN (
				SELECT t.Id,
					   COUNT(*) AS [CountOfBookings]
				  FROM Tourists AS t
				  JOIN Bookings AS b ON t.Id = b.TouristId
			  GROUP BY t.Id 
		   ) AS cb ON t.Id = cb.Id
	 WHERE c.[Name] = @country
  ORDER BY t.[Name],
		   cb.CountOfBookings DESC
END

GO

