CREATE DATABASE queComemos
on ( NAME='queComemos_dat',FILENAME='C:\HellDocs\queComemos\Base de datos\queComemos.dbo')
GO
-----------------------------------------------------
USE queComemos
GO
-----------------------------------------------------
CREATE TABLE Recetas (

IdReceta_Rec INT IDENTITY(1,1) NOT NULL,
IdTipo1_Rec INT NOT NULL,
IdTipo2_Rec INT NOT NULL,
Nombre_Rec VARCHAR (50) NOT NULL,
Descripcion_Rec VARCHAR (max) NULL,
URLImagen_Rec VARCHAR (max) NULL DEFAULT 'NONE',
Tiempo_Aprox_Rec INT NOT NULL,
CONSTRAINT PK_REC PRIMARY KEY (IdReceta_Rec)
)
GO
-----------------------------------------------------
CREATE TABLE Ingredientes (

IdIngrediente_Ing INT IDENTITY(1,1) NOT NULL,
IdTipo1_Ing INT NOT NULL,
IdTipo2_Ing INT NOT NULL,
Nombre_Ing VARCHAR(50) NOT NULL,
Cantidad_Ing INT NOT NULL,
Unidad_De_Medida_Ing VARCHAR(10) CHECK ( Unidad_De_Medida_Ing IN('Gramos','Unidades','Litros')) NOT NULL,
Calorias_Ing DECIMAL (10,2) NULL,
Proteinas_Ing DECIMAL (10,2) NULL,
Carbohidratos_Ing DECIMAL (10,2) NULL,
Grasas_Ing DECIMAL (10,2) NULL,
CONSTRAINT PK_ING PRIMARY KEY (IdIngrediente_Ing)
)
GO
-----------------------------------------------------
CREATE TABLE RecetaXIngrediente (

IdReceta_RXI INT NOT NULL,
IdIngrediente_RXI INT NOT NULL,
Cantidad_RXI INT NOT NULL,
CONSTRAINT PK_RXI PRIMARY KEY (IdReceta_RXI,IdIngrediente_RXI)
)
GO
-----------------------------------------------------
CREATE TABLE Tipos (

IdTipo_Tip INT IDENTITY(1,1) NOT NULL,
Nombre_Tip VARCHAR (50) NOT NULL,
CONSTRAINT PK_TIP PRIMARY KEY (IdTipo_Tip)
)
GO
-----------------------------------------------------
CREATE TABLE Perfiles (

IdPerfil_P INT IDENTITY(1,1) NOT NULL,
Nombre_P VARCHAR (50) NOT NULL,
UrlAvatar_P VARCHAR (max) NULL,
CONSTRAINT PK_PER PRIMARY KEY (IdPerfil_P)
)
GO
------------------------------------------------------
CREATE TABLE RecetaXFecha (

IdFecha_RXF DATE NOT NULL,
IdReceta_RXF INT NOT NULL,
IdPerfil_RXF INT NOT NULL,
CONSTRAINT PK_RXF PRIMARY KEY (IdFecha_RXF,IdReceta_RXF,IdPerfil_RXF)
)
GO
-----------------------------------------------------------------------------------------
CREATE TABLE PesosHistoricos (

IdPesoH_PH INT IDENTITY(1,1) NOT NULL,
IdPerfil_PH INT NOT NULL,
Fecha_PH DATE NOT NULL,
Peso_PH INT NOT NULL,
CONSTRAINT PK_PEHI PRIMARY KEY (IdPesoH_PH)
)
GO
-----------------------------------------------------------------------------------------
CREATE TABLE Comercios (

IdComercio_C INT IDENTITY(1,1) NOT NULL,
Nombre_C VARCHAR (50) NOT NULL,
Direccion_C VARCHAR (50) NULL,
Horario_C VARCHAR (max) NULL,
Telefono_C VARCHAR (20) NULL,
Dias_C NCHAR (7) NULL DEFAULT 'lmijvsd',
CONSTRAINT PK_COM PRIMARY KEY (IdComercio_C)
)
GO
-----------------------------------------------------------------------------------------
CREATE TABLE IngredienteXComercio (

IdComercio_IXC INT NOT NULL,
IdIngrediente_IXC INT NOT NULL,
Costo_IXC INT NOT NULL,
CONSTRAINT PK_IXC PRIMARY KEY (IdComercio_IXC,IdIngrediente_IXC)
)
GO
-----------------------------------------------------------------------------------------
--CLAVES FORANEAS:

ALTER TABLE Recetas
ADD CONSTRAINT FK_REC1 FOREIGN KEY (IdTipo1_Rec) REFERENCES Tipos (IdTipo_Tip)
GO
ALTER TABLE Recetas
ADD CONSTRAINT FK_REC2 FOREIGN KEY (IdTipo2_Rec) REFERENCES Tipos (IdTipo_Tip)
GO
-----------------------------------------------------------------------------------------
ALTER TABLE Ingredientes
ADD CONSTRAINT FK_ING1 FOREIGN KEY (IdTipo1_Ing) REFERENCES Tipos (IdTipo_Tip)
GO
ALTER TABLE Ingredientes
ADD CONSTRAINT FK_ING2 FOREIGN KEY (IdTipo2_Ing) REFERENCES Tipos (IdTipo_Tip)
GO
-----------------------------------------------------------------------------------------
ALTER TABLE RecetaXIngrediente
ADD CONSTRAINT FK_RXI1 FOREIGN KEY (IdReceta_RXI) REFERENCES Recetas (IdReceta_Rec)
GO
ALTER TABLE RecetaXIngrediente
ADD CONSTRAINT FK_RXI2 FOREIGN KEY (IdIngrediente_RXI) REFERENCES Ingredientes (IdIngrediente_Ing)
GO
-----------------------------------------------------------------------------------------
ALTER TABLE IngredienteXComercio
ADD CONSTRAINT FK_IXC1 FOREIGN KEY (IdComercio_IXC) REFERENCES Comercios (IdComercio_C)
GO
ALTER TABLE IngredienteXComercio
ADD CONSTRAINT FK_IXC2 FOREIGN KEY (IdIngrediente_IXC) REFERENCES Ingredientes (IdIngrediente_Ing)
GO
-----------------------------------------------------------------------------------------
ALTER TABLE RecetaXFecha
ADD CONSTRAINT FK_RXF1 FOREIGN KEY (IdReceta_RXF) REFERENCES Recetas (IdReceta_Rec)
GO
ALTER TABLE RecetaXFecha
ADD CONSTRAINT FK_RXF2 FOREIGN KEY (IdPerfil_RXF) REFERENCES Perfiles (IdPerfil_P)
GO
-----------------------------------------------------------------------------------------
ALTER TABLE PesosHistoricos
ADD CONSTRAINT FK_PH FOREIGN KEY (IdPerfil_PH) REFERENCES Perfiles (IdPerfil_P)
GO
-----------------------------------------------------------------------------------------
INSERT INTO Tipos (Nombre_Tip)
SELECT '' UNION
SELECT 'Celiaco' UNION
SELECT 'Omnivoro' UNION
SELECT 'Vegano' UNION
SELECT 'Vegetariano'
GO
-----------------------------------------------------------------------------------------
--CARGA DE DATOS--

----Perfiles
INSERT INTO Perfiles (Nombre_P,UrlAvatar_P)
SELECT 'Hellfishg','C:\HellDocs\queComemos\Imagenes Raw\nurgle.jpg' UNION
SELECT 'Mina', 'C:\HellDocs\queComemos\Imagenes Raw\nurgle.jpg' 
GO
-----------------------------------------------------------------------------------------
--Ingredientes
INSERT INTO Ingredientes (IdTipo1_Ing, IdTipo2_Ing, Nombre_Ing, Cantidad_Ing, Calorias_Ing ,Proteinas_Ing ,
Carbohidratos_Ing ,Grasas_Ing, Unidad_De_Medida_Ing)
SELECT 4 , 2 ,'Tomate', 100 , 22.17 , 0.88 , 3.50 , 0.21 , 'Gramos' UNION
SELECT 4 , 2 ,'Cebolla',100 , 31.85 , 1.19 , 5.30 , 0.25 , 'Gramos' UNION
SELECT 4 , 2 , 'Ajo' , 1 , 3.57 , 0.13 , 0.73 , 0.0 , 'Unidades' UNION
SELECT 4 , 2 , 'Papa' , 1 , 147.18 , 4.68 , 29.60 , 0.22 , 'Unidades' UNION
SELECT 3 , 2 , 'Pollo', 1,2,3,4,5, 'Unidades' UNION
SELECT 4 , 2 , 'Calabaza', 1,2,3,4,5, 'Unidades' UNION
SELECT 4 , 2 , 'Berenjena', 1,2,3,4,5, 'Unidades' UNION
SELECT 5 , 2 , 'Queso', 1,2,3,4,5, 'Gramos' UNION
SELECT 5 , 2 , 'Leche', 1,2,3,4,5, 'Litros' UNION
SELECT 4 , 2 , 'Arroz', 1,2,3,4,5, 'Gramos' UNION
SELECT 3 , 1 , 'Galletitas', 1,2,3,4,5, 'Gramos'
GO
-----------------------------------------------------------------------------------------
--Comercios
INSERT INTO Comercios (Nombre_C, Direccion_C, Horario_C, Telefono_C, Dias_C)
SELECT 'Super Nuevo Estilo' ,'San Lorenzo 12343', '09:00 a 14:00', '4-713-3456', 'lmijvs0' UNION
SELECT 'Super Coto' ,'Balbin 3900', '09:00 a 21:00', '4-713-7456', 'lmijvsd' UNION
SELECT 'Pizzeria Simoqueña' ,'Matheu 3600', '18:00 a 23:30', '4-713-7856', '0mijvsd' UNION
SELECT 'Dietetica Tomillo' , 'Malaver 4567' , '15:00 a 19:00' , '4-713-9812' , 'lmijv'
GO
-----------------------------------------------------------------------------------------
--IngredientesxComercios
INSERT INTO IngredientexComercio (IdComercio_IXC, IdIngrediente_IXC, Costo_IXC)
SELECT 1, 1, 5 UNION
SELECT 1, 2, 10 UNION
SELECT 1, 3, 20 UNION
SELECT 2, 3, 330 UNION
SELECT 2, 4, 12 UNION
SELECT 2, 5, 1 UNION
SELECT 3, 5, 32 UNION
SELECT 3, 7, 56 UNION
SELECT 1, 6, 89 UNION 
SELECT 4, 4, 32 UNION
SELECT 4, 7, 56 UNION
SELECT 4, 6, 89 
GO
-----------------------------------------------------------------------------------------
--Procedimientos:
CREATE procedure PROC_COM_1
@Id_Com char (2)
AS
SELECT Nombre_Ing, Costo_IXC FROM Ingredientes
INNER JOIN IngredienteXComercio 
ON Ingredientes.IdIngrediente_Ing = IngredienteXComercio.IdIngrediente_IXC
INNER JOIN Comercios
on IngredienteXComercio.IdComercio_IXC = Comercios.IdComercio_C
WHERE IdComercio_C = @Id_Com
GO
-----------------------------------------------------------------------------------------
CREATE procedure PROC_COM_2
@Nombre_C VARCHAR (20)
AS
SELECT IdComercio_C FROM Comercios
WHERE Nombre_C LIKE @Nombre_C
GO
-----------------------------------------------------------------------------------------

