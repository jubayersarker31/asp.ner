USE [LoginDB]
GO
/****** Object:  Table [dbo].[tblComment2]    Script Date: 5/18/2020 5:51:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblComment2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NULL,
	[CommentText] [nvarchar](max) NULL,
	[UserID] [int] NULL,
	[DateTime] [nvarchar](max) NULL,
	[UserName] [varchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLike]    Script Date: 5/18/2020 5:51:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLike](
	[ID] [int] NOT NULL,
	[CommentId] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[isLike] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPostText]    Script Date: 5/18/2020 5:51:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPostText](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PostText] [nvarchar](max) NULL,
	[UserId] [varchar](255) NULL,
	[Date] [nvarchar](50) NULL,
	[UserName] [varchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 5/18/2020 5:51:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [int] NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](250) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblPostText] ON 

INSERT [dbo].[tblPostText] ([ID], [PostText], [UserId], [Date], [UserName]) VALUES (3, N'@PostText', N'@UserId', N'@Date', NULL)
INSERT [dbo].[tblPostText] ([ID], [PostText], [UserId], [Date], [UserName]) VALUES (4, N'@PostText', N'@UserId', N'@Date', NULL)
INSERT [dbo].[tblPostText] ([ID], [PostText], [UserId], [Date], [UserName]) VALUES (5, N'i am user 1', N'1', N'5/18/2020 12:00:00 AM', NULL)
SET IDENTITY_INSERT [dbo].[tblPostText] OFF
GO
INSERT [dbo].[tblUser] ([UserID], [UserName], [Password]) VALUES (1, N'User1', N'123')
INSERT [dbo].[tblUser] ([UserID], [UserName], [Password]) VALUES (2, N'User2', N'234')
GO
