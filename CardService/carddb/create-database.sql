CREATE DATABASE apidb;
GO
USE apidb
GO
CREATE TABLE Cards (
	Id bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	CardNumber bigint ,
	ExpirationDate VARCHAR(1000) ,
	CardCCV int
);
GO