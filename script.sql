USE [master]
GO
/****** Object:  Database [personaje]    Script Date: 2/7/2024 14:12:56 ******/
CREATE DATABASE [personaje]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'personaje', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\personaje.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'personaje_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\personaje_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [personaje] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [personaje].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [personaje] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [personaje] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [personaje] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [personaje] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [personaje] SET ARITHABORT OFF 
GO
ALTER DATABASE [personaje] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [personaje] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [personaje] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [personaje] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [personaje] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [personaje] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [personaje] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [personaje] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [personaje] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [personaje] SET  DISABLE_BROKER 
GO
ALTER DATABASE [personaje] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [personaje] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [personaje] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [personaje] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [personaje] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [personaje] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [personaje] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [personaje] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [personaje] SET  MULTI_USER 
GO
ALTER DATABASE [personaje] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [personaje] SET DB_CHAINING OFF 
GO
ALTER DATABASE [personaje] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [personaje] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [personaje] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [personaje] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [personaje] SET QUERY_STORE = ON
GO
ALTER DATABASE [personaje] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [personaje]
GO
/****** Object:  Table [dbo].[TablaPersonajes]    Script Date: 2/7/2024 14:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablaPersonajes](
	[tipo] [nvarchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[edad] [nvarchar](50) NOT NULL,
	[caracteristica] [varchar](50) NOT NULL,
	[resucitado] [bit] NOT NULL,
	[colorHumano] [nvarchar](50) NULL,
	[colorPelo] [nvarchar](50) NULL,
	[especieOrco] [nvarchar](50) NULL,
	[especieElfo] [nvarchar](50) NULL,
	[canibal] [bit] NULL,
	[inmortalidad] [bit] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[TablaPersonajes] ([tipo], [nombre], [edad], [caracteristica], [resucitado], [colorHumano], [colorPelo], [especieOrco], [especieElfo], [canibal], [inmortalidad]) VALUES (N'Humano', N'hola1', N'Joven', N'Enano', 1, N'Morocho', N'Negro', NULL, NULL, NULL, NULL)
INSERT [dbo].[TablaPersonajes] ([tipo], [nombre], [edad], [caracteristica], [resucitado], [colorHumano], [colorPelo], [especieOrco], [especieElfo], [canibal], [inmortalidad]) VALUES (N'Orco', N'agus', N'Adulto', N'Enano', 1, NULL, NULL, N'Orogs', NULL, 1, NULL)
INSERT [dbo].[TablaPersonajes] ([tipo], [nombre], [edad], [caracteristica], [resucitado], [colorHumano], [colorPelo], [especieOrco], [especieElfo], [canibal], [inmortalidad]) VALUES (N'Humano', N'ee', N'No_Especificado', N'No_Especificado', 0, N'No_Especificado', N'No_Especificado', NULL, NULL, NULL, NULL)
INSERT [dbo].[TablaPersonajes] ([tipo], [nombre], [edad], [caracteristica], [resucitado], [colorHumano], [colorPelo], [especieOrco], [especieElfo], [canibal], [inmortalidad]) VALUES (N'Humano', N'prueba1', N'No_Especificado', N'No_Especificado', 0, N'No_Especificado', N'No_Especificado', NULL, NULL, NULL, NULL)
INSERT [dbo].[TablaPersonajes] ([tipo], [nombre], [edad], [caracteristica], [resucitado], [colorHumano], [colorPelo], [especieOrco], [especieElfo], [canibal], [inmortalidad]) VALUES (N'Elfo', N'Sin nombre', N'No_Especificado', N'No_Especificado', 0, NULL, NULL, NULL, N'No_Especificado', NULL, 0)
GO
USE [master]
GO
ALTER DATABASE [personaje] SET  READ_WRITE 
GO
