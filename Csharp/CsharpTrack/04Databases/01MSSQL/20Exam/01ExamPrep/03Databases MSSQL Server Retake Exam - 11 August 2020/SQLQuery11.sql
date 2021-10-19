select c.FirstName+' '+ c.LastName as CustomerName,c.PhoneNumber as PhoneNumber,c.Gender as Gender
	from
		Customers as c
			left join Feedbacks as fb on fb.CustomerId=c.Id
			where fb.Id is null
			order by c.Id asc

			SELECT CONCAT(FirstName,' ',LastName) AS CustomerName,PhoneNumber,Gender
	FROM Customers
	WHERE Id NOT IN (SELECT CustomerId FROM Feedbacks)
 ORDER BY Id 