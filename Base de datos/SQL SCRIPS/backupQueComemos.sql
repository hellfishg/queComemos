USE [master]
GO
/****** Object:  Database [queComemos]    Script Date: 07/25/2017 18:27:29 ******/
CREATE DATABASE [queComemos] ON  PRIMARY 
( NAME = N'queComemos_dat', FILENAME = N'C:\HellDocs\queComemos\Base de datos\queComemos.dbo' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'queComemos_log', FILENAME = N'C:\HellDocs\queComemos\Base de datos\queComemos_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [queComemos] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [queComemos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [queComemos] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [queComemos] SET ANSI_NULLS OFF
GO
ALTER DATABASE [queComemos] SET ANSI_PADDING OFF
GO
ALTER DATABASE [queComemos] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [queComemos] SET ARITHABORT OFF
GO
ALTER DATABASE [queComemos] SET AUTO_CLOSE ON
GO
ALTER DATABASE [queComemos] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [queComemos] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [queComemos] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [queComemos] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [queComemos] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [queComemos] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [queComemos] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [queComemos] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [queComemos] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [queComemos] SET  ENABLE_BROKER
GO
ALTER DATABASE [queComemos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [queComemos] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [queComemos] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [queComemos] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [queComemos] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [queComemos] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [queComemos] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [queComemos] SET  READ_WRITE
GO
ALTER DATABASE [queComemos] SET RECOVERY SIMPLE
GO
ALTER DATABASE [queComemos] SET  MULTI_USER
GO
ALTER DATABASE [queComemos] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [queComemos] SET DB_CHAINING OFF
GO
USE [queComemos]
GO
/****** Object:  Table [dbo].[Tipos]    Script Date: 07/25/2017 18:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipos](
	[IdTipo_Tip] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Tip] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TIP] PRIMARY KEY CLUSTERED 
(
	[IdTipo_Tip] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comercios]    Script Date: 07/25/2017 18:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comercios](
	[IdComercio_C] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_C] [varchar](50) NOT NULL,
	[Direccion_C] [varchar](50) NULL,
	[Horario_C] [varchar](max) NULL,
	[Telefono_C] [varchar](20) NULL,
	[Dias_C] [nchar](7) NULL,
 CONSTRAINT [PK_COM] PRIMARY KEY CLUSTERED 
(
	[IdComercio_C] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Perfiles]    Script Date: 07/25/2017 18:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfiles](
	[IdPerfil_P] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_P] [varchar](50) NOT NULL,
	[UrlAvatar_P] [varchar](max) NULL,
 CONSTRAINT [PK_PER] PRIMARY KEY CLUSTERED 
(
	[IdPerfil_P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recetas]    Script Date: 07/25/2017 18:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recetas](
	[IdReceta_Rec] [int] IDENTITY(1,1) NOT NULL,
	[IdTipo1_Rec] [int] NOT NULL,
	[IdTipo2_Rec] [int] NOT NULL,
	[Nombre_Rec] [varchar](50) NOT NULL,
	[Descripcion_Rec] [varchar](max) NULL,
	[URLImagen_Rec] [varchar](max) NULL,
	[Tiempo_Aprox_Rec] [int] NOT NULL,
	[Porciones_Rec] [int] NOT NULL,
	[Costo_Rec] [int] NOT NULL,
 CONSTRAINT [PK_REC] PRIMARY KEY CLUSTERED 
(
	[IdReceta_Rec] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PesosHistoricos]    Script Date: 07/25/2017 18:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PesosHistoricos](
	[IdPesoH_PH] [int] IDENTITY(1,1) NOT NULL,
	[IdPerfil_PH] [int] NOT NULL,
	[Fecha_PH] [date] NOT NULL,
	[Peso_PH] [int] NOT NULL,
 CONSTRAINT [PK_PEHI] PRIMARY KEY CLUSTERED 
(
	[IdPesoH_PH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[PROC_COM_2]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------------------------------------------------------
CREATE procedure [dbo].[PROC_COM_2]
@Nombre_C VARCHAR (50)
AS
SELECT IdComercio_C FROM Comercios
WHERE Nombre_C LIKE @Nombre_C
GO
/****** Object:  Table [dbo].[Ingredientes]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ingredientes](
	[IdIngrediente_Ing] [int] IDENTITY(1,1) NOT NULL,
	[IdTipo1_Ing] [int] NOT NULL,
	[IdTipo2_Ing] [int] NOT NULL,
	[Nombre_Ing] [varchar](50) NOT NULL,
	[Cantidad_Ing] [int] NOT NULL,
	[Unidad_De_Medida_Ing] [varchar](11) NOT NULL,
	[Calorias_Ing] [decimal](10, 2) NULL,
	[Proteinas_Ing] [decimal](10, 2) NULL,
	[Carbohidratos_Ing] [decimal](10, 2) NULL,
	[Grasas_Ing] [decimal](10, 2) NULL,
 CONSTRAINT [PK_ING] PRIMARY KEY CLUSTERED 
(
	[IdIngrediente_Ing] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RecetaXIngrediente]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecetaXIngrediente](
	[IdReceta_RXI] [int] NOT NULL,
	[IdIngrediente_RXI] [int] NOT NULL,
	[Cantidad_RXI] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_RXI] PRIMARY KEY CLUSTERED 
(
	[IdReceta_RXI] ASC,
	[IdIngrediente_RXI] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecetaXFecha]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecetaXFecha](
	[IdFecha_RXF] [date] NOT NULL,
	[IdReceta_RXF] [int] NOT NULL,
	[IdPerfil_RXF] [int] NOT NULL,
 CONSTRAINT [PK_RXF] PRIMARY KEY CLUSTERED 
(
	[IdFecha_RXF] ASC,
	[IdReceta_RXF] ASC,
	[IdPerfil_RXF] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngredienteXComercio]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredienteXComercio](
	[IdComercio_IXC] [int] NOT NULL,
	[IdIngrediente_IXC] [int] NOT NULL,
	[Costo_IXC] [int] NOT NULL,
 CONSTRAINT [PK_IXC] PRIMARY KEY CLUSTERED 
(
	[IdComercio_IXC] ASC,
	[IdIngrediente_IXC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[PROC_PESO_FECHA]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------------------------------------------------------
--Busca la ultima fecha donde se cargo un peso de un perfil determinado por ID.
CREATE procedure [dbo].[PROC_PESO_FECHA]
@IdPerfil_P int
AS
SELECT  Fecha_PH , Peso_PH, IdPesoH_PH, IdPerfil_PH FROM PesosHistoricos
WHERE IdPerfil_PH = @IdPerfil_P
ORDER BY Fecha_PH DESC
GO
/****** Object:  StoredProcedure [dbo].[PROC_REC_3]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------------------------------------------------------
-- RECETAS.setConsulta(string recetaNombre)
CREATE procedure [dbo].[PROC_REC_3]
@Nombre_Rec VARCHAR (50)
AS
SELECT IdReceta_Rec FROM Recetas
WHERE Nombre_Rec LIKE @Nombre_Rec
GO
/****** Object:  StoredProcedure [dbo].[PROC_REC_2]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------------------------------------------------------
--Busca la cantidad de porciones segun el ID_RECETA
CREATE procedure [dbo].[PROC_REC_2]
@IdReceta_Rec char (4)
AS
SELECT Porciones_Rec FROM Recetas
WHERE IdReceta_Rec = @IdReceta_Rec
GO
/****** Object:  StoredProcedure [dbo].[PROC_REC_1]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------------------------------------------------------
CREATE procedure [dbo].[PROC_REC_1]
@IdReceta_Rec char (4)
AS
SELECT Nombre_Ing , Cantidad_RXI FROM Recetas
INNER JOIN RecetaXIngrediente ON IdReceta_RXI = IdReceta_Rec
INNER JOIN Ingredientes	ON IdIngrediente_Ing = IdIngrediente_RXI
WHERE IdReceta_Rec = @IdReceta_Rec
GO
/****** Object:  StoredProcedure [dbo].[PROC_MACRO]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------------------------------------------------------
--Regresa una tabla con todos los macronutrientes :
CREATE procedure [dbo].[PROC_MACRO]
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
/****** Object:  StoredProcedure [dbo].[PROC_FECHA_REC]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------------------------------------------------
--Consulta de las recetas de una fecha, de un perfil y toda la suma de sus macronutrientes.
CREATE procedure [dbo].[PROC_FECHA_REC]
@IdPerfil_P INT, @Fecha DATE
AS
SELECT 
	Nombre_Rec AS Receta,
	SUM(
	CAST(((  nullif(Calorias_Ing,0) /Cantidad_Ing ) * Cantidad_RXI) / Porciones_Rec AS decimal(16,0)) 
		)	AS Calorias ,
	SUM(
	CAST(((  nullif(Proteinas_Ing,0) /Cantidad_Ing ) * Cantidad_RXI) / Porciones_Rec AS decimal(16,0)) 
		)	AS Proteinas ,
	SUM(
	CAST(((  nullif(Carbohidratos_Ing,0) /Cantidad_Ing ) * Cantidad_RXI) / Porciones_Rec AS decimal(16,0)) 
		)	AS Carbohidratos ,
	SUM(
	CAST(((  nullif(Grasas_Ing,0) /Cantidad_Ing ) * Cantidad_RXI) / Porciones_Rec AS decimal(16,0)) 
		)	AS Grasas 
	
FROM Ingredientes
	INNER JOIN RecetaXIngrediente ON IdIngrediente_RXI = IdIngrediente_Ing
	INNER JOIN Recetas ON IdReceta_Rec = IdReceta_RXI
	INNER JOIN RecetaXFecha ON IdReceta_RXF = IdReceta_Rec
WHERE IdPerfil_RXF = @IdPerfil_P AND IdFecha_RXF = @Fecha
GROUP BY  Nombre_Rec
GO
/****** Object:  StoredProcedure [dbo].[PROC_FECHA_PERF]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------------------------------------------------------
--Busqueda de receta por fecha de un perfil especifico:
CREATE procedure [dbo].[PROC_FECHA_PERF]
@Fecha VARCHAR (11) , @Nombre_P VARCHAR (50)
AS
SELECT Nombre_Rec  FROM Perfiles
INNER JOIN RecetaXFecha ON IdPerfil_RXF = IdPerfil_P
INNER JOIN Recetas ON IdReceta_Rec = IdReceta_RXF
WHERE IdFecha_RXF = @Fecha AND Nombre_P LIKE @Nombre_P
GO
/****** Object:  StoredProcedure [dbo].[PROC_COM_1]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------------------------------------------------------
--Procedimientos:
CREATE procedure [dbo].[PROC_COM_1]
@Id_Com char (4)
AS
SELECT Nombre_Ing, Costo_IXC FROM Ingredientes
INNER JOIN IngredienteXComercio 
ON Ingredientes.IdIngrediente_Ing = IngredienteXComercio.IdIngrediente_IXC
INNER JOIN Comercios
on IngredienteXComercio.IdComercio_IXC = Comercios.IdComercio_C
WHERE IdComercio_C = @Id_Com
GO
/****** Object:  StoredProcedure [dbo].[PROC_BUSC_CALORIAS]    Script Date: 07/25/2017 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------------------------------------------------------
--Consulta hasta cuantas calorias en todas las recetas:
CREATE procedure [dbo].[PROC_BUSC_CALORIAS]
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
/****** Object:  Default [DF__Comercios__Dias___0EA330E9]    Script Date: 07/25/2017 18:27:30 ******/
ALTER TABLE [dbo].[Comercios] ADD  DEFAULT ('lmijvsd') FOR [Dias_C]
GO
/****** Object:  Default [DF__Recetas__URLImag__7F60ED59]    Script Date: 07/25/2017 18:27:30 ******/
ALTER TABLE [dbo].[Recetas] ADD  DEFAULT ('NONE') FOR [URLImagen_Rec]
GO
/****** Object:  Check [CK__Ingredien__Unida__023D5A04]    Script Date: 07/25/2017 18:27:31 ******/
ALTER TABLE [dbo].[Ingredientes]  WITH CHECK ADD CHECK  (([Unidad_De_Medida_Ing]='Mililitros' OR [Unidad_De_Medida_Ing]='Unidades' OR [Unidad_De_Medida_Ing]='Gramos'))
GO
/****** Object:  ForeignKey [FK_REC1]    Script Date: 07/25/2017 18:27:30 ******/
ALTER TABLE [dbo].[Recetas]  WITH CHECK ADD  CONSTRAINT [FK_REC1] FOREIGN KEY([IdTipo1_Rec])
REFERENCES [dbo].[Tipos] ([IdTipo_Tip])
GO
ALTER TABLE [dbo].[Recetas] CHECK CONSTRAINT [FK_REC1]
GO
/****** Object:  ForeignKey [FK_REC2]    Script Date: 07/25/2017 18:27:30 ******/
ALTER TABLE [dbo].[Recetas]  WITH CHECK ADD  CONSTRAINT [FK_REC2] FOREIGN KEY([IdTipo2_Rec])
REFERENCES [dbo].[Tipos] ([IdTipo_Tip])
GO
ALTER TABLE [dbo].[Recetas] CHECK CONSTRAINT [FK_REC2]
GO
/****** Object:  ForeignKey [FK_PH]    Script Date: 07/25/2017 18:27:30 ******/
ALTER TABLE [dbo].[PesosHistoricos]  WITH CHECK ADD  CONSTRAINT [FK_PH] FOREIGN KEY([IdPerfil_PH])
REFERENCES [dbo].[Perfiles] ([IdPerfil_P])
GO
ALTER TABLE [dbo].[PesosHistoricos] CHECK CONSTRAINT [FK_PH]
GO
/****** Object:  ForeignKey [FK_ING1]    Script Date: 07/25/2017 18:27:31 ******/
ALTER TABLE [dbo].[Ingredientes]  WITH CHECK ADD  CONSTRAINT [FK_ING1] FOREIGN KEY([IdTipo1_Ing])
REFERENCES [dbo].[Tipos] ([IdTipo_Tip])
GO
ALTER TABLE [dbo].[Ingredientes] CHECK CONSTRAINT [FK_ING1]
GO
/****** Object:  ForeignKey [FK_ING2]    Script Date: 07/25/2017 18:27:31 ******/
ALTER TABLE [dbo].[Ingredientes]  WITH CHECK ADD  CONSTRAINT [FK_ING2] FOREIGN KEY([IdTipo2_Ing])
REFERENCES [dbo].[Tipos] ([IdTipo_Tip])
GO
ALTER TABLE [dbo].[Ingredientes] CHECK CONSTRAINT [FK_ING2]
GO
/****** Object:  ForeignKey [FK_RXI1]    Script Date: 07/25/2017 18:27:31 ******/
ALTER TABLE [dbo].[RecetaXIngrediente]  WITH CHECK ADD  CONSTRAINT [FK_RXI1] FOREIGN KEY([IdReceta_RXI])
REFERENCES [dbo].[Recetas] ([IdReceta_Rec])
GO
ALTER TABLE [dbo].[RecetaXIngrediente] CHECK CONSTRAINT [FK_RXI1]
GO
/****** Object:  ForeignKey [FK_RXI2]    Script Date: 07/25/2017 18:27:31 ******/
ALTER TABLE [dbo].[RecetaXIngrediente]  WITH CHECK ADD  CONSTRAINT [FK_RXI2] FOREIGN KEY([IdIngrediente_RXI])
REFERENCES [dbo].[Ingredientes] ([IdIngrediente_Ing])
GO
ALTER TABLE [dbo].[RecetaXIngrediente] CHECK CONSTRAINT [FK_RXI2]
GO
/****** Object:  ForeignKey [FK_RXF1]    Script Date: 07/25/2017 18:27:31 ******/
ALTER TABLE [dbo].[RecetaXFecha]  WITH CHECK ADD  CONSTRAINT [FK_RXF1] FOREIGN KEY([IdReceta_RXF])
REFERENCES [dbo].[Recetas] ([IdReceta_Rec])
GO
ALTER TABLE [dbo].[RecetaXFecha] CHECK CONSTRAINT [FK_RXF1]
GO
/****** Object:  ForeignKey [FK_RXF2]    Script Date: 07/25/2017 18:27:31 ******/
ALTER TABLE [dbo].[RecetaXFecha]  WITH CHECK ADD  CONSTRAINT [FK_RXF2] FOREIGN KEY([IdPerfil_RXF])
REFERENCES [dbo].[Perfiles] ([IdPerfil_P])
GO
ALTER TABLE [dbo].[RecetaXFecha] CHECK CONSTRAINT [FK_RXF2]
GO
/****** Object:  ForeignKey [FK_IXC1]    Script Date: 07/25/2017 18:27:31 ******/
ALTER TABLE [dbo].[IngredienteXComercio]  WITH CHECK ADD  CONSTRAINT [FK_IXC1] FOREIGN KEY([IdComercio_IXC])
REFERENCES [dbo].[Comercios] ([IdComercio_C])
GO
ALTER TABLE [dbo].[IngredienteXComercio] CHECK CONSTRAINT [FK_IXC1]
GO
/****** Object:  ForeignKey [FK_IXC2]    Script Date: 07/25/2017 18:27:31 ******/
ALTER TABLE [dbo].[IngredienteXComercio]  WITH CHECK ADD  CONSTRAINT [FK_IXC2] FOREIGN KEY([IdIngrediente_IXC])
REFERENCES [dbo].[Ingredientes] ([IdIngrediente_Ing])
GO
ALTER TABLE [dbo].[IngredienteXComercio] CHECK CONSTRAINT [FK_IXC2]
GO
