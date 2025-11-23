/*  PART I Bank Database */
USE Bank

GO

/* PROBLEM 1 */
CREATE TABLE  Logs (
	LogId INT IDENTITY PRIMARY KEY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	OldSum DECIMAL(18,4) NOT NULL,
	NewSum DECIMAL(18,4) NOT NULL
)

GO

CREATE TRIGGER tr_Accounts_BalanceChange
ON Accounts
AFTER UPDATE
AS
BEGIN
    INSERT INTO Logs (AccountId, OldSum, NewSum)
    SELECT d.Id, d.Balance, i.Balance
    FROM deleted d
    JOIN inserted i ON d.Id = i.Id
    WHERE d.Balance <> i.Balance;
END

GO

/* PROBLEM 2 */
CREATE TABLE NotificationEmails(
    Id INT IDENTITY PRIMARY KEY,
    Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
    [Subject] VARCHAR(50) NOT NULL,
    Body VARCHAR(250) NOT NULL
)

GO

CREATE TRIGGER tr_Logs_InsertEmail
ON Logs
AFTER INSERT
AS
BEGIN
    INSERT INTO NotificationEmails (Recipient, [Subject], Body)
    SELECT i.AccountId, 
           CONCAT_WS(' ','Balance change for account:',i.AccountId), 
           CONCAT_WS(' ','On',GETDATE(),'your balance was changed from', i.OldSum, 'to', i.NewSum )
    FROM inserted i
END

GO

/* PROBLEM 3 */
CREATE OR ALTER PROCEDURE usp_DepositMoney
    @AccountId INT,
    @MoneyAmount DECIMAL(18,4)
AS
BEGIN
    IF @MoneyAmount <= 0
BEGIN
    RETURN
END

UPDATE Accounts
SET Balance = Balance + @MoneyAmount
WHERE Id = @AccountId
    
END

GO

/* PROBLEM 4 */
CREATE OR ALTER PROCEDURE usp_WithdrawMoney 
    @AccountId INT,
    @MoneyAmount DECIMAL(18,4)
AS
BEGIN
    IF @MoneyAmount <= 0
BEGIN
    RETURN
END

UPDATE Accounts
SET Balance = Balance - @MoneyAmount
WHERE Id = @AccountId
    
END

GO

/* PROBLEM 5 */
CREATE OR ALTER PROCEDURE usp_TransferMoney 
    @SenderId INT,
    @ReceiverId INT, 
    @MoneyAmount DECIMAL(18,4)
AS
BEGIN

EXEC usp_WithdrawMoney @SenderId, @MoneyAmount;
EXEC usp_DepositMoney @ReceiverId, @MoneyAmount;
   
END

GO

/* PART III SoftUni Database */
USE SoftUni

GO

/* PROBLEM 8 */
CREATE OR ALTER PROCEDURE usp_AssignProject (@emloyeeId INT, @projectID INT)
AS
BEGIN
    
    BEGIN TRANSACTION

    INSERT INTO EmployeesProjects(EmployeeId, ProjectId)
    VALUES(@emloyeeId, @projectID)
    
    DECLARE @ProjectCount INT

    SELECT @ProjectCount = COUNT(*)
      FROM EmployeesProjects
     WHERE EmployeeID = @emloyeeId

     IF @ProjectCount > 3
     BEGIN
         RAISERROR('The employee has too many projects!', 16, 1)
         ROLLBACK TRANSACTION
         RETURN
     END

     COMMIT TRANSACTION
END

GO

/* PROBLEM 9 */
CREATE TABLE Deleted_Employees (
    EmployeeId INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    MiddleName NVARCHAR(50),
    JobTitle NVARCHAR(50),
    DepartmentId INT,
    Salary DECIMAL(18,4)
)

GO

CREATE TRIGGER tr_Employees_Delete
ON Employees
AFTER DELETE
AS
BEGIN

    INSERT INTO Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
    SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary
    FROM deleted

END