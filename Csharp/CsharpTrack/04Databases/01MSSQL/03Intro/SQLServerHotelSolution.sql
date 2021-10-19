CREATE Database Hotel

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Title NVARCHAR(30) NOT NULL,
Notes NVARCHAR(200)
)

INSERT INTO Employees(FirstName,LastName,Title)
	VALUES
	('Pena','Chistackata','cleaning'),
	('Lena','Chistackata','cleaning'),
	('Gena','Chistackata','cleaning')

CREATE TABLE Customers
(
AccountNumber INT PRIMARY KEY NOT NULL,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
PhoneNumber int NOT NULL,
EmergencyName NVARCHAR(30) NOT NULL,
EmergencyNumber int NOT NULL,
Notes NVARCHAR(200)
)

INSERT INTO Customers(AccountNumber,FirstName,LastName,PhoneNumber,EmergencyName,EmergencyNumber)
	VALUES
	(5423564,'TOTO','kOTO',0544235,'SPESHO',0543432),
	(2312421,'lOTO','kOTO',0544235,'SPESHO',0543432),
	(43242121,'kROTO','kOTO',0544235,'SPESHO',0543432)

CREATE TABLE RoomStatus
(
RoomStatus NVARCHAR(10) NOT NULL,
Notes NVARCHAR(200)
)

INSERT INTO RoomStatus(RoomStatus)
	VALUES
	('AVAILABLE'),
	('UN'),	
	('UN')

CREATE TABLE RoomTypes
(
RoomType NVARCHAR(10) NOT NULL,
Notes NVARCHAR(200)
)

INSERT INTO RoomTypes(RoomType)
	VALUES
	('SINGLE'),
	('DOUBLE'),	
	('TRIPPLE')
--•	BedTypes (BedType, Notes)

Use Hotel
CREATE TABLE BedTypes
(
BedType NVARCHAR(10) NOT NULL,
Notes NVARCHAR(200)
)

INSERT INTO BedTypes(BedType)
	VALUES
	('SINGLE'),
	('DOUBLE'),	
	('TRIPPLE')

Use Hotel
CREATE TABLE Rooms
(
RoomNumber INT UNIQUE NOT NULL,
RîîmType NVARCHAR(10) NOT NULL,
BedType NVARCHAR(10) NOT NULL,
Rate INT,
RoomStatus NVARCHAR(10) NOT NULL,
Notes NVARCHAR(200)
)

INSERT INTO Rooms(RoomNumber,RîîmType,BedType,RoomStatus)
	VALUES
	(1,'SINGLE','SINGLE','Available'),
	(2,'DOUBLE','DOUBLE','Available'),
	(3,'TRIPPLE','TRIPPLE','UN')

CREATE TABLE Payments
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
PaymentDate DATE NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
FirstDateOccupied  DATE NOT NULL,
LastDateOccupied  DATE NOT NULL,
TotalDays INT NOT NULL ,
AmountCharged decimal(18,2) not null,
TaxRate int,
TaxAmount decimal(18,2),
PaymentTotal decimal (18,2),
Notes NVARCHAR(200)
)

INSERT INTO Payments(EmployeeId,PaymentDate,AccountNumber,FirstDateOccupied,LastDateOccupied,TotalDays,AmountCharged)
	VALUES
	(1,'01.02.2021',5423564,'01.02.2021','01.12.2021',10,500.21),
	(2,'01.02.2021',2312421,'01.02.2021','01.12.2021',10,500.21),
	(3,'01.02.2021',43242121,'01.02.2021','01.12.2021',10,500.21)

CREATE TABLE Occupancies
(
Id INT PRIMARY KEY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
DateOccupied DATE NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
RoomNumber INT UNIQUE NOT NULL,
RateApplied INT,
PhoneCharge DECIMAL(18,2),
Notes NVARCHAR(200)
)

INSERT INTO Occupancies(Id,EmployeeId,DateOccupied,AccountNumber,RoomNumber)
	VALUES
	(1,1,'01.02.2021',5423564,1),
	(2,2,'01.02.2021',2312421,2),
	(3,3,'01.02.2021',43242121,3)
