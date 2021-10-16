select top(5) r.Id,r.Name,count(r.Id) as [Commits]
	from
		RepositoriesContributors as rc
			join Repositories as r on r.Id= rc.RepositoryId
				join Commits as c on c.RepositoryId =r.Id
				group by r.Id,r.Name
				order by [Commits] desc,r.Id,r.Name