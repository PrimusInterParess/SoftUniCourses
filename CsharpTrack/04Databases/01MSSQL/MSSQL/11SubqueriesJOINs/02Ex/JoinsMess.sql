USE SoftUni

SELECT TOP(50) FirstName,LastName,T.Name AS Town,A.AddressText
FROM Employees AS E
JOIN Addresses AS A ON a.AddressID = E.AddressID
JOIN Towns AS T ON T.TownID=A.TownID
ORDER BY FirstName,LastName ASC

SELECT TOP(5) EmployeeID,JobTitle,E.AddressID,A.AddressText
FROM Employees AS E
JOIN Addresses AS A ON A.AddressID = E.AddressID
ORDER BY A.AddressID ASC

SELECT TOP(50) FirstName,LastName,T.[Name] AS Town,A.AddressText
FROM Employees AS E
JOIN Addresses AS A ON A.AddressID = E.AddressID
JOIN Towns AS T ON T.TownID= A.TownID
ORDER BY FirstName ASC,LastName

SELECT * FROM Employees


SELECT * FROM Departments

SELECT EmployeeID,FirstName,LastName, D.[Name] AS [DepartmentName]
		FROM Employees AS E
			JOIN Departments AS D ON E.DepartmentID =d.DepartmentID
		WHERE E.DepartmentID = 3
	ORDER BY E.EmployeeID ASC

SELECT E.[FirstName],E.[LastName],E.[HireDate],D.[Name]
		FROM Employees AS E
			JOIN Departments AS D ON D.DepartmentID=E.DepartmentID
		WHERE E.HireDate >'1/1/1999' AND D.DepartmentID IN(3,10)
	ORDER BY E.HireDate ASC

SELECT TOP(5) E.EmployeeID,E.FirstName,E.Salary,D.[Name] AS [DepartmentName]
		FROM Employees AS E
			JOIN Departments AS D ON E.DepartmentID = D.DepartmentID
		WHERE E.Salary>15000
	ORDER BY D.DepartmentID

SELECT E.EmployeeID,
	    E.[FirstName] + ' ' + E.[LastName] AS [EmployeeName],
	    M.[FirstName] + ' ' + M.[LastName] AS [ManagerName],
		D.[Name] AS [DepartmentName]
		FROM Employees AS E
			LEFT JOIN Employees AS M ON E.ManagerID = M.EmployeeID
			LEFT JOIN Departments AS D ON D.DepartmentID = E.DepartmentID
		ORDER BY E.EmployeeID ASC

select * from EmployeesProjects
select * from Employees

SELECT TOP(3) E.[EmployeeID],E.[FirstName]
		FROM Employees AS E
				LEFT JOIN EmployeesProjects AS P ON E.[EmployeeID] = P.[EmployeeID]
			 WHERE P.[EmployeeID] IS NULL
		ORDER BY E.[EmployeeID] ASC

SELECT E.[FirstName],E.[LastName],E.[HireDate],D.[Name] AS [DeptName]
		FROM Employees AS E
			JOIN Departments AS D ON  E.[DepartmentID]=D.[DepartmentID]
		WHERE E.[HireDate] >'1/1/1999' AND E.DepartmentID IN(3,10)
	ORDER BY E.HireDate ASC

	SELECT TOP(5) E.[EmployeeID],E.[FirstName],PRJ.[Name] AS [ProjectName]
		FROM Employees AS E
				LEFT JOIN EmployeesProjects AS P ON E.[EmployeeID] = P.[EmployeeID]
				JOIN Projects AS PRJ ON PRJ.ProjectID=P.ProjectID
			 WHERE P.[EmployeeID] IS Not NULL and PRJ.StartDate>'08.13.2002'
		ORDER BY E.[EmployeeID] ASC

	SELECT E.EmployeeID,E.FirstName,
			CASE
					WHEN DATEPART(YEAR,P.StartDate)>=2005 THEN NULL
				ELSE
			P.[Name]	
		end
	AS 'ProjectName'
			FROM Employees AS E
				JOIN EmployeesProjects AS PRJ ON PRJ.EmployeeID = e.EmployeeID
				JOIN Projects AS P ON P.ProjectID = PRJ.ProjectID
			WHERE E.EmployeeID = 24
	
	SELECT E.EmployeeID,E.FirstName,E.ManagerID,M.[FirstName] AS [ManagerName]			
			FROM Employees AS E
				JOIN Employees AS M ON E.ManagerID = M.EmployeeID
				WHERE M.EmployeeID IN(3,7)
			ORDER BY E.EmployeeID ASC


SELECT TOP(50) E.[EmployeeID],
	   E.[FirstName] + ' ' + E.[LastName],
	   M.[FirstName] + ' ' + M.[LastName] AS [ManagerName],
	   D.[Name] AS [DepartmentName]
			FROM Employees AS E
				JOIN Employees AS M ON E.ManagerID = M.EmployeeID
					JOIN Departments AS D ON E.DepartmentID = D.DepartmentID
		ORDER BY E.EmployeeID

	SELECT * from Departments
	ORDER BY DepartmentID
	SELECT * from Employees
	ORDER BY DepartmentID
	

	select MIN(AVG(E.Salary)) AS 'mIN'
		FROM Employees AS E
		LEFT JOIN Departments AS D ON D.DepartmentID = E.DepartmentID

SELECT top(1)
(select AVG(Salary)
from Employees as E
where d.DepartmentID = E.DepartmentID) AS 'MinAverageSalary'
FROM Departments AS D
ORDER BY MinAverageSalary asc


USE Geography

SELECT * FROM Countries
SELECT * FROM MountainsCountries
SELECT * FROM Mountains
SELECT * FROM Peaks

SELECT C.CountryCode,M.MountainRange,P.PeakName,P.Elevation 
	FROM Countries AS C
			JOIN MountainsCountries AS MC ON MC.CountryCode=C.CountryCode
				JOIN Mountains AS M ON M.Id = MC.MountainId
			JOIN Peaks AS P ON P.MountainId = M.Id
		WHERE MC.CountryCode = 'BG' AND P.Elevation>2835
	ORDER BY P.Elevation DESC


SELECT C.CountryCode,COUNT(*) AS 'MountainRanges'
		FROM Countries AS C
		JOIN MountainsCountries AS MC ON MC.CountryCode=C.CountryCode
			WHERE C.CountryCode IN ('BG','US','RU')
		GROUP BY C.CountryCode
		
			
SELECT TOP(5) C.CountryName,
	R.RiverName
	FROM Countries AS C
	LEFT JOIN CountriesRivers AS RC ON C.CountryCode=RC.CountryCode
	LEFT JOIN Rivers AS R ON R.Id=RC.RiverId
	 WHERE C.ContinentCode = 'AF'
	 ORDER BY C.CountryName ASC

	 USE SoftUni
	 SELECT E.EmployeeID,E.JobTitle,E.AddressID,A.AddressText
	 FROM Employees AS E
	  JOIN Addresses AS A ON E.AddressID=A.AddressID

	SELECT TOP(50) E.FirstName,E.LastName,T.[Name],A.AddressText
	FROM Employees AS E
	LEFT JOIN Addresses AS A ON E.AddressID=A.AddressID
	LEFT JOIN Towns AS T ON T.TownID=A.TownID
	ORDER BY E.FirstName ASC,E.LastName

	SELECT TOP(5) E.EmployeeID, E.FirstName ,E.Salary,D.Name
	FROM Employees AS E
	LEFT JOIN Departments AS D ON D.DepartmentID =E.DepartmentID
	ORDER BY D.DepartmentID ASC

	SELECT * FROM Projects
	SELECT * FROM EmployeesProjects

	SELECT E.EmployeeID,E.FirstName
	FROM Employees AS E
	LEFT JOIN EmployeesProjects AS EP ON EP.EmployeeID = E.EmployeeID
	WHERE EP.EmployeeID IS NULL
	ORDER BY E.EmployeeID ASC

	SELECT E.FirstName,E.LastName,E.HireDate,D.Name 
	FROM Employees AS E
	LEFT JOIN Departments AS D ON D.DepartmentID =E.DepartmentID
	WHERE D.Name IN('Sales','Finance')
	ORDER BY E.HireDate ASC
	

	SELECT top(5) E.EmployeeID,E.FirstName, P.Name AS [ProjectName]
	FROM Employees AS E
 LEFT JOIN EmployeesProjects AS EP ON EP.EmployeeID=E.EmployeeID
	JOIN Projects AS P ON EP.ProjectID=P.ProjectID
	WHERE P.StartDate> '08.13.2002' and ep.EmployeeID is not null
	ORDER BY E.EmployeeID ASC

	SELECT TOP(5) E.[EmployeeID],E.[FirstName],PRJ.[Name] AS [ProjectName]
		FROM Employees AS E
				LEFT JOIN EmployeesProjects AS P ON E.[EmployeeID] = P.[EmployeeID]
				JOIN Projects AS PRJ ON PRJ.ProjectID=P.ProjectID
			 WHERE P.[EmployeeID] IS Not NULL and PRJ.StartDate>'08.13.2002'
		ORDER BY E.[EmployeeID] ASC


USE SOFTUNI


								--SUBQUERIES


SELECT
E.FirstName,
E.LastName,
E.HireDate,
D.Name as DeptName,
(SELECT COUNT(*) FROM Employees
WHERE D.DepartmentID=E.DepartmentID) AS EmployeesCount
FROM Employees AS E
JOIN Departments AS D ON E.DepartmentID=D.DepartmentID
WHERE E.HireDate>'1999-01-01' AND 
D.Name IN (SELECT D.Name 
			FROM Departments 
			WHERE Name LIKE'E%')
ORDER BY HireDate

--???????????????????????????????????????????
SELECT * FROM
(
SELECT FirstName,LastName
FROM Employees
) AS COOL

---------
			
SELECT TOP(1)
D.DepartmentID,
D.Name,
ISNULL((SELECT AVG(Salary)
FROM Employees AS E
WHERE E.DepartmentID = D.DepartmentID),0) AS AVERAGEsALARY
FROM Departments AS D
--WHERE (SELECT COUNT(*) FROM Employees AS E WHERE E.DepartmentID=D.DepartmentID )>0
ORDER BY AVERAGEsALARY ASC
