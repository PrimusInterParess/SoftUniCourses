USE Geography

SELECT m.MountainRange,p.PeakName,p.Elevation
	FROM Peaks AS P
	JOIN Mountains AS M ON P.MountainId=M.Id
	WHERE MountainRange = 'Rila'
	ORDER BY P.Elevation DESC