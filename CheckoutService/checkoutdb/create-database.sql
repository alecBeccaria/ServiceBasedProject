CREATE DATABASE apidb;
GO
USE apidb;
GO
CREATE TABLE Checkouts (
	Id bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	userID int,
	basketID int,
);
GO