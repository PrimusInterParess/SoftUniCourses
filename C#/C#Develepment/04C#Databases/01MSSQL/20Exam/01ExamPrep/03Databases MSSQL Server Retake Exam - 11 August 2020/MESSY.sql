use Bakery

select fin.ContrName as CountryName,fin.DistrName
from(
select dc.CountryName AS ContrName,dc.DistributorsName AS DistrName, DENSE_RANK() over (PARTITION by DC.COUNTRYNAME  ORDER BY DC.COUNT desc) AS RANCKED
from(
select c.Name as CountryName,d.Name as DistributorsName,(select count(*) from Ingredients as i where d.Id=i.DistributorId) as Count
	from Distributors as d
	join Countries as c on d.CountryId=c.Id
	) as DC) as fin
	where fin.RANCKED=1 
	order by fin.ContrName,fin.DistrName
	



	