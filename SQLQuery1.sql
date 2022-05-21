CREATE TABLE Users
(
	Id Int NOT NULL IDENTITY(1, 1),
	UserName nvarchar(16) NOT NULL,
	UserEmail nvarchar(27) NOT NULL,
	UserPassword nvarchar(20) NOT NULL,
	CarId int,
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

ALTER TABLE Users

	ADD FOREIGN KEY (CarId)
	REFERENCES Cars.Id