CREATE DATABASE Inventario

USE Inventario


CREATE TABLE InventarioProductos(
ID			INT,
Clave		VARCHAR(50),
Nombre		VARCHAR(50),
Precio		DECIMAL(10,2),
Cantidad	INT,
CONSTRAINT PK_InventarioProductos PRIMARY KEY(ID)
)

Select * from InventarioProductos


