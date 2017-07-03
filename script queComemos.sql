USE [master]
GO
/****** Object:  Database [queComemos]    Script Date: 06/25/2017 21:57:45 ******/
CREATE DATABASE [queComemos] ON  PRIMARY 
( NAME = N'queComemos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\queComemos.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'queComemos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\queComemos_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [queComemos] SET AUTO_CLOSE OFF
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
ALTER DATABASE [queComemos] SET  DISABLE_BROKER
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
/****** Object:  Table [dbo].[Tipo]    Script Date: 06/25/2017 21:57:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo](
	[idTipo] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tipo] PRIMARY KEY CLUSTERED 
(
	[idTipo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingrediente]    Script Date: 06/25/2017 21:57:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingrediente](
	[idIngrediente] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[calorias] [int] NULL,
	[proteinas] [decimal](18, 0) NULL,
	[carbohidratos] [decimal](18, 0) NULL,
	[grasas] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Ingrediente] PRIMARY KEY CLUSTERED 
(
	[idIngrediente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comercio]    Script Date: 06/25/2017 21:57:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comercio](
	[idComercio] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[direccion] [nvarchar](50) NOT NULL,
	[horario] [nvarchar](50) NULL,
	[telefono] [nvarchar](20) NULL,
 CONSTRAINT [PK_Comercio] PRIMARY KEY CLUSTERED 
(
	[idComercio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 06/25/2017 21:57:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[idPerfil] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[imagen] [nvarchar](max) NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[idPerfil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngredienteTipo]    Script Date: 06/25/2017 21:57:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredienteTipo](
	[idIngrediente] [int] NOT NULL,
	[idTipo] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngredienteComercio]    Script Date: 06/25/2017 21:57:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredienteComercio](
	[idComercio] [int] NOT NULL,
	[idIngrediente] [int] NOT NULL,
	[costo] [money] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receta]    Script Date: 06/25/2017 21:57:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receta](
	[idReceta] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[urlImagen] [nvarchar](max) NULL,
	[descripcion] [nvarchar](max) NOT NULL,
	[tiempoPreparacion] [nvarchar](50) NULL,
	[idTipo] [int] NOT NULL,
 CONSTRAINT [PK_Receta] PRIMARY KEY CLUSTERED 
(
	[idReceta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PesoHistorico]    Script Date: 06/25/2017 21:57:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PesoHistorico](
	[idPerfil] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[peso] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecetaIngrediente]    Script Date: 06/25/2017 21:57:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecetaIngrediente](
	[idReceta] [int] NOT NULL,
	[idIngrediente] [int] NOT NULL,
	[cantidad] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecetaFecha]    Script Date: 06/25/2017 21:57:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecetaFecha](
	[fecha] [datetime] NOT NULL,
	[idReceta] [int] NOT NULL,
	[idPerfil] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_IngredienteTipo_Ingrediente]    Script Date: 06/25/2017 21:57:45 ******/
ALTER TABLE [dbo].[IngredienteTipo]  WITH CHECK ADD  CONSTRAINT [FK_IngredienteTipo_Ingrediente] FOREIGN KEY([idIngrediente])
REFERENCES [dbo].[Ingrediente] ([idIngrediente])
GO
ALTER TABLE [dbo].[IngredienteTipo] CHECK CONSTRAINT [FK_IngredienteTipo_Ingrediente]
GO
/****** Object:  ForeignKey [FK_IngredienteTipo_Tipo]    Script Date: 06/25/2017 21:57:45 ******/
ALTER TABLE [dbo].[IngredienteTipo]  WITH CHECK ADD  CONSTRAINT [FK_IngredienteTipo_Tipo] FOREIGN KEY([idTipo])
REFERENCES [dbo].[Tipo] ([idTipo])
GO
ALTER TABLE [dbo].[IngredienteTipo] CHECK CONSTRAINT [FK_IngredienteTipo_Tipo]
GO
/****** Object:  ForeignKey [FK_IngredienteComercio_Comercio]    Script Date: 06/25/2017 21:57:45 ******/
ALTER TABLE [dbo].[IngredienteComercio]  WITH CHECK ADD  CONSTRAINT [FK_IngredienteComercio_Comercio] FOREIGN KEY([idComercio])
REFERENCES [dbo].[Comercio] ([idComercio])
GO
ALTER TABLE [dbo].[IngredienteComercio] CHECK CONSTRAINT [FK_IngredienteComercio_Comercio]
GO
/****** Object:  ForeignKey [FK_IngredienteComercio_Ingrediente]    Script Date: 06/25/2017 21:57:45 ******/
ALTER TABLE [dbo].[IngredienteComercio]  WITH CHECK ADD  CONSTRAINT [FK_IngredienteComercio_Ingrediente] FOREIGN KEY([idIngrediente])
REFERENCES [dbo].[Ingrediente] ([idIngrediente])
GO
ALTER TABLE [dbo].[IngredienteComercio] CHECK CONSTRAINT [FK_IngredienteComercio_Ingrediente]
GO
/****** Object:  ForeignKey [FK_Receta_Tipo]    Script Date: 06/25/2017 21:57:45 ******/
ALTER TABLE [dbo].[Receta]  WITH CHECK ADD  CONSTRAINT [FK_Receta_Tipo] FOREIGN KEY([idTipo])
REFERENCES [dbo].[Tipo] ([idTipo])
GO
ALTER TABLE [dbo].[Receta] CHECK CONSTRAINT [FK_Receta_Tipo]
GO
/****** Object:  ForeignKey [FK_PesoHistorico_Perfil]    Script Date: 06/25/2017 21:57:45 ******/
ALTER TABLE [dbo].[PesoHistorico]  WITH CHECK ADD  CONSTRAINT [FK_PesoHistorico_Perfil] FOREIGN KEY([idPerfil])
REFERENCES [dbo].[Perfil] ([idPerfil])
GO
ALTER TABLE [dbo].[PesoHistorico] CHECK CONSTRAINT [FK_PesoHistorico_Perfil]
GO
/****** Object:  ForeignKey [FK_RecetaIngrediente_Ingrediente]    Script Date: 06/25/2017 21:57:45 ******/
ALTER TABLE [dbo].[RecetaIngrediente]  WITH CHECK ADD  CONSTRAINT [FK_RecetaIngrediente_Ingrediente] FOREIGN KEY([idIngrediente])
REFERENCES [dbo].[Ingrediente] ([idIngrediente])
GO
ALTER TABLE [dbo].[RecetaIngrediente] CHECK CONSTRAINT [FK_RecetaIngrediente_Ingrediente]
GO
/****** Object:  ForeignKey [FK_RecetaIngrediente_Receta]    Script Date: 06/25/2017 21:57:45 ******/
ALTER TABLE [dbo].[RecetaIngrediente]  WITH CHECK ADD  CONSTRAINT [FK_RecetaIngrediente_Receta] FOREIGN KEY([idReceta])
REFERENCES [dbo].[Receta] ([idReceta])
GO
ALTER TABLE [dbo].[RecetaIngrediente] CHECK CONSTRAINT [FK_RecetaIngrediente_Receta]
GO
/****** Object:  ForeignKey [FK_RecetaFecha_Perfil]    Script Date: 06/25/2017 21:57:45 ******/
ALTER TABLE [dbo].[RecetaFecha]  WITH CHECK ADD  CONSTRAINT [FK_RecetaFecha_Perfil] FOREIGN KEY([idPerfil])
REFERENCES [dbo].[Perfil] ([idPerfil])
GO
ALTER TABLE [dbo].[RecetaFecha] CHECK CONSTRAINT [FK_RecetaFecha_Perfil]
GO
/****** Object:  ForeignKey [FK_RecetaFecha_Receta]    Script Date: 06/25/2017 21:57:45 ******/
ALTER TABLE [dbo].[RecetaFecha]  WITH CHECK ADD  CONSTRAINT [FK_RecetaFecha_Receta] FOREIGN KEY([idReceta])
REFERENCES [dbo].[Receta] ([idReceta])
GO
ALTER TABLE [dbo].[RecetaFecha] CHECK CONSTRAINT [FK_RecetaFecha_Receta]
GO
