# PlantStore
## Introduction
This is an Plant Store application where the user can perform CRUD operation like Create, Read, Update and Delete Plants.
![PlantStore](https://github.com/Ayush1099/PlantStore/assets/30565720/b585997b-60dd-49d2-a3cf-9731a13f157c)

## Technologies Used
1. Framework: ASP.NET Core MVC
2. Database: MSSQL
3. Language: C#, JavaScript

## Features
1. It has a Cart feature using which the user can purchase the plants.
2. Here Session Storage is used to store the Cart Items.
3. The checkout button will give a success message upon successful purchase and reduce the quantity of the plants purchased in the DB.
![checkout](https://github.com/Ayush1099/PlantStore/assets/30565720/79ec6c7b-d06f-4dd9-8c1b-ca43a6501eb6)

The user can also create new plants
![image](https://github.com/Ayush1099/PlantStore/assets/30565720/ee06e0d5-8e8f-47d5-a57b-f7e0da144e5f)

## Setup Application & DB
1. Clone the Git Repository 'https://github.com/Ayush1099/PlantStore.git' in Visual Studio(VS).
2. Click on the "View" option on the top left of VS.
3. Select "SQL Server Object Explorer".
4. Right click on "(localdb)\MSSQLLocalDB" and select "New Query" and then run the following commands.

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
