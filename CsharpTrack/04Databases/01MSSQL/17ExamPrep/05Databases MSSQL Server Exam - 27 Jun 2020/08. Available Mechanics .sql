SELECT m.FirstName+' '+m.LastName
	FROM Mechanics AS M 
	LEFT JOIN Jobs AS J ON M.MechanicId=J.MechanicId
	WHERE J.Status LIKE 'Finished' or m.MechanicId not in(select MechanicId from Jobs)
	group by m.FirstName,m.LastName,m.MechanicId
	order by m.MechanicId