CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(25)) 
RETURNS INT
AS
BEGIN
	
DECLARE @NUMBERoFcOMITS INT = (SELECT COUNT(*)
							FROM Users AS U
								JOIN Commits AS C ON C.ContributorId=U.Id
									WHERE U.Username = @username)

RETURN  @NUMBERoFcOMITS
END