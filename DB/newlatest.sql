USE [master]
GO
/****** Object:  Database [QuestionPaperGenration]    Script Date: 04/20/2018 21:03:45 ******/
CREATE DATABASE [QuestionPaperGenration] ON  PRIMARY 
( NAME = N'QuestionPaperGenration', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\QuestionPaperGenration.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuestionPaperGenration_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\QuestionPaperGenration_log.LDF' , SIZE = 504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuestionPaperGenration] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuestionPaperGenration].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuestionPaperGenration] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET ANSI_NULLS OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET ANSI_PADDING OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET ARITHABORT OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [QuestionPaperGenration] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [QuestionPaperGenration] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [QuestionPaperGenration] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET  ENABLE_BROKER
GO
ALTER DATABASE [QuestionPaperGenration] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [QuestionPaperGenration] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [QuestionPaperGenration] SET  READ_WRITE
GO
ALTER DATABASE [QuestionPaperGenration] SET RECOVERY FULL
GO
ALTER DATABASE [QuestionPaperGenration] SET  MULTI_USER
GO
ALTER DATABASE [QuestionPaperGenration] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [QuestionPaperGenration] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuestionPaperGenration', N'ON'
GO
USE [QuestionPaperGenration]
GO
/****** Object:  Table [dbo].[TempData]    Script Date: 04/20/2018 21:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionName] [nvarchar](max) NULL,
	[LId] [int] NULL,
	[SubId] [nvarchar](50) NULL,
	[QsId] [int] NULL,
	[SetNo] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TempData] ON
INSERT [dbo].[TempData] ([id], [QuestionName], [LId], [SubId], [QsId], [SetNo]) VALUES (1, N'A', 3, N'2', 1, 1)
INSERT [dbo].[TempData] ([id], [QuestionName], [LId], [SubId], [QsId], [SetNo]) VALUES (2, N'V', 1, N'2', 3, 1)
INSERT [dbo].[TempData] ([id], [QuestionName], [LId], [SubId], [QsId], [SetNo]) VALUES (3, N'A1', 3, N'2', 4, 1)
SET IDENTITY_INSERT [dbo].[TempData] OFF
/****** Object:  Table [dbo].[Subject_Master]    Script Date: 04/20/2018 21:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject_Master](
	[SubId] [int] IDENTITY(1,1) NOT NULL,
	[SubName] [nvarchar](100) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Subject_Master] ON
INSERT [dbo].[Subject_Master] ([SubId], [SubName]) VALUES (1, N'Artificial intelligence')
INSERT [dbo].[Subject_Master] ([SubId], [SubName]) VALUES (2, N'Cryptography')
INSERT [dbo].[Subject_Master] ([SubId], [SubName]) VALUES (3, N'Soft Computing')
INSERT [dbo].[Subject_Master] ([SubId], [SubName]) VALUES (4, N'DSP')
INSERT [dbo].[Subject_Master] ([SubId], [SubName]) VALUES (5, N'PDS')
INSERT [dbo].[Subject_Master] ([SubId], [SubName]) VALUES (6, N'HMI')
INSERT [dbo].[Subject_Master] ([SubId], [SubName]) VALUES (7, N'Digital Forencics')
INSERT [dbo].[Subject_Master] ([SubId], [SubName]) VALUES (8, N'DWN')
INSERT [dbo].[Subject_Master] ([SubId], [SubName]) VALUES (9, N'SPCC')
INSERT [dbo].[Subject_Master] ([SubId], [SubName]) VALUES (10, N'MCC')
SET IDENTITY_INSERT [dbo].[Subject_Master] OFF
/****** Object:  Table [dbo].[QuestionSection]    Script Date: 04/20/2018 21:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionSection](
	[QsId] [int] IDENTITY(1,1) NOT NULL,
	[Marks] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[QuestionSection] ON
INSERT [dbo].[QuestionSection] ([QsId], [Marks]) VALUES (1, 2)
INSERT [dbo].[QuestionSection] ([QsId], [Marks]) VALUES (3, 5)
INSERT [dbo].[QuestionSection] ([QsId], [Marks]) VALUES (4, 10)
SET IDENTITY_INSERT [dbo].[QuestionSection] OFF
/****** Object:  Table [dbo].[Login]    Script Date: 04/20/2018 21:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[UId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Login] ON
INSERT [dbo].[Login] ([UId], [Username], [Password]) VALUES (1, N'Admin', N'admin')
SET IDENTITY_INSERT [dbo].[Login] OFF
/****** Object:  Table [dbo].[Level_Master]    Script Date: 04/20/2018 21:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level_Master](
	[LId] [int] IDENTITY(1,1) NOT NULL,
	[LevelName] [nvarchar](100) NULL,
	[Level] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Level_Master] ON
INSERT [dbo].[Level_Master] ([LId], [LevelName], [Level]) VALUES (1, N'High', 3)
INSERT [dbo].[Level_Master] ([LId], [LevelName], [Level]) VALUES (2, N'Medium ', 2)
INSERT [dbo].[Level_Master] ([LId], [LevelName], [Level]) VALUES (3, N'Low', 1)
SET IDENTITY_INSERT [dbo].[Level_Master] OFF
/****** Object:  Table [dbo].[Faculty_Master]    Script Date: 04/20/2018 21:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty_Master](
	[FId] [int] IDENTITY(1,1) NOT NULL,
	[FacultyName] [nvarchar](100) NULL,
	[PhoneNo] [nvarchar](50) NULL,
	[EmailId] [nvarchar](100) NULL,
	[SubId] [int] NULL,
	[Password] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Faculty_Master] ON
INSERT [dbo].[Faculty_Master] ([FId], [FacultyName], [PhoneNo], [EmailId], [SubId], [Password]) VALUES (1, N'Computer Sci', N'9484845645', N'ComputerSci@gmail.com', 2, N'12345')
INSERT [dbo].[Faculty_Master] ([FId], [FacultyName], [PhoneNo], [EmailId], [SubId], [Password]) VALUES (2, N'IT', N'9632587410', N'ITDepartment@gmail.com', 4, N'123456')
INSERT [dbo].[Faculty_Master] ([FId], [FacultyName], [PhoneNo], [EmailId], [SubId], [Password]) VALUES (3, N'sdfsd', N'919892369017', N'chintan@gmail.com', 1, N'chintan')
SET IDENTITY_INSERT [dbo].[Faculty_Master] OFF
/****** Object:  Table [dbo].[QuestionBank]    Script Date: 04/20/2018 21:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionBank](
	[QId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionName] [nvarchar](max) NULL,
	[LId] [int] NULL,
	[SubId] [int] NULL,
	[FId] [int] NULL,
	[QsId] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[QuestionBank] ON
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (1, N'A', 1, 2, 1, 1)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (3, N'CM', 2, 8, 2, 4)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (4, N'D', 1, 2, 1, 1)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (5, N'E', 1, 2, 1, 1)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (6, N'F', 1, 2, 1, 2)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (7, N'G', 1, 2, 1, 3)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (8, N'H', 1, 2, 1, 4)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (9, N'I', 1, 2, 1, 1)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (10, N'J', 1, 2, 1, 2)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (11, N'K', 1, 2, 1, 3)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (12, N'L', 1, 2, 1, 4)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (13, N'M', 2, 2, 1, 1)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (14, N'N', 3, 2, 1, 1)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (15, N'O', 1, 2, 1, 1)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (16, N'P', 3, 2, 1, 1)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (17, N'Q', 1, 2, 1, 1)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (18, N'R', 2, 2, 1, 2)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (19, N'S', 1, 2, 1, 2)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (20, N'T', 2, 2, 1, 2)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (21, N'U', 1, 2, 1, 2)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (22, N'V', 3, 2, 1, 3)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (23, N'W', 1, 2, 1, 3)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (24, N'X', 2, 2, 1, 3)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (25, N'Y', 1, 2, 1, 3)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (26, N'X', 2, 2, 1, 3)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (27, N'A1', 1, 2, 1, 4)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (28, N'B1', 3, 2, 1, 4)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (29, N'C1', 2, 2, 1, 4)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (30, N'D1', 2, 2, 1, 4)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (31, N'E1', 2, 1, 1, 2)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (32, N'What is Soft Computing?', 3, 3, 1, 3)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (33, N'What is AI?', 1, 1, 1, 4)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (34, N'How to Find Out Signal?', 1, 4, 2, 1)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (35, N'What Digital Processing?', 1, 4, 2, 2)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (36, N'Describe Derivation?', 1, 4, 2, 3)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (37, N'DSP in Brif?', 1, 4, 2, 4)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (38, N'DSP?', 2, 4, 2, 4)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (39, N'MCI', 3, 4, 2, 3)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (40, N'LMN?', 1, 1, 1, 2)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (41, N'bvdffdg', 3, 1, 1, 2)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (42, N'vfsdvgf', 2, 1, 1, 1)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (43, N'gvsgvfdsg', 3, 1, 1, 3)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (44, N'sfsdf', 3, 1, 1, 4)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (45, N'fdgdfgdf', 1, 2, 1, 1)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (46, N'fgfdgf', 3, 2, 1, 2)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (47, N'fbbcvb', 1, 2, 1, 3)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (48, N'gfdgdf', 3, 2, 1, 4)
INSERT [dbo].[QuestionBank] ([QId], [QuestionName], [LId], [SubId], [FId], [QsId]) VALUES (49, N'WHAT is ML?', 1, 1, 1, 4)
SET IDENTITY_INSERT [dbo].[QuestionBank] OFF
/****** Object:  StoredProcedure [dbo].[Questinmark]    Script Date: 04/20/2018 21:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Questinmark]
as begin
Select T.*,QM.Marks,S.SubName from TempData T join QuestionSection QM on T.QsId=QM.QsId
join Subject_Master S on T.SubId=S.SubId where Marks=2
end
GO
/****** Object:  StoredProcedure [dbo].[QuestionDetails]    Script Date: 04/20/2018 21:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[QuestionDetails]
(
@SetNo int
)
As Begin 
Select T.*,QM.Marks,S.SubName from TempData T join QuestionSection QM on T.QsId=QM.QsId
join Subject_Master S on T.SubId=S.SubId where SetNo=@SetNo
End
GO
