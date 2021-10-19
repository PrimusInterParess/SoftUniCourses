select c.FirstName,c.Age,c.PhoneNumber
	from Customers as c
	join Countries as contr on contr.Id = c.CountryId
		where (c.Age>=21 and CHARINDEX('an',c.FirstName)>0) or (c.PhoneNumber like'%38' and contr.Name != 'Greece')
		order by c.FirstName asc,age desc

		select 
		*
		from Customers
		where FirstName = '%an'