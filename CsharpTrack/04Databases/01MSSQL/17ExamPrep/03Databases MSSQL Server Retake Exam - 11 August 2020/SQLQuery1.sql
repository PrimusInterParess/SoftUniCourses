

	CREATE TABLE Countries
	(
		Id  INT PRIMARY KEY IDENTITY,
		[Name] NVARCHAR(50) UNIQUE NOT NULL,
	)

	CREATE TABLE Customers
	(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		FirstName NVARCHAR(25),
		LastName NVARCHAR(25),
		Gender CHAR(1) CHECK(Gender IN('M','F')),
		Age INT ,
		PhoneNumber VARCHAR(10) CHECK(LEN(PhoneNumber)=10),
		CountryId INT FOREIGN KEY (CountryId) REFERENCES Countries(Id)
	)

	CREATE TABLE Products
	(
		Id INT PRIMARY KEY IDENTITY,
		[Name] NVARCHAR(25) UNIQUE,
		[Description] NVARCHAR(250),
		Recipe NVARCHAR(MAX),
		Price DECIMAL(18,2) CHECK(Price>=0)
	)

	CREATE TABLE Feedbacks
	(
		Id INT PRIMARY KEY IDENTITY,
		[Description] NVARCHAR(255),
		Rate DECIMAL(4,2) CHECK(Rate BETWEEN 0 AND 10),
		ProductId INT FOREIGN KEY (ProductId) REFERENCES Products(Id) NOT NULL,
		CustormerId INT FOREIGN KEY (CustormerId) REFERENCES Customers(Id) NOT NULL
	)

	CREATE TABLE Distributors
	(
		Id INT PRIMARY KEY IDENTITY,
		[Name] NVARCHAR(25) UNIQUE NOT NULL,
		AddressText NVARCHAR(30),
		Summary NVARCHAR(200),
		CountryId INT FOREIGN KEY (CountryId) REFERENCES Countries(Id)
	)

	CREATE TABLE Ingredients
	(
		Id INT PRIMARY KEY IDENTITY,
		[Name] NVARCHAR(30) NOT NULL,
		[Description] NVARCHAR(200),
		OriginCountryId INT FOREIGN KEY (OriginCountryId) REFERENCES Countries(Id),
		DistributorsId INT FOREIGN  KEY (DistributorsId) REFERENCES Distributors
	)

	CREATE TABLE ProductsIngredients
	(
		ProductId INT FOREIGN KEY (ProductId) REFERENCES Products(Id),
		IngredientId INT FOREIGN KEY (IngredientId) REFERENCES Ingredients(id),
		CONSTRAINT PK_ProductsIngredients PRIMARY KEY (ProductId,IngredientId)
	)