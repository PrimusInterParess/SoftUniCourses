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