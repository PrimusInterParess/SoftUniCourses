CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(10))
AS
SELECT F.Id,F.Name,CONCAT(F.Size,'KB')
FROM Files AS F
WHERE Name like '%'+ @fileExtension
ORDER BY F.Id,F.Size DESC
	

	EXEC DBO.usp_SearchForFiles 'txt'

