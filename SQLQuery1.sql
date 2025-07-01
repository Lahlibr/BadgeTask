CREATE DATABASE ProductDB
	USE ProductDB

CREATE TABLE Products (
   Id INT PRIMARY KEY IDENTITY,
   PName VARCHAR(100) UNIQUE,
   Price DECIMAL(10,2));

CREATE PROCEDURE InsertProducts
   @PName NVARCHAR(100),
   @Price DECIMAL(10,2)
AS
BEGIN 
   INSERT INTO Products(PName,Price)
   VALUES(@PName,@Price)
END

 CREATE PROCEDURE GetAllProducts
 AS 
 BEGIN
      SELECT * FROM Products
 END

 CREATE PROCEDURE GetPrById
 @Id INT
 AS
 BEGIN
    SELECT * FROM Products WHERE Id = @Id
 END
 
 CREATE PROCEDURE UPDATEProduct
 @Id INT,
 @PName NVARCHAR(100),
 @Price DECIMAL(10,2)
 AS 
 BEGIN
   UPDATE Products
   SET PName=@PName,
       Price=@Price
   WHERE Id = @Id
END

CREATE PROCEDURE DeleteProduct
    @Id INT
AS
BEGIN
    DELETE FROM Products WHERE Id = @Id
END
		  DROP TABLE Products;