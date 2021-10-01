CREATE PROC usp_ChangeJourneyPurpose (@JourneyId INT, @NewPurpose VARCHAR(11))
AS
	
		IF NOT EXISTS(SELECT * FROM Journeys
								WHERE Id=@JourneyId)
						THROW  50001,'The journey does not exist!',1;
	
		ELSE IF ((SELECT Purpose
					FROM Journeys
						WHERE Id=@JourneyId) LIKE @NewPurpose)
				 THROW  50002,'You cannot change the purpose!',2;

		ELSE
			
			update Journeys
			set Purpose = @NewPurpose
			where Id= @JourneyId
	
GO;


SELECT J. Purpose , J.Id
FROM Journeys AS J
WHERE J.Id = 16
