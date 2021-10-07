CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN

 DECLARE @HotelBaseRate DECIMAL(12,2) =(SELECT H.BaseRate
							FROM Hotels AS H
							WHERE H.Id=@HotelId)

DECLARE @RoomPrice decimal(12,3) = (SELECT TOP(1) r.Price 
	FROM Hotels AS H
		JOIN Rooms AS R ON R.HotelId=H.Id
			JOIN Trips AS T ON T.RoomId = R.Id
		WHERE H.Id=@HotelId AND NOT(@Date BETWEEN T.ArrivalDate AND T.ReturnDate) AND R.Beds>@People AND T.CancelDate IS NULL
		ORDER BY   r.Price  DESC)

		IF(@RoomPrice IS NULL)
		RETURN 'No rooms available'


DECLARE @ROOMNUMBER INT = (SELECT TOP(1) R.Id 
	FROM Hotels AS H
		JOIN Rooms AS R ON R.HotelId=H.Id
			JOIN Trips AS T ON T.RoomId = R.Id
		WHERE H.Id=@HotelId AND NOT(@Date BETWEEN T.ArrivalDate AND T.ReturnDate) AND R.Beds>@People AND T.CancelDate IS NULL
		ORDER BY   r.Price  DESC)

DECLARE @BEDS INT =(SELECT TOP(1) R.Beds 
	FROM Hotels AS H
		JOIN Rooms AS R ON R.HotelId=H.Id
			JOIN Trips AS T ON T.RoomId = R.Id
		WHERE H.Id=@HotelId AND NOT(@Date BETWEEN T.ArrivalDate AND T.ReturnDate) AND R.Beds>@People AND T.CancelDate IS NULL
		ORDER BY   r.Price  DESC)

		DECLARE @ROOMTYPE NVARCHAR(max) =(SELECT TOP(1) R.Type 
	FROM Hotels AS H
		JOIN Rooms AS R ON R.HotelId=H.Id
			JOIN Trips AS T ON T.RoomId = R.Id
		WHERE H.Id=@HotelId AND NOT(@Date BETWEEN T.ArrivalDate AND T.ReturnDate) AND R.Beds>@People AND T.CancelDate IS NULL
		ORDER BY   r.Price  DESC)

 DECLARE @TOTAL DECIMAL(12,2) = (@HotelBaseRate+ @RoomPrice)*@PEOPLE

 RETURN CONCAT('Room ',@ROOMNUMBER,': ',@ROOMTYPE,' (',@BEDS,' beds) - $',@TOTAL)
END

GO

DECLARE @HotelId INT = 94
DECLARE @Date DATE = '2015-07-26'
DECLARE @People INT =3

 DECLARE @HotelBaseRate DECIMAL(12,2) =(SELECT H.BaseRate
							FROM Hotels AS H
							WHERE H.Id=@HotelId)

DECLARE @RoomPrice decimal(12,3) = (SELECT TOP(1) r.Price 
	FROM Hotels AS H
		JOIN Rooms AS R ON R.HotelId=H.Id
			JOIN Trips AS T ON T.RoomId = R.Id
		WHERE H.Id=@HotelId AND NOT(@Date BETWEEN T.ArrivalDate AND T.ReturnDate) AND R.Beds>@People AND T.CancelDate IS NULL
		ORDER BY   r.Price  DESC)

DECLARE @ROOMNUMBER INT = (SELECT TOP(1) R.Id 
	FROM Hotels AS H
		JOIN Rooms AS R ON R.HotelId=H.Id
			JOIN Trips AS T ON T.RoomId = R.Id
		WHERE H.Id=@HotelId AND NOT(@Date BETWEEN T.ArrivalDate AND T.ReturnDate) AND R.Beds>@People AND T.CancelDate IS NULL
		ORDER BY   r.Price  DESC)

DECLARE @BEDS INT =(SELECT TOP(1) R.Beds 
	FROM Hotels AS H
		JOIN Rooms AS R ON R.HotelId=H.Id
			JOIN Trips AS T ON T.RoomId = R.Id
		WHERE H.Id=@HotelId AND NOT(@Date BETWEEN T.ArrivalDate AND T.ReturnDate) AND R.Beds>@People AND T.CancelDate IS NULL
		ORDER BY   r.Price  DESC)


 DECLARE @TOTAL DECIMAL(12,2) = (@HotelBaseRate+ @RoomPrice)*@PEOPLE

 SELECT @BEDS
 SELECT @TOTAL
 SELECT @ROOMNUMBER


  SELECT DBO.udf_GetAvailableRoom (112,'2011-12-17', 2)

  SELECT DBO.udf_GetAvailableRoom (94, '2015-07-26', 3)
