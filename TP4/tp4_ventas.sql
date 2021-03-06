USE [master]
GO
/****** Object:  Database [tp4_ventas]    Script Date: 22/11/2020 21:48:13 ******/
CREATE DATABASE [tp4_ventas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'tp4_ventas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\tp4_ventas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'tp4_ventas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\tp4_ventas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [tp4_ventas] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tp4_ventas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tp4_ventas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tp4_ventas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tp4_ventas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tp4_ventas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tp4_ventas] SET ARITHABORT OFF 
GO
ALTER DATABASE [tp4_ventas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [tp4_ventas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tp4_ventas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tp4_ventas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tp4_ventas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [tp4_ventas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tp4_ventas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tp4_ventas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tp4_ventas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tp4_ventas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [tp4_ventas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tp4_ventas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [tp4_ventas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [tp4_ventas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [tp4_ventas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tp4_ventas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [tp4_ventas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [tp4_ventas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [tp4_ventas] SET  MULTI_USER 
GO
ALTER DATABASE [tp4_ventas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [tp4_ventas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [tp4_ventas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [tp4_ventas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [tp4_ventas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [tp4_ventas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [tp4_ventas] SET QUERY_STORE = OFF
GO
USE [tp4_ventas]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 22/11/2020 21:48:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[marca] [nvarchar](50) NULL,
	[precioUnitario] [float] NULL,
	[tipo] [nvarchar](50) NULL,
	[material] [nvarchar](50) NULL,
	[fechaVencimiento] [datetime] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 22/11/2020 21:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[factura] [int] NULL,
	[fecha] [datetime] NULL,
	[cliente] [varchar](50) NULL,
	[total] [float] NULL,
	[estado] [varchar](50) NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([id], [nombre], [marca], [precioUnitario], [tipo], [material], [fechaVencimiento]) VALUES (1, N'Espinaca', N'Carrefour', 50, N'Congelado', NULL, CAST(N'2020-11-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Productos] ([id], [nombre], [marca], [precioUnitario], [tipo], [material], [fechaVencimiento]) VALUES (2, N'Hamburguesas', N'Paty', 150.5, N'Congelado', NULL, CAST(N'2020-11-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Productos] ([id], [nombre], [marca], [precioUnitario], [tipo], [material], [fechaVencimiento]) VALUES (3, N'Helado', N'Frigor', 200, N'Congelado', NULL, CAST(N'2020-12-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Productos] ([id], [nombre], [marca], [precioUnitario], [tipo], [material], [fechaVencimiento]) VALUES (4, N'Balde', N'Colombraro', 300, N'Bazar', N'Plastico', NULL)
INSERT [dbo].[Productos] ([id], [nombre], [marca], [precioUnitario], [tipo], [material], [fechaVencimiento]) VALUES (5, N'Jarra', N'Luxury', 122.35, N'Bazar', N'Vidrio', NULL)
INSERT [dbo].[Productos] ([id], [nombre], [marca], [precioUnitario], [tipo], [material], [fechaVencimiento]) VALUES (6, N'Silla', N'Madera San Juan', 1500, N'Bazar', N'Madera', NULL)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
USE [master]
GO
ALTER DATABASE [tp4_ventas] SET  READ_WRITE 
GO
