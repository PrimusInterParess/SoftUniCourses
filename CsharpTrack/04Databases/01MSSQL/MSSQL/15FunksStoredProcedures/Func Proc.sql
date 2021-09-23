
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

CREATE FUNCTION udf_CustomPowerFunk(@Base INT,@Ext INT)
RETURNS INT
AS
BEGIN
	DECLARE @Base INT =2;
	DECLARE @Ext INT =126;
	DECLARE REsult DECIMAL(38) =1;

		WHILE(@Ext >0)
	BEGIN 
			SET @Result = @Result * @Base;
			SET	@EXT -=1;
	END

 RETURN @Result;
END

SELECT @Result