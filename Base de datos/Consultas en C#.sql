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

------------------------------------------------------

------------------------------------------------------


