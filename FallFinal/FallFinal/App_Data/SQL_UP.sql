-- swql upscript for the Fall 2017 CS 460 Final Database

CREATE TABLE dbo.Seller(
	S_ID INT IDENTITY(1,1) NOT NULL,
	Seller_Name NVARCHAR(64) NOT NULL,
	
	CONSTRAINT [PK_dbo.Seller] PRIMARY KEY CLUSTERED (S_ID ASC),
);

Create Table dbo.Items(

	I_ID	INT IDENTITY(1,1) NOT NULL,
	I_Name NVARCHAR(64) NOT NULL,
	I_Description NVARCHAR(160),
	Seller_ID INT FOREIGN KEY REFERENCES dbo.Seller(S_ID),

	CONSTRAINT [PK_dbo.Items] Primary Key Clustered (I_ID ASC),
	CONSTRAINT [FK_dbo.Items.Seller] Foreign Key (Seller_ID)
		References dbo.Seller(S_ID)
			On DELETE CASCADE
			On UPDATE CASCADE
);



CREATE TABLE dbo.Buyer(
	B_ID INT IDENTITY(1,1) NOT NULL,
	Buyer_Name NVARCHAR(64) NOT NULL,

	Constraint [PK_dbo.Buyer] PRIMARY KEY CLUSTERED (B_ID ASC)
);

CREATE TABLE dbo.Bid(
	Bid_ID INT IDENTITY(1,1) NOT NULL,
	Price INT NOT NULL,
	Buyer_ID INT Foreign Key References dbo.Buyer(B_ID) NOT NULL,
	Item_ID INT Foreign Key References dbo.Items(I_ID) NOT NULL,
	Bid_Time DateTime NOT NULL,

	Constraint [PK_dbo.Bid] PRIMARY KEY CLUSTERED (Bid_ID ASC),
	Constraint [FK_dbo.Bid.BuyerID] Foreign Key (Buyer_ID)
		references dbo.Buyer(B_ID)
			On DELETE CASCADE
			on UPDATE CASCADE,

	Constraint [FK_dbo.Bid.ItemID] Foreign Key (Item_ID)
		references dbo.ITEMS(I_ID)
			On DELETE CASCADE
			on UPDATE CASCADE,
);

INSERT INTO dbo.Buyer (Buyer_Name) Values
	('Jane Stone'),
	('Tom McMasters'),
	('Otto Vanderwall');

INSERT INTO dbo.Seller (Seller_Name) VALUES
	('Gayle Hardy'),
	('Lyle Banks'),
	('Pearl Greene');

INSERT INTO dbo.Items (I_Name, I_Description, Seller_ID) Values
	('Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln','3'),
	('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927','1'),
	('Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan','2');

INSERT INTO dbo.Bid (Item_ID, Buyer_ID, Price, Bid_Time) Values 
	('1', '3', '250000','12/04/2017 08:44:03' ),
	('3', '1', '95000', '12/04/2017 08:44:03');