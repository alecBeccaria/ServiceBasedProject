CREATE DATABASE catalogdb
GO
USE catalogdb
GO
CREATE TABLE "Items" (
	"Id" bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	"Title" VARCHAR(1000),
	"Description" VARCHAR(1000),
	"Price" DECIMAL(10,2),
	"Quantity" bigint
);
GO