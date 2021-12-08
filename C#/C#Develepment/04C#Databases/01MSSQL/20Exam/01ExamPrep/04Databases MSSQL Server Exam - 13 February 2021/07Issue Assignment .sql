select i.Id,u.Username +' '+':'+ ' '+i.Title
	from Issues as i 
	join Users as u on i.AssigneeId=u.Id
	order by i.Id desc,i.AssigneeId