/* PART I Gringotts Database */
USE Gringotts

GO

/* PROBLEM 1 */
    SELECT Count(*)
      FROM WizzardDeposits AS [k]

GO

/* PROBLEM 2 */
    SELECT MAX(w.MagicWandSize) AS [LongestMagicWand]
      FROM WizzardDeposits AS [w]

GO

/* PROBLEM 3 */
    SELECT w.DepositGroup,
           MAX(w.MagicWandSize) AS [LongestMagicWand]
      FROM WizzardDeposits AS [w]
  GROUP BY w.DepositGroup

GO

/* PROBLEM 4 */
/* PROBLEM 5 */
/* PROBLEM 6 */
/* PROBLEM 7 */
/* PROBLEM 8 */
/* PROBLEM 9 */
/* PROBLEM 10 */

/* PROBLEM 11 */
    SELECT w.DepositGroup,
           w.IsDepositExpired,
           AVG(w.DepositInterest) AS [AverageInterest]
      FROM WizzardDeposits AS w
     WHERE DepositStartDate > '1985-01-01'
  GROUP BY w.DepositGroup, IsDepositExpired
  ORDER BY w.DepositGroup DESC,
           w.IsDepositExpired

GO

/* PROBLEM 12 */

/* PART II SoftUni Database */
USE SoftUni

GO

/* PROBLEM 13 */
    SELECT e.DepartmentID,
           SUM(Salary) AS [TotalSalary]
      FROM Employees AS e
  GROUP BY e.DepartmentID
  ORDER BY e.DepartmentID

GO

/* PROBLEM 14 */
    SELECT e.DepartmentID,
           MIN(Salary) AS [MinimumSalary]
      FROM Employees AS e
     WHERE e.HireDate > '2000-01-01'
  GROUP BY e.DepartmentID
    HAVING e.DepartmentID IN (2,5,7)
  ORDER BY e.DepartmentID

GO

/* PROBLEM 15 */
    SELECT *
      INTO [FilteredEmployeeTable]
      FROM Employees AS e
     WHERE e.Salary > 30000

     DELETE 
       FROM FilteredEmployeeTable
      WHERE ManagerID = 42


    SELECT fe.DepartmentID,
           CASE
                WHEN fe.DepartmentID = 1 THEN AVG(fe.Salary) + 5000
                ELSE AVG(fe.Salary)
           END AS [AverageSalary]
      FROM FilteredEmployeeTable AS [fe]
  GROUP BY fe.DepartmentID

GO

/* PROBLEM 16 */
    SELECT e.DepartmentID,
           MAX(e.Salary) AS [MaxSalary]
      FROM Employees AS e
  GROUP BY e.DepartmentID
    HAVING MAX(e.Salary) < 30000 
        OR MAX(e.Salary) > 70000

GO

/* PROBLEM 17 */
    SELECT COUNT(*)
      FROM Employees AS e
     WHERE e.ManagerID IS NULL