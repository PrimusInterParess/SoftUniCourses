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

	SELECT 
	FROM Employees