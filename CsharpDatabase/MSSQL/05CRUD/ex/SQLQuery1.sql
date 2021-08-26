use Geography

SELECT PeakName
FROM Peaks
order by PeakName

select top(30) CountryName,[Population]
from Countries
where ContinentCode = 'EU'
order by Population desc,CountryName


SELECT CountryName,CountryCode,
CASE
WHEN CurrencyCode='EUR' THEN'Euro'
ELSE 'Not Euro'
END AS [Currency]
FROM Countries
ORDER BY CountryName


