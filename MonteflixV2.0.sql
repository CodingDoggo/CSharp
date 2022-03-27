USE [master]
GO
/****** Object:  Database [Monteflix]    Script Date: 3/27/2022 10:25:37 PM ******/
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
/****** Object:  Table [dbo].[Movies]    Script Date: 3/27/2022 10:25:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Movie_ID] [int] IDENTITY(1,1) NOT NULL,
	[Movie_Title] [varchar](50) NOT NULL,
	[Movie_Release] [int] NOT NULL,
	[Movie_Genre] [varchar](50) NOT NULL,
	[Movie_Review] [varchar](50) NULL,
	[Movie_Trailer] [varchar](100) NULL,
	[Movie_Image] [varchar](100) NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Movie_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/27/2022 10:25:38 PM ******/
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
SET IDENTITY_INSERT [dbo].[Movies] ON 
GO
INSERT [dbo].[Movies] ([Movie_ID], [Movie_Title], [Movie_Release], [Movie_Genre], [Movie_Review], [Movie_Trailer], [Movie_Image]) VALUES (1, N'Batman', 2022, N'Action', N'Very Good', N'https://www.youtube.com/watch?v=mqqft2x_Aa4', N'C:\Users\User\Desktop\Images\Batman.jpg')
GO
INSERT [dbo].[Movies] ([Movie_ID], [Movie_Title], [Movie_Release], [Movie_Genre], [Movie_Review], [Movie_Trailer], [Movie_Image]) VALUES (2, N'Avengers', 2019, N'Adventure', N'Very Good', N'https://www.youtube.com/watch?v=eOrNdBpGMv8', N'C:\Users\User\Desktop\Images\Avengers.jpg')
GO
INSERT [dbo].[Movies] ([Movie_ID], [Movie_Title], [Movie_Release], [Movie_Genre], [Movie_Review], [Movie_Trailer], [Movie_Image]) VALUES (3, N'Spiderman', 2021, N'Action', N'Very Good', N'https://www.youtube.com/watch?v=JfVOs4VSpmA&t=16s', N'C:\Users\User\Desktop\Images\Spiderman.jpg')
GO
INSERT [dbo].[Movies] ([Movie_ID], [Movie_Title], [Movie_Release], [Movie_Genre], [Movie_Review], [Movie_Trailer], [Movie_Image]) VALUES (4, N'The Incredible Hulk', 2011, N'Thriller', N'Bad', N'https://www.youtube.com/watch?v=xbqNb2PFKKA', N'C:\Users\User\Desktop\Images\Hulk.jpg')
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
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20220327-220243]    Script Date: 3/27/2022 10:25:38 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20220327-220243] ON [dbo].[Users]
(
	[User_Name] ASC,
	[User_Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Monteflix] SET  READ_WRITE 
GO
