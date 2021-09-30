USE ColonialJourney

CREATE TABLE [Planets]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [Spaceports]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[PlanetId] INT FOREIGN KEY ([PlanetId]) REFERENCES [Planets]([Id]) NOT NULL
)

CREATE TABLE [Spaceships]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[Manufacturer] VARCHAR(30) NOT NULL,
[LightSpeedRate] INT DEFAULT 0
)

CREATE TABLE [Colonists]
(
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(20) NOT NULL,
[LastName] VARCHAR(20) NOT NULL,
[Ucn] VARCHAR(10) UNIQUE NOT NULL,
[BirthDate] DATE NOT NULL
)



CREATE TABLE [Journeys]
(
[Id] INT PRIMARY KEY IDENTITY,
[JourneyStart] DATETIME NOT NULL,
[JourneyEnd] DATETIME NOT NULL,
[Purpose] VARCHAR(11) NOT NULL CHECK ([Purpose] IN ('Medical','Technical','Educational','Military')),
[DestinationSpaceportId] INT FOREIGN KEY ([DestinationSpaceportId]) REFERENCES [Spaceports]([Id]) NOT NULL,
[SpaceshipId] INT FOREIGN KEY ([SpaceshipId]) REFERENCES [Spaceships]([Id]) NOT NULL
)

CREATE TABLE [TravelCards]
(
[Id] INT PRIMARY KEY IDENTITY,
[CardNumber]  VARCHAR(10) NOT NULL UNIQUE,
[JobDuringJourney] VARCHAR(8) CHECK ([JobDuringJourney] IN ('Pilot','Engineer','Trooper','Cleaner','Cook')),
[ColonistId] INT FOREIGN KEY ([ColonistId]) REFERENCES [Colonists]([Id]) NOT NULL,
[JourneyId] INT FOREIGN KEY ([JourneyId]) REFERENCES [Journeys]([Id]) NOT NULL
)



