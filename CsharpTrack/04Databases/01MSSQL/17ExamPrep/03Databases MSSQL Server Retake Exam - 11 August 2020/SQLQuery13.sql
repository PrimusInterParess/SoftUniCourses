SELECT	
D.Name AS DistributorName ,I.Name AS IngredientName,P.Name AS ProductName ,AVG(FB.Rate) AS AverageRate
FROM ProductsIngredients AS [PI]
			JOIN Products AS P ON [PI].ProductId=P.Id
				JOIN Ingredients AS I ON [PI].IngredientId=I.Id
			JOIN Distributors AS D ON D.Id=I.DistributorId
			JOIN Feedbacks AS FB ON FB.ProductId=P.Id
			GROUP BY D.Name,I.Name,P.Name
			HAVING AVG(FB.Rate) BETWEEN 5 AND 8

SELECT d.Name as DistributorName,i.Name as IngredientName, p.Name,AVG(FB.Rate) AS Rate
	FROM Distributors AS D
 JOIN Ingredients as I ON d.Id=I.DistributorId
 JOIN ProductsIngredients AS IPR ON IPR.IngredientId=I.Id
 JOIN Products AS P ON IPR.ProductId=P.Id
 JOIN Feedbacks AS FB ON FB.ProductId=P.Id
	GROUP BY d.Name,i.Name,p.Name
	having AVG(FB.Rate) between 5 and 8
	order by d.Name,i.Name,p.Name 