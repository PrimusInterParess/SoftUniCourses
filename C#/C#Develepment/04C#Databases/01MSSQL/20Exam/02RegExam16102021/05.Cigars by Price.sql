

	SELECT C.CigarName,C.PriceForSingleCigar,C.ImageURL
		FROM Cigars AS C
			ORDER BY C.PriceForSingleCigar ASC,C.CigarName DESC