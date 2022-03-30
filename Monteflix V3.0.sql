USE [master]
GO
/****** Object:  Database [Monteflix]    Script Date: 3/30/2022 12:26:20 PM ******/
CREATE DATABASE [Monteflix]
GO
ALTER DATABASE [Monteflix] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Monteflix].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Monteflix] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Monteflix] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Monteflix] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Monteflix] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Monteflix] SET ARITHABORT OFF 
GO
ALTER DATABASE [Monteflix] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Monteflix] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Monteflix] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Monteflix] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Monteflix] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Monteflix] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Monteflix] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Monteflix] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Monteflix] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Monteflix] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Monteflix] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Monteflix] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Monteflix] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Monteflix] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Monteflix] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Monteflix] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Monteflix] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Monteflix] SET RECOVERY FULL 
GO
ALTER DATABASE [Monteflix] SET  MULTI_USER 
GO
ALTER DATABASE [Monteflix] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Monteflix] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Monteflix] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Monteflix] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Monteflix] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Monteflix] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Monteflix', N'ON'
GO
ALTER DATABASE [Monteflix] SET QUERY_STORE = OFF
GO
USE [Monteflix]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 3/30/2022 12:26:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Movie_ID] [int] IDENTITY(1,1) NOT NULL,
	[Movie_Title] [varchar](50) NOT NULL,
	[Movie_Release] [int] NOT NULL,
	[Movie_Genre] [varchar](50) NOT NULL,
	[Movie_Trailer] [varchar](100) NULL,
	[Movie_Image] [varchar](100) NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Movie_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/30/2022 12:26:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [varchar](50) NOT NULL,
	[User_Email] [varchar](50) NOT NULL,
	[User_Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users_Movies]    Script Date: 3/30/2022 12:26:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_Movies](
	[Users_Movies_ID] [int] IDENTITY(1,1) NOT NULL,
	[FUser_ID] [int] NOT NULL,
	[FMovie_ID] [int] NOT NULL,
	[Users_Movies_Review] [varchar](50) NULL,
 CONSTRAINT [PK_Users_Movies] PRIMARY KEY CLUSTERED 
(
	[Users_Movies_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 
GO
INSERT [dbo].[Movies] ([Movie_ID], [Movie_Title], [Movie_Release], [Movie_Genre], [Movie_Trailer], [Movie_Image]) VALUES (1, N'Goodfellas ', 1991, N'Action, Mafia', N'https://www.youtube.com/watch?v=qo5jJpHtI1Y', N'C:\Users\User\Desktop\Images\Goodfellas.jpg')
GO
INSERT [dbo].[Movies] ([Movie_ID], [Movie_Title], [Movie_Release], [Movie_Genre], [Movie_Trailer], [Movie_Image]) VALUES (2, N'Avengers', 2019, N'Adventure', N'https://www.youtube.com/watch?v=eOrNdBpGMv8', N'C:\Users\User\Desktop\Images\Avengers.jpg')
GO
INSERT [dbo].[Movies] ([Movie_ID], [Movie_Title], [Movie_Release], [Movie_Genre], [Movie_Trailer], [Movie_Image]) VALUES (3, N'Spiderman-Miles Morales', 2021, N'Action', N'https://www.youtube.com/watch?v=JfVOs4VSpmA&t=16s', N'C:\Users\User\Desktop\Images\Spiderman.jpg')
GO
INSERT [dbo].[Movies] ([Movie_ID], [Movie_Title], [Movie_Release], [Movie_Genre], [Movie_Trailer], [Movie_Image]) VALUES (4, N'The Incredible Hulk', 2011, N'Thriller', N'https://www.youtube.com/watch?v=xbqNb2PFKKA', N'C:\Users\User\Desktop\Images\Hulk.jpg')
GO
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([User_ID], [User_Name], [User_Email], [User_Password]) VALUES (1, N'John', N'john@gmail.com', N'john123')
GO
INSERT [dbo].[Users] ([User_ID], [User_Name], [User_Email], [User_Password]) VALUES (2, N'Smith', N'smith@gmail.com', N'smith123')
GO
INSERT [dbo].[Users] ([User_ID], [User_Name], [User_Email], [User_Password]) VALUES (3, N'Rod', N'rod@gmail.com', N'rod123')
GO
INSERT [dbo].[Users] ([User_ID], [User_Name], [User_Email], [User_Password]) VALUES (5, N'Stewart', N'stewart@gmail.com', N'stewart123')
GO
INSERT [dbo].[Users] ([User_ID], [User_Name], [User_Email], [User_Password]) VALUES (6, N'Sarah', N'sarah@gmail.com', N'sarah123')
GO
INSERT [dbo].[Users] ([User_ID], [User_Name], [User_Email], [User_Password]) VALUES (7, N'Smile', N'smile@gmail.com', N'smile123')
GO
INSERT [dbo].[Users] ([User_ID], [User_Name], [User_Email], [User_Password]) VALUES (8, N'Admin', N'monteflix.admin@gmail.com', N'admin123')
GO
INSERT [dbo].[Users] ([User_ID], [User_Name], [User_Email], [User_Password]) VALUES (14, N'Helper', N'helper@gmail.com', N'helper123')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Users_Movies] ON 
GO
INSERT [dbo].[Users_Movies] ([Users_Movies_ID], [FUser_ID], [FMovie_ID], [Users_Movies_Review]) VALUES (1, 6, 2, N'Very Good')
GO
INSERT [dbo].[Users_Movies] ([Users_Movies_ID], [FUser_ID], [FMovie_ID], [Users_Movies_Review]) VALUES (2, 6, 3, N'Bad')
GO
INSERT [dbo].[Users_Movies] ([Users_Movies_ID], [FUser_ID], [FMovie_ID], [Users_Movies_Review]) VALUES (3, 3, 1, N'Very Good')
GO
INSERT [dbo].[Users_Movies] ([Users_Movies_ID], [FUser_ID], [FMovie_ID], [Users_Movies_Review]) VALUES (4, 3, 4, N'Good')
GO
INSERT [dbo].[Users_Movies] ([Users_Movies_ID], [FUser_ID], [FMovie_ID], [Users_Movies_Review]) VALUES (5, 6, 1, N'Very Good')
GO
INSERT [dbo].[Users_Movies] ([Users_Movies_ID], [FUser_ID], [FMovie_ID], [Users_Movies_Review]) VALUES (6, 6, 4, N'Very Good')
GO
INSERT [dbo].[Users_Movies] ([Users_Movies_ID], [FUser_ID], [FMovie_ID], [Users_Movies_Review]) VALUES (7, 3, 2, N'Bad')
GO
INSERT [dbo].[Users_Movies] ([Users_Movies_ID], [FUser_ID], [FMovie_ID], [Users_Movies_Review]) VALUES (8, 14, 4, N'Good')
GO
INSERT [dbo].[Users_Movies] ([Users_Movies_ID], [FUser_ID], [FMovie_ID], [Users_Movies_Review]) VALUES (9, 14, 1, N'Very Good')
GO
INSERT [dbo].[Users_Movies] ([Users_Movies_ID], [FUser_ID], [FMovie_ID], [Users_Movies_Review]) VALUES (10, 14, 2, N'Good')
GO
INSERT [dbo].[Users_Movies] ([Users_Movies_ID], [FUser_ID], [FMovie_ID], [Users_Movies_Review]) VALUES (11, 14, 3, N'Bad')
GO
INSERT [dbo].[Users_Movies] ([Users_Movies_ID], [FUser_ID], [FMovie_ID], [Users_Movies_Review]) VALUES (12, 7, 1, N'Bad')
GO
SET IDENTITY_INSERT [dbo].[Users_Movies] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20220327-220243]    Script Date: 3/30/2022 12:26:20 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20220327-220243] ON [dbo].[Users]
(
	[User_Name] ASC,
	[User_Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users_Movies]  WITH CHECK ADD  CONSTRAINT [FK_Users_Movies_Movies] FOREIGN KEY([FMovie_ID])
REFERENCES [dbo].[Movies] ([Movie_ID])
GO
ALTER TABLE [dbo].[Users_Movies] CHECK CONSTRAINT [FK_Users_Movies_Movies]
GO
ALTER TABLE [dbo].[Users_Movies]  WITH CHECK ADD  CONSTRAINT [FK_Users_Movies_Users] FOREIGN KEY([FUser_ID])
REFERENCES [dbo].[Users] ([User_ID])
GO
ALTER TABLE [dbo].[Users_Movies] CHECK CONSTRAINT [FK_Users_Movies_Users]
GO
USE [master]
GO
ALTER DATABASE [Monteflix] SET  READ_WRITE 
GO
