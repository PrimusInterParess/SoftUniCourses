

	select C.LastName AS LastName,AVG(s.Length) AS CiagrLength,CEILING(AVG(S.RingRange))
		from Clients as C
			JOIN ClientsCigars AS CC ON CC.ClientId= C.Id
				JOIN Cigars AS CR ON CC.CigarId=CR.Id
					join Sizes as s on s.Id=CR.SizeId
				group by c.LastName
			ORDER BY CiagrLength DESC