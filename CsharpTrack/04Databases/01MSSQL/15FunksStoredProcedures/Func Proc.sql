
--variables
DECLARE @Year SMALLINT = 0
SELECT @Year




DECLARE @MTempTable TABLE(Id INT PRIMARY KEY IDENTITY, [Name] nvarchar(MAX))
INSERT INTO @MTempTable (Name) VALUEs ('Niki')
SELECT * FROM @MTempTable


--conditional statments
IF YEAR(GETDATE())=2022
BEGIN
	SET @Year = 2021
	INSERT INTO @MTempTable (Name) VALUEs ('mONI')
END


ELSE IF YEAR(GETDATE())=2024
	SET @Year =-2000
ELSE
	 SET @YEAR = YEAR(GETDATE())

	SELECT @Year


SELECT CASE @Year
	WHEN 2020 THEN '2021?'
	WHEN 2021 THEN '2021!!!'
	ELSE 'UKNOWNyEAR ' END;
	
	GO
--loops
 
 use SoftUni
DECLARE @Year SMALLINT = 2000;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year

SET @Year = @Year + 1;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year

SET @Year = @Year + 1;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year

SET @Year = @Year + 1;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year

SET @Year = @Year + 1;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year

SET @Year = @Year + 1;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year
GO

DECLARE @Year SMALLINT = 2000;
WHILE (@Year<2008)
BEGIN 
SET @Year = @Year + 1;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year
END

--FUNKS
go

--CREATE FUNCTION udf_CustomPowerFunk(@Base INT,@Ext INT)
--RETURNS decimal(38)
--AS
--BEGIN
--	DECLARE @Result DECIMAL(38) =1;

--		WHILE(@Ext >0)
--	BEGIN 
--			SET @Result = @Result * @Base;
--			SET	@Ext -=1;
--	END

-- RETURN @Result;
--END

SELECT dbo.udf_CustomPowerFunk(2,100)



--wiew

CREATE OR ALTER VIEW EmployeesByYear AS
SELECT * 
FROM Employees AS E
WHERE E.HireDate>'2000'

--FUNK

CREATE or ALTER FUNCTION udf_EmployeeByYear(@Year SMALLINT)
RETURNS TABLE
AS 
RETURN
(
SELECT * FROM Employees
WHERE YEAR(HireDate)=@Year
)

SELECT * FROM udf_EmployeeByYear(1999)

SELECT * FROM dbo.udf_AllPowers(100)

CREATE FUNCTION udf_AllPowers(@MaxPower INT)
RETURNS @Table TABLE(Id INT IDENTITY PRIMARY KEY,SQUARE BIGINT)
AS
BEGIN
	DECLARE @I INT =1;
	WHILE(@MaxPower >=@I)
	BEGIN
	INSERT INTO @Table (SQUARE) VALUES (@I * @I)
	SET @I=@I+1;
	END
	RETURN
END


go

Create FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS VARCHAR(max)
AS
BEGIN
	
	IF @Salary< 30000
		RETURN 'Low'
	ELSE IF  @Salary<=50000
		RETURN 'Average'

		RETURN 'High'
END

go

use SoftUni

SELECT FirstName,LastName,Salary,dbo.ufn_GetSalaryLevel(Salary)
FROM Employees

go

CREATE PROCEDURE dbo.usp_SlectEmployeesBySeniority
AS
	SELECT * 
		FROM Employees
		WHERE DATEDIFF(YEAR,HireDate,GETDATE()) >20
GO

EXEC dbo.usp_SlectEmployeesBySeniority

GO





