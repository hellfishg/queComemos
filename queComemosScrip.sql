CREATE DATA BASE queComemos
on ( NAME='queComemos_dat',FILENAME='C:\ALGO')
GO
-----------------------------------------------------
USE queComemos
GO
-----------------------------------------------------
CREATE TABLE Recetas (

IdReceta_Rec INT IDENTITY(1,1) NOT NULL,
IdTipo_Rec INT NOT NULL,
Nombre VARCHAR (50) NOT NULL,
Descripcion VARCHAR (max) NULL,
URLImagen VARCHAR (50) NULL DEFAULT 'NONE',
Tiempo_Aprox INT NOT NULL,
Porcion INT NOT NULL,
CONSTRAINT PK_REC PRIMARY KEY (IdReceta_Rec)
)
GO
-----------------------------------------------------
CREATE TABLE Ingredientes (

IdIngrediente_Ing INT IDENTITY(1,1) NOT NULL,
IdTipo_Ing INT NOT NULL,
Nombre VARCHAR(50) NOT NULL,
Calorias INT NULL,
Proteinas INT NULL,
Carbohidratos INT NULL,
Grasas INT NULL,
Unidad_De_Medida VARCHAR CHECK ( Unidad_De_Medida IN('Gramo','Unidad','Litro')) NOT NULL,
CONSTRAINT PK_ING PRIMARY KEY (IdIngrediente_Ing)
)
GO
-----------------------------------------------------
CREATE TABLE RecetaXIngrediente (

IdReceta_RXI INT NOT NULL,
IdIngrediente_RXI INT NOT NULL,
Cantidad INT NOT NULL,
CONSTRAINT PK_RXI PRIMARY KEY (IdReceta_RXI,IdIngrediente_RXI)
)
GO
-----------------------------------------------------
CREATE TABLE Tipos (

IdTipo_Tip INT IDENTITY(1,1) NOT NULL,
Nombre VARCHAR (50) NOT NULL,
CONSTRAINT PK_TIP PRIMARY KEY (IdTipo_Tip)
)
GO
-----------------------------------------------------
CREATE TABLE Perfiles (

IdPerfil_P INT IDENTITY(1,1) NOT NULL,
Nombre VARCHAR (50) NOT NULL,
UrlAvatar VARCHAR (50) NULL,
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
CREATE TABLE PesoHistorico (

IdPesoH_PH INT IDENTITY(1,1) NOT NULL,
IdPerfil_PH INT NOT NULL,
Fecha DATE NOT NULL,
Peso INT NOT NULL,
CONSTRAINT PK_PEHI PRIMARY KEY (IdPesoH_PH)
)
GO
-----------------------------------------------------------------------------------------
CREATE TABLE Comercios (

IdComercio_C INT IDENTITY(1,1) NOT NULL,
Nombre VARCHAR (50) NOT NULL,
Direccion VARCHAR (50) NULL,
Horario VARCHAR (20) NULL,
Telefono VARCHAR (20) NULL,
CONSTRAINT PK_COM PRIMARY KEY (IdComercio_C)
)
GO
-----------------------------------------------------------------------------------------
CREATE TABLE IngredienteXComercio (

IdComercio_IXC INT NOT NULL,
IdIngrediente_IXC INT NOT NULL,
Costo INT NOT NULL,
CONSTRAINT PK_IXC PRIMARY KEY (IdComercio_IXC,IdIngrediente_IXC)
)
GO
-----------------------------------------------------------------------------------------
--CLAVES FORANEAS:

ALTER TABLE Recetas
ADD CONSTRAINT FK_REC FOREIGN KEY (IdTipo_Rec) REFERENCES Tipos (IdTipo_Tip)
-----------------------------------------------------------------------------------------
ALTER TABLE Ingredientes
ADD CONSTRAINT FK_ING FOREIGN KEY (IdTipo_Ing) REFERENCES Tipos (IdTipo_Tip)
-----------------------------------------------------------------------------------------
ALTER TABLE RecetaXIngrediente
ADD CONSTRAINT FK_RXI1 FOREIGN KEY (IdReceta_RXI) REFERENCES Recetas (IdReceta_Rec)
ADD CONSTRAINT FK_RXI2 FOREIGN KEY (IdIngrediente_RXI) REFERENCES Ingredientes (IdIngrediente_Ing)
-----------------------------------------------------------------------------------------
ALTER TABLE IngredienteXComercio
ADD CONSTRAINT FK_IXC1 FOREIGN KEY (IdComercio_IXC) REFERENCES Comercios (IdComercio_C)
ADD CONSTRAINT FK_IXC2 FOREIGN KEY (IdIngrediente_IXC) REFERENCES Ingredientes (IdIngrediente_Ing)
-----------------------------------------------------------------------------------------
ALTER TABLE RecetaXFecha
ADD CONSTRAINT FK_RXF1 FOREIGN KEY (IdReceta_RXF) REFERENCES Recetas (IdReceta_Rec)
ADD CONSTRAINT FK_RXF2 FOREIGN KEY (IdPerfil_RXF) REFERENCES Perfiles (IdPerfil_P)
-----------------------------------------------------------------------------------------
