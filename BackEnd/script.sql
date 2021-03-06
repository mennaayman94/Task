USE [QualityStandard]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/8/2021 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[StdId] [int] IDENTITY(1,1) NOT NULL,
	[StdName] [varchar](255) NOT NULL,
	[Mail] [varchar](255) NOT NULL,
	[TeacherId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 3/8/2021 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](255) NOT NULL,
	[Specification] [varchar](255) NOT NULL,
	[Mail] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StdId], [StdName], [Mail], [TeacherId]) VALUES (1, N'Merna Mohamed', N'merna@mail.com', 4)
INSERT [dbo].[Student] ([StdId], [StdName], [Mail], [TeacherId]) VALUES (2, N'Esraa Mohamed', N'Esraa@mail.com', 2)
INSERT [dbo].[Student] ([StdId], [StdName], [Mail], [TeacherId]) VALUES (4, N'Soha ahmed', N'Soha@gmail.com', 2)
INSERT [dbo].[Student] ([StdId], [StdName], [Mail], [TeacherId]) VALUES (8, N'ALya Mohamed', N'Alya@mail.com', 3)
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [Specification], [Mail]) VALUES (2, N'Esraa Nabil', N'English', N'Esraa@mail.com')
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [Specification], [Mail]) VALUES (3, N'Ayman', N'Science', N'Ayman@mail.com')
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [Specification], [Mail]) VALUES (4, N'Marihan ', N'Math', N'Marihan@mail.com')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
ON DELETE SET NULL
GO
