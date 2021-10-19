select m.FirstName +' '+m.LastName as 'Mechanic',
avg(DATEDIFF(day,j.IssueDate,j.FinishDate)) as 'Average Days'
	from Jobs as j
		join Mechanics as m on m.MechanicId=j.MechanicId
		group by m.FirstName,m.LastName,m.MechanicId
		order by m.MechanicId
		