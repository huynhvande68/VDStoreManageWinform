-- Create database
CREATE DATABASE PiStoreDB;
GO

USE PiStoreDB;
GO

-- Create Employee table
CREATE TABLE Employee (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE,
    Phone NVARCHAR(20),
    Address NVARCHAR(255),
    Salary DECIMAL(10, 2),
    HireDate DATETIME DEFAULT GETDATE()
);
GO

-- Create Client table
CREATE TABLE Client (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    Address NVARCHAR(255)
);
GO

-- Create Product table
CREATE TABLE Product (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(10, 2) NOT NULL,
    Quantity INT NOT NULL DEFAULT 0
);
GO

-- Create Order table
CREATE TABLE [Order] (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ClientID INT FOREIGN KEY REFERENCES Client(ID),
    EmployeeID INT FOREIGN KEY REFERENCES Employee(ID),
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalPrice DECIMAL(10, 2) NOT NULL DEFAULT 0
);
GO

-- Create OrderItem table
CREATE TABLE OrderItem (
    ID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES [Order](ID),
    ProductID INT FOREIGN KEY REFERENCES Product(ID),
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL
);
GO

-- Create Bill table
CREATE TABLE Bill (
    ID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES [Order](ID),
    ClientID INT FOREIGN KEY REFERENCES Client(ID),
    EmployeeID INT FOREIGN KEY REFERENCES Employee(ID),
    BillDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10, 2) NOT NULL,
    IsPaid BIT NOT NULL DEFAULT 0
);
GO

-- Create User table for authentication
CREATE TABLE [User] (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) NOT NULL,
    EmployeeID INT FOREIGN KEY REFERENCES Employee(ID)
);
GO

-- Insert admin user
INSERT INTO Employee (Name, Email, Phone, Address, Salary, HireDate)
VALUES ('Admin', 'admin@pistore.com', '123-456-7890', 'Pi Store Address', 5000.00, GETDATE());
GO

INSERT INTO [User] (Username, Password, Role, EmployeeID)
VALUES ('admin', 'admin123', 'Admin', 1);
GO

-- Create stored procedures

-- Procedure to place an order
CREATE PROCEDURE sp_PlaceOrder
    @ClientID INT,
    @EmployeeID INT,
    @OrderDate DATETIME,
    @OrderID INT OUTPUT
AS
BEGIN
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Insert the order
        INSERT INTO [Order] (ClientID, EmployeeID, OrderDate, TotalPrice)
        VALUES (@ClientID, @EmployeeID, @OrderDate, 0);
        
        -- Get the order ID
        SET @OrderID = SCOPE_IDENTITY();
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Procedure to add an item to an order
CREATE PROCEDURE sp_AddOrderItem
    @OrderID INT,
    @ProductID INT,
    @Quantity INT
AS
BEGIN
    BEGIN TRANSACTION;
    
    BEGIN TRY
        DECLARE @UnitPrice DECIMAL(10, 2);
        DECLARE @CurrentQuantity INT;
        
        -- Get the product price and current quantity
        SELECT @UnitPrice = Price, @CurrentQuantity = Quantity
        FROM Product
        WHERE ID = @ProductID;
        
        -- Check if there's enough quantity
        IF @CurrentQuantity < @Quantity
        BEGIN
            THROW 50001, 'Not enough products in stock', 1;
        END;
        
        -- Add the order item
        INSERT INTO OrderItem (OrderID, ProductID, Quantity, UnitPrice)
        VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice);
        
        -- Update the product quantity
        UPDATE Product
        SET Quantity = Quantity - @Quantity
        WHERE ID = @ProductID;
        
        -- Update the order total price
        UPDATE [Order]
        SET TotalPrice = TotalPrice + (@UnitPrice * @Quantity)
        WHERE ID = @OrderID;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Procedure to generate a bill
CREATE PROCEDURE sp_GenerateBill
    @OrderID INT,
    @BillID INT OUTPUT
AS
BEGIN
    BEGIN TRANSACTION;
    
    BEGIN TRY
        DECLARE @ClientID INT;
        DECLARE @EmployeeID INT;
        DECLARE @TotalAmount DECIMAL(10, 2);
        
        -- Get order details
        SELECT @ClientID = ClientID, @EmployeeID = EmployeeID, @TotalAmount = TotalPrice
        FROM [Order]
        WHERE ID = @OrderID;
        
        -- Insert the bill
        INSERT INTO Bill (OrderID, ClientID, EmployeeID, BillDate, TotalAmount, IsPaid)
        VALUES (@OrderID, @ClientID, @EmployeeID, GETDATE(), @TotalAmount, 0);
        
        -- Get the bill ID
        SET @BillID = SCOPE_IDENTITY();
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Procedure to mark bill as paid
CREATE PROCEDURE sp_MarkBillAsPaid
    @BillID INT
AS
BEGIN
    UPDATE Bill
    SET IsPaid = 1
    WHERE ID = @BillID;
END;
GO 