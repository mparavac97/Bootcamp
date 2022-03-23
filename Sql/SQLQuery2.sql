INSERT INTO Movie (MovieName, ReleaseYear)
VALUES ('Inception', '2010');

INSERT INTO Company (CompanyName, CompanyAddress)
VALUES ('Warner Bros', 'Chicago Avenue 142, New York')

INSERT INTO Director (FirstName, LastName)
VALUES ('Christopher', 'Nolan');

--INSERT INTO Director (CompanyID)
--VALUES ('f842f755-e52a-4535-a415-1b18378ffe45');

DELETE FROM Director WHERE CompanyID='f842f755-e52a-4535-a415-1b18378ffe45';

INSERT INTO Company (CompanyName, CompanyAddress)
VALUES ('Columbia Pictures', '21st Avenue, Los Angeles')

INSERT INTO Company (CompanyName, CompanyAddress)
VALUES ('Paramount Pictures', 'Long street 456, Texas')

INSERT INTO Company (CompanyName, CompanyAddress)
VALUES ('Universal Pictures', 'Random Avenue, San Francisco')

INSERT INTO Director (FirstName, LastName, CompanyID)
VALUES ('Stephen', 'Jackson', (SELECT CompanyID FROM Company WHERE CompanyName='Columbia Pictures'));

INSERT INTO Director (FirstName, LastName, CompanyID)
VALUES ('Stephen', 'Spielberg', (SELECT CompanyID FROM Company WHERE CompanyName='Universal Pictures'));

INSERT INTO Movie (MovieName, ReleaseYear, DirectorID)
VALUES ('Lord of the Rings: Two towers', '2002', (SELECT DirectorID FROM Director WHERE FirstName='Stephen' AND LastName='Jackson'));

SELECT * FROM Movie;

SELECT * FROM Director
WHERE FirstName = 'Stephen';

CREATE INDEX IndexDirectorName
ON Director (FirstName, LastName);

SELECT * 
FROM Director WITH(INDEX(IndexDirectorName));

SELECT * FROM Director, Movie;

DELETE