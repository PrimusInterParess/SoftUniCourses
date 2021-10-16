
create view v_UserWithCountries
as
select cust.FirstName + ' '+ cust.LastName as [Customername],
	   cust.Age as [Age],
	   cust.Gender as [Gender],
	   countr.[Name] as [CountryName]
from
	Customers as cust
	join Countries as countr on cust.CountryId= countr.Id

	select top(5)* from dbo.v_UserWithCountries
	order by Age
