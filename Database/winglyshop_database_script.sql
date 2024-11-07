----------------------------------
--      Creating Database       --
----------------------------------

CREATE DATABASE WinglyShop;
GO

USE WinglyShop;
GO

CREATE TABLE Roles(
    id INT PRIMARY KEY IDENTITY,
    access INT,
    isActive BIT
);
GO

CREATE TABLE [User](
    id INT PRIMARY KEY IDENTITY,
    login VARCHAR(255) UNIQUE,
    email VARCHAR(255),
    password VARCHAR(255),
    name VARCHAR(255),
    surname VARCHAR(255),
    image VARCHAR(1000),
    phone VARCHAR(255),
    isActive BIT,
    idRole INT,
    CONSTRAINT FK_Users_Roles FOREIGN KEY (idRole) REFERENCES Roles (id)
);
GO

CREATE TABLE Address(
    id INT PRIMARY KEY IDENTITY,
    city VARCHAR(255),
    state VARCHAR(255),
    country VARCHAR(255),
    postalCode VARCHAR(255),
    isActive BIT,
    idUser INT,
    CONSTRAINT FK_Addresses_Users FOREIGN KEY (idUser) REFERENCES [User] (id) ON DELETE CASCADE
);
GO

CREATE TABLE Category(
    id INT PRIMARY KEY IDENTITY,
    code VARCHAR(255),
    description VARCHAR(255),
    isActive BIT
);
GO

CREATE TABLE Product(
    id INT PRIMARY KEY IDENTITY,
    code VARCHAR(255),
    description VARCHAR(255),
    price DECIMAL(10, 2),
    imageUrl VARCHAR(255),
    hasStock BIT,
    isActive BIT,
    idCategory INT,
    CONSTRAINT FK_Products_Categories FOREIGN KEY (idCategory) REFERENCES Category (id)
);
GO

CREATE TABLE [Order](
    id INT PRIMARY KEY IDENTITY,
    status INT,
    orderDate DATETIME,
    paymentMethod INT,
    totalValue DECIMAL(10, 2),
    idUser INT,
    CONSTRAINT FK_Orders_Users FOREIGN KEY (idUser) REFERENCES [User] (id)
);
GO

CREATE TABLE OrderDetail(
    id INT PRIMARY KEY IDENTITY,
    quantity INT,
    price DECIMAL(10, 2),
    idOrder INT,
    idProduct INT,
    idAddress INT,
    CONSTRAINT FK_OrderDetails_Orders FOREIGN KEY (idOrder) REFERENCES [Order](id) ON DELETE CASCADE,
    CONSTRAINT FK_OrderDetails_Products FOREIGN KEY (idProduct) REFERENCES Product(id),
    CONSTRAINT FK_OrderDetails_Addresses FOREIGN KEY (idAddress) REFERENCES Address(id)
);
GO

CREATE TABLE Cart(
    id INT PRIMARY KEY IDENTITY,
    totalValue DECIMAL(10, 2),
    isActive BIT,
    idUser INT,
    CONSTRAINT FK_Carts_Users FOREIGN KEY (idUser) REFERENCES [User] (id) ON DELETE CASCADE
);
GO

CREATE TABLE CartDetail(
    id INT PRIMARY KEY IDENTITY,
    quantity INT,
    price DECIMAL(10, 2),
    idCart INT,
    idProduct INT,
    CONSTRAINT FK_CartDetails_Carts FOREIGN KEY (idCart) REFERENCES Cart (id) ON DELETE CASCADE,
    CONSTRAINT FK_CartDetails_Products FOREIGN KEY (idProduct) REFERENCES Product (id)
);
GO

--------------------------------------
--      Drop Database Script        --
--------------------------------------

-- USE master;
-- ALTER DATABASE [WinglyShop] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
-- DROP DATABASE [WinglyShop];