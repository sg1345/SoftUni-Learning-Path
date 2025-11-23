--PROBLEM 1
CREATE DATABASE [Minions]

GO

--PROBLEM 2
CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY,
	[Name] varchar(50),
	[Age] INT
);



--PROBLEM 3
CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY,
	[Name] varchar(150) NOT NULL
);



ALTER TABLE [Minions]
ADD [TownId] INT NOT NULL



ALTER TABLE [Minions]
ADD CONSTRAINT FK_Minions_Towns
FOREIGN KEY (TownId) REFERENCES Towns(Id)


--PROBLEM 4
INSERT INTO [Towns] ([Id],[Name])
VALUES (1, 'Sofia'),
	   (2, 'Plovdiv'),
	   (3, 'Varna');


INSERT INTO [Minions] ([Id],[Name],[Age],[TownId])
VALUES (1,'Kevin', 22, 1),
	   (2,'Bob', 15, 3),
	   (3, 'Steward', NULL, 2);


SELECT * FROM [Towns]
SELECT * FROM [Minions]

--PROBLEM 5
TRUNCATE TABLE [Minions]

--PROBLEM 6
ALTER TABLE [Minions]
DROP CONSTRAINT FK_Minions_Towns;

DROP TABLE [Minions]
DROP TABLE [Towns]

--PROBLEM 7
USE Minions

GO

CREATE TABLE [People](
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(200) NOT NULL,
	[Picture] VARBINARY(MAX) NULL CHECK (DATALENGTH([Picture]) <= 2097152),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	[Gender] NCHAR(1) NOT NULL CHECK([Gender] IN ('m', 'f')),
	[Birthdate] DATE NOT NULL,
	[Biography] nvarchar(MAX)
)

INSERT INTO [People]
			([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
	 VALUES ('Ana', NULL, 1.7, 65, 'm','1995-07-12', '2 times TI Winner. Ex OG player on Carry position'),
			('Ame', NULL, 1.71, 65.50, 'm','1995-09-11', '3 times TI finalist. Played for PSG.LGD and XG.'),
			('Ammar The F', NULL, 1.77, 85.20, 'm', '1995-01-01', 'TI14 winner (2025). He is playing for Falcon Gaming.'),
			('Ephey', NULL, 1.60, 45.50, 'f','1995-05-15',NULL),
			('SyndereN', NULL, 1.80, 86, 'm', '1989-12-24', 'Dota 2 Analyst and Commentator. Ex mousesports player.')
GO

/* PROBLEM 8 */
CREATE DATABASE [01_DatabaseIntroduction]

GO

USE [01_DatabaseIntroduction]

GO

CREATE TABLE [Users](
	[Id] BIGINT IDENTITY PRIMARY KEY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX) NULL CHECK (DATALENGTH([ProfilePicture]) <= 921600),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT
)

INSERT INTO [Users]([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
	VALUES
			('ALOOOOU', '123456789', NULL,'2025-09-22 02:51:12',0),
			('Ame', 'qwertyuiop', NULL, '2025-09-21 18:31:55', 0),
			('ManOfHonor', 'asdfghjkl', NULL, '2024-04-12 21:45:01', 1),
			('Maestro_DPL', '1234567890', NULL, '2025-09-22 01:14:55', 0),
			('Mims', 'qwertyuiop', NULL, '2025-09-13 22:22:22', 0)

GO

/* PROBLEM 9 */
ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC0735C841F4]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_Users_Id_Username] PRIMARY KEY([Id], [Username])

GO

/* PROBLEM 10 */

/* PROBLEM 11 */

/* PROBLEM 12 */

/* PROBLEM 13 */
CREATE DATABASE Movies

GO

USE Movies

GO

CREATE TABLE [Directors] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(2000) NULL
	)

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(2000) NULL
	)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(2000) NULL
	)

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] VARCHAR(150) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrightYear] INT NOT NULL,
	[Length] INT NOT NULL, --IN MINUTES
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Rating] DECIMAL(3,1) NOT NULL,
	[Notes] VARCHAR(2000) NULL
	)

INSERT INTO Directors (DirectorName, Notes)
	VALUES 
			('Christopher Nolan', 'Known for mind-bending plots and visual storytelling.'),
			('Steven Spielberg', 'Legendary filmmaker with decades of hits.'),
			('Peter Jackson', 'Famous for The Lord of the Rings trilogy.'),
			('Quentin Tarantino', 'Cult director known for dialogue and violence.'),
			('Hayao Miyazaki', 'Renowned Japanese animation director.')

INSERT INTO Genres (GenreName, Notes)
	VALUES
			('Action', 'Fast-paced, high-energy films.'),
			('Adventure', 'Epic journeys and exploration.'),
			('Animation', 'Animated films for all ages.'),
			('Drama', 'Emotionally-driven stories.'),
			('Thriller', 'Suspenseful, edge-of-your-seat narratives.')

INSERT INTO Categories (CategoryName, Notes)
	VALUES
			('Blockbuster', 'High-budget, widely released films.'),
			('Indie', 'Independent, often low-budget films.'),
			('Classic', 'Timeless, iconic films.'),
			('Family', 'Suitable for all ages.'),
			('Cult', 'Films with devoted niche audiences.')

INSERT INTO Movies (Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
	VALUES
			('Inception', 1, 2010, 148, 1, 1, 8.8, 'Sci-fi thriller with dreams within dreams.'),
			('Jurassic Park', 2, 1993, 127, 2, 1, 8.1, 'Dinosaurs brought back to life.'),
			('The Lord of the Rings: The Return of the King', 3, 2003, 201, 2, 1, 8.9, 'Epic conclusion to the trilogy.'),
			('Pulp Fiction', 4, 1994, 154, 4, 5, 8.9, 'Non-linear crime story with iconic dialogue.'),
			('Spirited Away', 5, 2001, 125, 3, 4, 8.6, 'Animated fantasy film from Studio Ghibli.')

GO

/* PROBLEM 14 */
CREATE DATABASE CarRental

GO

USE CarRental

GO

CREATE TABLE Categories (
	Id INT IDENTITY PRIMARY KEY,
	CategoryName VARCHAR(100) NOT NULL,
	DailyRate DECIMAL(18,2) NOT NULL,
    WeeklyRate DECIMAL(18,2) NOT NULL,
    MonthlyRate DECIMAL(18,2) NOT NULL,
    WeekendRate DECIMAL(18,2) NOT NULL
)


CREATE TABLE Cars (
	Id INT IDENTITY PRIMARY KEY,
	PlateNumber VARCHAR(15),
	Manufacturer VARCHAR(100) NOT NULL,
	Model VARCHAR(100) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors INT NOT NULL,
	Picture VARBINARY(MAX) NULL,
	Condition VARCHAR(50),
	Available BIT NOT NULL,
)


CREATE TABLE Employees(
	Id INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	Title VARCHAR(100) NOT NULL,
	Notes VARCHAR(2000) NULL
)


CREATE TABLE Customers (
	Id INT IDENTITY PRIMARY KEY,
	DriverLicenceNumber VARCHAR(20) NOT NULL,
	FullName VARCHAR(300) NOT NULL,
	[Address] VARCHAR(200) NOT NULL,
	City VARCHAR(100) NOT NULL, 
	ZIPCode VARCHAR(10) NOT NULL, 
	Notes VARCHAR(2000) NULL
)


CREATE TABLE RentalOrders (
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL, 
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL, 
	TankLevel INT NOT NULL, 
	KilometrageStart INT NOT NULL, 
	KilometrageEnd INT NOT NULL, 
	TotalKilometrage AS (KilometrageEnd - KilometrageStart), 
	StartDate DATE NOT NULL, 
	EndDate DATE NOT NULL, 
	TotalDays AS DATEDIFF(DAY,StartDate,EndDate), 
	RateApplied DECIMAL(18,2), 
	TaxRate DECIMAL(5,2), 
	OrderStatus BIT NOT NULL, 
	Notes VARCHAR(2000) NULL
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES 
('Economy', 30.50, 200.00, 700.00, 60.00),
('Standard', 50.00, 320.00, 1200.00, 100.00),
('Luxury', 80.00, 500.00, 1800.00, 150.00)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
('M-AB1234', 'Toyota', 'Corolla', 2020, 1, 4, NULL, 'Good', 1),
('M-CD5678', 'BMW', '320i', 2021, 2, 4, NULL, 'Excellent', 1),
('M-EF9012', 'Mercedes', 'C-Class', 2022, 3, 4, NULL, 'Excellent', 1)

INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES
('Alice', 'Smith', 'Manager', 'Experienced in fleet management'),
('Bob', 'Johnson', 'Sales', 'Handles VIP clients'),
('Carol', 'Williams', 'Support', 'Specializes in rental issues')

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
VALUES
('D1234567', 'John Doe', '123 Main St', 'Munich', '80331', 'Regular customer'),
('D2345678', 'Jane Roe', '456 Elm St', 'Munich', '80333', 'Prefers luxury cars'),
('D3456789', 'Mike Lee', '789 Oak St', 'Munich', '80335', 'Needs weekend rentals')

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 1, 1, 100, 12000, 12200, '2025-10-01', '2025-10-05', 30.50, 19.00, 1, 'No issues'),
(2, 2, 2, 80, 5000, 5400, '2025-10-02', '2025-10-09', 50.00, 19.00, 1, 'VIP rental'),
(3, 3, 3, 100, 2000, 2200, '2025-10-03', '2025-10-06', 80.00, 19.00, 1, 'Weekend rental')

GO

/* PROBLEM 15 */
CREATE DATABASE Hotel

GO

USE Hotel

GO

CREATE TABLE Employees (
	Id INT IDENTITY PRIMARY KEY, 
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL, 
	Title VARCHAR(100) NOT NULL, 
	Notes VARCHAR(2000) NULL
)

CREATE TABLE Customers (
	AccountNumber INT IDENTITY PRIMARY KEY, 
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL, 
	PhoneNumber VARCHAR(30) NOT NULL, 
	EmergencyName VARCHAR(50) NOT NULL, 
	EmergencyNumber VARCHAR(30) NULL, 
	Notes VARCHAR(2000) NULL
)

CREATE TABLE RoomStatus (
	RoomStatus VARCHAR(50) PRIMARY KEY,
	Notes VARCHAR(2000) NULL
)

CREATE TABLE RoomTypes (
	RoomType VARCHAR(50) PRIMARY KEY,
	Notes VARCHAR(2000) NULL
)

CREATE TABLE BedTypes (
	BedType VARCHAR(50) PRIMARY KEY,
	Notes VARCHAR(2000) NULL
)

CREATE TABLE Rooms (
	RoomNumber CHAR(4) PRIMARY KEY,
	RoomType VARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType VARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate DECIMAL(18,2) NOT NULL, 
	RoomStatus VARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL, 
	Notes VARCHAR(2000) NULL
)

CREATE TABLE Payments (
	Id INT IDENTITY PRIMARY KEY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
	PaymentDate DATE NOT NULL, 
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL, 
	FirstDateOccupied DATE NOT NULL, 
	LastDateOccupied DATE NOT NULL, 
	TotalDays AS DATEDIFF(DAY,FirstDateOccupied,LastDateOccupied), 
	AmountCharged DECIMAL(18,2) NOT NULL, 
	TaxRate DECIMAL(5,2) NOT NULL, 
	TaxAmount AS (AmountCharged * TaxRate / 100), 
	PaymentTotal AS (AmountCharged + (AmountCharged * TaxRate / 100)), 
	Notes VARCHAR(2000) NULL
)

CREATE TABLE Occupancies (
	Id INT IDENTITY PRIMARY KEY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
	DateOccupied DATE NOT NULL, 
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL, 
	RoomNumber CHAR(4) FOREIGN KEY REFERENCES Rooms (RoomNumber), 
	RateApplied DECIMAL(18,2) NOT NULL, 
	PhoneCharge DECIMAL(18,2) NOT NULL, 
	Notes VARCHAR(2000) NULL
)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('Alice', 'Smith', 'Manager', 'Oversees all room operations'),
('Bob', 'Johnson', 'Reception', 'Handles check-ins and payments'),
('Carol', 'Williams', 'Housekeeping', 'Responsible for room cleaning')

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
('John', 'Doe', '+491761234567', 'Jane Doe', '+491761234568', 'VIP customer'),
('Mary', 'Roe', '+491761234569', 'Paul Roe', '+491761234570', 'Prefers quiet rooms'),
('Mike', 'Lee', '+491761234571', 'Linda Lee', '+491761234572', 'Weekend bookings')

INSERT INTO RoomStatus (RoomStatus, Notes) VALUES
('Available', 'Room ready for check-in'),
('Occupied', 'Currently occupied by a guest'),
('Maintenance', 'Room under maintenance')

INSERT INTO RoomTypes (RoomType, Notes) VALUES
('Single', '1 bed, 1 person'),
('Double', '2 beds, up to 2 people'),
('Suite', 'Luxury suite with living area')

INSERT INTO BedTypes (BedType, Notes) VALUES
('Twin', 'Two separate beds'),
('Queen', 'One queen-size bed'),
('King', 'One king-size bed')

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
('101A', 'Single', 'Twin', 50.00, 'Available', 'Quiet room near elevator'),
('102B', 'Double', 'Queen', 80.00, 'Occupied', 'Includes balcony'),
('201C', 'Suite', 'King', 150.00, 'Maintenance', 'Luxury suite with sea view')

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate, Notes) VALUES
(1, '2025-10-01', 1, '2025-10-01', '2025-10-03', 100.00, 19.00, 'Regular stay'),
(2, '2025-10-02', 2, '2025-10-02', '2025-10-05', 240.00, 19.00, 'Weekend booking'),
(3, '2025-10-03', 3, '2025-10-03', '2025-10-04', 150.00, 19.00, 'VIP booking')

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, '2025-10-01', 1, '101A', 50.00, 5.00, 'Checked in late evening'),
(2, '2025-10-02', 2, '102B', 80.00, 0.00, 'No extra charges'),
(3, '2025-10-03', 3, '201C', 150.00, 10.00, 'VIP customer used phone service')


GO

/* PROBLEM 16 */
/* PROBLEM 17 */
/* PROBLEM 18 */

/* PROBLEM 19 */
USE SoftUni

GO

    SELECT *
	  FROM Towns

    SELECT *
	  FROM Departments

    SELECT *
	  FROM Employees

GO

/* PROBLEM 20 */
    SELECT *
	  FROM Towns AS t
  ORDER BY t.[Name]

    SELECT *
	  FROM Departments AS d
  ORDER BY d.[Name]

    SELECT *
	  FROM Employees AS e
  ORDER BY e.Salary DESC

GO

/* PROBLEM 21 */
    SELECT t.[Name]
	  FROM Towns AS t
  ORDER BY t.[Name]

    SELECT d.[Name]
	  FROM Departments AS d
  ORDER BY d.[Name]

    SELECT e.FirstName,
		   e.LastName,
		   e.JobTitle,
		   e.Salary
	  FROM Employees AS e
  ORDER BY e.Salary DESC

GO

/* PROBLEM 22 */
UPDATE Employees
SET	Salary = Salary + (Salary * 0.1) --I never execute it

    SELECT e.Salary
	  FROM Employees AS e

GO

/* PROBLEM 23 */
USE Hotel

GO

UPDATE Payments
SET TaxRate = TaxRate - 0.03 -- its judge based Database and its never executed

SELECT TaxRate
  FROM Payments

GO