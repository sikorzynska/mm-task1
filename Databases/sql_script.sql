CREATE DATABASE MentorMateRestaurant;
GO

USE MentorMateRestaurant;

CREATE TABLE [Role] (
  Id int NOT NULL IDENTITY (1, 1),
  [Name] nvarchar(100) NOT NULL,
  IsDeleted bit NOT NULL,
  PRIMARY KEY (Id),
);

CREATE TABLE [User] (
  Id int NOT NULL IDENTITY(1, 1),
  FirstName nvarchar(100) NOT NULL,
  LastName nvarchar(100) NOT NULL,
  Email nvarchar(255) NOT NULL,
  [Role] int NOT NULL,
  Created datetime,
  Updated datetime,
  CreatedBy int,
  UpdatedBy int,
  IsDeleted bit NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (Role) REFERENCES [Role](Id)
);

CREATE TABLE [Table] (
  Id int NOT NULL IDENTITY(1, 1),
  Number int,
  Capacity int NOT NULL,
  Created datetime,
  Updated datetime,
  CreatedBy int,
  UpdatedBy int,
  IsDeleted bit NOT NULL,
  PRIMARY KEY (Id),
);

CREATE TABLE Category (
  Id int NOT NULL IDENTITY(1, 1),
  [Name] nvarchar(100) NOT NULL,
  Parent int,
  Created datetime,
  Updated datetime,
  CreatedBy int,
  UpdatedBy int,
  IsDeleted bit NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (Parent) REFERENCES Category(Id)
);

CREATE TABLE Product (
  Id int NOT NULL IDENTITY(1, 1),
  [Name] nvarchar(100) NOT NULL,
  [Description] nvarchar(255),
  ImagePath nvarchar(255),
  Price decimal(18, 2) NOT NULL,
  Category int NOT NULL,
  Created datetime,
  Updated datetime,
  CreatedBy int,
  UpdatedBy int,
  IsDeleted bit NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (Category) REFERENCES Category(Id),
);

CREATE TABLE [Order] (
  Id int NOT NULL IDENTITY(1, 1),
  [Status] nvarchar(20) NOT NULL CHECK ([Status] IN('Active', 'Complete')) DEFAULT 'Active',
  Waiter int NOT NULL,
  [Table] int NOT NULL,
  Created datetime,
  Updated datetime,
  CreatedBy int,
  UpdatedBy int,
  IsDeleted bit NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (Waiter) REFERENCES [User](Id),
  FOREIGN KEY ([Table]) REFERENCES [Table](Id),
);

CREATE TABLE [OrderProduct] (
  Id int NOT NULL IDENTITY(1, 1),
  [Order] int NOT NULL,
  Product int NOT NULL,
  Price decimal(18, 2) NOT NULL,
  Quantity int NOT NULL,
  PRIMARY KEY(Id),
  FOREIGN KEY ([Order]) REFERENCES [Order](Id),
  FOREIGN KEY (Product) REFERENCES Product(Id),
);

-- insert roles

INSERT INTO [Role] ([Name], IsDeleted)
VALUES ('Administrator', 0);

INSERT INTO [Role] ([Name], IsDeleted)
VALUES ('Bartender', 0);

INSERT INTO [Role] ([Name], IsDeleted)
VALUES ('Waiter', 0);

-- insert users

-- administrator
INSERT INTO [User] (FirstName, LastName, Email, [Role], Created, IsDeleted)
VALUES ('John', 'Doe', 'johndoe@gmail.com', 1, GETDATE(), 0);

-- bartender
INSERT INTO [User] (FirstName, LastName, Email, [Role], Created, CreatedBy, IsDeleted)
VALUES ('Jane', 'Doe', 'janedoe@gmail.com', 2, GETDATE(), 1, 0);

-- waiter
INSERT INTO [User] (FirstName, LastName, Email, [Role], Created, CreatedBy, IsDeleted)
VALUES ('Billy', 'Bob', 'billybob@gmail.com', 3, GETDATE(), 1, 0);

-- insert tables

INSERT INTO [Table] (Number, Capacity, Created, CreatedBy, IsDeleted)
VALUES (10, 2, GETDATE(), 1, 0);

INSERT INTO [Table] (Number, Capacity, Created, CreatedBy, IsDeleted)
VALUES (11, 4, GETDATE(), 2, 0);

INSERT INTO [Table] (Number, Capacity, Created, CreatedBy, IsDeleted)
VALUES (12, 6, GETDATE(), 2, 0);

INSERT INTO [Table] (Number, Capacity, Created, CreatedBy, IsDeleted)
VALUES (13, 8, GETDATE(), 1, 0);

INSERT INTO [Table] (Number, Capacity, Created, CreatedBy, IsDeleted)
VALUES (14, 10, GETDATE(), 3, 0);


-- insert categories

-- top cat food
SET IDENTITY_INSERT Category ON;

INSERT INTO Category (Id, [Name], Created, CreatedBy, IsDeleted)
VALUES (1, 'Food', GETDATE(), 1, 0);

-- top cat beverage
INSERT INTO Category (Id, [Name], Created, CreatedBy, IsDeleted)
VALUES (2, 'Beverage', GETDATE(), 1, 0);

-- food child - meat
INSERT INTO Category (Id, [Name], Parent, Created, CreatedBy, IsDeleted)
VALUES (3, 'Meat', 1, GETDATE(), 1, 0);

-- food child - vegetable
INSERT INTO Category (Id, [Name], Parent, Created, CreatedBy, IsDeleted)
VALUES (4, 'Vegetable', 1, GETDATE(), 1, 0);

-- beverage child - alcohol
INSERT INTO Category (Id, [Name], Parent, Created, CreatedBy, IsDeleted)
VALUES (5, 'Alcohol', 2, GETDATE(), 1, 0);

-- beverage child - soft drink
INSERT INTO Category (Id, [Name], Parent, Created, CreatedBy, IsDeleted)
VALUES (6, 'Soft Drink', 2, GETDATE(), 1, 0);

-- meat child - veal
INSERT INTO Category (Id, [Name], Parent, Created, CreatedBy, IsDeleted)
VALUES (7, 'Veal', 3, GETDATE(), 1, 0);
-- meat child - pork
INSERT INTO Category (Id, [Name], Parent, Created, CreatedBy, IsDeleted)
VALUES (8, 'Pork', 3, GETDATE(), 1, 0);
-- meat child - chicken
INSERT INTO Category (Id, [Name], Parent, Created, CreatedBy, IsDeleted)
VALUES (9, 'Chicken', 3, GETDATE(), 1, 0);

-- vegetable child - carrot
INSERT INTO Category (Id, [Name], Parent, Created, CreatedBy, IsDeleted)
VALUES (10, 'Carrot', 4, GETDATE(), 1, 0);
-- vegetable child - cucumber
INSERT INTO Category (Id, [Name], Parent, Created, CreatedBy, IsDeleted)
VALUES (11, 'Cucumber', 4, GETDATE(), 1, 0);
-- vegetable child - spinach
INSERT INTO Category (Id, [Name], Parent, Created, CreatedBy, IsDeleted)
VALUES (12, 'Spinach', 4, GETDATE(), 1, 0);

-- alcohol child - whiskey
INSERT INTO Category (Id, [Name], Parent, Created, CreatedBy, IsDeleted)
VALUES (13, 'Whiskey', 5, GETDATE(), 1, 0);

-- soft drink child - lemonade
INSERT INTO Category (Id, [Name], Parent, Created, CreatedBy, IsDeleted)
VALUES (14, 'Lemonade', 6, GETDATE(), 1, 0);

SET IDENTITY_INSERT Category OFF;


-- insert products

-- meat
INSERT INTO Product ([Name], [Description], ImagePath, Price, Category, Created, CreatedBy, IsDeleted)
VALUES ('Veal Burger', 'Its a burger made out of veal', 'https://www.mygourmetconnection.com/wp-content/uploads/grilled-veal-burgers.jpg', 9.99, 7, GETDATE(), 2, 0);

INSERT INTO Product ([Name], [Description], Price, Category, Created, CreatedBy, IsDeleted)
VALUES ('Pork Burger', 'Its a burger made out of pork', 9.99, 8, GETDATE(), 2, 0);

INSERT INTO Product ([Name], [Description], Price, Category, Created, CreatedBy, IsDeleted)
VALUES ('Chicken Burger', 'Its a burger made out of chicken', 9.99, 9, GETDATE(), 2, 0);

-- vegetable
INSERT INTO Product ([Name], [Description], Price, Category, Created, CreatedBy, IsDeleted)
VALUES ('Carrot Soup', 'Its soup with carrots', 5.99, 10, GETDATE(), 2, 0);

INSERT INTO Product ([Name], [Description], Price, Category, Created, CreatedBy, IsDeleted)
VALUES ('Cucumber soup', 'Its soup with cucumber', 5.99, 11, GETDATE(), 2, 0);

INSERT INTO Product ([Name], [Description], Price, Category, Created, CreatedBy, IsDeleted)
VALUES ('Spinach soup', 'Its soup with spinach', 5.99, 12, GETDATE(), 2, 0);

-- alcohol
INSERT INTO Product ([Name], [Description], Price, Category, Created, CreatedBy, IsDeleted)
VALUES ('Jack Daniels', 'Its your best friend Jack', 2.99, 13, GETDATE(), 2, 0);

-- soft drink
INSERT INTO Product ([Name], [Description], Price, Category, Created, CreatedBy, IsDeleted)
VALUES ('Lipton Lemonade', 'Cold lemonade', 1.99, 14, GETDATE(), 2, 0);


-- insert orders

-- order number 1
INSERT INTO [Order] (Waiter, [Table], Created, CreatedBy, IsDeleted)
VALUES (3, 1, GETDATE(), 2, 0);

-- insert order-products for order 1
INSERT INTO OrderProduct ([Order], Product, Price, Quantity)
VALUES (1, 3, 8.99, 2)

INSERT INTO OrderProduct ([Order], Product, Price, Quantity)
VALUES (1, 5, 5, 7)

INSERT INTO OrderProduct ([Order], Product, Price, Quantity)
VALUES (1, 7, 5, 4)

-- order number 2
INSERT INTO [Order] ([Status], Waiter, [Table], Created, CreatedBy, IsDeleted)
VALUES ('Complete', 3, 2, GETDATE(), 2, 0);

-- insert order-products for order 2
INSERT INTO OrderProduct ([Order], Product, Price, Quantity)
VALUES (2, 5, 4.99, 6)

-- order number 3
INSERT INTO [Order] ([Status], Waiter, [Table], Created, CreatedBy, IsDeleted)
VALUES ('Complete', 3, 3, GETDATE(), 2, 0);

-- insert order-products for order 3
INSERT INTO OrderProduct ([Order], Product, Price, Quantity)
VALUES (3, 1, 10.99, 2)

-- order number 4
INSERT INTO [Order] ([Status], Waiter, [Table], Created, CreatedBy, IsDeleted)
VALUES ('Complete', 3, 4, GETDATE(), 2, 0);

-- insert order-products for order 4
INSERT INTO OrderProduct ([Order], Product, Price, Quantity)
VALUES (4, 2, 5.99, 10)

-- Products list - select all active products
SELECT * 
FROM Product
WHERE IsDeleted = 0 
ORDER BY Id

-- List of busy/occupied tables
SELECT *
FROM [Table] t
JOIN [Order] o ON  o.[Table] = t.Id
WHERE o.[Status] = 'Active' AND o.IsDeleted = 0 AND t.IsDeleted = 0
ORDER BY t.Id

-- List of free tables
SELECT *
FROM [Table] t
JOIN [Order] o ON  o.[Table] = t.Id
WHERE o.[Status] != 'Active' AND o.IsDeleted = 0 AND t.IsDeleted = 0
ORDER BY o.Id

-- List orders in progress
SELECT *
FROM [Order] o
WHERE o.[Status] != 'Complete' AND o.IsDeleted = 0
ORDER BY o.Id

-- List completed orders
SELECT * 
FROM [Order] o
WHERE o.[Status] = 'Complete' AND o.IsDeleted = 0 
ORDER BY Id

-- Search by part of product name - select all matching products
SELECT *
FROM Product p
WHERE p.[Name] LIKE '%burger'
ORDER BY p.Id

-- Select order details by order number - result should contain total price, waiter, date and time
USE MentorMateRestaurant
GO

DROP PROCEDURE IF EXISTS [dbo].[GetOrderById]
GO

CREATE PROCEDURE [dbo].[GetOrderById]  @orderId int AS
BEGIN
    SELECT op.Price * op.Quantity AS TotalPrice,
	       u.FirstName + ' ' + u.LastName AS Waiter,
	       o.Created AS [Date]
    FROM [Order] o
    JOIN OrderProduct op ON o.Id = op.[Order]
	JOIN [User] u ON o.Waiter = u.Id
    WHERE @orderId = o.Id
END
GO

EXEC [dbo].[GetOrderById] @orderId = 2


-- List of order products by order number - result should contain name, code, price
USE MentorMateRestaurant
GO

DROP PROCEDURE IF EXISTS [dbo].[GetProductsByOrderId]
GO

CREATE PROCEDURE [dbo].[GetProductsByOrderId]  @orderId int AS
BEGIN
    SELECT p.[Name] AS [Name],
	       op.Price AS Price
    FROM Product p
    JOIN OrderProduct op ON p.Id = op.Product
    WHERE @orderId = op.[Order]
END
GO

EXEC [dbo].[GetProductsByOrderId] @orderId = 2


-- List orders per period (start date and time, end date time) - result should contain order total and date
USE MentorMateRestaurant
GO

DROP PROCEDURE IF EXISTS dbo.GetOrdersInTimePeriod
GO

CREATE PROCEDURE dbo.GetOrdersInTimePeriod  @startDate DATETIME, @endDate DATETIME AS
BEGIN
    SELECT o.Created AS [Date],
	       op.Price * op.Quantity AS TotalPrice
    FROM [Order] o
    JOIN OrderProduct op ON o.Id = op.[Order]
    WHERE o.Created >= @startDate AND o.Created <= @endDate
END
GO

EXEC dbo.GetOrdersInTimePeriod @startDate = '1989-12-23', @endDate = '2022-03-16'


-- List sold products for a given month - result should show aggregated quantity and aggregated price for all sales during the search period. Every matching product should exist once into the result.
USE MentorMateRestaurant
GO

DROP PROCEDURE IF EXISTS dbo.GetSoldProductsForGivenMonth
GO

CREATE PROCEDURE dbo.GetSoldProductsForGivenMonth  @date DATETIME AS
BEGIN
    SELECT p.[Name],
	       AVG(op.Quantity) AS Quantity,
	       AVG(op.Price) AS Price
    FROM Product p
    JOIN OrderProduct op ON p.Id = op.Product
	JOIN [Order] o ON op.Id = op.[Order]
    WHERE MONTH(o.Created) = MONTH(@date)
	GROUP BY p.[Name]
END
GO

EXEC dbo.GetSoldProductsForGivenMonth @date = '2022-03-16'


-- drop database
USE [MASTER]

-- Close All Existing connections to Drop database in SQL Server
ALTER DATABASE MentorMateRestaurant SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

DROP DATABASE MentorMateRestaurant;