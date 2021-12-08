

		CREATE  PROCEDURE usp_SearchByTaste(@taste VARCHAR(20))
		AS

		SELECT C.CigarName AS CigarName,
		CONCAT('$',C.PriceForSingleCigar) AS Price,
		T.TasteType AS TasteType,
		B.BrandName AS BrandName,
		CONCAT(S.Length,' cm') AS CigarLength ,
		CONCAT(S.RingRange,' cm') AS CigarRingRange
			FROM Cigars AS C
				JOIN Tastes AS T ON T.Id=C.TastId
				JOIN Brands AS B ON B.Id=C.BrandId
				JOIN Sizes AS S ON S.Id=C.SizeId
				where t.TasteType = @taste
			order by s.Length,s.RingRange DESC

			go
			exec dbo.usp_SearchByTaste 'Woody'