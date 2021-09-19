USE Gringotts


--1. Records� Count
SELECT COUNT(*)
FROM WizzardDeposits

--2. Longest Magic Wand

SELECT MAX(W.MagicWandSize)
FROM WizzardDeposits AS W

--3. Longest Magic Wand per Deposit Groups 

SELECT W.DepositGroup , MAX(W.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup

--4. * Smallest Deposit Group Per Magic Wand Size

SELECT TOP(2) W.DepositGroup
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup
ORDER BY AVG(W.MagicWandSize) ASC

--5. Deposits Sum

SELECT	W.DepositGroup ,SUM(W.DepositAmount)
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup

--6. Deposits Sum for Ollivander Family 

SELECT W.DepositGroup, SUM(W.DepositAmount) AS TotalSum
FROM WizzardDeposits AS W
WHERE W.MagicWandCreator ='Ollivander family'
GROUP BY W.DepositGroup


--7. Deposits Filter

SELECT W.DepositGroup, SUM(W.DepositAmount) AS TotalSum
FROM WizzardDeposits AS W
WHERE W.MagicWandCreator ='Ollivander family'
GROUP BY W.DepositGroup
HAVING SUM(W.DepositAmount)< 150000
ORDER BY SUM(W.DepositAmount) DESC


--8.Deposit Charge

SELECT W.DepositGroup,W.MagicWandCreator,MIN(W.DepositCharge)
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup,W.MagicWandCreator
ORDER BY W.MagicWandCreator,W.DepositGroup

--9. Age Groups


select result.AgeGroup,Count(result.AgeGroup)
from
(
SELECT CASE
	WHEN Age BETWEEN 0 AND 10 then '[0-10]'
	WHEN Age BETWEEN 11 AND 20 then '[11-20]'
	WHEN Age BETWEEN 21 AND 30 then '[21-30]'
	WHEN Age BETWEEN 31 AND 40 then '[31-40]'
	WHEN Age BETWEEN 41 AND 50 then '[41-50]'
	WHEN Age BETWEEN 51 AND 60 then '[51-60]'
	when age >=61 then '[61+]'
	END as AgeGroup
FROM WizzardDeposits) as result
group by result.AgeGroup

SELECT Result.AgeGroup , COUNT(Result.AgeGroup)
FROM
(
SELECT 
CASE
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	WHEN Age >=61 THEN '[61+]'
	END AS AgeGroup
FROM WizzardDeposits) AS Result
GROUP BY Result.AgeGroup

--10 FirstLetter

SELECT LEFT(W.FirstName,1)
FROM WizzardDeposits AS W
WHERE W.DepositGroup = 'Troll Chest'
GROUP BY LEFT(W.FirstName,1)
ORDER BY LEFT(W.FirstName,1) ASC

--11.Average Interest

SELECT W.DepositGroup,W.IsDepositExpired , AVG(W.DepositInterest)
FROM WizzardDeposits AS W
WHERE W.DepositStartDate >='01/01/1985'
GROUP BY W.DepositGroup,W.IsDepositExpired
ORDER BY W.DepositGroup DESC,W.IsDepositExpired ASC

--12.RichWizard,PoorWizard

SELECT SUM(GUEST.DepositAmount-HOST.DepositAmount)
FROM WizzardDeposits AS HOST
JOIN WizzardDeposits AS GUEST ON GUEST.Id+1 = HOST.Id


