// Create Database on SqlServer
CREATE DATABASE checkoutdb

// Create Table
USE checkoutdb
CREATE TABLE "Orders" (
	"Id" bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	"userId" bigint,
	"basketId" bigint
);