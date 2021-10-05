

SELECT top(10) c.Id,C.Name,c.CountryCode,COUNT(A.Id)
	FROM Accounts AS A
		JOIN Cities AS C ON C.Id = A.CityId
			GROUP BY C.Name,c.Id,c.CountryCode
			order by COUNT(A.Id) desc

			SELECT top(10) C.Id,C.Name,C.CountryCode,COUNT(A.Id) as Accounts
				FROM Cities AS C
					JOIN Accounts AS A ON A.CityId=C.Id
					GROUP BY C.Id,C.Name,C.CountryCode
					ORDER BY Accounts desc