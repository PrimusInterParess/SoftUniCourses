SELECT A.FirstName,A.LastName,FORMAT (A.BirthDate, 'MM-dd-yyyy ') ,C.[Name],a.Email
	FROM Accounts AS A
		JOIN Cities AS C ON A.CityId=C.Id
		WHERE A.Email LIKE 'E%'
		ORDER BY C.Name

