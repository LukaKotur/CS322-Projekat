USE [master]
GO
/****** Object:  Database [BazaProjekat]    Script Date: 06/01/2018 23:07:05 ******/
CREATE DATABASE [BazaProjekat]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BazaProjekat', FILENAME = N'C:\Users\luko9\BazaProjekat.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BazaProjekat_log', FILENAME = N'C:\Users\luko9\BazaProjekat_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BazaProjekat] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BazaProjekat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BazaProjekat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BazaProjekat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BazaProjekat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BazaProjekat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BazaProjekat] SET ARITHABORT OFF 
GO
ALTER DATABASE [BazaProjekat] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BazaProjekat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BazaProjekat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BazaProjekat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BazaProjekat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BazaProjekat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BazaProjekat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BazaProjekat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BazaProjekat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BazaProjekat] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BazaProjekat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BazaProjekat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BazaProjekat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BazaProjekat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BazaProjekat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BazaProjekat] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BazaProjekat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BazaProjekat] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BazaProjekat] SET  MULTI_USER 
GO
ALTER DATABASE [BazaProjekat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BazaProjekat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BazaProjekat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BazaProjekat] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BazaProjekat] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BazaProjekat] SET QUERY_STORE = OFF
GO
USE [BazaProjekat]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BazaProjekat]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Age] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clanovi]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clanovi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adresa] [nvarchar](max) NULL,
	[DatumRodjenja] [datetime2](7) NOT NULL,
	[Ime] [nvarchar](max) NULL,
	[Prezime] [nvarchar](max) NULL,
	[Telefon] [nvarchar](max) NULL,
	[ClanOgrankaId] [int] NULL,
	[ClanskaKartaId] [int] NULL,
 CONSTRAINT [PK_Clanovi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClanskaKarta]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClanskaKarta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Dug] [decimal](18, 2) NOT NULL,
	[VremePravljenja] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ClanskaKarta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IstorijaIznajmljivanja]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IstorijaIznajmljivanja](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClanskaKartaId] [int] NOT NULL,
	[DatumIznajmljivanja] [datetime2](7) NOT NULL,
	[DatumVracanja] [datetime2](7) NULL,
	[VideoKlubAssetId] [int] NOT NULL,
 CONSTRAINT [PK_IstorijaIznajmljivanja] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Iznajmljivanje]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Iznajmljivanje](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClanskaKartaId] [int] NULL,
	[DatumKraja] [datetime2](7) NOT NULL,
	[DatumPocetka] [datetime2](7) NOT NULL,
	[VideoKlubAssetId] [int] NOT NULL,
 CONSTRAINT [PK_Iznajmljivanje] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RadnoVreme]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RadnoVreme](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DanUNedelji] [int] NOT NULL,
	[OgranakId] [int] NULL,
	[VremeKadaJeOtvoreno] [int] NOT NULL,
	[VremeKadaJeZatvoreno] [int] NOT NULL,
 CONSTRAINT [PK_RadnoVreme] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rezervacija]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rezervacija](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClanskaKartaId] [int] NULL,
	[StavljenaRezervacija] [datetime2](7) NOT NULL,
	[VideoKlubAssetId] [int] NULL,
 CONSTRAINT [PK_Rezervacija] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](max) NOT NULL,
	[Opis] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VideoKlubAsset]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoKlubAsset](
	[DatumIzlaska] [datetime2](7) NOT NULL,
	[GlavniGlumci] [nvarchar](max) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrojKopija] [int] NOT NULL,
	[Cena] [decimal](18, 2) NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[ImgUrl] [nvarchar](max) NULL,
	[LokacijaId] [int] NULL,
	[Naziv] [nvarchar](max) NOT NULL,
	[StatusId] [int] NOT NULL,
	[Producent] [nvarchar](max) NULL,
 CONSTRAINT [PK_VideoKlubAsset] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VideoKlubOgranak]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoKlubOgranak](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adresa] [nvarchar](max) NOT NULL,
	[ImgUrl] [nvarchar](max) NULL,
	[Naziv] [nvarchar](30) NOT NULL,
	[Opis] [nvarchar](max) NULL,
	[Telefon] [nvarchar](max) NOT NULL,
	[VremeKadaJeOtvoreno] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_VideoKlubOgranak] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zaposleni]    Script Date: 06/01/2018 23:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zaposleni](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](max) NOT NULL,
	[Sifra] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Zaposleni] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20171227170948_Initial migration', N'2.0.1-rtm-125')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20171227181413_Entity Migration', N'2.0.1-rtm-125')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20171227182423_Entity Migration2', N'2.0.1-rtm-125')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20171227185246_Entity Migration3', N'2.0.1-rtm-125')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20171227190810_Entity Migration4', N'2.0.1-rtm-125')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20171227194107_Entity Migration5', N'2.0.1-rtm-125')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20171227203623_Entity Migration6', N'2.0.1-rtm-125')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180101151609_Adding Zaposleni', N'2.0.1-rtm-125')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180103173659_Security', N'2.0.1-rtm-125')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [Age], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'979fd203-2427-4c93-aee8-41a5af36c1ac', 0, 21, N'928da1e7-995c-4f33-a109-1c021b811533', N'looko95@gmail.com', 1, 1, NULL, N'LOOKO95@GMAIL.COM', N'ADMIN', N'AQAAAAEAACcQAAAAEJATppFJIIQjaYldNn3eNykDP0IBlfcO1gXnyHJ4Cr0Z5wpnV7W+EHOTtaa0eiEwHg==', NULL, 0, N'e6e00669-ecf2-48d3-85b9-843215f55633', 0, N'admin')
SET IDENTITY_INSERT [dbo].[Clanovi] ON 

INSERT [dbo].[Clanovi] ([Id], [Adresa], [DatumRodjenja], [Ime], [Prezime], [Telefon], [ClanOgrankaId], [ClanskaKartaId]) VALUES (1, N'Cetinjska 16', CAST(N'1990-05-30T00:00:00.0000000' AS DateTime2), N'Pera', N'Peric', N'011-510-133', 1, 1)
INSERT [dbo].[Clanovi] ([Id], [Adresa], [DatumRodjenja], [Ime], [Prezime], [Telefon], [ClanOgrankaId], [ClanskaKartaId]) VALUES (2, N'Bezanijska 26', CAST(N'1995-01-30T00:00:00.0000000' AS DateTime2), N'Mika', N'Mikic', N'064-530-2133', 1, 2)
INSERT [dbo].[Clanovi] ([Id], [Adresa], [DatumRodjenja], [Ime], [Prezime], [Telefon], [ClanOgrankaId], [ClanskaKartaId]) VALUES (3, N'Tadeusa Koscuska 71', CAST(N'1980-03-30T00:00:00.0000000' AS DateTime2), N'Zika', N'Zikic', N'061-550-441', 2, 3)
INSERT [dbo].[Clanovi] ([Id], [Adresa], [DatumRodjenja], [Ime], [Prezime], [Telefon], [ClanOgrankaId], [ClanskaKartaId]) VALUES (4, N'Neka adresa 15', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Petar', N'Petrovski', N'05105305310', 2, 4)
INSERT [dbo].[Clanovi] ([Id], [Adresa], [DatumRodjenja], [Ime], [Prezime], [Telefon], [ClanOgrankaId], [ClanskaKartaId]) VALUES (1004, N'Neka adresa 15', CAST(N'1940-01-16T00:00:00.0000000' AS DateTime2), N'milos', N'Milosevic', N'05105305310', 1, 1004)
INSERT [dbo].[Clanovi] ([Id], [Adresa], [DatumRodjenja], [Ime], [Prezime], [Telefon], [ClanOgrankaId], [ClanskaKartaId]) VALUES (1005, N'teoateoa', CAST(N'1958-01-23T00:00:00.0000000' AS DateTime2), N'Luka', N'Tralala', N'156646466', 1, 1005)
INSERT [dbo].[Clanovi] ([Id], [Adresa], [DatumRodjenja], [Ime], [Prezime], [Telefon], [ClanOgrankaId], [ClanskaKartaId]) VALUES (1007, N'TestAdresa', CAST(N'1940-01-18T00:00:00.0000000' AS DateTime2), N'Test', N'TestPreyime', N'529159319539531', 2, 1007)
SET IDENTITY_INSERT [dbo].[Clanovi] OFF
SET IDENTITY_INSERT [dbo].[ClanskaKarta] ON 

INSERT [dbo].[ClanskaKarta] ([Id], [Dug], [VremePravljenja]) VALUES (1, CAST(0.00 AS Decimal(18, 2)), CAST(N'2016-05-24T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ClanskaKarta] ([Id], [Dug], [VremePravljenja]) VALUES (2, CAST(500.00 AS Decimal(18, 2)), CAST(N'2015-05-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ClanskaKarta] ([Id], [Dug], [VremePravljenja]) VALUES (3, CAST(250.00 AS Decimal(18, 2)), CAST(N'2017-03-23T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ClanskaKarta] ([Id], [Dug], [VremePravljenja]) VALUES (4, CAST(0.00 AS Decimal(18, 2)), CAST(N'2018-01-02T14:34:24.4325974' AS DateTime2))
INSERT [dbo].[ClanskaKarta] ([Id], [Dug], [VremePravljenja]) VALUES (1004, CAST(0.00 AS Decimal(18, 2)), CAST(N'2018-01-02T15:21:46.9676462' AS DateTime2))
INSERT [dbo].[ClanskaKarta] ([Id], [Dug], [VremePravljenja]) VALUES (1005, CAST(0.00 AS Decimal(18, 2)), CAST(N'2018-01-02T15:22:25.5293201' AS DateTime2))
INSERT [dbo].[ClanskaKarta] ([Id], [Dug], [VremePravljenja]) VALUES (1006, CAST(0.00 AS Decimal(18, 2)), CAST(N'2018-01-05T18:34:32.9400853' AS DateTime2))
INSERT [dbo].[ClanskaKarta] ([Id], [Dug], [VremePravljenja]) VALUES (1007, CAST(0.00 AS Decimal(18, 2)), CAST(N'2018-01-06T19:24:42.6827575' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ClanskaKarta] OFF
SET IDENTITY_INSERT [dbo].[IstorijaIznajmljivanja] ON 

INSERT [dbo].[IstorijaIznajmljivanja] ([Id], [ClanskaKartaId], [DatumIznajmljivanja], [DatumVracanja], [VideoKlubAssetId]) VALUES (3002, 2, CAST(N'2017-12-29T15:07:53.9730528' AS DateTime2), CAST(N'2017-12-29T15:08:04.9692498' AS DateTime2), 6)
INSERT [dbo].[IstorijaIznajmljivanja] ([Id], [ClanskaKartaId], [DatumIznajmljivanja], [DatumVracanja], [VideoKlubAssetId]) VALUES (3003, 2, CAST(N'2017-12-29T15:08:24.5223433' AS DateTime2), CAST(N'2017-12-29T15:08:31.8539489' AS DateTime2), 6)
INSERT [dbo].[IstorijaIznajmljivanja] ([Id], [ClanskaKartaId], [DatumIznajmljivanja], [DatumVracanja], [VideoKlubAssetId]) VALUES (3004, 1, CAST(N'2017-12-29T15:08:39.8854528' AS DateTime2), CAST(N'2017-12-29T15:08:43.4377066' AS DateTime2), 6)
INSERT [dbo].[IstorijaIznajmljivanja] ([Id], [ClanskaKartaId], [DatumIznajmljivanja], [DatumVracanja], [VideoKlubAssetId]) VALUES (3005, 1, CAST(N'2018-01-01T15:14:46.1472189' AS DateTime2), CAST(N'2018-01-01T16:47:27.8578407' AS DateTime2), 6)
INSERT [dbo].[IstorijaIznajmljivanja] ([Id], [ClanskaKartaId], [DatumIznajmljivanja], [DatumVracanja], [VideoKlubAssetId]) VALUES (4005, 2, CAST(N'2018-01-01T16:47:33.2157220' AS DateTime2), CAST(N'2018-01-01T18:06:41.6024364' AS DateTime2), 6)
INSERT [dbo].[IstorijaIznajmljivanja] ([Id], [ClanskaKartaId], [DatumIznajmljivanja], [DatumVracanja], [VideoKlubAssetId]) VALUES (4006, 1, CAST(N'2018-01-01T18:19:20.0362032' AS DateTime2), CAST(N'2018-01-01T18:21:36.3383500' AS DateTime2), 2)
INSERT [dbo].[IstorijaIznajmljivanja] ([Id], [ClanskaKartaId], [DatumIznajmljivanja], [DatumVracanja], [VideoKlubAssetId]) VALUES (4007, 1, CAST(N'2018-01-01T18:19:32.2850998' AS DateTime2), CAST(N'2018-01-01T18:21:44.0194444' AS DateTime2), 6)
INSERT [dbo].[IstorijaIznajmljivanja] ([Id], [ClanskaKartaId], [DatumIznajmljivanja], [DatumVracanja], [VideoKlubAssetId]) VALUES (4008, 2, CAST(N'2018-01-01T18:21:44.1446634' AS DateTime2), CAST(N'2018-01-01T18:21:47.3677245' AS DateTime2), 6)
INSERT [dbo].[IstorijaIznajmljivanja] ([Id], [ClanskaKartaId], [DatumIznajmljivanja], [DatumVracanja], [VideoKlubAssetId]) VALUES (4009, 3, CAST(N'2018-01-01T18:21:47.5015384' AS DateTime2), NULL, 6)
INSERT [dbo].[IstorijaIznajmljivanja] ([Id], [ClanskaKartaId], [DatumIznajmljivanja], [DatumVracanja], [VideoKlubAssetId]) VALUES (4010, 1005, CAST(N'2018-01-02T15:23:10.3905855' AS DateTime2), CAST(N'2018-01-02T15:23:30.9458827' AS DateTime2), 2)
INSERT [dbo].[IstorijaIznajmljivanja] ([Id], [ClanskaKartaId], [DatumIznajmljivanja], [DatumVracanja], [VideoKlubAssetId]) VALUES (4011, 1005, CAST(N'2018-01-03T21:38:58.0027173' AS DateTime2), NULL, 2)
INSERT [dbo].[IstorijaIznajmljivanja] ([Id], [ClanskaKartaId], [DatumIznajmljivanja], [DatumVracanja], [VideoKlubAssetId]) VALUES (4012, 1005, CAST(N'2018-01-05T17:06:48.9237609' AS DateTime2), CAST(N'2018-01-05T17:06:52.2398380' AS DateTime2), 9)
SET IDENTITY_INSERT [dbo].[IstorijaIznajmljivanja] OFF
SET IDENTITY_INSERT [dbo].[Iznajmljivanje] ON 

INSERT [dbo].[Iznajmljivanje] ([Id], [ClanskaKartaId], [DatumKraja], [DatumPocetka], [VideoKlubAssetId]) VALUES (4009, 3, CAST(N'2018-01-31T18:21:47.5015384' AS DateTime2), CAST(N'2018-01-01T18:21:47.5015384' AS DateTime2), 6)
INSERT [dbo].[Iznajmljivanje] ([Id], [ClanskaKartaId], [DatumKraja], [DatumPocetka], [VideoKlubAssetId]) VALUES (4011, 1005, CAST(N'2018-02-02T21:38:58.0027173' AS DateTime2), CAST(N'2018-01-03T21:38:58.0027173' AS DateTime2), 2)
SET IDENTITY_INSERT [dbo].[Iznajmljivanje] OFF
SET IDENTITY_INSERT [dbo].[RadnoVreme] ON 

INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (1, 1, 1, 7, 14)
INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (2, 2, 1, 7, 18)
INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (3, 3, 1, 7, 18)
INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (4, 4, 1, 7, 18)
INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (5, 5, 1, 7, 18)
INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (6, 6, 1, 7, 18)
INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (7, 7, 1, 7, 14)
INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (8, 1, 2, 6, 20)
INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (9, 2, 2, 6, 20)
INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (10, 3, 2, 6, 20)
INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (11, 4, 2, 6, 20)
INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (12, 5, 2, 6, 20)
INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (13, 6, 2, 6, 20)
INSERT [dbo].[RadnoVreme] ([Id], [DanUNedelji], [OgranakId], [VremeKadaJeOtvoreno], [VremeKadaJeZatvoreno]) VALUES (14, 7, 2, 6, 20)
SET IDENTITY_INSERT [dbo].[RadnoVreme] OFF
SET IDENTITY_INSERT [dbo].[Rezervacija] ON 

INSERT [dbo].[Rezervacija] ([Id], [ClanskaKartaId], [StavljenaRezervacija], [VideoKlubAssetId]) VALUES (2009, 2, CAST(N'2018-01-01T18:22:23.8250970' AS DateTime2), 6)
SET IDENTITY_INSERT [dbo].[Rezervacija] OFF
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [Naziv], [Opis]) VALUES (1, N'Iznajmljen', N'Film je iznajmljen i nije dostupan')
INSERT [dbo].[Status] ([Id], [Naziv], [Opis]) VALUES (2, N'Dostupan', N'Film je dostupan i slobodan je za iznajmljivanje')
INSERT [dbo].[Status] ([Id], [Naziv], [Opis]) VALUES (3, N'Izgubljen', N'Kopija filma je izgubljena')
INSERT [dbo].[Status] ([Id], [Naziv], [Opis]) VALUES (4, N'Rezervisan', N'Film je rezervisan od strane nekog korsinika')
SET IDENTITY_INSERT [dbo].[Status] OFF
SET IDENTITY_INSERT [dbo].[VideoKlubAsset] ON 

INSERT [dbo].[VideoKlubAsset] ([DatumIzlaska], [GlavniGlumci], [Id], [BrojKopija], [Cena], [Discriminator], [ImgUrl], [LokacijaId], [Naziv], [StatusId], [Producent]) VALUES (CAST(N'2017-12-15T00:00:00.0000000' AS DateTime2), N'Daisy Ridley, John Boyega, Mark Hamill', 2, 10, CAST(550.00 AS Decimal(18, 2)), N'film', N'/images/tlj.png', 1, N'Star Wars: The Last Jedi', 1, N'Rian Johnson')
INSERT [dbo].[VideoKlubAsset] ([DatumIzlaska], [GlavniGlumci], [Id], [BrojKopija], [Cena], [Discriminator], [ImgUrl], [LokacijaId], [Naziv], [StatusId], [Producent]) VALUES (CAST(N'2017-12-15T00:00:00.0000000' AS DateTime2), N'Daisy Ridley, John Boyega, Mark Hamill', 3, 2, CAST(480.00 AS Decimal(18, 2)), N'film', N'/images/tlj.png', 2, N'Star Wars: The Last Jedi', 2, N'Rian Johnson')
INSERT [dbo].[VideoKlubAsset] ([DatumIzlaska], [GlavniGlumci], [Id], [BrojKopija], [Cena], [Discriminator], [ImgUrl], [LokacijaId], [Naziv], [StatusId], [Producent]) VALUES (CAST(N'2017-12-15T00:00:00.0000000' AS DateTime2), N'Daisy Ridley, John Boyega, Oscar Isaac', 4, 4, CAST(450.00 AS Decimal(18, 2)), N'film', N'/images/tfa.png', 2, N'Star Wars: The Force Awakens', 2, N'J.J Abrams')
INSERT [dbo].[VideoKlubAsset] ([DatumIzlaska], [GlavniGlumci], [Id], [BrojKopija], [Cena], [Discriminator], [ImgUrl], [LokacijaId], [Naziv], [StatusId], [Producent]) VALUES (CAST(N'1990-10-26T00:00:00.0000000' AS DateTime2), N'Robert De Niro, Ray Liotta, Joe Pesci', 6, 1, CAST(500.00 AS Decimal(18, 2)), N'film', N'/images/goodfellas.png', 2, N'Goodfellas', 1, N'Martin Scorsese')
INSERT [dbo].[VideoKlubAsset] ([DatumIzlaska], [GlavniGlumci], [Id], [BrojKopija], [Cena], [Discriminator], [ImgUrl], [LokacijaId], [Naziv], [StatusId], [Producent]) VALUES (CAST(N'1990-10-26T00:00:00.0000000' AS DateTime2), N'Robert De Niro, Ray Liotta, Joe Pesci', 7, 4, CAST(500.00 AS Decimal(18, 2)), N'film', N'/images/goodfellas.png', 1, N'Goodfellas', 2, N'Martin Scorsese')
INSERT [dbo].[VideoKlubAsset] ([DatumIzlaska], [GlavniGlumci], [Id], [BrojKopija], [Cena], [Discriminator], [ImgUrl], [LokacijaId], [Naziv], [StatusId], [Producent]) VALUES (CAST(N'2016-05-16T00:00:00.0000000' AS DateTime2), N'Chris Evans, Robert Downey Jr., Scarlett Johansson ', 8, 1, CAST(485.00 AS Decimal(18, 2)), N'Film', N'/images/7e55ed0f-e272-4c50-be53-f18178b5823a.jpg', 2, N'Captain America: Civil War', 2, N'Anthony Russo, Joe Russo')
INSERT [dbo].[VideoKlubAsset] ([DatumIzlaska], [GlavniGlumci], [Id], [BrojKopija], [Cena], [Discriminator], [ImgUrl], [LokacijaId], [Naziv], [StatusId], [Producent]) VALUES (CAST(N'2012-05-04T00:00:00.0000000' AS DateTime2), N'Robert Downey Jr., Chris Evans, Scarlett Johansson |', 9, 1, CAST(350.00 AS Decimal(18, 2)), N'Film', N'/images/6e84acfd-f264-4aa6-b60f-ae52861da271.jpg', 2, N'The Avengers', 2, N'Joss Whedon')
SET IDENTITY_INSERT [dbo].[VideoKlubAsset] OFF
SET IDENTITY_INSERT [dbo].[VideoKlubOgranak] ON 

INSERT [dbo].[VideoKlubOgranak] ([Id], [Adresa], [ImgUrl], [Naziv], [Opis], [Telefon], [VremeKadaJeOtvoreno]) VALUES (1, N'Cetinjska 15a', N'/images/ogranak/1.png', N'Video Klub Tralala u Zemunu', N'Prvi video klub Tralala napravljen u Zemunu pored glavne ulice.', N'011-514-5003', CAST(N'2002-05-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[VideoKlubOgranak] ([Id], [Adresa], [ImgUrl], [Naziv], [Opis], [Telefon], [VremeKadaJeOtvoreno]) VALUES (2, N'Tadeusa Koscuska 56', N'/images/ogranak/2.png', N'Video Klub Tralala na Dorcolu', N'Posle uspesnog starta video kluba u zemunu napravljen je klub i na Dorcolu.', N'011-514-5043', CAST(N'2004-06-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[VideoKlubOgranak] OFF
SET IDENTITY_INSERT [dbo].[Zaposleni] ON 

INSERT [dbo].[Zaposleni] ([Id], [Ime], [Sifra]) VALUES (1, N'Petar', N'admin')
INSERT [dbo].[Zaposleni] ([Id], [Ime], [Sifra]) VALUES (2, N'Mile', N'password')
SET IDENTITY_INSERT [dbo].[Zaposleni] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 06/01/2018 23:07:05 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 06/01/2018 23:07:05 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Clanovi_ClanOgrankaId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_Clanovi_ClanOgrankaId] ON [dbo].[Clanovi]
(
	[ClanOgrankaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Clanovi_ClanskaKartaId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_Clanovi_ClanskaKartaId] ON [dbo].[Clanovi]
(
	[ClanskaKartaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IstorijaIznajmljivanja_ClanskaKartaId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_IstorijaIznajmljivanja_ClanskaKartaId] ON [dbo].[IstorijaIznajmljivanja]
(
	[ClanskaKartaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IstorijaIznajmljivanja_VideoKlubAssetId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_IstorijaIznajmljivanja_VideoKlubAssetId] ON [dbo].[IstorijaIznajmljivanja]
(
	[VideoKlubAssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Iznajmljivanje_ClanskaKartaId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_Iznajmljivanje_ClanskaKartaId] ON [dbo].[Iznajmljivanje]
(
	[ClanskaKartaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Iznajmljivanje_VideoKlubAssetId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_Iznajmljivanje_VideoKlubAssetId] ON [dbo].[Iznajmljivanje]
(
	[VideoKlubAssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RadnoVreme_OgranakId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_RadnoVreme_OgranakId] ON [dbo].[RadnoVreme]
(
	[OgranakId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rezervacija_ClanskaKartaId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_Rezervacija_ClanskaKartaId] ON [dbo].[Rezervacija]
(
	[ClanskaKartaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rezervacija_VideoKlubAssetId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_Rezervacija_VideoKlubAssetId] ON [dbo].[Rezervacija]
(
	[VideoKlubAssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VideoKlubAsset_LokacijaId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_VideoKlubAsset_LokacijaId] ON [dbo].[VideoKlubAsset]
(
	[LokacijaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VideoKlubAsset_StatusId]    Script Date: 06/01/2018 23:07:05 ******/
CREATE NONCLUSTERED INDEX [IX_VideoKlubAsset_StatusId] ON [dbo].[VideoKlubAsset]
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Clanovi]  WITH CHECK ADD  CONSTRAINT [FK_Clanovi_ClanskaKarta_ClanskaKartaId] FOREIGN KEY([ClanskaKartaId])
REFERENCES [dbo].[ClanskaKarta] ([Id])
GO
ALTER TABLE [dbo].[Clanovi] CHECK CONSTRAINT [FK_Clanovi_ClanskaKarta_ClanskaKartaId]
GO
ALTER TABLE [dbo].[Clanovi]  WITH CHECK ADD  CONSTRAINT [FK_Clanovi_VideoKlubOgranak_ClanOgrankaId] FOREIGN KEY([ClanOgrankaId])
REFERENCES [dbo].[VideoKlubOgranak] ([Id])
GO
ALTER TABLE [dbo].[Clanovi] CHECK CONSTRAINT [FK_Clanovi_VideoKlubOgranak_ClanOgrankaId]
GO
ALTER TABLE [dbo].[IstorijaIznajmljivanja]  WITH CHECK ADD  CONSTRAINT [FK_IstorijaIznajmljivanja_ClanskaKarta_ClanskaKartaId] FOREIGN KEY([ClanskaKartaId])
REFERENCES [dbo].[ClanskaKarta] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IstorijaIznajmljivanja] CHECK CONSTRAINT [FK_IstorijaIznajmljivanja_ClanskaKarta_ClanskaKartaId]
GO
ALTER TABLE [dbo].[IstorijaIznajmljivanja]  WITH CHECK ADD  CONSTRAINT [FK_IstorijaIznajmljivanja_VideoKlubAsset_VideoKlubAssetId] FOREIGN KEY([VideoKlubAssetId])
REFERENCES [dbo].[VideoKlubAsset] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IstorijaIznajmljivanja] CHECK CONSTRAINT [FK_IstorijaIznajmljivanja_VideoKlubAsset_VideoKlubAssetId]
GO
ALTER TABLE [dbo].[Iznajmljivanje]  WITH CHECK ADD  CONSTRAINT [FK_Iznajmljivanje_ClanskaKarta_ClanskaKartaId] FOREIGN KEY([ClanskaKartaId])
REFERENCES [dbo].[ClanskaKarta] ([Id])
GO
ALTER TABLE [dbo].[Iznajmljivanje] CHECK CONSTRAINT [FK_Iznajmljivanje_ClanskaKarta_ClanskaKartaId]
GO
ALTER TABLE [dbo].[Iznajmljivanje]  WITH CHECK ADD  CONSTRAINT [FK_Iznajmljivanje_VideoKlubAsset_VideoKlubAssetId] FOREIGN KEY([VideoKlubAssetId])
REFERENCES [dbo].[VideoKlubAsset] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Iznajmljivanje] CHECK CONSTRAINT [FK_Iznajmljivanje_VideoKlubAsset_VideoKlubAssetId]
GO
ALTER TABLE [dbo].[RadnoVreme]  WITH CHECK ADD  CONSTRAINT [FK_RadnoVreme_VideoKlubOgranak_OgranakId] FOREIGN KEY([OgranakId])
REFERENCES [dbo].[VideoKlubOgranak] ([Id])
GO
ALTER TABLE [dbo].[RadnoVreme] CHECK CONSTRAINT [FK_RadnoVreme_VideoKlubOgranak_OgranakId]
GO
ALTER TABLE [dbo].[Rezervacija]  WITH CHECK ADD  CONSTRAINT [FK_Rezervacija_ClanskaKarta_ClanskaKartaId] FOREIGN KEY([ClanskaKartaId])
REFERENCES [dbo].[ClanskaKarta] ([Id])
GO
ALTER TABLE [dbo].[Rezervacija] CHECK CONSTRAINT [FK_Rezervacija_ClanskaKarta_ClanskaKartaId]
GO
ALTER TABLE [dbo].[Rezervacija]  WITH CHECK ADD  CONSTRAINT [FK_Rezervacija_VideoKlubAsset_VideoKlubAssetId] FOREIGN KEY([VideoKlubAssetId])
REFERENCES [dbo].[VideoKlubAsset] ([Id])
GO
ALTER TABLE [dbo].[Rezervacija] CHECK CONSTRAINT [FK_Rezervacija_VideoKlubAsset_VideoKlubAssetId]
GO
ALTER TABLE [dbo].[VideoKlubAsset]  WITH CHECK ADD  CONSTRAINT [FK_VideoKlubAsset_Status_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VideoKlubAsset] CHECK CONSTRAINT [FK_VideoKlubAsset_Status_StatusId]
GO
ALTER TABLE [dbo].[VideoKlubAsset]  WITH CHECK ADD  CONSTRAINT [FK_VideoKlubAsset_VideoKlubOgranak_LokacijaId] FOREIGN KEY([LokacijaId])
REFERENCES [dbo].[VideoKlubOgranak] ([Id])
GO
ALTER TABLE [dbo].[VideoKlubAsset] CHECK CONSTRAINT [FK_VideoKlubAsset_VideoKlubOgranak_LokacijaId]
GO
USE [master]
GO
ALTER DATABASE [BazaProjekat] SET  READ_WRITE 
GO
