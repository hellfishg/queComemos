--Consultas SQL queComemos:


--Busca los dias lunes y domingo con el nombre 'super'
SELECT Nombre,Dias FROM Comercios
WHERE Dias LIKE '%m%i%' AND Nombre LIKE '%super%'
------------------------------------------------------
--Procedimiento
CREATE procedure INV_CLI
@cli char(4)
AS
SELECT sum(Total_f)
from Facturas
where Cuit_f = @cli
GO
exec INV_CLI 'xxxx'
------------------------------------------------------
SELECT   Nombre_Ing, Nombre_C FROM Ingredientes
INNER JOIN IngredienteXComercio 
ON Ingredientes.IdIngrediente_Ing = IngredienteXComercio.IdIngrediente_IXC
INNER JOIN Comercios
on IngredienteXComercio.IdComercio_IXC = Comercios.IdComercio_C
WHERE IdComercio_C = 1
------------------------------------------------------
CREATE procedure PROC_COM_1
@Id_Com char (2)
AS
SELECT Nombre_Ing, Precio_IXC FROM Ingredientes
INNER JOIN IngredienteXComercio 
ON Ingredientes.IdIngrediente_Ing = IngredienteXComercio.IdIngrediente_IXC
INNER JOIN Comercios
on IngredienteXComercio.IdComercio_IXC = Comercios.IdComercio_C
WHERE IdComercio_C = @Id_Com
GO
------------------------------------------------------
SELECT max(IdComercio_C) FROM Comercios
------------------------------------------------------
--Busqueda de ingredientes por receta
SELECT Nombre_Ing , Cantidad_RXI FROM Recetas
INNER JOIN RecetaXIngrediente ON IdReceta_RXI = IdReceta_Rec
INNER JOIN Ingredientes	ON IdIngrediente_Ing = IdIngrediente_RXI

------------------------------------------------------
CREATE procedure PROC_REC_3
@MacroNutriente NCHAR (max) , @IdReceta_Rec char (2)
AS
SELECT sum( cast(@MacroNutriente as int)) FROM Recetas
INNER JOIN RecetaXIngrediente ON IdReceta_RXI = IdReceta_Rec
INNER JOIN Ingredientes	ON IdIngrediente_Ing = IdIngrediente_RXI
WHERE IdReceta_Rec = @IdReceta_Rec
GO
------------------------------------------------------
--Seleccion auna receta y muestra las calorias por ingrediente en receta. IMPORTANTE MODIFICAR RECETAS CON ESTO.
SELECT Nombre_Ing, Cantidad_RXI,Cantidad_Ing,Calorias_Ing,
 CAST((Calorias_Ing/Cantidad_Ing ) *Cantidad_RXI as INT) AS CaloriasXreceta FROM Ingredientes
INNER JOIN RecetaXIngrediente ON IdIngrediente_RXI = IdIngrediente_Ing
INNER JOIN Recetas ON IdReceta_Rec = IdReceta_RXI
WHERE Nombre_Rec LIKE '%Ensalada%'
------------------------------------------------------
--Consulta Naty sobre calorias:
SELECT IdReceta_Rec,
	SUM(
		CAST(((Calorias_Ing/Cantidad_Ing ) *Cantidad_RXI) / Porciones_Rec as INT) 
		)	AS CaloriasXreceta 
FROM Ingredientes
INNER JOIN RecetaXIngrediente ON IdIngrediente_RXI = IdIngrediente_Ing
INNER JOIN Recetas ON IdReceta_Rec = IdReceta_RXI
WHERE Nombre_Rec LIKE '%Ensalada%'
GROUP BY IdReceta_Rec
------------------------------------------------------
--Consulta hasta calorias.
SELECT * FROM 
	(
		SELECT 
			R1.Nombre_Rec, 
			R1.Tiempo_Aprox_Rec,
			SUM(
				CAST(((Calorias_Ing/Cantidad_Ing ) *Cantidad_RXI) / R1.Porciones_Rec as INT) 
				)
			AS CaloriasXreceta 
		FROM Ingredientes
			INNER JOIN RecetaXIngrediente ON IdIngrediente_RXI = IdIngrediente_Ing
			INNER JOIN Recetas R1 ON R1.IdReceta_Rec = IdReceta_RXI
		GROUP BY R1.IdReceta_Rec, R1.Nombre_Rec, R1.Tiempo_Aprox_Rec
	) 
	AS Total
WHERE CaloriasXreceta < 800
-------------------------------------------------------