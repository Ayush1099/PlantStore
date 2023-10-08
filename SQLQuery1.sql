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