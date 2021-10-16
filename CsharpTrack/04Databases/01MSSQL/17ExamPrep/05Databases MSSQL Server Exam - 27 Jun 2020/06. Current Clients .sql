SELECT c.FirstName+' '+c.LastName as Client,
		DATEDIFF(DAY,j.IssueDate,'2017-04-24')as [Days going],
		j.Status
	FROM Clients AS c
	JOIN Jobs AS J ON C.ClientId=J.ClientId
	WHERE J.Status <> 'Finished'
	order by [Days going] desc,c.ClientId