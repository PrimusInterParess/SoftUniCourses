SELECT P.[Name] AS [Name],p.Price as Price, p.[Description] as [Description]		
		FROM Products AS P 
		ORDER BY P.Price DESC,P.[Name] ASC
 			