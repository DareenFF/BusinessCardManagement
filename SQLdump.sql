USE [BusinessCardDb]
GO
/****** Object:  Table [dbo].[BusinessCards]    Script Date: 10/15/2024 10:36:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[DOB] [date] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Photo] [varbinary](max) NULL,
 CONSTRAINT [PK_BusinessCards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BusinessCards] ON 

INSERT [dbo].[BusinessCards] ([Id], [Name], [Gender], [DOB], [Email], [Phone], [Address], [Photo]) VALUES (1036, N'Dareen Fraihat', N'Female', CAST(N'2001-07-04' AS Date), N'dareenfraihat21@gmail.com', N'0791487616', N'Amman,Jordan', NULL)
INSERT [dbo].[BusinessCards] ([Id], [Name], [Gender], [DOB], [Email], [Phone], [Address], [Photo]) VALUES (1037, N'Ahmad Omar', N'Male', CAST(N'2000-01-07' AS Date), N'Ahmad@gmail.com', N'0782233901', N'Jerash -Jordan', NULL)
INSERT [dbo].[BusinessCards] ([Id], [Name], [Gender], [DOB], [Email], [Phone], [Address], [Photo]) VALUES (1038, N'john', N'Male', CAST(N'1985-05-12' AS Date), N'john.doe@example.com', N'0791234567', N'new york', NULL)
INSERT [dbo].[BusinessCards] ([Id], [Name], [Gender], [DOB], [Email], [Phone], [Address], [Photo]) VALUES (1039, N'jane', N'Female', CAST(N'1992-08-20' AS Date), N'jane.doe@example.com', N'0799876543', N'london', NULL)
INSERT [dbo].[BusinessCards] ([Id], [Name], [Gender], [DOB], [Email], [Phone], [Address], [Photo]) VALUES (1040, N'omar', N'Male', CAST(N'1995-11-15' AS Date), N'omar99@gmail.com', N'0795551234', N'dubai', NULL)
INSERT [dbo].[BusinessCards] ([Id], [Name], [Gender], [DOB], [Email], [Phone], [Address], [Photo]) VALUES (1041, N'layla', N'Female', CAST(N'2000-04-18' AS Date), N'layla.khan@yahoo.com', N'0792244668', N'mumbai', NULL)
INSERT [dbo].[BusinessCards] ([Id], [Name], [Gender], [DOB], [Email], [Phone], [Address], [Photo]) VALUES (1042, N'ahmad', N'Male', CAST(N'1989-12-01' AS Date), N'ahmad.hassan@gmail.com', N'0796655443', N'amman', NULL)
INSERT [dbo].[BusinessCards] ([Id], [Name], [Gender], [DOB], [Email], [Phone], [Address], [Photo]) VALUES (1043, N'sara', N'Female', CAST(N'1997-09-10' AS Date), N'sara.smith@outlook.com', N'0791122334', N'toronto', NULL)
INSERT [dbo].[BusinessCards] ([Id], [Name], [Gender], [DOB], [Email], [Phone], [Address], [Photo]) VALUES (1044, N'michael', N'Male', CAST(N'1987-02-25' AS Date), N'michael.jordan@nba.com', N'0795566778', N'london', NULL)
INSERT [dbo].[BusinessCards] ([Id], [Name], [Gender], [DOB], [Email], [Phone], [Address], [Photo]) VALUES (1045, N'fatima', N'Female', CAST(N'1993-06-30' AS Date), N'fatima.ali@hotmail.com', N'0799988776', N'cairo', NULL)
INSERT [dbo].[BusinessCards] ([Id], [Name], [Gender], [DOB], [Email], [Phone], [Address], [Photo]) VALUES (1046, N'ali', N'Male', CAST(N'1990-10-05' AS Date), N'ali.khan@gmail.com', N'0794433221', N'doha', NULL)
INSERT [dbo].[BusinessCards] ([Id], [Name], [Gender], [DOB], [Email], [Phone], [Address], [Photo]) VALUES (1047, N'noor', N'Female', CAST(N'1998-07-22' AS Date), N'noor.farah@gmail.com', N'0797788990', N'kuwait', NULL)
SET IDENTITY_INSERT [dbo].[BusinessCards] OFF
GO
