

delete files 
where CommitId=36

delete from Commits 
where RepositoryId=3

delete from Issues 
	where RepositoryId=3

	delete from RepositoriesContributors
		where RepositoryId=3

delete from Repositories 
where Name like 'Softuni-Teamwork'




