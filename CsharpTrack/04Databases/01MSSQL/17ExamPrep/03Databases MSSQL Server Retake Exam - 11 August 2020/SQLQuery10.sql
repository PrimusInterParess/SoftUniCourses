SELECT
FB.ProductId as ProductId,
FB.Rate AS Rate,
fb.Description,
c.Id as CustomerId,
c.Age as Age,
c.Gender as Gender
	FROM Feedbacks AS FB
		JOIN Customers AS C ON C.Id=FB.CustomerId
		WHERE FB.Rate<=5.0
		ORDER BY FB.ProductId DESC,FB.Rate ASC