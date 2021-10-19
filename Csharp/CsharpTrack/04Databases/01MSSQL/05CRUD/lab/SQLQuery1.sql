Create database SoftUni 



--•	Towns (Id, Name)
CREATE TABLE Towns
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(40) NOT NULL
)
--•	Towns: Sofia, Plovdiv, Varna, Burgas

INSERT INTO Towns(Name)
	VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')


--•	Addresses (Id, AddressText, TownId)
CREATE TABLE Addresses
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
AddressText NVARCHAR(100) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

--•	Departments (Id, Name)
CREATE TABLE Departments
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(40) NOT NULL
)

--•	Departments: Engineering, Sales, Marketing, Software Development, Quality Assurance

INSERT INTO Departments(Name)
	VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')



--•	Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(40) NOT NULL,
MiddleName NVARCHAR(40),
LastName NVARCHAR(40) NOT NULL,
JobTitle NVARCHAR(40) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
HireDate DATE NOT NULL,
Salary DECIMAL(18,2),
AddressId INT FOREIGN KEY REFERENCES Addresses(Id) 
)

use SoftUni

INSERT INTO Employees(FirstName,MiddleName,LastName,JobTitle,DepartmentId,HireDate,Salary)
	VALUES
	('Ivan','Ivanov','Ivanov','.NET Developer',4,'02/03/2013',3500.00),
	('Petar','Petrov','Petrov','Senior Engineer',1,'03/02/2004',4000.00),
	('Maria','Petrova','Ivanova','Intern',5,'08/28/2016',525.25),
	('Georgi','Teziev','Ivanov','CEO',2,'12/09/2007',3000.00),
	('Peter','Pan','Pan','Intern',3,'08/28/2016',599.88)


select * from Towns

select * from Departments

select * from Employees

select * from Towns
order by [Name] ASC

select * from Departments 
order by [Name] ASC

select * from Employees
order by Salary desc



select [Name] from Towns
order by [Name] ASC

select [Name] from Departments
order by [Name] ASC

select FirstName,LastName,JobTitle,Salary from Employees
order by Salary desc
Use SoftUni

UPDATE Employees 
set Salary +=Salary*0.1;

select Salary from Employees

use Hotel
Update Payments
set TaxRate+= TaxRate*0.97;

select TaxRate from Payments




--Id columns are auto incremented starting from 1 and increased by 1 (1, 2, 3, 4…).
--Make sure you use appropriate data types for each column. 
--Add primary and foreign keys as constraints for each table.
--Use only SQL queries.
--Consider which fields are always required and which are optional.
