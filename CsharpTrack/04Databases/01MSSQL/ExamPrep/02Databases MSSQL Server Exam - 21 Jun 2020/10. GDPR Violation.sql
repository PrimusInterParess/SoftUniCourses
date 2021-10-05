

select	t.Id, a.FirstName + ' '+a.MiddleName + ' '+ a.LastName
	from AccountsTrips as ac
		join Accounts as a on a.Id = ac.AccountId
			join Trips as t on t.Id = ac.TripId
				join Rooms as r on r.Id = t.RoomId
					join Hotels as h on h.Id = r.HotelId
						join Cities as c on c.Id = h.CityId