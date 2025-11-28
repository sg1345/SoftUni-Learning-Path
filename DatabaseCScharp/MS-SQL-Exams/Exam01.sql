CREATE DATABASE LibraryDb

GO

USE LibraryDb

GO
/* SECTION 1 */
	/* PROBLEM 1 */
CREATE TABLE [Genres] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
) 

CREATE TABLE [Contacts](
	[Id] INT PRIMARY KEY IDENTITY,
	Email NVARCHAR(100),
	[PhoneNumber] NVARCHAR(20) NULL,
	[PostAddress] NVARCHAR(200) NULL,
	[Website] NVARCHAR(50) NULL
)

CREATE TABLE [Libraries](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[ContactId] INT FOREIGN KEY REFERENCES [Contacts]([Id]) NOT NULL
)

CREATE TABLE [Authors](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[ContactId] INT FOREIGN KEY REFERENCES [Contacts]([Id]) NOT NULL
)

CREATE TABLE [Books](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(100) NOT NULL,
	[YearPublished] INT NOT NULL,
	[ISBN] NVARCHAR(13) UNIQUE NOT NULL,
	[AuthorId] INT FOREIGN KEY REFERENCES [Authors]([Id]) NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL
)

CREATE TABLE [LibrariesBooks](
	[LibraryId] INT FOREIGN KEY REFERENCES [Libraries]([Id]) NOT NULL,
	[BookId] INT FOREIGN KEY REFERENCES [Books]([Id]) NOT NULL,
	PRIMARY KEY([LibraryId], [BookId])
)

GO

/* SECTION 2 */
	/* PROBLEM 2 */
INSERT INTO Contacts (Email, PhoneNumber, PostAddress, Website)
VALUES
    (NULL, NULL, NULL, NULL),
    (NULL, NULL, NULL, NULL),
    ('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
    ('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com')

INSERT INTO Authors (Name, ContactId)
VALUES
    ('George Orwell', 21),
    ('Aldous Huxley', 22),
    ('Stephen King', 23),
    ('Suzanne Collins', 24)

INSERT INTO Books (Title, YearPublished, ISBN, AuthorId, GenreId)
VALUES
    ('1984', 1949, '9780451524935', 16, 2),
    ('Animal Farm', 1945, '9780451526342', 16, 2),
    ('Brave New World', 1932, '9780060850524', 17, 2),
    ('The Doors of Perception', 1954, '9780060850531', 17, 2),
    ('The Shining', 1977, '9780307743657', 18, 9),
    ('It', 1986, '9781501142970', 18, 9),
    ('The Hunger Games', 2008, '9780439023481', 19, 7),
    ('Catching Fire', 2009, '9780439023498', 19, 7),
    ('Mockingjay', 2010, '9780439023511', 19, 7)

INSERT INTO LibrariesBooks (LibraryId, BookId)
VALUES
    (1, 36),
    (1, 37),
    (2, 38),
    (2, 39),
    (3, 40),
    (3, 41),
    (4, 42),
    (4, 43),
    (5, 44);

GO
	/* PROBLEM 3 */

	UPDATE [Contacts]
	   SET Website = CONCAT('www.', LOWER(REPLACE([a].[Name],' ' ,'')), '.com')
	  FROM [Authors] AS [a]
      JOIN [Contacts] AS [c] ON [a].ContactId = [c].Id
	 WHERE [c].[Website] IS NULL

GO
	/* PROBLEM 4 */

BEGIN TRANSACTION

DELETE [LibrariesBooks]
  FROM [LibrariesBooks] AS [lb]
  JOIN [Books] AS [b] ON [lb].BookId = [b].[Id]
  JOIN [Authors] AS [a] ON [b].AuthorId = [a].Id
 WHERE [a].[Name] = 'Alex Michaelides'

DELETE [Books]
  FROM [Books] AS [b]
  JOIN [Authors] AS [a] ON [b].AuthorId = [a].Id
 WHERE [a].[Name] = 'Alex Michaelides'

DELETE [Authors]
  FROM [Authors] AS [a] 
 WHERE [a].[Name] = 'Alex Michaelides'

ROLLBACK

SELECT *
  FROM [Authors] AS [a]
 WHERE [a].[Name] = 'Alex Michaelides'

/* SECTION 3 */
	/* PROBLEM 5 */
    SELECT Title AS [Book Title],
		   ISBN,
		   YearPublished AS [YearReleased]
      FROM Books
  ORDER BY YearPublished DESC,
		   Title ASC

GO

	/* PROBLEM 6 */
    SELECT [b].Id,
		   [b].Title,
		   [b].ISBN,
		   [g].[Name] AS [Genre]
	  FROM [Books] AS [b]
	  JOIN [Genres] AS [g] ON [b].[GenreId] = [g].Id
	 WHERE [g].[Name] = 'Biography' OR
		   [g].[Name] = 'Historical Fiction' 
  ORDER BY [g].[Name],
		   [b].[Title]

GO

	/* PROBLEM 7 */
	SELECT DISTINCT
		   [l].[Name] AS [Library],
		   [c].Email
	  FROM [Books] AS [b]
 LEFT JOIN [Genres] AS [g] ON [b].GenreId = [g].Id
 LEFT JOIN [LibrariesBooks] AS [lb] ON [b].Id = [lb].BookId
 LEFT JOIN [Libraries] AS [l] ON [lb].LibraryId = [l].Id
 LEFT JOIN [Contacts] AS [c] ON [l].ContactId = [c].Id
	 WHERE [g].Name <> 'Mystery'
  ORDER BY [l].Name ASC

  	SELECT DISTINCT
		   [l].[Name] AS [Library],
		   [c].Email
	  FROM [Libraries] AS [l]
	  JOIN [Contacts] AS [c] ON [l].ContactId = [c].Id
	 WHERE [l].Id NOT IN (
			  SELECT [l].Id
				FROM [Books] AS [b]
				JOIN [Genres] AS [g] ON [b].GenreId = [g].Id
				JOIN [LibrariesBooks] AS [lb] ON [b].Id = [lb].BookId
				JOIN [Libraries] AS [l] ON [lb].LibraryId = [l].Id
				JOIN [Contacts] AS [c] ON [l].ContactId = [c].Id
					 WHERE [g].[Name] = 'Mystery'
			)
   ORDER BY [l].Name ASC

   GO

	/* PROBLEM 8 */
	SELECT TOP(3) 
		   [b].[Title],
		   [b].[YearPublished] AS [Year],
		   [g].[Name] AS [Genre]
	  FROM [Books] AS [b]
	  JOIN [Genres] AS [g] ON [b].GenreId = [g].Id
	 WHERE ([b].[YearPublished] > 2000 AND CHARINDEX('a',[b].[Title]) > 0)
		   OR
		   ([b].[YearPublished] < 1950 AND CHARINDEX('Fantasy',[g].[Name]) > 0)
  ORDER BY [b].[Title] ASC,
		   [b].[YearPublished] DESC

  GO

	/* PROBLEM 9 */
	SELECT [a].[Name] AS [Author],
		   [c].[Email],
		   [c].[PostAddress] AS [Address]
	  FROM [Authors] AS [a]
	  JOIN [Contacts] AS [c] ON [a].[ContactId] = [c].[Id]
	 WHERE CHARINDEX('UK',[c].[PostAddress]) > 0
  ORDER BY [a].[Name] ASC

  GO

	/* PROBLEM 10 */
	SELECT [a].[Name] AS [Author],
		   [b].[Title],
		   [l].[Name] AS [Library],
		   [c].[PostAddress] AS [Library Address]
	  FROM [Books] AS [b]
	  JOIN [Genres] AS [g] ON [b].[GenreId] = [g].[Id]
	  JOIN [Authors] AS [a] ON [b].[AuthorId] = [a].[Id]
	  JOIN [LibrariesBooks] AS [lb] ON [b].[Id] = [lb].[BookId]
	  JOIN [Libraries] AS [l] ON  [lb].[LibraryId] = [l].[Id]
	  JOIN [Contacts] AS [c] ON [l].ContactId = [c].Id
	 WHERE [g].[Name] = 'Fiction' AND CHARINDEX('Denver',[c].[PostAddress]) > 0
  ORDER BY [b].[Title] ASC

GO

/* SECTION 4 */
	/* PROBLEM 11 */
CREATE FUNCTION udf_AuthorsWithBooks (@name NVARCHAR(100))
RETURNS INT
AS
BEGIN

	RETURN (
				SELECT COUNT(*)
				  FROM [Books] AS [b]
				  JOIN [Authors] AS [a] ON [b].[AuthorId] = [a].[Id]
				 WHERE [a].[Name] = @name
			)
END

GO
	
	/* PROBLEM 12 */
CREATE PROCEDURE usp_SearchBookByGenre @genreName NVARCHAR(30), @city NVARCHAR(100) = NULL
AS
BEGIN
	SELECT [b].[Title],
		   [b].[YearPublished] AS [Year],
		   [b].[ISBN],
		   [a].[Name] AS [Author],
		   [g].[Name] AS [Genre]
	  FROM [Books] AS [b]
	  JOIN [Genres] AS [g] ON [b].[GenreId] = [g].[Id]
	  JOIN [Authors] AS [a] ON [b].[AuthorId] = [a].[Id]
	  JOIN [LibrariesBooks] AS [lb] ON [b].[Id] = [lb].[BookId]
	  JOIN [Libraries] AS [l] ON  [lb].[LibraryId] = [l].[Id]
	  JOIN [Contacts] AS [c] ON [l].ContactId = [c].Id
	 WHERE [g].[Name] = @genreName AND
		   (@city IS NULL OR CHARINDEX(@city, [c].[PostAddress]) > 0)
  ORDER BY [b].[Title],
		   [b].[YearPublished] DESC
END

GO