USE [master]
GO
/****** Object:  Database [SMS]    Script Date: 10/8/2017 5:11:15 PM ******/
CREATE DATABASE [SMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SMS', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\SMS.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SMS_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\SMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SMS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [SMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SMS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SMS] SET  MULTI_USER 
GO
ALTER DATABASE [SMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SMS]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 10/8/2017 5:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](255) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentDetail]    Script Date: 10/8/2017 5:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentDetail](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentID] [bigint] NULL,
	[SubjectID] [int] NULL,
	[Mark] [numeric](5, 2) NULL,
 CONSTRAINT [PK_StudentDetail1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 10/8/2017 5:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StudentID], [Email], [Password]) VALUES (2, N'rana@gmail.com', N'123')
INSERT [dbo].[Student] ([StudentID], [Email], [Password]) VALUES (3, N'masud@gmail.com', N'123')
INSERT [dbo].[Student] ([StudentID], [Email], [Password]) VALUES (50010, N'checking', N'123')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[StudentDetail] ON 

INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (1, 2, 1, CAST(82.00 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (2, 2, 2, CAST(73.00 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (3, 2, 3, CAST(90.00 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (4, 2, 4, CAST(80.00 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (5, 2, 7, CAST(68.00 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (6, 2, 9, CAST(75.00 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (7, 3, 1, CAST(72.00 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (8, 3, 2, CAST(63.00 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (9, 3, 3, CAST(75.00 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (10, 3, 4, CAST(80.00 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (11, 3, 5, CAST(68.00 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (12, 3, 8, CAST(82.00 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (13, 3, 9, CAST(90.00 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (50056, 50010, 1, CAST(12.25 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (50057, 50010, 2, CAST(13.26 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (50058, 50010, 3, CAST(14.27 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (50059, 50010, 4, CAST(15.28 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (50060, 50010, 5, CAST(16.29 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (50061, 50010, 7, CAST(17.30 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (50062, 50010, 8, CAST(18.31 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (50063, 50010, 9, CAST(19.32 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (50064, 50010, 1002, CAST(20.33 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (50065, 50010, 1004, CAST(21.34 AS Numeric(5, 2)))
INSERT [dbo].[StudentDetail] ([ID], [StudentID], [SubjectID], [Mark]) VALUES (50066, 50010, 3004, CAST(22.35 AS Numeric(5, 2)))
SET IDENTITY_INSERT [dbo].[StudentDetail] OFF
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([SubjectID], [Name]) VALUES (1, N'Math')
INSERT [dbo].[Subject] ([SubjectID], [Name]) VALUES (2, N'English')
INSERT [dbo].[Subject] ([SubjectID], [Name]) VALUES (3, N'Bangla')
INSERT [dbo].[Subject] ([SubjectID], [Name]) VALUES (4, N'Physics')
INSERT [dbo].[Subject] ([SubjectID], [Name]) VALUES (5, N'Chemistry')
INSERT [dbo].[Subject] ([SubjectID], [Name]) VALUES (7, N'Botany')
INSERT [dbo].[Subject] ([SubjectID], [Name]) VALUES (8, N'Zoology')
INSERT [dbo].[Subject] ([SubjectID], [Name]) VALUES (9, N'Islamic Studies')
INSERT [dbo].[Subject] ([SubjectID], [Name]) VALUES (1002, N'Programming with C')
INSERT [dbo].[Subject] ([SubjectID], [Name]) VALUES (1004, N'Geometry')
INSERT [dbo].[Subject] ([SubjectID], [Name]) VALUES (3004, N'Higher Math')
SET IDENTITY_INSERT [dbo].[Subject] OFF
ALTER TABLE [dbo].[StudentDetail]  WITH CHECK ADD  CONSTRAINT [FK_StudentDetail1_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentDetail] CHECK CONSTRAINT [FK_StudentDetail1_Student]
GO
ALTER TABLE [dbo].[StudentDetail]  WITH CHECK ADD  CONSTRAINT [FK_StudentDetail1_Subject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([SubjectID])
GO
ALTER TABLE [dbo].[StudentDetail] CHECK CONSTRAINT [FK_StudentDetail1_Subject]
GO
USE [master]
GO
ALTER DATABASE [SMS] SET  READ_WRITE 
GO
