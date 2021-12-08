USE SoftUni

SELECT[NAME] FROM Departments

SELECT FirstName,LastName,Salary
	FROM Employees

	SELECT FirstName,MiddleName,LastName
	FROM Employees

SELECT FirstName+'.'+LastName+'@softuni.bg' AS 'Full Email address'
	FROM Employees


SELECT DISTINCT Salary
FROM Employees


SELECT EmployeeID,FirstName,LastName,MiddleName,JobTitle,DepartmentID,ManagerID,HireDate,Salary,AddressID
FROM Employees
WHERE JobTitle = 'Sales Representative'

SELECT FirstName,LastName,JobTitle
FROM Employees
WHERE Salary>=20000 AND Salary<=30000

SELECT FirstName+' '+MiddleName+' '+LastName AS 'Full Name'
FROM Employees
WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary=23600

SELECT FirstName,LastName
FROM Employees
WHERE ManagerID IS NULL

SELECT FirstName,LastName,Salary
	FROM Employees
	WHERE Salary>50000
	ORDER BY Salary DESC

SELECT TOP(5) FirstName,LastName
FROM Employees
ORDER BY Salary DESC

SELECT FirstName,LastName
FROM Employees
WHERE DepartmentID!=4


SELECT EmployeeID,FirstName,LastName,MiddleName,JobTitle,DepartmentID,ManagerID,HireDate,Salary,AddressID
FROM Employees
ORDER BY Salary DESC,FirstName,LastName DESC,MiddleName

CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName,LastName,Salary
FROM Employees

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName+' '+ISNULL(MiddleName,'')+' '+LastName AS 'Full Name',JobTitle
FROM Employees

select*[V_EmployeeNameJobTitle]


SELECT DISTINCT JobTitle
FROM Employees

SELECT TOP(10) ProjectID,[Name],[Description],StartDate,EndDate
FROM Projects
ORDER BY StartDate ASC,[Name]

SELECT TOP(7) FirstName,LastName,HireDate
FROM Employees
ORDER BY HireDate DESC

UPDATE Employees
SET Salary= Salary*1.12
WHERE DepartmentID IN (1,2,4,11)

SELECT Salary
FROM Employees

UPDATE Employees
SET Salary= Salary*0.88;

SELECT Salary
FROM Employees



