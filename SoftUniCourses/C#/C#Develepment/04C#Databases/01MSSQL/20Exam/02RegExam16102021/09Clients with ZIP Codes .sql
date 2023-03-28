
SELECT C.FirstName+' '+ C.LastName AS FullName,adr.Country,adr.ZIP,CONCAT('$',max(cgr.PriceForSingleCigar)) as CigarPrice																		
	FROM Clients AS C
		JOIN Addresses AS ADR ON C.AddressId=ADR.Id
			join ClientsCigars as cc on c.Id=cc.ClientId
				join Cigars as cgr on cgr.Id= cc.CigarId
			WHERE (PATINDEX('%[^0-9]%', ZIP) =0)
			group by c.FirstName,c.LastName,adr.Country,adr.ZIP
			


