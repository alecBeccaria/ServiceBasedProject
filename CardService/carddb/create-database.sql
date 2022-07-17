CREATE DATABASE apidb;
USE apidb
CREATE TABLE "Cards" (
	"Id" bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	"CardNumber" bigint ,
	"ExpirationDate" VARCHAR(1000) ,
	"CardCCV" int
);