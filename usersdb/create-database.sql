CREATE DATABASE usersdb;
USE usersdb;
CREATE TABLE "Users" (
	"Id" bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	"Name" VARCHAR(1000),
	"PhoneNumber" VARCHAR(1000),
	"Email" VARCHAR(1000),
	"Address" VARCHAR(1000),
	"CardID" int
);