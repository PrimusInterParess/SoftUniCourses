

	CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR)
	RETURNS INT
	AS
	BEGIN

		DECLARE @RESULT INT = (SELECT COUNT(cc.ClientId)
						FROM ClientsCigars AS CC
							JOIN Clients AS C ON C.Id= CC.ClientId
							WHERE C.FirstName LIKE 'BETTY'
							GROUP BY C.Id)
	RETURN @RESULT
	END
	GO
	SELECT COUNT(*)
		FROM Clients AS C
			JOIN ClientsCigars AS CC ON C.Id= CC.ClientId
			WHERE C.FirstName LIKE 'BETTY'

			(SELECT COUNT(cc.ClientId)
						FROM Clients AS C
							JOIN ClientsCigars AS CC ON C.Id= CC.ClientId
							WHERE C.FirstName LIKE'BETTY'
							GROUP BY C.Id


							GO

		SELECT dbo.udf_ClientWithCigars('Betty')		

		select * from Clients 
		where FirstName= 'betty'

		SELECT COUNT(cc.ClientId)
						FROM ClientsCigars AS CC
							JOIN Clients AS C ON C.Id= CC.ClientId
							WHERE C.FirstName LIKE 'BETTY'
							GROUP BY C.Id