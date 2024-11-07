----------------------------------------
--      Insert the First Category     --
----------------------------------------

SET IDENTITY_INSERT [Category] ON;

-- No Category --
INSERT INTO [Category] ([id], [code], [description], [isActive])
VALUES (1, 00001, 'Categoria Padrão', 0);

SET IDENTITY_INSERT [Category] OFF;

SELECT * FROM [Category]

---------------------------------------
--      Insert the First Product     --
---------------------------------------

SET IDENTITY_INSERT [Product] ON;

-- No Product --
INSERT INTO [Product] ([id], [code], [description], [price], [hasStock], [isActive], [idCategory])
VALUES (1, '00001', 'Produto Padrão', 0, 0, 0, 1);

SET IDENTITY_INSERT [Product] OFF;

SELECT * FROM [Product]