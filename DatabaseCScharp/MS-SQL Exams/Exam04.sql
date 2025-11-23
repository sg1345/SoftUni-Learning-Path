USE master

go

CREATE DATABASE RailwaysDb

GO

USE RailwaysDb

GO

/* SECTION 1 */
	/* PROBLEM 1 */
CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE RailwayStations(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Trains(
	Id INT PRIMARY KEY IDENTITY,
	HourOfDeparture VARCHAR(5) NOT NULL,
	HourOfArrival VARCHAR(5) NOT NULL,
	DepartureTownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL,
	ArrivalTownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE TrainsRailwayStations (
	TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL,
	RailwayStationId INT FOREIGN KEY REFERENCES RailwayStations(Id) NOT NULL
	PRIMARY KEY(TrainId, RailwayStationId)
)

CREATE TABLE MaintenanceRecords(
	Id INT PRIMARY KEY IDENTITY,
	DateOfMaintenance DATETIME2 NOT NULL,
	Details VARCHAR(2000) NOT NULL,
	TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18,2) NOT NULL,
	DateOfDeparture DATETIME2 NOT NULL,
	DateOfArrival DATETIME2 NOT NULL,
	TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)


/* SECTION 2 */
	/* PROBLEM 2 */
INSERT INTO Trains (HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
VALUES
    ('07:00', '19:00', 1, 3),
    ('08:30', '20:30', 5, 6),
    ('09:00', '21:00', 4, 8),
    ('06:45', '03:55', 27, 7),
    ('10:15', '12:15', 15, 5)

INSERT INTO TrainsRailwayStations (TrainId, RailwayStationId)
VALUES
    (36, 1),
    (37, 60),
    (39, 3),
    (36, 4),
    (37, 16),
    (39, 31),
    (36, 31),
    (38, 10),
    (39, 19),
    (36, 57),
    (38, 50),
    (40, 41),
    (36, 7),
    (38, 52),
    (40, 7),
    (37, 13),
    (38, 22),
    (40, 52),
    (37, 54),
    (39, 68),
    (40, 13)

INSERT INTO Tickets (Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId)
VALUES
    (90.00, '2023-12-01', '2023-12-01', 36, 1),
    (115.00, '2023-08-02', '2023-08-02', 37, 2),
    (160.00, '2023-08-03', '2023-08-03', 38, 3),
    (255.00, '2023-09-01', '2023-09-02', 39, 21),
    (95.00, '2023-09-02', '2023-09-03', 40, 22)

GO

	/* PROBLEM 3 */
	
UPDATE Tickets
   SET DateOfArrival = DATEADD(DAY, 7, DateOfArrival), DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture)
 WHERE MONTH(DateOfDeparture) > 10

 GO


	/* PROBLEM 4 */
BEGIN TRANSACTION

DELETE TrainsRailwayStations
  FROM Trains AS td 
  JOIN Towns AS t ON td.DepartureTownId = t.Id
  JOIN TrainsRailwayStations AS trs ON td.Id = trs.TrainId
 WHERE t.[Name] = 'Berlin'

DELETE MaintenanceRecords
  FROM Trains AS td 
  JOIN Towns AS t ON td.DepartureTownId = t.Id
  JOIN MaintenanceRecords AS mr ON td.Id = mr.TrainId
 WHERE t.[Name] = 'Berlin'

DELETE Tickets
  FROM Trains AS td 
  JOIN Towns AS t ON td.DepartureTownId = t.Id
  JOIN Tickets AS tt ON td.Id = tt.TrainId
 WHERE t.[Name] = 'Berlin'

DELETE Trains
  FROM Trains AS td 
  JOIN Towns AS t ON td.DepartureTownId = t.Id
 WHERE t.[Name] = 'Berlin'

ROLLBACK
COMMIT

SELECT *
  FROM Trains AS td 
  JOIN Towns AS t ON td.DepartureTownId = t.Id
  JOIN TrainsRailwayStations AS trs ON td.Id = trs.TrainId
 WHERE t.[Name] = 'Berlin'




/* SECTION 3 */
	/* PROBLEM 5 */
	SELECT DateOfDeparture,
		   Price AS [TicketPrice]
	  FROM Tickets
  ORDER BY Price,
		   DateOfDeparture DESC

GO

	/* PROBLEM 6 */
	SELECT p.[Name] AS PassengerName,
		   t.Price AS TicketPrice,
		   t.DateOfDeparture,
		   t.TrainId
	  FROM Passengers AS p
	  JOIN Tickets AS t ON p.Id=t.PassengerId
  ORDER BY t.Price DESC,
		   p.[Name]

GO

	/* PROBLEM 7 */
	SELECT tw.[Name] AS Town,
		   rs.[Name] AS RailwayStation
	  FROM RailwayStations AS rs
 LEFT JOIN TrainsRailwayStations AS trs ON rs.Id = trs.RailwayStationId
 LEFT JOIN Trains AS t  ON trs.TrainId = t.Id
	  JOIN Towns AS tw ON rs.TownId = tw.Id
     WHERE t.Id IS NULL
  ORDER BY tw.[Name],
		   rs.[Name]

GO

	/* PROBLEM 8 */
	SELECT TOP(3)
		   tr.Id AS [TrainId],
		   tr.HourOfDeparture,
		   tt.Price AS TicketPrice,
		   t.[Name] AS Destination
	  FROM Trains AS tr
	  JOIN Towns AS t ON tr.ArrivalTownId = t.Id
	  JOIN Tickets AS tt ON tr.Id = tt.TrainId
	 WHERE CONVERT(time ,HourOfDeparture) >= '08:00:00.0000000' 
	   AND CONVERT(time ,HourOfDeparture) <= '08:59:00.0000000'
	   AND tt.Price > 50
  ORDER BY tt.Price ASC

GO
	/* PROBLEM 9 */
	SELECT t.[Name] AS TownName,
		   COUNT(*) AS PassengersCount
	  FROM Passengers AS p
	  JOIN Tickets AS tt ON p.Id = tt.PassengerId
	  JOIN Trains AS tr ON tt.TrainId = tr.Id
	  JOIN Towns AS t ON tr.ArrivalTownId = t.Id
	 WHERE tt.Price > 76.99
  GROUP BY t.[Name]
  ORDER BY t.[Name]

GO

	/* PROBLEM 10 */
	SELECT mr.TrainId,
		   T.[Name] AS DepartureTown,
		   mr.Details
	  FROM MaintenanceRecords AS mr
	  JOIN Trains AS tr ON mr.TrainId = tr.Id
	  JOIN Towns AS t ON tr.DepartureTownId = t.Id
	 WHERE mr.Details LIKE '%inspection%'
  ORDER BY mr.TrainId

GO

/* SECTION 4 */
	/* PROBLEM 11 */
CREATE FUNCTION udf_TownsWithTrains(@name VARCHAR(30))
RETURNS INT
AS
BEGIN
	
RETURN (
			SELECT COUNT(*)
			  FROM Towns AS t
			  JOIN Trains AS td ON td.DepartureTownId = t.Id OR td.ArrivalTownId = t.Id
			 WHERE t.[Name] = @name
		  GROUP BY t.[Name]
	   )

END

GO

	/* PROBLEM 12 */
CREATE PROCEDURE usp_SearchByTown @townName VARCHAR(30)
AS
BEGIN
	SELECT p.[Name] AS PassengerName,
		   tt.DateOfDeparture,
		   ta.HourOfDeparture
	  FROM Passengers AS p
	  JOIN Tickets AS tt ON p.Id = tt.PassengerId
	  JOIN Trains AS ta ON tt.TrainId = ta.Id
	  JOIN Towns AS t ON ta.ArrivalTownId = t.Id
	 WHERE t.[Name] = @townName
  ORDER BY tt.DateOfDeparture DESC,
		   p.[Name]
END

GO