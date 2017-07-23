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
Porciones_Rec INT NOT NULL,
Costo_Rec INT NOT NULL,
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
Unidad_De_Medida_Ing VARCHAR(11) CHECK ( Unidad_De_Medida_Ing IN('Gramos','Unidades','Mililitros')) NOT NULL,
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
Cantidad_RXI DECIMAL (10,2) NOT NULL,
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
SELECT 'Hellfishg','C:\HellDocs\queComemos\QueComemos\QueComemos\imagenes\hellfish.jpg' UNION
SELECT 'Mina', 'C:\HellDocs\queComemos\QueComemos\QueComemos\imagenes\hada.jpg' 
GO
-----------------------------------------------------------------------------------------
--Ingredientes
INSERT INTO Ingredientes (IdTipo1_Ing, IdTipo2_Ing, Nombre_Ing, Cantidad_Ing, Calorias_Ing ,Proteinas_Ing ,
Carbohidratos_Ing ,Grasas_Ing, Unidad_De_Medida_Ing)
SELECT 4 , 2 ,'Tomate', 1 , 22.17 , 0.88 , 3.50 , 0.21 , 'Unidades' UNION
SELECT 4 , 2 ,'Cebolla', 1 , 31.85 , 1.19 , 5.30 , 0.25 , 'Unidades' UNION
SELECT 4 , 2 , 'Ajo' , 1 , 3.57 , 0.13 , 0.73 , 0.0 , 'Unidades' UNION
SELECT 4 , 2 , 'Papa' , 1 , 147.18 , 4.68 , 29.60 , 0.22 , 'Unidades' UNION
SELECT 4 , 2 , 'Calabaza' , 1 , 260 , 10 , 65 , 1 , 'Unidades' UNION
SELECT 5 , 2 , 'Queso rallado' , 100 , 367 , 31 , 0 , 27 , 'Gramos' UNION
SELECT 4 , 1 , 'Fideos de semola' , 100 , 372 , 12 , 74 , 1.8 , 'Gramos' UNION
SELECT 3 , 1 , 'Calditos Knorr' , 1 , 26 , 0 , 1.6 , 2 , 'Unidades' UNION
SELECT 5 , 2 , 'Huevos' , 1 , 78 , 6 , 0.2 , 5.9 , 'Unidades' UNION
SELECT 3 , 2 , 'Jamon' , 100 , 107 , 16.85 , 0.7 , 4 , 'Gramos' UNION
SELECT 5 , 2 , 'Queso Cremoso' , 100 , 305 , 18.7 , 1.3 , 25 , 'Gramos' UNION
SELECT 4 , 1 , 'Tapa de tarta' , 1 , 1274 , 26 , 105 , 42.9 , 'Unidades' UNION
SELECT 3 , 2 , 'Pollo' , 1 , 2490 , 298.5 , 0 , 144 , 'Unidades' UNION
SELECT 4 , 2 , 'Aceite' , 15 , 125.86 , 0.14 , 0 , 13.99 , 'Mililitros' UNION
SELECT 4 , 2 , 'Sal' , 0.5 , 0 , 0 , 0 , 0 , 'Gramos' UNION
SELECT 4 , 2 , 'Lechuga' , 1 , 19.6 , 1.37 , 1.40 , 0.60 , 'Unidades' UNION
SELECT 4 , 1 , 'Salsa de soja' , 15 , 9.86 , 1.31 , 1.01 , 0.02 , 'Mililitros' UNION
SELECT 4 , 2 , 'Jugo de limon' , 15 , 21 , 0.4, 6.5 , 0.3 , 'Mililitros'
GO
-----------------------------------------------------------------------------------------
--Recetas:
INSERT INTO Recetas (IdTipo1_Rec, IdTipo2_Rec, Nombre_Rec, Descripcion_Rec,
 URLImagen_Rec, Tiempo_Aprox_Rec, Porciones_Rec, Costo_Rec )
SELECT 3 , 1 , 'Ensalada de pollo' , 'Cortar algo..' , 'C:\HellDocs\queComemos\QueComemos\QueComemos\imagenes\EnsaPollo.jpg' , 30 , 3 , 70 UNION
SELECT 3 , 2 , 'Pollo con papas al horno', 'Meter el pollo al horno..' , 'C:\HellDocs\queComemos\QueComemos\QueComemos\imagenes\PolloAlHorno.jpg' , 60 , 4 , 60 UNION
SELECT 3 , 1 , 'Sopa de calabaza' , 'Hervir la calabaza...' , 'C:\HellDocs\queComemos\QueComemos\QueComemos\imagenes\sopaCalabaza.jpg' , 40 , 3 , 40 UNION
SELECT 3 , 1 , 'Tarta de jamon y queso' , 'Colocar la pascualina...', 'C:\HellDocs\queComemos\QueComemos\QueComemos\imagenes\TartaJQ.jpg' , 30 , 2 , 90
GO
-----------------------------------------------------------------------------------------
--IngredientexReceta:
/*
1	Calditos Knorr
2	Jamon
3	Pollo
4	Fideos de semola
5	Salsa de soja
6	Tapa de tarta
7	Aceite
8	Ajo
9	Calabaza
10	Cebolla
11	Jugo de limon
12	Lechuga
13	Papa
14	Sal
15	Tomate
16	Huevos
17	Queso Cremoso
18	Queso rallado
*/

INSERT INTO RecetaXIngrediente (IdReceta_RXI, IdIngrediente_RXI, Cantidad_RXI)
--Ensalada de pollo:
SELECT 1 , 3 , 0.25 UNION
SELECT 1 , 12 , 1 UNION
SELECT 1 , 15 , 3 UNION
SELECT 1 , 18 , 20 UNION
SELECT 1 , 16 , 3 UNION
SELECT 1 , 5 , 10 UNION
SELECT 1 , 11 , 10 UNION
--Sopa de calabaza:
SELECT 2 , 9 , 1 UNION
SELECT 2 , 18 , 100 UNION
SELECT 2 , 4 , 50 UNION
SELECT 2 , 1 , 2 UNION
SELECT 2 , 16 , 3 UNION
--Tarta de jamon y queso:
SELECT 3 , 2 , 150 UNION
SELECT 3 , 17 , 200 UNION
SELECT 3 , 16 , 3 UNION
SELECT 3 , 6 , 1 UNION
--Pollo con papas al horno:
SELECT 4 , 13 ,  4 UNION
SELECT 4 , 3 , 1 UNION
SELECT 4 , 7 , 20 UNION
SELECT 4 , 14 , 1 
------------------------
GO
/*
Recetas:
	Sopa de calabaza 40,3
		1 calabaza
		100 g queso rallado
		50 g fideos municiones
		2 calditos knor
		3 huevos

	Tarta de jamón y queso 30,2
		150 g de jamón
		200 g de queso cremoso
		3 huevos
		1 tapa de tarta

	Pollo con papas al horno 60,4
		4 papas
		1 pollo
		20 mL aceite
		Sal

	Ensalada de pollo 30,3
		1/4 pollo
		1 lechuga
		3 tomates
		20 g queso rallado
		3 huevos
		10 mL salsa de soja
		10 mL jugo de limón

*/
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
--PesosHistoricos
INSERT INTO PesosHistoricos (IdPerfil_PH, Fecha_PH , Peso_PH)
SELECT 1, '16-07-2017', 75 UNION
SELECT 1, '17-07-2017', 70 UNION
SELECT 1, '18-07-2017', 72 UNION
SELECT 1, '19-07-2017', 75 UNION
SELECT 1, '20-07-2017', 80 UNION
SELECT 2, '16-07-2017', 40 UNION
SELECT 2, '17-07-2017', 50 UNION
SELECT 2, '18-07-2017', 65 
GO
-----------------------------------------------------------------------------------------
--Procedimientos:
CREATE procedure PROC_COM_1
@Id_Com char (4)
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
@Nombre_C VARCHAR (50)
AS
SELECT IdComercio_C FROM Comercios
WHERE Nombre_C LIKE @Nombre_C
GO
-----------------------------------------------------------------------------------------
CREATE procedure PROC_REC_1
@IdReceta_Rec char (4)
AS
SELECT Nombre_Ing , Cantidad_RXI FROM Recetas
INNER JOIN RecetaXIngrediente ON IdReceta_RXI = IdReceta_Rec
INNER JOIN Ingredientes	ON IdIngrediente_Ing = IdIngrediente_RXI
WHERE IdReceta_Rec = @IdReceta_Rec
GO
-----------------------------------------------------------------------------------------
--Busca la cantidad de porciones segun el ID_RECETA
CREATE procedure PROC_REC_2
@IdReceta_Rec char (4)
AS
SELECT Porciones_Rec FROM Recetas
WHERE IdReceta_Rec = @IdReceta_Rec
GO
-----------------------------------------------------------------------------------------
-- RECETAS.setConsulta(string recetaNombre)
CREATE procedure PROC_REC_3
@Nombre_Rec VARCHAR (50)
AS
SELECT IdReceta_Rec FROM Recetas
WHERE Nombre_Rec LIKE @Nombre_Rec
GO
-----------------------------------------------------------------------------------------
--Regresa una tabla con todos los macronutrientes :
CREATE procedure PROC_MACRO
AS
SELECT IdReceta_Rec,
	SUM(
		CAST((( nullif(Calorias_Ing,0) /Cantidad_Ing ) *Cantidad_RXI) / Porciones_Rec as INT) 
		)	AS CaloriasXreceta ,
 	SUM(
		CAST((( nullif(Carbohidratos_Ing,0)/Cantidad_Ing ) *Cantidad_RXI) / Porciones_Rec as INT) 
		)	AS CarbohidratosXreceta ,
 	SUM(
		CAST((( nullif(Proteinas_Ing,0)/Cantidad_Ing ) *Cantidad_RXI) / Porciones_Rec as INT) 
		)	AS ProteinasXreceta ,
 	SUM(
		CAST((( nullif(Grasas_Ing,0)/Cantidad_Ing ) *Cantidad_RXI) / Porciones_Rec as INT) 
		)	AS GrasasXreceta
		
FROM Ingredientes
INNER JOIN RecetaXIngrediente ON IdIngrediente_RXI = IdIngrediente_Ing
INNER JOIN Recetas ON IdReceta_Rec = IdReceta_RXI
GROUP BY IdReceta_Rec
GO
-----------------------------------------------------------------------------------------
--Consulta hasta cuantas calorias en todas las recetas:
CREATE procedure PROC_BUSC_CALORIAS
@Num int
AS
SELECT * FROM 
	(
		SELECT 
			Nombre_Rec, 
			Tiempo_Aprox_Rec,
			SUM(
				CAST((( nullif(Calorias_Ing,0) /Cantidad_Ing ) *Cantidad_RXI) / Porciones_Rec as INT) 
				)
			AS CaloriasXreceta 
		FROM Ingredientes
			INNER JOIN RecetaXIngrediente ON IdIngrediente_RXI = IdIngrediente_Ing
			INNER JOIN Recetas ON IdReceta_Rec = IdReceta_RXI
		GROUP BY IdReceta_Rec, Nombre_Rec, Tiempo_Aprox_Rec
	) 
	AS Total
WHERE CaloriasXreceta < @Num
GO
-----------------------------------------------------------------------------------------
--Busqueda de receta por fecha de un perfil especifico:
CREATE procedure PROC_FECHA_PERF
@Fecha VARCHAR (11) , @Nombre_P VARCHAR (50)
AS
SELECT Nombre_Rec  FROM Perfiles
INNER JOIN RecetaXFecha ON IdPerfil_RXF = IdPerfil_P
INNER JOIN Recetas ON IdReceta_Rec = IdReceta_RXF
WHERE IdFecha_RXF = @Fecha AND Nombre_P LIKE @Nombre_P
GO
------------------------------------------------------------------------------------------
--Consulta de las recetas de una fecha, de un perfil y toda la suma de sus macronutrientes.
CREATE procedure PROC_FECHA_REC
@IdPerfil_P INT, @Fecha DATE
AS
SELECT 
	Nombre_Rec AS Receta,
	SUM(
	CAST(((Calorias_Ing /Cantidad_Ing ) * Cantidad_RXI) / Porciones_Rec AS decimal(16,0)) 
		)	AS Calorias ,
	SUM(
	CAST(((Proteinas_Ing /Cantidad_Ing ) * Cantidad_RXI) / Porciones_Rec AS decimal(16,0)) 
		)	AS Proteinas ,
	SUM(
	CAST(((Carbohidratos_Ing /Cantidad_Ing ) * Cantidad_RXI) / Porciones_Rec AS decimal(16,0)) 
		)	AS Carbohidratos ,
	SUM(
	CAST(((Grasas_Ing /Cantidad_Ing ) * Cantidad_RXI) / Porciones_Rec AS decimal(16,0)) 
		)	AS Grasas 
	
FROM Ingredientes
	INNER JOIN RecetaXIngrediente ON IdIngrediente_RXI = IdIngrediente_Ing
	INNER JOIN Recetas ON IdReceta_Rec = IdReceta_RXI
	INNER JOIN RecetaXFecha ON IdReceta_RXF = IdReceta_Rec
WHERE IdPerfil_RXF = @IdPerfil_P AND IdFecha_RXF = @Fecha
GROUP BY  Nombre_Rec
GO
---------------------------------------------------------------------------------------------
--Busca la ultima fecha donde se cargo un peso de un perfil determinado por ID.
CREATE procedure PROC_PESO_FECHA
@IdPerfil_P int
AS
SELECT  Fecha_PH , Peso_PH, IdPesoH_PH, IdPerfil_PH FROM PesosHistoricos
WHERE IdPerfil_PH = @IdPerfil_P
ORDER BY Fecha_PH DESC
GO
----------------------------------------------------------------------------------------------