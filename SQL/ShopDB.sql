use ShopDB
return
create database ShopDB
----------------------------------------

CREATE TABLE Users (
    Id INT IDENTITY PRIMARY KEY,
    userName VARCHAR(50) NOT NULL,
    userPassword NVARCHAR(50) NOT NULL,
    userDescription NVARCHAR(100)
);
----------------------------------------

CREATE PROCEDURE sp_ValidateUser		-- for login user and validate user
    @userName VARCHAR(50),
    @userPassword NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, userName, userPassword, userDescription
    FROM Users
    WHERE userName = @userName AND userPassword = @userPassword;
END;
----------------------------------------

CREATE TABLE Products (
    Id INT IDENTITY PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL
);
----------------------------------------
CREATE PROCEDURE sp_GetAllProducts			-- for get all products form table	
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, ProductName, Price FROM Products;
END;
----------------------------------------------
CREATE PROCEDURE sp_GetProductById		-- product get by id any specific product
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, ProductName, Price
    FROM Products
    WHERE Id = @Id;
END;
----------------------------------------
CREATE PROCEDURE sp_AddProduct				-- add new product in table
    @ProductName VARCHAR(100),
    @Price DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Products (ProductName, Price)
    VALUES (@ProductName, @Price);
END;

----------------------------------------
CREATE PROCEDURE sp_UpdateProduct			-- for update product details 
    @Id INT,
    @ProductName VARCHAR(100),
    @Price DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Products
    SET ProductName = @ProductName,
        Price = @Price
    WHERE Id = @Id;
END;


----------------------------------------
CREATE PROCEDURE sp_DeleteProduct				-- delete any product
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Products
    WHERE Id = @Id;
END;


----------------------------------------


----------------------------------------

----------------------------------------



