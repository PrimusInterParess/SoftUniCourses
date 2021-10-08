CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
		DECLARE @HotelId int = (SELECT r.HotelId
									FROM Trips AS T
							JOIN Rooms AS R ON R.Id=T.RoomId
						WHERE T.ID =@TripId)

		DECLARE @ExistingRoom INT = (SELECT COUNT(*) 
										FROM Rooms as r
										WHERE r.HotelId = @HotelId and @TargetRoomId =r.Id)
										
		DECLARE @AccountsCounts INT= (SELECT t.Id,count(ac.AccountId)
										from AccountsTrips as ac
											join Trips as t on t.Id=ac.TripId
											where t.Id = @TripId
											group by t.id)

		DECLARE @BedCount INT = (SELECT Beds
									FROM Rooms 
										WHERE HotelId=@HotelId AND Id=@TargetRoomId)

		IF(@BedCount<@AccountsCounts)
				THROW 60001,'Not enough beds in target room!',1

		IF(@ExistingRoom=0)
		THROW 60000,'Target room is in another hotel!',1

 
		RETURN @TargetRoomId
		
END
GO

DECLARE @TripId INT=10
DECLARE @TargetRoomId INT=11

SELECT Beds FROM Rooms
WHERE Id=1



DECLARE @BedCount INT = (SELECT Beds
									FROM Rooms 
										WHERE HotelId=6 AND Id=11)



SELECT @BedCount



go

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS	
		DECLARE @HotelId INT = (SELECT R.HotelId FROM Trips AS T
									JOIN Rooms AS R ON  R.Id = T.RoomId
									WHERE T.Id = @TripId)
		DECLARE @RoomId INT = (SELECT Id FROM Rooms WHERE HotelId=@HotelId AND ID = @TargetRoomId)
		
		IF(@RoomId IS NULL)
			THROW 60000,'Target room is in another hotel!',1

		DECLARE @TripsCount INT  =(SELECT COUNT(*)
										FROM AccountsTrips
										WHERE TripId = @TripId)

		DECLARE @RoomBeds INT = (SELECT Beds
										FROM Rooms
										WHERE ID = @RoomId)
		IF(@TripsCount>@RoomBeds)
			THROW 60001,'Not enough beds in target room!',1

		UPDATE Trips
			SET RoomId = @TargetRoomId
			WHERE Id = @TripId

	GO



