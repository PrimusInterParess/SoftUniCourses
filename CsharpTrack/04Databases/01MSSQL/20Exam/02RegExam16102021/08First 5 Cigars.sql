

	
	SELECT top(5) C.CigarName,C.PriceForSingleCigar,C.ImageURL		
		FROM Cigars AS C
			JOIN Sizes AS S ON S.Id=C.SizeId
				WHERE (S.[Length]>=12 AND CHARINDEX('ci',C.CigarName)>0) or (c.PriceForSingleCigar>=50 and s.RingRange>=2.55 AND S.[Length]>=12)
	order by c.CigarName,c.PriceForSingleCigar desc
			


			SELECT *
		FROM Cigars AS C
			JOIN Sizes AS S ON S.Id=C.SizeId
				WHERE c.CigarName in ('DAVIDOFF MILLENNIUM BLEND ROBUSTO','DAVIDOFF SIGNATURE NO.2 TUBOS')
