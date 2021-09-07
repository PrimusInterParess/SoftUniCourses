SELECT FirstName,LastName
	FROM Employees
	WHERE FirstName LIKE 'Sa%'

	SELECT FirstName,LastName
	FROM Employees
	WHERE LastName LIKE '%ei%'
	 

	SELECT FirstName
	FROM Employees
	WHERE DepartmentID = 3 or DepartmentID = 10 AND
	YEAR(HireDate)>=1995 and YEAR(HireDate)<=2005

	SELECT FirstName,LastName
	FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

	SELECT [Name]
	FROM Towns
	WHERE LEN(Name)=5 OR LEN(Name)=6
	ORDER BY Name

	--Write a SQL query to find all towns that start with letters M, K, B or E.
	--Order them alphabetically by town name. 

	SELECT TownID,[Name]
	FROM Towns
	WHERE Name LIKE 'M%'or Name LIKE 'K%' or Name LIKE 'B%' or Name LIKE 'E%'
	ORDER BY [Name]


	--Write a SQL query to find all towns that does not start with letters R, B or D. 
	--Order them alphabetically by name. 

   SELECT TownID,[Name]
	FROM Towns
	WHERE Name NOT LIKE 'R%' AND Name NOT LIKE 'B%' AND Name NOT LIKE  'D%'
	ORDER BY [Name]


	--Write a SQL query to create view V_EmployeesHiredAfter2000 with first and last name
	--to all employees hired after 2000 year. 

	CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName,LastName
	FROM Employees
	WHERE YEAR(HireDate)>2000

	--Write a SQL query to find the names of
	--all employees whose last name is exactly 5 characters long.

	SELECT FirstName,LastName
	FROM Employees
	WHERE LEN(LastName)=5

	SELECT * FROM(
	SELECT EmployeeID,FirstName,LastName,Salary,
	DENSE_RANK() OVER  (PARTITION BY Salary
						ORDER BY EmployeeID ) AS Rank
						FROM Employees
						WHERE Salary>=10000 AND Salary <=50000 						
						 )
						AS Res
						where Rank=2
						ORDER BY  Salary DESC

USE Geography		
select CountryName,IsoCode
from Countries
where CountryName like '%a%a%a%'
ORDER BY IsoCode

SELECT PeakName,RiverName,
LOWER(LEFT(PeakName,LEN(PeakName)-1)+RiverName) AS Mix
FROM Peaks,Rivers
WHERE RIGHT(PeakName,1) = LEFT(RiverName,1)
order by Mix


USE Diablo


SELECT TOP(50) [Name],format(Start,'yyyy-MM-dd') AS [Start]
	FROM Games
		WHERE DATEPART(yyyy,[Start]) BETWEEN 2011 AND 2012
			ORDER BY [Start],[Name]


SELECT Username,SUBSTRING(Email,charindex('@',Email)+1,LEN(Email)) AS [Email Provider]
FROM Users
order by [Email Provider] asc,Username

SELECT Username,IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

SELECT * FROM Games

SELECT [Name],
CASE
WHEN DATEPART(HOUR,Start) BETWEEN 0 AND 11 THEN 'Morning'
WHEN DATEPART(HOUR,Start) BETWEEN 12 AND 17 THEN 'Afternoon'
WHEN DATEPART(HOUR,Start) BETWEEN 18 AND 23 THEN 'Evening'
END
AS [Part of the Day],
CASE
WHEN Duration<=3 THEN 'Extra Short'
WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
WHEN Duration>6 THEN 'Long'
ELSE
'Extra Long'
END
AS [Duration]
FROM Games
ORDER BY [Name],[Duration],[Part of the Day]

SELECT ProductName,
	   OrderDate,
	   DATEADD(DAY,3,OrderDate) AS [Pay Due],
	   DATEADD(month,1,OrderDate) AS [Deliver Due]
	   FROM Orders


						
						
						



						
					