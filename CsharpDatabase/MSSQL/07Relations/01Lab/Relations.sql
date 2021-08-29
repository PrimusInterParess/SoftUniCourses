 CREATE DATABASE CoursesTest
use CoursesTest

CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	FacultyNumber char(6) NOT NULL UNIQUE,
	Photo varbinary(max),
	DateOfEnlistment date,
) 

ALTER TABLE Students
ADD Courses nvarchar(500)

<<<<<<< HEAD
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

=======
create table Towns
(
Id int primary key identity,
[Name] varchar(50) unique,

)

insert into Towns(Name)
values
('Sofia'),
('Plovdiv'),
('Ruse'),
('Varna'),
('Stara Zagora')

create table Course
(
Id int primary key identity,
[Name] varchar(100) Not null,
TownId int not null foreign key references Towns(Id)
)

insert into Course([Name],TownId)
values
('C#',1),
('Python',2),
('HTML',3),
('PHP',4),
('CSS',1)


CREATE TABLE StudentsInCourses
(

	StudentId INT REFERENCES Students(Id),
	CourseId INT REFERENCES Course(Id),
	Mark DECIMAL(3,2),
	CONSTRAINT PK_StudentsCourses
	PRIMARY KEY(StudentId,CourseId)
)
>>>>>>> 28b45bc6ed31e115af6168f34d6e693124354df8
