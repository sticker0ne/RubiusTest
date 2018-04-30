USE [master]
GO
/****** Object:  Database [MusicService]    Script Date: 01.05.2018 1:33:35 ******/
CREATE DATABASE [MusicService]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MusicService', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MusicService.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MusicService_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MusicService_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MusicService] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MusicService].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MusicService] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MusicService] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MusicService] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MusicService] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MusicService] SET ARITHABORT OFF 
GO
ALTER DATABASE [MusicService] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MusicService] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MusicService] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MusicService] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MusicService] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MusicService] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MusicService] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MusicService] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MusicService] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MusicService] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MusicService] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MusicService] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MusicService] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MusicService] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MusicService] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MusicService] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MusicService] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MusicService] SET RECOVERY FULL 
GO
ALTER DATABASE [MusicService] SET  MULTI_USER 
GO
ALTER DATABASE [MusicService] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MusicService] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MusicService] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MusicService] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MusicService] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MusicService', N'ON'
GO
ALTER DATABASE [MusicService] SET QUERY_STORE = OFF
GO
USE [MusicService]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
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
USE [MusicService]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 01.05.2018 1:33:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ReleaseYear] [date] NOT NULL,
	[MusicianId] [bigint] NOT NULL,
 CONSTRAINT [Unique_Identifier2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 01.05.2018 1:33:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [Unique_Identifier4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MusicianGenres]    Script Date: 01.05.2018 1:33:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MusicianGenres](
	[MusicianId] [bigint] NOT NULL,
	[GenreId] [bigint] NOT NULL,
 CONSTRAINT [Unique_Identifier8] PRIMARY KEY CLUSTERED 
(
	[MusicianId] ASC,
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musicians]    Script Date: 01.05.2018 1:33:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musicians](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[CareerStartYear] [date] NOT NULL,
 CONSTRAINT [Unique_Identifier3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tracks]    Script Date: 01.05.2018 1:33:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tracks](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Duration] [bigint] NOT NULL,
	[AlbumId] [bigint] NOT NULL,
 CONSTRAINT [Unique_Identifier1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserFavorite]    Script Date: 01.05.2018 1:33:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFavorite](
	[UserId] [uniqueidentifier] NOT NULL,
	[TrackId] [bigint] NOT NULL,
 CONSTRAINT [Unique_Identifier7] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserListened]    Script Date: 01.05.2018 1:33:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserListened](
	[UserId] [uniqueidentifier] NOT NULL,
	[TrackId] [bigint] NOT NULL,
 CONSTRAINT [Unique_Identifier6] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01.05.2018 1:33:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[Male] [bit] NULL,
 CONSTRAINT [Unique_Identifier5] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersLikes]    Script Date: 01.05.2018 1:33:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersLikes](
	[UserId] [uniqueidentifier] NOT NULL,
	[TrackId] [bigint] NOT NULL,
	[IsLike] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Relationship1]    Script Date: 01.05.2018 1:33:36 ******/
CREATE NONCLUSTERED INDEX [IX_Relationship1] ON [dbo].[Albums]
(
	[MusicianId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Relationship2]    Script Date: 01.05.2018 1:33:36 ******/
CREATE NONCLUSTERED INDEX [IX_Relationship2] ON [dbo].[Tracks]
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__Id__70DDC3D8]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [Relationship1] FOREIGN KEY([MusicianId])
REFERENCES [dbo].[Musicians] ([Id])
GO
ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [Relationship1]
GO
ALTER TABLE [dbo].[MusicianGenres]  WITH CHECK ADD  CONSTRAINT [Relationship3] FOREIGN KEY([MusicianId])
REFERENCES [dbo].[Musicians] ([Id])
GO
ALTER TABLE [dbo].[MusicianGenres] CHECK CONSTRAINT [Relationship3]
GO
ALTER TABLE [dbo].[MusicianGenres]  WITH CHECK ADD  CONSTRAINT [Relationship4] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[MusicianGenres] CHECK CONSTRAINT [Relationship4]
GO
ALTER TABLE [dbo].[Tracks]  WITH CHECK ADD  CONSTRAINT [Relationship2] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Albums] ([Id])
GO
ALTER TABLE [dbo].[Tracks] CHECK CONSTRAINT [Relationship2]
GO
ALTER TABLE [dbo].[UserFavorite]  WITH CHECK ADD  CONSTRAINT [Relationship6] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserFavorite] CHECK CONSTRAINT [Relationship6]
GO
ALTER TABLE [dbo].[UserFavorite]  WITH CHECK ADD  CONSTRAINT [Relationship8] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Tracks] ([Id])
GO
ALTER TABLE [dbo].[UserFavorite] CHECK CONSTRAINT [Relationship8]
GO
ALTER TABLE [dbo].[UserListened]  WITH CHECK ADD  CONSTRAINT [Relationship5] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserListened] CHECK CONSTRAINT [Relationship5]
GO
ALTER TABLE [dbo].[UserListened]  WITH CHECK ADD  CONSTRAINT [Relationship7] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Tracks] ([Id])
GO
ALTER TABLE [dbo].[UserListened] CHECK CONSTRAINT [Relationship7]
GO
ALTER TABLE [dbo].[UsersLikes]  WITH CHECK ADD  CONSTRAINT [FK_usersLikes_Tracks] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Tracks] ([Id])
GO
ALTER TABLE [dbo].[UsersLikes] CHECK CONSTRAINT [FK_usersLikes_Tracks]
GO
ALTER TABLE [dbo].[UsersLikes]  WITH CHECK ADD  CONSTRAINT [FK_usersLikes_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UsersLikes] CHECK CONSTRAINT [FK_usersLikes_Users]
GO
USE [master]
GO
ALTER DATABASE [MusicService] SET  READ_WRITE 
GO
