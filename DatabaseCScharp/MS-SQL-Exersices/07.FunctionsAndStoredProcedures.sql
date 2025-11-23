/* PART I SoftUni Database */
USE SoftUni

GO

/* PROBLEM 1 */
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName,
		   LastName
	  FROM Employees
	 WHERE Salary > 35000

END

GO

/* PROBLEM 2 */
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @salary DECIMAL(18,4)
AS  
BEGIN
	SELECT FirstName,
		   LastName
	  FROM Employees
	 WHERE Salary >= @salary

END

GO

/* PROBLEM 3 */
CREATE PROCEDURE usp_GetTownsStartingWith @startingLetter VARCHAR(50)
AS  
BEGIN
	SELECT [Name]
      FROM Towns
     WHERE CHARINDEX(@startingLetter, [Name], 1) = 1

END

GO

/* PROBLEM 4 */
CREATE PROCEDURE usp_GetEmployeesFromTown @searchedTown VARCHAR(50)
AS  
BEGIN
	SELECT e.FirstName,
		   e.LastName
	  FROM Employees AS e
	  JOIN Addresses AS a ON e.AddressID = a.AddressID
	  JOIN Towns AS t ON a.TownID = t.TownID
	 WHERE t.[Name] = @searchedTown

END

GO

/* PROBLEM 5 */
CREATE FUNCTION ufn_GetSalaryLevel (@Salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @Result VARCHAR(10)
	
	IF @Salary < 30000 
		SET @Result = 'Low'
	ELSE IF @Salary > 50000
		SET @Result = 'High'
	ELSE 
		SET @Result = 'Average'

	RETURN @Result
END

GO

/* PROBLEM 6 */
CREATE OR ALTER PROCEDURE usp_EmployeesBySalaryLevel @levelOfSalary VARCHAR(10)
AS
BEGIN
	SELECT e.FirstName,
		   e.LastName
	  FROM Employees AS e
	 WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @levelOfSalary
END

GO

/* PROBLEM 7 */

/*
string setOfLetters = Console.Readline();
string word = Console.Readline();

int count = 0;
int length = word.Length;

while(count != length){

	if(setOfLetters.Contains(word[count])) {
		count++;

	}
	else break;
}

*/
CREATE OR ALTER FUNCTION ufn_IsWordComprised (@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
    DECLARE @Matches BIT
	DECLARE @Count TINYINT
	SET @Count = 1
	SET @Matches = 1

	WHILE (@Count <= LEN(@word))
	BEGIN
		DECLARE @Letter CHAR(1)
		SET @Letter = SUBSTRING(@word, @Count, 1)

		IF CHARINDEX(@Letter, @setOfLetters) > 0
		BEGIN
			SET @Count = @Count + 1
		END
		ELSE
		BEGIN
			SET @Matches = 0
			SET @Count = LEN(@word)
			BREAK
		END
	END
			
	RETURN @Matches
END

GO

/* PROBLEM 8 */

CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment @departmentId INT
AS
BEGIN
	ALTER TABLE Departments
	ALTER COLUMN  ManagerID INT NULL

	UPDATE Departments
	   SET ManagerID = NULL
	 WHERE ManagerID IN (
	 	SELECT EmployeeID
		  FROM Employees
		 WHERE DepartmentID = @departmentId
	 )
	
	UPDATE Employees
	   SET ManagerID = NULL
	 WHERE ManagerID IN (
		SELECT EmployeeID
		  FROM Employees
		 WHERE DepartmentID = @departmentId
		 )


	DELETE 
	  FROM EmployeesProjects
	 WHERE EmployeeID IN (
		SELECT EmployeeID
		  FROM Employees
		 WHERE DepartmentID = @departmentId
	  )

	DELETE
	  FROM Employees
	 WHERE DepartmentID = @departmentId

	DELETE
	  FROM Departments
     WHERE DepartmentID = @departmentId

	 SELECT COUNT(*)
	   FROM Employees
	  WHERE DepartmentID = @departmentId
END

GO

/* PART II Bank Database */
USE Bank

GO

/* PROBLEM 9 */
CREATE PROCEDURE usp_GetHoldersFullName 
AS
BEGIN
	SELECT CONCAT_WS(' ',FirstName,LastName) AS [Full Name]
	  FROM AccountHolders
END

GO

/* PROBLEM 10 */

CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan @minBalance DECIMAL(18,4)
AS
BEGIN
	  SELECT ah.FirstName,
			 ah.LastName
		FROM (
				 SELECT SUM(a.Balance) AS [TotalMoney],
						a.AccountHolderId
				   FROM AccountHolders AS ah
			  LEFT JOIN Accounts AS a ON ah.Id = a.AccountHolderId
			   GROUP BY a.AccountHolderId
				 HAVING SUM(a.Balance) > @minBalance
			  ) AS t
		JOIN AccountHolders AS ah ON t.AccountHolderId = ah.Id
	ORDER BY FirstName,
			 LastName
END

GO

/* PROBLEM 11 */
CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (@Sum DECIMAL(18,4), @InterestRate FLOAT, @Years INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
    DECLARE @Result DECIMAL(30,10)
	SET @Result = @Sum * POWER(1 + @InterestRate, @Years)
	RETURN CEILING(@Result * 10000) / 10000
END

GO

/* PROBLEM 12 */
CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount @acountID INT, @interestRate FLOAT
AS
BEGIN
	SELECT TOP(1) ah.Id AS [Account Id],
		   ah.FirstName AS [First Name],
		   ah.LastName AS [Last Name],
		   a.Balance AS [Current Balance],
		   dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	  FROM AccountHolders AS ah
	  JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	 WHERE ah.Id = @acountID
END

GO

/* PART III Diablo Database */
USE Diablo

GO
/* PROBLEM 13 */

CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@GameName VARCHAR(50))
RETURNS TABLE
AS
RETURN
	(	
		SELECT SUM(r.Cash) AS [SumCash]
		  FROM (
				SELECT ug.Cash,
					   ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS [RowNumber]
				  FROM UsersGames AS ug
				  JOIN Games AS g ON ug.GameId = g.Id
				 WHERE g.[Name] = @GameName
			   ) AS r
		 WHERE r.RowNumber % 2 = 1
	)

GO
