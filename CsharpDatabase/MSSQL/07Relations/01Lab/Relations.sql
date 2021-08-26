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