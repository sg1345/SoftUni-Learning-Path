/* Part I SoftUni Database */
 USE SoftUni

 GO

 /* PROBLEM 1 */
SELECT [FirstName], [LastName]
  FROM Employees
 WHERE LOWER([FirstName]) LIKE 'sa%'

 GO

SELECT [FirstName], [LastName]
  FROM Employees
 WHERE SUBSTRING(LOWER([FirstName]),1,2) = 'sa'

 GO

 /* PROBLEM 2 */
SELECT [FirstName],
	   [LastName]
  FROM Employees
 WHERE LOWER([LastName]) LIKE '%ei%'

GO

/* PROBLEM 3 */
SELECT [FirstName]
  FROM Employees
 WHERE [DepartmentID] IN (3,10)
	   AND DATEPART(YEAR,[HireDate]) BETWEEN 1995 AND 2005

GO

/* PROBLEM 4 */
SELECT [FirstName],
	   [LastName]
  FROM Employees
 WHERE CHARINDEX('engineer', LOWER(JobTitle)) = 0

GO

/* PROBLEM 5 */
  SELECT [Name]
    FROM [Towns]
   WHERE LEN(Name) IN (5, 6)
ORDER BY [Name]

GO

/* PROBLEM 6 */
  SELECT *
    FROM [Towns]
   WHERE SUBSTRING(LOWER(Name),1,1) IN ('m','k','b','e')
ORDER BY [Name]

GO

/* PROBLEM 7 */
  SELECT *
    FROM [Towns]
   WHERE SUBSTRING(LOWER(Name),1,1) NOT IN ('r','b','d')
ORDER BY [Name]

GO

/* PROBLEM 8 */
CREATE VIEW [V_EmployeesHiredAfter2000] AS
	 SELECT [FirstName],
			[LastName]
	   FROM Employees
	  WHERE DATEPART(YEAR,[HireDate]) > 2000

GO

/* PROBLEM 9 */
SELECT [FirstName],
	   [LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5

GO

/* PROBLEM 10 */
SELECT [EmployeeID],
	   [FirstName],
	   [LastName],
	   [Salary],
	   DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
  FROM Employees
  WHERE [Salary] BETWEEN 10000 AND 50000
  ORDER BY [Salary] DESC

GO

/* PROBLEM 11 */
SELECT [EmployeeID],
	   [FirstName],
	   [LastName],
	   [Salary],
	   [Rank]
  FROM (
		SELECT [EmployeeID],
			    [FirstName],
			    [LastName],
			    [Salary],
			    DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
		    FROM Employees
		    WHERE [Salary] BETWEEN 10000 AND 50000
        )
     AS [RankedTable]
  WHERE [Rank] = 2
ORDER BY [Salary] DESC

/* PART II Geography Database */
USE [Geography]

GO

/* PROBLEM 12 */
SELECT [CountryName] AS [Country Name],
	   [IsoCode] AS [ISO Code]
FROM [Countries]
WHERE  LOWER([CountryName]) LIKE '%a%a%a%'
ORDER BY [ISO Code]

GO

SELECT [CountryName] AS [Country Name],
	   [IsoCode] AS [ISO Code]
FROM [Countries]
WHERE  (LEN([CountryName]) - LEN(REPLACE(CountryName,'a', ''))) >=3
ORDER BY [ISO Code]

GO

/* PROBLEM 13 */
SELECT [p].[PeakName] AS [PeakName],
	   [r].[RiverName],
	   CONCAT(LOWER([p].[PeakName]), LOWER(SUBSTRING([r].[RiverName],2,LEN([r].[RiverName]) - 1))) AS [Mix]
FROM [Peaks] AS [p],[Rivers] AS [r]
WHERE SUBSTRING(LOWER([p].[PeakName]),LEN([p].[PeakName]),1) = SUBSTRING(LOWER([r].[RiverName]),1,1)
ORDER BY Mix

GO

SELECT [p].[PeakName],
	   [r].[RiverName],
	   CONCAT(SUBSTRING(LOWER([p].[PeakName]),1,LEN([p].[PeakName]) - 1),LOWER([r].[RiverName])) AS [Mix]
FROM [Peaks] AS [p],[Rivers] AS [r]
WHERE LOWER(RIGHT([PeakName],1)) = LOWER (LEFT([RiverName],1))
ORDER BY Mix

GO

/* PART III Diablo Database */
USE [Diablo]

GO

/* PROBLEM 14 */
  SELECT TOP(50)
	     [Name],
	     FORMAT([Start],'yyyy-MM-dd') AS [Start]
    FROM Games
   WHERE DATEPART(YEAR,[Start]) IN (2011,2012)
ORDER BY [Start],
		 [Name]

GO

/* PROBLEM 15 */
  SELECT [Username],
		 SUBSTRING(
					[Email],
					CHARINDEX( '@', [Email], 1) + 1,
					LEN([Email]) - (CHARINDEX( '@', [Email], 1))
				   ) AS [Email Provider]
    FROM Users
ORDER BY [Email Provider],
		 [Username]

GO

/* PROBLEM 16 */
SELECT [Username],
	   [IpAddress] AS [IP Address]
  FROM Users
 WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY [Username]

GO

/* PROBLEM 17 */
SELECT [Name],
	   CASE
			WHEN DATEPART(HOUR,[Start]) BETWEEN 0 AND 11 THEN 'Morning'
			WHEN DATEPART(HOUR,[Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
			WHEN DATEPART(HOUR,[Start]) BETWEEN 18 AND 23 THEN 'Evening'
	   END AS [Part of the Day],
	   CASE
			WHEN [Duration] <= 3 THEN 'Extra Short'
			WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
			WHEN [Duration] > 6 THEN 'Long'
			WHEN [Duration] IS NULL THEN 'Extra Long'
	   END
	   [Duration]
FROM Games
ORDER BY [Name],
		 [Duration],
		 [Part of the Day]

GO

/* PART IV Orders Database */
USE Orders

GO

/* PROBLEM 18 */
SELECT [ProductName],
	   [OrderDate],
	   DATEADD( DAY, 3, [OrderDate]) AS [Pay Due],
	   DATEADD( MONTH, 1, [OrderDate]) AS [Deliver Due]
  FROM Orders

