--AdditionaExercises
USE Diablo

--Problem 1.	Number of Users for Email Provider



select *
	from Users

	select	Email
		from Users

		select CHARINDEX('@','vlado@softuni.bg')

		SELECT SUBSTRING('vlado@softuni.bg',CHARINDEX('@','vlado@softuni.bg')+1,LEN('vlado@softuni.bg')-CHARINDEX('@','vlado@softuni.bg')+1)



select Domain,count(domain.Domain) as 'Number Of Users'
from
(SELECT  SUBSTRING(Email,CHARINDEX('@',Email)+1,LEN(Email)-CHARINDEX('@',Email)+1) AS Domain
	FROM Users AS U
	)as domain
	group by domain.Domain
	order by [Number Of Users] desc,Domain asc



--Problem 2.	All User in Games

SELECT * 
	FROM Users

	SELECT * 
	FROM UsersGames
	
	SELECT * FROM [Statistics]

	SELECT * FROM Characters

	select * from Games
	order by Name

	select * from GameTypes


SELECT G.[Name] AS 'Game' ,GT.[Name] AS 'Game Type',U.Username,UG.[Level],UG.Cash,C.Name AS 'Character'
	FROM UsersGames AS UG
	JOIN Games AS G ON G.Id= UG.GameId
	JOIN GameTypes AS GT ON GT.Id=G.GameTypeId
	JOIN Users AS U ON U.Id = UG.UserId
	JOIN Characters AS C ON C.Id = UG.CharacterId
order by UG.[Level] DESC,U.Username, G.[Name]


--Problem 3.	Users in Games with Their Items

SELECT * FROM UserGameItems

SELECT * FROM UsersGames AS UG
JOIN UserGameItems AS UGI ON UGI.UserGameId=UG.GameId
ORDER BY UG.UserId



SELECT U.Username ,G.Name, UGI.ItemId
	FROM UserGameItems AS UGI
	JOIN Items AS I ON I.Id=UGI.ItemId
	JOIN UsersGames AS UG ON UG.Id = UGI.UserGameId
	JOIN Games AS G ON G.Id=UG.GameId
	JOIN Users AS U ON U.Id=UG.UserId

	

SELECT U.Username,COUNT(G.[Name]) AS 'Game'
	FROM Users as U
	JOIN UsersGames AS UG ON UG.UserId = U.Id
	JOIN Games AS G ON G.Id=UG.GameId
	JOIN UserGameItems AS UGI ON UGI.UserGameId = UG.Id
	JOIN Items AS I ON I.Id = UGI.ItemId


SELECT U.[Username],G.[Name] AS [Game],COUNT(I.Name) AS [Item Count],SUM(I.Price) AS [Items Price]
	FROM Users AS U
	JOIN UsersGames AS UG ON UG.UserId=U.Id
	JOIN Games AS G ON G.Id=UG.GameId
	JOIN UserGameItems AS UGI ON UGI.UserGameId=UG.Id
	JOIN Items AS I ON I.Id=UGI.ItemId
GROUP BY U.Username,G.Name
HAVING COUNT(I.Name)>=10
ORDER BY COUNT(I.Name) desc,SUM(I.Price) desc,u.Username

--Problem 4.	* User in Games with Their Statistics

