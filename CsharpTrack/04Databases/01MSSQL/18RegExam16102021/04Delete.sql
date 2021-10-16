--In table Addresses, delete every country which name starts with 'C', 
--keep in mind that could be foreign key constraint conflicts.

-- 7,8,10,23 - CONTRYiDS

--(7,8,20) CLIENTS

SELECT * FROM Clients AS C
	JOIN Addresses AS A ON C.AddressId= A.Id
	
			WHERE Country LIKE 'C%'

			DELETE FROM Clients 
			WHERE AddressId IN(7,8,10)
		
			DELETE  FROM Addresses 
				WHERE Country LIKE 'c%'
		



DELETE FROM ClientsCigars
	WHERE ClientId =10

DELETE Clients
	WHERE AddressId IN(7,8,20,23)

		DELETE FROM Addresses
	where Country LIKE 'C%' 

