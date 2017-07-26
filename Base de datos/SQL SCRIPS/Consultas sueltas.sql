--Consultas sueltas:
----------------------------------------------------------------------------------------------
--Genera una tabla donde muestra todas los macronutrientes consumidos en las fechas de una perfil especifico.
SELECT IdPerfil_RXF, IdFecha_RXF, Calorias_Ing,Proteinas_Ing,Carbohidratos_Ing,Grasas_Ing   FROM Ingredientes
INNER JOIN RecetaXIngrediente ON IdIngrediente_RXI = IdIngrediente_Ing
INNER JOIN Recetas ON IdReceta_Rec = IdReceta_RXI
INNER JOIN RecetaXFecha ON IdReceta_RXF = IdReceta_Rec
WHERE IdPerfil_RXF = 1 AND IdFecha_RXF = '2017-07-18'
----------------------------------------------------------------------------------------------
--Busqueda de ingredientes por receta
SELECT Nombre_Ing , Cantidad_RXI FROM Recetas
INNER JOIN RecetaXIngrediente ON IdReceta_RXI = IdReceta_Rec
INNER JOIN Ingredientes	ON IdIngrediente_Ing = IdIngrediente_RXI
----------------------------------------------------------------------------------------------
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
----------------------------------------------------------------------------------------------
--Consulta la ultima fecha de una perfil especifico.
SELECT  Fecha_PH , Peso_PH, IdPesoH_PH, IdPerfil_PH FROM PesosHistoricos
WHERE IdPerfil_PH = 1 
ORDER BY Fecha_PH DESC
----------------------------------------------------------------------------------------------
--TRIGGER:
CREATE TRIGGER UPDATE_INGREDIENTE ON Ingredientes
AFTER UPDATE 
AS 
BEGIN 
	SET NOCOUNT ON;
	BEGIN 
		UPDATE IngredientexComercio
		SET Costo_IXC =(SELECT CAST ((Cantidad_Ing * Costo_IXC) AS INT) FROM Ingredientes
								INNER JOIN IngredientexComercio ON IdIngrediente_IXC = IdIngrediente_Ing) 
	END
END
GO
----------------------------------------------------------------------------------------------