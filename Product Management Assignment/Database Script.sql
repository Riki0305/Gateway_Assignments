USE [master]
GO
/****** Object:  Database [ProductManagementDb]    Script Date: 1/9/2021 6:49:35 PM ******/
CREATE DATABASE [ProductManagementDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductManagementDb', FILENAME = N'C:\Users\Rikin\ProductManagementDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProductManagementDb_log', FILENAME = N'C:\Users\Rikin\ProductManagementDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProductManagementDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductManagementDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductManagementDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductManagementDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductManagementDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductManagementDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductManagementDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductManagementDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ProductManagementDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductManagementDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductManagementDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductManagementDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductManagementDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductManagementDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductManagementDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductManagementDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductManagementDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProductManagementDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductManagementDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductManagementDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductManagementDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductManagementDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductManagementDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ProductManagementDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductManagementDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProductManagementDb] SET  MULTI_USER 
GO
ALTER DATABASE [ProductManagementDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductManagementDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductManagementDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductManagementDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductManagementDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProductManagementDb] SET QUERY_STORE = OFF
GO
USE [ProductManagementDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ProductManagementDb]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 1/9/2021 6:49:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 1/9/2021 6:49:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NLog]    Script Date: 1/9/2021 6:49:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[level] [varchar](100) NOT NULL,
	[logger] [varchar](1000) NOT NULL,
	[message] [varchar](3600) NOT NULL,
	[Callsite] [varchar](3600) NULL,
	[exception] [varchar](3600) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 1/9/2021 6:49:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ShortDesc] [nvarchar](max) NOT NULL,
	[LongDesc] [nvarchar](max) NOT NULL,
	[SmallImagePath] [nvarchar](max) NOT NULL,
	[LongImagePath] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/9/2021 6:49:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[ConfirmPassword] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryId]    Script Date: 1/9/2021 6:49:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [ProductManagementDb] SET  READ_WRITE 
GO
