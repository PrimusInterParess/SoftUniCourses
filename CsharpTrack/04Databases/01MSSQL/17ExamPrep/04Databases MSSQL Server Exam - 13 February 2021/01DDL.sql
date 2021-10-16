

CREATE TABLE Users
(
	Id INT PRIMARY KEY  IDENTITY,
	Username VARCHAR(30) NOT NULL,
	Password VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY  KEY  IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
RepositoryId INT FOREIGN KEY (RepositoryId) REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY (ContributorId) REFERENCES Users(Id) NOT NULL,
 CONSTRAINT PK_RepositoriesContributors PRIMARY KEY(RepositoryId,ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY  KEY  IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus VARCHAR(6) CHECK(LEN(IssueStatus)<=6 AND  IssueStatus IN('open','closed')) NOT NULL,
	RepositoryId INT FOREIGN KEY (RepositoryId) REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY (AssigneeId) REFERENCES Users(Id) NOT NULL,
)

CREATE TABLE Commits
(
	Id INT PRIMARY  KEY  IDENTITY,
	Message VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY (IssueId) REFERENCES Issues(Id) NOT NULL,
	RepositoryId INT FOREIGN KEY (RepositoryId) REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY (ContributorId) REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
		Id INT PRIMARY  KEY  IDENTITY,
		Name VARCHAR(100) NOT NULL,
		Size DECIMAL(10,2) NOT NULL,
		ParentId INT FOREIGN KEY (ParentId) REFERENCES Files(Id) NOT NULL,
		CommitId INT FOREIGN KEY (CommitId) REFERENCES Commits(Id) NOT NULL
)

