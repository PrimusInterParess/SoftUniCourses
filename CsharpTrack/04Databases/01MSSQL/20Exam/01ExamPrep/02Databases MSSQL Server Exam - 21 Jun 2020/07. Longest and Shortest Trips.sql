
SELECT alabala.AccountId,alabala.FullName,alabala.LongestTrip,alabala.ShortestTrip
	FROM 
	(
SELECT A.Id as AccountId ,
A.FirstName + ' ' + A.LastName AS FullName,
A.MiddleName AS MIDnAME,
T.CancelDate AS Cancelled,
MAX(DATEDIFF(DAY,T.ArrivalDate,T.ReturnDate)) AS LongestTrip,
MIN(DATEDIFF(DAY,T.ArrivalDate,T.ReturnDate)) AS ShortestTrip
	FROM Accounts AS A
		JOIN AccountsTrips AS AC ON AC.AccountId = A.Id
			JOIN Trips AS T ON T.Id = AC.TripId
		GROUP BY a.Id ,a.FirstName,a.LastName,A.MiddleName,T.CancelDate) AS alabala
WHERE alabala.MIDnAME IS NULL AND alabala.Cancelled IS NULL
ORDER BY alabala.LongestTrip DESC,alabala.ShortestTrip ASC

		