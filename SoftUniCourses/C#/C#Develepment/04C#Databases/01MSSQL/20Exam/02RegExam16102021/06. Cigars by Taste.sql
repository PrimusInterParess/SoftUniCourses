
		SELECT C.Id,C.CigarName,C.PriceForSingleCigar,T.TasteType,T.TasteStrength
			FROM Cigars AS C
				JOIN Tastes AS T ON T.Id = C.TastId
					WHERE T.TasteType IN('Earthy','Woody')
					ORDER BY C.PriceForSingleCigar DESC