SELECT *
	FROM AccountsTrips AS AC
		JOIN Accounts AS A ON A.Id =AC.AccountId
			JOIN Trips AS T ON T.Id =AC.TripId
		WHERE  AC.AccountId=47

		DELETE FROM AccountsTrips
		WHERE AccountId =47

		DELETE FROM Accounts
		WHERE Id =47