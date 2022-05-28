CREATE TABLE Users
(
	Id Int NOT NULL IDENTITY(1, 1),
	UserName nvarchar(16) NOT NULL,
	UserEmail nvarchar(27) NOT NULL,
	UserPassword nvarchar(20) NOT NULL,
	CarId int,
	OrderId int,
	Wallet int,
	AvatarURL nvarchar(300),
	PRIMARY KEY (Id)
)
GO

CREATE TABLE Cars
(
	Id Int NOT NULL IDENTITY(1,1),
	Model nvarchar(20) NOT NULL,
	Price Int NOT NULL,
	PRIMARY KEY (Id)
)
GO

CREATE TABLE Orders
(
	Id int NOT NULL IDENTITY(1,1),
	NameAd nvarchar(50) NOT NULL,
	DiscriptionAd nvarchar(200) NOT NULL,
	PriceAd int NOT NULL,
	NumberAd nvarchar(12) NOT NULL,
	CarId int NOT NULL,
	PRIMARY KEY (Id)
)
GO

ALTER TABLE Users

	ADD FOREIGN KEY (CarId)
	REFERENCES Cars.Id

ALTER TABLE Users
	ADD FOREIGN KEY (OrderId)
	REFERENCES Orders.Id

ALTER TABLE Orders
	ADD FOREIGN KEY (CarId)
	REFERENCES Cars.Id