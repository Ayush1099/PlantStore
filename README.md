# PlantStore
## Introduction
This is an Plant Store application where the user can perform CRUD operation like Create, Read, Update and Delete Plants.
![PlantStore](https://github.com/Ayush1099/PlantStore/assets/30565720/b585997b-60dd-49d2-a3cf-9731a13f157c)

## Technologies Used
Framework: ASP.NET Core MVC
Database: MSSQL
Language: C#, JavaScript

## Features
It has a Cart feature using which the user can purchase the plants. The checkout button will give a success message upon successful purchase and reduce the quantity of the plants purchased in the DB

## Setup Application & DB
Clone the Git Repository 'https://github.com/Ayush1099/PlantStore.git' in Visual Studio(VS)
Click on the "View" option on the top left of VS
Select "SQL Server Object Explorer"
Right click on "(localdb)\MSSQLLocalDB" and select "New Query" and then run the following commands

CREATE DATABASE PlantNurseryDB
GO
USE PlantNurseryDB
GO
CREATE TABLE Plants
(
	[PlantId] CHAR(4) CONSTRAINT pk_ProductId PRIMARY KEY,
	[PlantName] VARCHAR(50) CONSTRAINT uq_ProductName UNIQUE NOT NULL,
	[Price] NUMERIC(8) CONSTRAINT chk_Price CHECK(Price>0) NOT NULL,
	[QuantityAvailable] INT CONSTRAINT chk_QuantityAvailable CHECK (QuantityAvailable>=0) NOT NULL
)
GO

INSERT INTO Plants(PlantId,PlantName,Price,QuantityAvailable) VALUES('P101','Blossom',10,5)
INSERT INTO Plants(PlantId,PlantName,Price,QuantityAvailable) VALUES('P102','Cherry',10,5)
INSERT INTO Plants(PlantId,PlantName,Price,QuantityAvailable) VALUES('P103','Rose',10,5)

select * from Plants
