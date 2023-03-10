USE [master]
GO
/****** Object:  Database [OkulYonetim]    Script Date: 8.12.2022 18:59:52 ******/
CREATE DATABASE [OkulYonetim]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OkulYonetim', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVERNEW\MSSQL\DATA\OkulYonetim.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OkulYonetim_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVERNEW\MSSQL\DATA\OkulYonetim_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OkulYonetim] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OkulYonetim].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OkulYonetim] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OkulYonetim] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OkulYonetim] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OkulYonetim] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OkulYonetim] SET ARITHABORT OFF 
GO
ALTER DATABASE [OkulYonetim] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OkulYonetim] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OkulYonetim] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OkulYonetim] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OkulYonetim] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OkulYonetim] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OkulYonetim] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OkulYonetim] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OkulYonetim] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OkulYonetim] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OkulYonetim] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OkulYonetim] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OkulYonetim] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OkulYonetim] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OkulYonetim] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OkulYonetim] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OkulYonetim] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OkulYonetim] SET RECOVERY FULL 
GO
ALTER DATABASE [OkulYonetim] SET  MULTI_USER 
GO
ALTER DATABASE [OkulYonetim] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OkulYonetim] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OkulYonetim] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OkulYonetim] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OkulYonetim] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OkulYonetim] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OkulYonetim', N'ON'
GO
ALTER DATABASE [OkulYonetim] SET QUERY_STORE = OFF
GO
USE [OkulYonetim]
GO
/****** Object:  Table [dbo].[Ders]    Script Date: 8.12.2022 18:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](30) NULL,
	[Kredisi] [varchar](4) NULL,
	[OkulYonetimId] [int] NULL,
 CONSTRAINT [PK_Ders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogrenci]    Script Date: 8.12.2022 18:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogrenci](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [varchar](30) NULL,
	[KayitTarih] [datetime2](7) NULL,
	[OgrenciNo] [varchar](11) NULL,
	[DTarih] [date] NULL,
	[Bolum] [varchar](30) NULL,
 CONSTRAINT [PK_Ogrenci] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OgrenciDers]    Script Date: 8.12.2022 18:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OgrenciDers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DersId] [int] NULL,
	[OgrenciId] [int] NULL,
 CONSTRAINT [PK_OgrenciDers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OkulYonetim]    Script Date: 8.12.2022 18:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OkulYonetim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [varchar](30) NULL,
	[Gorevi] [varchar](50) NULL,
	[YonetimTip] [int] NULL,
 CONSTRAINT [PK_OkulYonetim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ders] ON 

INSERT [dbo].[Ders] ([Id], [Ad], [Kredisi], [OkulYonetimId]) VALUES (1, N'Programlama Temelleri', N'5.5', 4)
INSERT [dbo].[Ders] ([Id], [Ad], [Kredisi], [OkulYonetimId]) VALUES (2, N'Jedi Eğitimine Giriş', N'7.5', 3)
INSERT [dbo].[Ders] ([Id], [Ad], [Kredisi], [OkulYonetimId]) VALUES (3, N'Tarih', N'2.0', 1)
INSERT [dbo].[Ders] ([Id], [Ad], [Kredisi], [OkulYonetimId]) VALUES (4, N'Roma Hukuku', N'6.0', 2)
INSERT [dbo].[Ders] ([Id], [Ad], [Kredisi], [OkulYonetimId]) VALUES (5, N'Python Giriş', N'3.0', 4)
INSERT [dbo].[Ders] ([Id], [Ad], [Kredisi], [OkulYonetimId]) VALUES (6, N'Form III Tekniğine Giriş', N'12.5', 3)
INSERT [dbo].[Ders] ([Id], [Ad], [Kredisi], [OkulYonetimId]) VALUES (7, N'Genel Veritabanı Tasarımı', N'4.0', 4)
SET IDENTITY_INSERT [dbo].[Ders] OFF
GO
SET IDENTITY_INSERT [dbo].[Ogrenci] ON 

INSERT [dbo].[Ogrenci] ([Id], [AdSoyad], [KayitTarih], [OgrenciNo], [DTarih], [Bolum]) VALUES (5, N'Sadettin Dursun', CAST(N'2022-12-07T06:10:37.0000000' AS DateTime2), N'20200108033', CAST(N'2001-07-01' AS Date), N'Bilgisayar Programcılığı')
INSERT [dbo].[Ogrenci] ([Id], [AdSoyad], [KayitTarih], [OgrenciNo], [DTarih], [Bolum]) VALUES (6, N'Abuzer Kömürcü', CAST(N'2022-12-07T06:10:37.0000000' AS DateTime2), N'20200108024', CAST(N'1960-01-01' AS Date), N'Kimya')
INSERT [dbo].[Ogrenci] ([Id], [AdSoyad], [KayitTarih], [OgrenciNo], [DTarih], [Bolum]) VALUES (7, N'Anakin Skywalker', CAST(N'2022-12-07T06:10:37.0000000' AS DateTime2), N'20200108035', CAST(N'1981-04-19' AS Date), N'Jedi Eğitim Fakültesi')
SET IDENTITY_INSERT [dbo].[Ogrenci] OFF
GO
SET IDENTITY_INSERT [dbo].[OgrenciDers] ON 

INSERT [dbo].[OgrenciDers] ([Id], [DersId], [OgrenciId]) VALUES (1, 1, 5)
INSERT [dbo].[OgrenciDers] ([Id], [DersId], [OgrenciId]) VALUES (2, 5, 5)
INSERT [dbo].[OgrenciDers] ([Id], [DersId], [OgrenciId]) VALUES (3, 3, 6)
INSERT [dbo].[OgrenciDers] ([Id], [DersId], [OgrenciId]) VALUES (4, 7, 5)
INSERT [dbo].[OgrenciDers] ([Id], [DersId], [OgrenciId]) VALUES (5, 2, 7)
SET IDENTITY_INSERT [dbo].[OgrenciDers] OFF
GO
SET IDENTITY_INSERT [dbo].[OkulYonetim] ON 

INSERT [dbo].[OkulYonetim] ([Id], [AdSoyad], [Gorevi], [YonetimTip]) VALUES (1, N'Sadettin Dursun', N'Ders Anlatmak', 12)
INSERT [dbo].[OkulYonetim] ([Id], [AdSoyad], [Gorevi], [YonetimTip]) VALUES (2, N'Recep Dursun', N'Yönetimden Sorumlu', 11)
INSERT [dbo].[OkulYonetim] ([Id], [AdSoyad], [Gorevi], [YonetimTip]) VALUES (3, N'Obi-Wan Kenobi', N'Jedi Eğitmeni', 12)
INSERT [dbo].[OkulYonetim] ([Id], [AdSoyad], [Gorevi], [YonetimTip]) VALUES (4, N'Refik Tanju Sirmen', N'Ders Anlatmak', 12)
SET IDENTITY_INSERT [dbo].[OkulYonetim] OFF
GO
ALTER TABLE [dbo].[Ders]  WITH CHECK ADD  CONSTRAINT [FK_Ders_OkulYonetim] FOREIGN KEY([OkulYonetimId])
REFERENCES [dbo].[OkulYonetim] ([Id])
GO
ALTER TABLE [dbo].[Ders] CHECK CONSTRAINT [FK_Ders_OkulYonetim]
GO
ALTER TABLE [dbo].[OgrenciDers]  WITH CHECK ADD  CONSTRAINT [FK_OgrenciDers_Ders] FOREIGN KEY([DersId])
REFERENCES [dbo].[Ders] ([Id])
GO
ALTER TABLE [dbo].[OgrenciDers] CHECK CONSTRAINT [FK_OgrenciDers_Ders]
GO
ALTER TABLE [dbo].[OgrenciDers]  WITH CHECK ADD  CONSTRAINT [FK_OgrenciDers_Ogrenci] FOREIGN KEY([OgrenciId])
REFERENCES [dbo].[Ogrenci] ([Id])
GO
ALTER TABLE [dbo].[OgrenciDers] CHECK CONSTRAINT [FK_OgrenciDers_Ogrenci]
GO
USE [master]
GO
ALTER DATABASE [OkulYonetim] SET  READ_WRITE 
GO
