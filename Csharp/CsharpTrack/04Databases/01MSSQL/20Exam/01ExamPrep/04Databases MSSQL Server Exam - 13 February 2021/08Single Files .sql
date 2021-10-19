SELECT 
F.Id,F.Name,CONCAT(F.Size,'KB')
FROM Files AS F
 WHERE F.Id NOT IN (SELECT FI.ParentId
							FROM Files AS FI
								JOIN Files AS FO ON FO.Id=FI.ParentId)
ORDER BY F.Id,F.Name,F.Size

	
