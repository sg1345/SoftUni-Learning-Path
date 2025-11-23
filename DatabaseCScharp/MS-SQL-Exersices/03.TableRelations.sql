CREATE DATABASE [03_TableRelations]

GO

USE [03_TableRelations]

GO

/* PROBLEM 1 */
CREATE TABLE [Passports] (
	[PassportID] INT IDENTITY(101,1) PRIMARY KEY,
	[PassportNumber] CHAR(8) NOT NULL
)

CREATE TABLE [Persons](
	[PersonID] INT IDENTITY PRIMARY KEY,
	[FirstName] VARCHAR(50) NOT NULL,
	[Salary] DECIMAL(18,2) NOT NULL,
	[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE NOT NULL 
)

INSERT INTO [Passports] ([PassportNumber])
	VALUES
			('N34FG21B'),
			('K65LO4R7'),
			('ZE657QP2')

INSERT INTO [Persons]([FirstName], [Salary], [PassportID])
	VALUES
			('Roberto', 43300.00, 102),
			('Tom', 56100.00, 103),
			('Yana', 60200, 101)

GO

/* PROBLEM 2 */
CREATE TABLE [Manufacturers](
	[ManufacturerID] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(80) UNIQUE NOT NULL,
	[EstablishedOn] DATE NOT NULL
)

CREATE TABLE [Models](
	[ModelID] INT IDENTITY(101,1) PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[ManufacturerID] INT FOREIGN KEY REFERENCES Manufacturers([ManufacturerID]) NOT NULL
)

INSERT INTO [Manufacturers]([Name], [EstablishedOn])
	VALUES
			('BMW', '07/03/1916'),
			('Tesla', '01/01/2003'),
			('Lada', '01/05/1966')

INSERT INTO [Models]([Name], [ManufacturerID])
	VALUES 
			('X1', 1),
			('i6', 1),
			('Model S', 2),
			('Model X', 2),
			('Model 3', 2),
			('Nova', 3)

GO

/* PROBLEM 3 */
CREATE TABLE [Exams](
	[ExamID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(100)
)

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE [StudentsExams](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL,
	[ExamID] INT  FOREIGN KEY REFERENCES [Exams]([ExamID]) NOT NULL,
	PRIMARY KEY([StudentID], [ExamID])
)

INSERT INTO [Students]([Name])
	VALUES
			('Mila'),
			('Toni'),
			('Ron')

INSERT INTO [Exams]([Name])
	VALUES
			('SpringMVC'),
			('Neo4j'),
			('Oracle 11g')

INSERT INTO [StudentsExams]([StudentID], [ExamID])
	VALUES
			(1, 101),
			(1, 102),
			(2, 101),
			(3, 103),
			(2, 102),
			(2, 103)

GO

/* PROBLEM 4 */
CREATE TABLE [Teachers](
	[TeacherID] INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID]) NULL
)

INSERT INTO [Teachers]([Name], [ManagerID])
	VALUES
			('John', NULL),
			('Maya', 106),
			('Silvia', 106),
			('Ted', 105),
			('Mark', 101),
			('Greta', 101)

GO

/* PROBLEM 5 */
CREATE TABLE [Cities](
	[CityID] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL
)

CREATE TABLE [Customers](
	[CustomerID] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[Birthday] DATE NOT NULL,
	[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID]) NOT NULL,
)

CREATE TABLE [Orders](
	[OrderID] INT IDENTITY PRIMARY KEY,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID]) NOT NULL,
)

CREATE TABLE [ItemTypes](
	[ItemTypeID] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
)

CREATE TABLE [Items](
	[ItemID] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
)

CREATE TABLE [OrderItems](
	[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]),
	[ItemID] INT FOREIGN KEY  REFERENCES [Items]([ItemID])
	PRIMARY KEY([OrderID], [ItemID])
)

GO

/* PROBLEM 6 */
CREATE TABLE [Subjects](
	[SubjectID] INT IDENTITY PRIMARY KEY,
	[SubjectName] VARCHAR(100) NOT NULL
)

CREATE TABLE [Majors](
	[MajorID] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL
)
/* The table Students already exists in the database, 
   but you need to change it in order to get the points from this problem */
CREATE TABLE [Students01](
	[StudentID] INT IDENTITY PRIMARY KEY,
	[StudentNumber] VARCHAR(20) NOT NULL,
	[StudentName] VARCHAR(100) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID]) NOT NULL
)

CREATE TABLE [Agenda](
	[StudentID] INT FOREIGN KEY REFERENCES [Students01]([StudentID]),
	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID])
	PRIMARY KEY([StudentID], [SubjectID])
)

CREATE TABLE [Payments](
	[PaymentsID] INT IDENTITY PRIMARY KEY,
	[PaymentDate] DATETIME NOT NULL,
	[PaymentAmount] DECIMAL(18, 2) NOT NULL,
	[StudentID] INT FOREIGN KEY REFERENCES [Students01]([StudentID])
)

/* PROBLEM 9 */
USE [Geography]
GO

    SELECT m.[MountainRange],
	       p.[PeakName],
	       p.[Elevation]
      FROM [Mountains] [m]
INNER JOIN [Peaks] [p] ON m.[Id] = p.[MountainId]
     WHERE m.MountainRange = 'Rila'
  ORDER BY P.[Elevation] DESC