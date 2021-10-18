

	SELECT C.Id,C.FirstName+' '+ C.LastName AS ClientName,c.Email
		FROM Clients AS C 
			WHERE C.Id NOT IN (SELECT CC.ClientId
									FROM ClientsCigars AS CC)
									ORDER BY ClientName