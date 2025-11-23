CREATE DATABASE EuroLeagues

GO

USE EuroLeagues

GO

/* SECTION 1 */
	/* PROBLEM 1 */
CREATE TABLE Leagues(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Teams(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL,
	City NVARCHAR(50) NOT NULL,
	LeagueId INT FOREIGN KEY REFERENCES Leagues(Id) NOT NULL
)

CREATE TABLE Players(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	Position NVARCHAR(20) NOT NULL
)

CREATE TABLE Matches(
	Id INT PRIMARY KEY IDENTITY,
	HomeTeamId INT FOREIGN KEY REFERENCES Teams(Id) NOT NULL,
	AwayTeamId INT FOREIGN KEY REFERENCES Teams(Id) NOT NULL,
	MatchDate DATETIME2 NOT NULL,
	HomeTeamGoals INT DEFAULT 0 NOT NULL,
	AwayTeamGoals INT DEFAULT 0 NOT NULL,
	LeagueId INT FOREIGN KEY REFERENCES Leagues(Id) NOT NULL
)

CREATE TABLE PlayersTeams(
	PlayerId INT FOREIGN KEY REFERENCES Players(Id) NOT NULL,
	TeamId INT FOREIGN KEY REFERENCES Teams(Id) NOT NULL
	PRIMARY KEY(PlayerId,TeamId)
)

CREATE TABLE PlayerStats(
	PlayerId INT PRIMARY KEY FOREIGN KEY REFERENCES Players(Id),
	Goals INT DEFAULT 0 NOT NULL,
	Assists INT DEFAULT 0 NOT NULL
)

CREATE TABLE TeamStats(
	TeamId INT PRIMARY KEY FOREIGN KEY REFERENCES Teams(Id),
	Wins INT DEFAULT 0 NOT NULL,
	Draws INT DEFAULT 0 NOT NULL,
	Losses INT DEFAULT 0 NOT NULL
)
/* SECTION 2 */
	/* PROBLEM 2 */
BEGIN TRANSACTION

INSERT INTO Leagues ([Name])
VALUES ('Eredivisie')

INSERT INTO Teams ([Name], City, LeagueId)
VALUES 
    ('PSV', 'Eindhoven', 6),
    ('Ajax', 'Amsterdam', 6)

INSERT INTO Players ([Name], Position)
VALUES 
    ('Luuk de Jong', 'Forward'),
    ('Josip Sutalo', 'Defender')

INSERT INTO Matches (HomeTeamId, AwayTeamId, MatchDate, HomeTeamGoals, AwayTeamGoals, LeagueId)
VALUES (98, 97, '2024-11-02 20:45:00', 3, 2, 6)

INSERT INTO PlayersTeams (PlayerId, TeamId)
VALUES 
    (2305, 97),
    (2306, 98)

INSERT INTO PlayerStats (PlayerId, Goals, Assists)
VALUES 
    (2305, 2, 0),
    (2306, 2, 0)

INSERT INTO TeamStats (TeamId, Wins, Draws, Losses)
VALUES 
    (97, 15, 1, 3),
    (98, 14, 3, 2)


GO

ROLLBACK
COMMIT
	/* PROBLEM 3 */
BEGIN TRANSACTION

UPDATE PlayerStats
   SET Goals = Goals + 1
  FROM PlayerStats AS ps
  JOIN Players AS p ON ps.PlayerId = p.Id
  JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
  JOIN Teams AS t ON pt.TeamId = t.Id
  JOIN Leagues AS l ON t.LeagueId = l.Id
 WHERE l.[Name] = 'La Liga' AND p.Position = 'Forward'

GO

ROLLBACK
COMMIT
	/* PROBLEM 4 */
BEGIN TRANSACTION
DELETE PlayersTeams 
  FROM PlayersTeams AS pt
  JOIN Players AS p ON pt.PlayerId = p.Id
  JOIN Teams AS t ON pt.TeamId = t.Id
  JOIN Leagues AS l ON t.LeagueId = l.Id
 WHERE l.[Name] = 'Eredivisie' 

DELETE PlayerStats 
  FROM PlayerStats AS ps
  JOIN Players AS p ON ps.PlayerId = p.Id
  JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
  JOIN Teams AS t ON pt.TeamId = t.Id
  JOIN Leagues AS l ON t.LeagueId = l.Id
 WHERE l.[Name] = 'Eredivisie' 

 DELETE Players
   FROM Players AS p
   JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
   JOIN Teams AS t ON pt.TeamId = t.Id
   JOIN Leagues AS l ON t.LeagueId = l.Id
 WHERE l.[Name] = 'Eredivisie' 
ROLLBACK
COMMIT

SELECT * FROM Leagues
/* SECTION 3 */
	/* PROBLEM 5 */
	SELECT FORMAT(MatchDate ,'yyyy-MM-dd') AS [MatchDate],
		   HomeTeamGoals,
		   AwayTeamGoals,
		   (HomeTeamGoals + AwayTeamGoals) AS TotalGoals
	  FROM Matches
	 WHERE (HomeTeamGoals + AwayTeamGoals) >= 5
  ORDER BY (HomeTeamGoals + AwayTeamGoals) DESC,
		   MatchDate ASC

GO

	/* PROBLEM 6 */
	SELECT p.[Name],
		   t.City
	  FROM Players AS p
	  JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
	  JOIN Teams AS t ON pt.TeamId = t.Id
	 WHERE p.[Name] LIKE '%Aaron%'
  ORDER BY p.[Name] ASC

  GO

	/* PROBLEM 7 */
	SELECT p.Id,
		   p.[Name],
		   p.Position
	  FROM Players AS p
	  JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
	  JOIN Teams AS t ON pt.TeamId = t.Id 
	 WHERE t.City = 'London'
  ORDER BY p.[Name]

  GO

	/* PROBLEM 8 */
	SELECT TOP(10)
		   ht.[Name] AS HomeTeamName,
		   [at].[Name] AS AwayTeamName,
		   l.[Name] AS LeagueName,
		   FORMAT(m.MatchDate ,'yyyy-MM-dd') AS [MatchDate]
	  FROM Matches AS m
	  JOIN Teams AS ht ON m.HomeTeamId = ht.Id
	  JOIN Teams AS [at] ON m.AwayTeamId = [at].Id
	  JOIN Leagues AS l ON ht.LeagueId = l.Id
	 WHERE (m.MatchDate BETWEEN '2024-09-01 17:00:00.0000000' AND '2024-09-15 17:00:00.0000000')
	   AND l.Id % 2 = 0
  ORDER BY m.MatchDate, ht.[Name]

  GO

	/* PROBLEM 9 */
	SELECT t.Id,
		   t.[Name],
		   SUM(m.AwayTeamGoals) AS TotalAwayGoals
	  FROM Matches AS m
	  JOIN Teams AS t ON m.AwayTeamId = t.Id
  GROUP BY t.Id, t.[Name]
    HAVING SUM(m.AwayTeamGoals) >= 6
  ORDER BY SUM(m.AwayTeamGoals) DESC,
           t.[Name]

GO

	/* PROBLEM 10 */
	SELECT l.[Name] AS LeagueName,
		   FORMAT(AVG(CAST((m.AwayTeamGoals + m.HomeTeamGoals) AS DECIMAL(10,1))), '0.##') AS AvgScoringRate
	  FROM Leagues AS l
	  JOIN Matches AS m ON l.Id = m.LeagueId
  GROUP BY l.[Name]
  ORDER BY FORMAT(AVG(CAST((m.AwayTeamGoals + m.HomeTeamGoals) AS DECIMAL(10,1))), '0.##') DESC

  GO

/* SECTION 4 */
	/* PROBLEM 11 */
CREATE FUNCTION udf_LeagueTopScorer (@leagueName NVARCHAR(50))
RETURNS TABLE
AS 
RETURN(
  	SELECT [Name] AS PlayerName,
		   Goals AS TotalGoals
	  FROM (
			SELECT p.[Name],
				   ps.Goals,
				   RANK() OVER(ORDER BY ps.Goals DESC) AS GoalRank
			  FROM Players AS p
			  JOIN PlayerStats AS ps ON p.Id = ps.PlayerId
			  JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
			  JOIN Teams AS t ON pt.TeamId = t.Id
			  JOIN Leagues AS l ON t.LeagueId = l.Id
			 WHERE l.[Name] =  @leagueName
		   ) AS TEMP
	 WHERE GoalRank = 1

	  )

GO

	/* PROBLEM 12 */
CREATE OR ALTER PROCEDURE usp_UpdatePlayerStats @PlayerId INT, @GoalsDelta INT = NULL, @AssistsDelta INT = NULL
AS
BEGIN

	IF EXISTS(SELECT 1 FROM PlayerStats WHERE PlayerId = @PlayerId)
	BEGIN
		UPDATE PlayerStats
		   SET Goals = Goals + ISNULL(@GoalsDelta, 0), Assists = Assists + ISNULL(@AssistsDelta, 0)
		  FROM PlayerStats AS ps
		  JOIN Players AS p ON ps.PlayerId = P.Id
		 WHERE p.Id = @PlayerId 
	 END
	 ELSE
	 BEGIN
		 INSERT INTO PlayerStats (PlayerId,Goals,Assists)
			VALUES (@PlayerId,ISNULL(@GoalsDelta, 0), ISNULL(@AssistsDelta, 0))
	 END
END


GO

EXEC usp_UpdatePlayerStats 5, NULL, 1;
EXEC usp_UpdatePlayerStats 7, 1, 2;

SELECT *
FROM Players p
JOIN PlayerStats ps ON ps.PlayerId = p.Id
WHERE p.Id = 5;

SELECT p.Id, p.[Name], ps.Goals, ps.Assists
FROM dbo.Players p
JOIN dbo.PlayerStats ps ON ps.PlayerId = p.Id
WHERE p.Id = 7;

SELECT * FROM PlayerStats WHERE PlayerId = 7
