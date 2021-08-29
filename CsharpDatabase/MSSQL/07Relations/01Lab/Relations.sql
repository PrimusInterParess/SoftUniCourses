 CREATE DATABASE CoursesTest
use CoursesTest

CREATE TABLE Students
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(100) NOT NULL,
FacultyNumber char(6) NOT NULL,
Photo varbinary(max),
DateOfEnlistment date,
)

ALTER TABLE Students
ADD Courses nvarchar(500)

use CoursesTest
ALTER TABLE Students
DROP COLUMN Courses

CREATE TABLE Courses
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE CoursesWithStudents
(
StudentId INT FOREIGN KEY REFERENCES Students(Id),
CourseId INT FOREIGN KEY REFERENCES Courses(Id),
Mark DECIMAL(3,2)
)





INSERT INTO Courses([Name]) 
	VALUES
	('C#'),
	('Python'),
	('HTML'),
	('PHP'),
	('CSS')

	INSERT INTO Courses(TownId)
	VALUES
	(1),
	(2),
	(4),
	(5)


INSERT INTO Students ([Name],FacultyNumber)
	VALUES
	('Niki','F12345'),
	('Stoyan','F12346'),
	('Pesho','F12347'),
	('Ivo','F12348')

	USE CoursesTest
INSERT INTO CoursesWithStudents(StudentId,CourseId,[Mark])
	VALUES
	(1,1,NULL),
	(1,3,2.00),
	(1,2,5.00),
	(2,4,4.00),
	(3,4,6.00),
	(3,1,5.90)


CREATE TABLE Towns 
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(50)
)

INSERT INTO Towns([Name])
	VALUES
	('Sofia'),
	('Varna'),
	('Burgas'),
	('Plovdiv'),
	('Ruse')

ALTER TABLE Courses
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

SELECT * FROM Courses
	JOIN Towns
	ON Courses.TownId = Towns.Id

