/* PART I SoftUni */
USE SoftUni

GO

/* PROBLEM 2 */
SELECT * 
  FROM [Departments]

GO	

/* PROBLEM 3 */
SELECT [Name]
  FROM [Departments]

GO

/* PROBLEM 4 */
SELECT [FirstName],
	   [LastName],
	   [Salary]
  FROM [Employees]

GO

/* PROBLEM 5 */
SELECT [FirstName],
	   [MiddleName],
	   [LastName]
  FROM [Employees]

GO

/* PROBLEM 6 */
SELECT CONCAT([FirstName],'.',[LastName],'@softuni.bg')
	AS [Full Email Address]
  FROM [Employees]

GO

/* PROBLEM 7 */
SELECT DISTINCT [Salary] 
           FROM [Employees]
       ORDER BY [Salary] ASC

GO

/* PROBLEM 8 */
SELECT *
  FROM [Employees]
 WHERE [JobTitle] = 'Sales Representative'

GO

/* PROBLEM 9 */
SELECT [FirstName],
	   [LastName],
	   [JobTitle]
  FROM [Employees]
 WHERE [Salary] >= 20000 AND [Salary] <= 30000

GO

/* PROBLEM 10 */
SELECT CONCAT_WS(' ',[FirstName],[MiddleName],[LastName])
	AS [Full Name]
  FROM [Employees]
 WHERE [Salary] IN (25000, 14000, 12500, 23600)

 /* PROBLEM 11 */
 SELECT [FirstName], [LastName]
   FROM [Employees]
  WHERE [ManagerID] IS NULL

GO

/* PROBLEM 12 */
  SELECT [FirstName], [LastName], [Salary]
    FROM [Employees]
   WHERE [Salary] > 50000
ORDER BY [Salary] desc

GO

/* PROBLEM 13 */
  SELECT TOP(5) [FirstName], [LastName]
           FROM [Employees]
       ORDER BY [Salary] desc

GO

/* PROBLEM 14 */
SELECT *
  FROM [Departments]

GO

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [DepartmentID] != 4

GO

 /* PROBLEM 15 */

  SELECT *
    FROM [Employees]
ORDER BY [Salary] DESC,
		 [FirstName] ASC,
		 [LastName] DESC,
		 [MiddleName] ASC

GO

/* PROBLEM 16 */
CREATE VIEW [V_EmployeesSalaries] AS
     SELECT [FirstName], [LastName], [Salary]
	   FROM [Employees]

GO

/* PROBLEM 17 */
CREATE VIEW [V_EmployeeNameJobTitle] AS
	 SELECT CONCAT([FirstName], ' ', [MiddleName], ' ',[LastName]) AS [Full Name],
			[JobTitle]
	   FROM [Employees]

GO

/* PROBLEM 18 */
SELECT DISTINCT [JobTitle]
           FROM [Employees]

GO

/* PROBLEM 19 */
SELECT TOP(10) [ProjectID] AS [ID], [Name], [Description], [StartDate], [EndDate]
		  FROM [Projects]
	  ORDER BY [StartDate] ASC,
			   [Name] ASC

GO

/* PROBLEM 20 */
SELECT TOP(7) [FirstName], [LastName], [HireDate]
		 FROM [Employees]
	 ORDER BY [HireDate] DESC

GO

/* PROBLEM 21 */
 UPDATE [Employees]
	SET [Salary]+= 0.12*[Salary]
  WHERE [DepartmentID] IN (
						   SELECT [DepartmentID]
							 FROM [Departments]
							WHERE [Name] IN ('Engineering','Tool Design', 'Marketing', 'Information Services')
						   )

 SELECT [Salary]
   FROM [Employees]

GO
/* way to test before commit!!!!

BEGIN TRANSACTION;

UPDATE Employees
SET Salary = Salary * 1.1
WHERE DepartmentID IN (1, 2, 3);

-- Preview the results
SELECT * FROM Employees;

-- If OK:
COMMIT TRANSACTION;

-- If not OK:
-- ROLLBACK TRANSACTION;
*/

/* PART II Geography */

USE [Geography]

GO

/* PROBLEM 22 */
  SELECT [PeakName]
    FROM [Peaks]
ORDER BY [PeakName] ASC

GO

/* PROBLEM 23 */
  SELECT TOP(30) [CountryName], [Population]
			FROM [Countries]
		   WHERE [ContinentCode] = (
							SELECT [ContinentCode]
							  FROM [Continents]
							 WHERE [ContinentName] = 'Europe' 
							)
		ORDER BY [Population] DESC,
				 [CountryName] ASC

GO

/* PROBLEM 24 */
  SELECT [CountryName], 
		 [CountryCode],
		 CASE
			WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
			ELSE  'Not Euro'
		 END AS [Currency]
    FROM [Countries]
ORDER BY [CountryName] ASC

GO

/* PART III Diablo */

USE [Diablo]

GO

/* PROBLEM 25 */
  SELECT [Name]
    FROM [Characters]
ORDER BY [Name] ASC

GO