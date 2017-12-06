-- sql upscript for the Fall 2017 retake CS 460 Final Database

CREATE TABLE dbo.Actor(
	A_ID INT IDENTITY(1,1) NOT NULL,
	A_Name NVARCHAR(64) NOT NULL,
	
	CONSTRAINT [PK_dbo.Actor] PRIMARY KEY CLUSTERED (A_ID ASC),
);

Create Table dbo.Director(

	D_ID	INT IDENTITY(1,1) NOT NULL,
	D_Name NVARCHAR(64) NOT NULL,
	
	CONSTRAINT [PK_dbo.Items] Primary Key Clustered (D_ID ASC),
	);



CREATE TABLE dbo.Movie(
	M_ID INT IDENTITY(1,1) NOT NULL,
	M_Name NVARCHAR(64) NOT NULL,
	M_Year varchar(24),
	M_Dir INT Foreign Key References dbo.Director(D_ID)  Not Null,

	Constraint [PK_dbo.Movie] PRIMARY KEY CLUSTERED (M_ID ASC),
	CONSTRAINT [FK_dbo.Movie.Director] Foreign Key (M_Dir)
		References dbo.Director(D_ID)
			On DELETE CASCADE
			On UPDATE CASCADE
);

CREATE TABLE dbo.Casts(
	C_ID INT IDENTITY(1,1) NOT NULL,
	C_ActorID INT Foreign Key References dbo.Actor(A_ID)NOT NULL,
	C_MovieID INT Foreign Key References dbo.Movie(M_ID) NOT NULL,
	
	Constraint [PK_dbo.Casts] PRIMARY KEY CLUSTERED (C_ID ASC),
	Constraint [FK_dbo.Casts.ActorID] Foreign Key (C_ActorID)
		references dbo.Actor(A_ID)
			On DELETE CASCADE
			on UPDATE CASCADE,

	Constraint [FK_dbo.Casts.MovieID] Foreign Key (C_MovieID)
		references dbo.Movie(M_ID)
			On DELETE CASCADE
			on UPDATE CASCADE,
);

INSERT INTO dbo.Actor (A_Name) Values
	('Daisy Ridley'),
	('Andy Serkis'),
	('Benicio Del Toro'),
	('Penelope Cruz');

INSERT INTO dbo.Director(D_Name) VALUES
	('Rian Johnson'),
	('Kenneth Branagh'),
	('Rob Marshall'),
	('James Marsh');

INSERT INTO dbo.Movie(M_Name,M_Year,M_Dir) Values
	('Star Wars: The Last Jedi','2017','1'),
	('Murder On The Orient Express','2017','2'),
	('Pirate of the Caribbean: On Stranger Tides','2011','3'),
	('The Theory Of Everything','2014','4');

INSERT INTO dbo.Casts(C_ActorID, C_MovieID) Values 
	('1', '1'),
	('2', '1'),
	('3', '1'),
	('1', '2'),
	('4', '2'),
	('4', '3');