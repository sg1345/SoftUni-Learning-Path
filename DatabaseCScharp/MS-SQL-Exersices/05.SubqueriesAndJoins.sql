/* PART I SoftUni Database */
USE SoftUni

GO

/* PROBLEM 1 */
  SELECT TOP(5)
	     e.EmployeeID,
	     e.JobTitle,
	     e.AddressID,
	     a.AddressText
    FROM Employees [e]
    JOIN Addresses [a] ON e.AddressID = a.AddressID
ORDER BY e.AddressID ASC

GO

/* PROBLEM 2 */
  SELECT TOP(50)
		 e.FirstName,
		 e.LastName,
		 t.[Name],
		 a.AddressText
    FROM Employees [e]
	JOIN Addresses [a] ON e.AddressID = a.AddressID
	JOIN Towns [t] ON t.TownID = a.TownID
ORDER BY FirstName,
		 LastName

GO

/* PROBLEM 3 */
   SELECT e.EmployeeID,
		  e.FirstName,
		  e.LastName,
		  d.[Name]
     FROM Employees [e]
LEFT JOIN Departments [d] ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] = 'Sales'
 ORDER BY e.EmployeeID ASC

GO

/* PROBLEM 4 */
   SELECT TOP(5)
		  e.EmployeeID,
		  e.FirstName,
		  e.Salary,
		  d.[Name]
     FROM Employees [e]
LEFT JOIN Departments [d] ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary > 15000
 ORDER BY e.DepartmentID ASC

GO

/* PROBLEM 5 */
   SELECT TOP(3)
		  e.EmployeeID,
		  e.FirstName
     FROM Employees [e]
LEFT JOIN EmployeesProjects [ep] ON [ep].EmployeeID = e.EmployeeID
LEFT JOIN Projects [p] ON p.ProjectID = [ep].ProjectID
    WHERE p.ProjectID  IS NULL
 ORDER BY e.EmployeeID ASC

GO

 /* PROBLEM 6 */
   SELECT e.FirstName,
		  e.LastName,
		  e.HireDate,
		  d.[Name] AS [DeptName]
     FROM Employees [e]
	 JOIN Departments [d] ON e.DepartmentID = d.DepartmentID
	WHERE e.HireDate > '1999-01-01'
	  AND d.[Name] IN ('Sales', 'Finance')
 ORDER BY e.HireDate ASC

GO

/* PROBLEM 7 */
   SELECT TOP(5) 
		  e.EmployeeID,
		  e.FirstName,
		  p.[Name] AS 'ProjectName'
     FROM Employees [e]
	 JOIN EmployeesProjects [ep] ON ep.EmployeeID = e.EmployeeID
	 JOIN Projects [p] ON p.ProjectID = ep.ProjectID
    WHERE p.StartDate > '2002-08-13'
	  AND p.EndDate IS NULL
 ORDER BY e.EmployeeID ASC

GO

/* PROBLEM 8 */
   SELECT e.EmployeeID,
		  e.FirstName,
		  CASE
				WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
				ELSE p.[Name]
		  END AS [ProjectName]
     FROM Employees [e]
	 JOIN EmployeesProjects [ep] ON ep.EmployeeID = e.EmployeeID
	 JOIN Projects [p] ON p.ProjectID = ep.ProjectID
    WHERE e.EmployeeID = 24

GO

/* PROBLEM 9 */
   SELECT e.EmployeeID,
		  e.FirstName,
		  e.ManagerID,
		  m.FirstName
     FROM Employees [e]
	 JOIN Employees [m] ON e.ManagerID = m.EmployeeID
    WHERE m.EmployeeID IN (3,7)
 ORDER BY e.EmployeeID ASC

GO

/* PROBLEM 10 */
   SELECT TOP(50) 
		  e.EmployeeID,
		  CONCAT_WS(' ', e.FirstName, e.LastName) AS [EmployeeName],
		  CONCAT_WS(' ',m.FirstName, m.LastName) AS [ManagerName],
		  d.[Name] AS [DepartmentName]
     FROM Employees [e]
	 JOIN Departments [d] ON  e.DepartmentID = d.DepartmentID
	 JOIN Employees [m] ON e.ManagerID = m.EmployeeID
 ORDER BY e.EmployeeID

GO

/* PROBLEM 11 */
    SELECT MIN(TEMP.AverageSalary) AS MinAverageSalary
	  FROM(
			  SELECT e.DepartmentID,
				     AVG(e.Salary) AS AverageSalary
			    FROM Employees [e]
			GROUP BY e.DepartmentID
		   ) AS TEMP

	GO


/* PART II Geography Database */
USE [Geography]
GO

/* PROBLEM 12 */
    SELECT c.CountryCode,
		   m.MountainRange,
		   p.PeakName,
		   p.Elevation
	  FROM Countries AS [c]
	  JOIN MountainsCountries AS [mc] ON c.CountryCode = mc.CountryCode
	  JOIN Mountains AS [m] ON mc.MountainId = m.Id
	  JOIN Peaks AS [p] ON p.MountainId = m.Id
	 WHERE c.CountryName = 'Bulgaria'
	   AND p.Elevation > 2835
  ORDER BY p.Elevation DESC

GO

/* PROBLEM 13 */
    SELECT c.CountryCode,
		   COUNT(c.CountryCode) AS [MountainRanges]
	  FROM Countries AS [c]
	  JOIN MountainsCountries AS [mc] ON c.CountryCode = mc.CountryCode
	  JOIN Mountains AS [m] ON mc.MountainId = m.Id
	 WHERE c.CountryCode IN ('BG', 'RU', 'US')
  GROUP BY c.CountryCode
  ORDER BY c.CountryCode

GO

/* PROBLEM 14 */
    SELECT TOP(5)
		   c.CountryName,
		   r.RiverName
	  FROM Countries AS [c]
 LEFT JOIN CountriesRivers AS [cr] ON c.CountryCode = cr.CountryCode
 LEFT JOIN Rivers AS [r] ON cr.RiverId = r.Id
	 WHERE c.ContinentCode = 'AF'
  ORDER BY c.CountryName ASC

GO

/* PROBLEM 16 */
    SELECT COUNT(c.CountryCode)
      FROM Countries AS [c]
 LEFT JOIN MountainsCountries AS [mc] ON c.CountryCode = mc.CountryCode
 LEFT JOIN Mountains AS [m] ON mc.MountainId = m.Id
     WHERE m.Id IS NULL

GO

/* PROBLEM 17 */
    SELECT TOP(5)
		   c.CountryName,
		   MAX(p.Elevation) AS [HighestPeakElevation],
		   MAX(r.Length) AS [LongestRiverLength]
	  FROM Countries AS [c]
	  JOIN MountainsCountries AS [mc] ON c.CountryCode = mc.CountryCode
	  JOIN Mountains AS [m] ON mc.MountainId = m.Id
	  JOIN Peaks AS [p] ON m.Id = p.MountainId
	  JOIN CountriesRivers AS [cr] ON c.CountryCode = cr.CountryCode
	  JOIN Rivers AS [r] ON cr.RiverId = r.Id
  GROUP BY c.CountryName
  ORDER BY HighestPeakElevation DESC,
		   LongestRiverLength DESC,
		   c.CountryName ASC