
select 
u.Username,avg(f.Size) as Size
	from Users as u
		join Commits as c on c.ContributorId=u.Id
			join Files as f on f.CommitId=c.Id
		group by u.Username
		order by Size desc,u.Username