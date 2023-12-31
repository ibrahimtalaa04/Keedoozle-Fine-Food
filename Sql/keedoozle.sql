USE [master]
GO
/****** Object:  Database [keedoozle]    Script Date: 5/8/2023 9:38:20 PM ******/
CREATE DATABASE [keedoozle]
GO
ALTER DATABASE [keedoozle] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [keedoozle].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [keedoozle] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [keedoozle] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [keedoozle] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [keedoozle] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [keedoozle] SET ARITHABORT OFF 
GO
ALTER DATABASE [keedoozle] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [keedoozle] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [keedoozle] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [keedoozle] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [keedoozle] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [keedoozle] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [keedoozle] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [keedoozle] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [keedoozle] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [keedoozle] SET  DISABLE_BROKER 
GO
ALTER DATABASE [keedoozle] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [keedoozle] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [keedoozle] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [keedoozle] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [keedoozle] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [keedoozle] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [keedoozle] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [keedoozle] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [keedoozle] SET  MULTI_USER 
GO
ALTER DATABASE [keedoozle] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [keedoozle] SET DB_CHAINING OFF 
GO
ALTER DATABASE [keedoozle] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [keedoozle] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [keedoozle] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [keedoozle] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'keedoozle', N'ON'
GO
ALTER DATABASE [keedoozle] SET QUERY_STORE = OFF
GO
USE [keedoozle]
GO
/****** Object:  Table [dbo].[food_order]    Script Date: 5/18/2023 8:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[food_order](
	[discount] [float] NULL,
	[subTotal] [float] NULL,
	[tax] [float] NULL,
	[grandTotal] [float] NULL,
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[date_created] [datetime] NULL,
 CONSTRAINT [PK_food_order] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[item]    Script Date: 5/18/2023 8:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [float] NOT NULL,
	[item_category_id] [int] NOT NULL,
	[tax] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[item_categories]    Script Date: 5/18/2023 8:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[item_categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_items]    Script Date: 5/18/2023 8:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_items](
	[order_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[comments] [varchar](200) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[food_order] ON 

INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 100, 0, 100, 1, CAST(N'2021-05-14T18:07:24.060' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 20, 0, 20, 2, CAST(N'2021-05-14T18:12:57.770' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 720, 7.5, 727.5, 3, CAST(N'2021-05-14T18:28:18.613' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 240, 0, 240, 4, CAST(N'2021-05-16T00:33:11.317' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 40, 0, 40, 5, CAST(N'2021-05-16T00:36:43.320' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 40, 0, 40, 6, CAST(N'2021-05-16T00:37:28.610' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 20, 0, 20, 7, CAST(N'2021-05-16T14:30:07.510' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 100, 0, 100, 8, CAST(N'2021-05-16T15:17:55.690' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 120, 0, 120, 9, CAST(N'2021-05-16T15:23:04.717' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 100, 0, 100, 10, CAST(N'2021-05-16T16:23:03.740' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 100, 0, 100, 11, CAST(N'2021-05-16T16:27:42.060' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 60, 0, 60, 12, CAST(N'2021-05-16T20:04:47.793' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 20, 0, 20, 13, CAST(N'2021-05-16T22:44:51.783' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 420, 9, 429, 14, CAST(N'2021-05-16T22:46:59.537' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 270, 0, 270, 15, CAST(N'2021-05-16T22:50:42.743' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 2450, 27.9, 2477.9, 16, CAST(N'2021-05-16T22:57:29.700' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 3150, 78.6, 3228.6, 17, CAST(N'2021-05-17T20:17:55.830' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 400, 12, 412, 18, CAST(N'2021-05-17T20:18:24.387' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 500, 15, 515, 19, CAST(N'2021-05-18T13:28:19.770' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 680, 17.4, 697.4, 20, CAST(N'2021-05-24T16:58:17.040' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 3706, 96.3, 3802.3, 21, CAST(N'2021-05-24T16:59:34.157' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 430, 7.5, 437.5, 22, CAST(N'2021-06-04T16:08:30.583' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 500, 0, 500, 23, CAST(N'2023-05-08T19:23:53.193' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 580, 5.4, 585.4, 24, CAST(N'2023-05-08T19:27:02.007' AS DateTime))
INSERT [dbo].[food_order] ([discount], [subTotal], [tax], [grandTotal], [order_id], [date_created]) VALUES (0, 500, 15, 515, 25, CAST(N'2023-05-08T19:51:27.520' AS DateTime))
SET IDENTITY_INSERT [dbo].[food_order] OFF
GO
SET IDENTITY_INSERT [dbo].[item] ON 

INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (1, N'Cocacola 250ml', 186, 30, 5, 0)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (2, N'Pudding', 96, 200, 3, 1)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (3, N'Juice-250gm', 6, 100, 2, 0)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (4, N'Apple 400gm', 198, 300, 7, 1)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (5, N'Cocacola 150ml', 56, 20, 5, 0)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (6, N'Banana 12-peices', 44, 60, 7, 0)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (7, N'Tea sm', 94, 30, 10, 0)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (8, N'HamBurger Small', 292, 250, 4, 1)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (9, N'Cocktail Juice', 1984, 340, 2, 1)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (10, N'Mc_Chicken_sm', 691, 400, 4, 1)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (11, N'Ice Cream 330gm', 11984, 50, 11, 0)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (12, N'Coffee', 220, 100, 9, 0)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (13, N'Gold Leaf', 98, 3, 6, 0)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (14, N'Zinger Burger', 94, 180, 4, 1)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (15, N'Water Bottle Small', 20, 30, 8, 0)
INSERT [dbo].[item] ([id], [name], [quantity], [price], [item_category_id], [tax]) VALUES (16, N'Dhania', 89, 10, 12, 0)
SET IDENTITY_INSERT [dbo].[item] OFF
GO
SET IDENTITY_INSERT [dbo].[item_categories] ON 

INSERT [dbo].[item_categories] ([id], [category_name]) VALUES (1, N'All')
INSERT [dbo].[item_categories] ([id], [category_name]) VALUES (2, N'Soft Drink')
INSERT [dbo].[item_categories] ([id], [category_name]) VALUES (3, N'Food')
INSERT [dbo].[item_categories] ([id], [category_name]) VALUES (4, N'Burger')
INSERT [dbo].[item_categories] ([id], [category_name]) VALUES (5, N'Cold Drink')
INSERT [dbo].[item_categories] ([id], [category_name]) VALUES (6, N'Cigarettes')
INSERT [dbo].[item_categories] ([id], [category_name]) VALUES (7, N'Fruit')
INSERT [dbo].[item_categories] ([id], [category_name]) VALUES (8, N'Drink')
INSERT [dbo].[item_categories] ([id], [category_name]) VALUES (9, N'Coffee')
INSERT [dbo].[item_categories] ([id], [category_name]) VALUES (10, N'Tea')
INSERT [dbo].[item_categories] ([id], [category_name]) VALUES (11, N'Ice Cream')
INSERT [dbo].[item_categories] ([id], [category_name]) VALUES (12, N'Vegetable')
SET IDENTITY_INSERT [dbo].[item_categories] OFF
GO
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (1, 3, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (1, 5, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (2, 5, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (3, 5, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (3, 7, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (3, 8, N'Sauce, Tomotto')
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (3, 15, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (4, 3, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (4, 5, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (5, 5, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (6, 5, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (7, 5, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (8, 3, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (9, 3, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (9, 5, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (10, 16, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (11, 3, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (12, 1, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (12, 7, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (13, 5, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (14, 4, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (14, 6, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (15, 1, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (16, 1, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (16, 3, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (16, 5, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (16, 6, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (16, 15, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (16, 13, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (16, 11, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (16, 9, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (16, 8, N'Spicy, Sauce, Tomotto')
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (16, 12, N'Milk, Sugar')
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (17, 7, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (17, 11, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (17, 15, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (17, 10, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (17, 3, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (17, 9, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (18, 2, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (19, 8, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (20, 2, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (20, 3, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (20, 14, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (21, 10, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (21, 11, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (21, 13, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (21, 14, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (21, 12, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (21, 4, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (21, 3, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (21, 7, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (21, 9, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (21, 8, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (21, 16, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (22, 1, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (22, 3, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (22, 5, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (22, 8, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (23, 11, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (24, 3, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (24, 14, NULL)
INSERT [dbo].[order_items] ([order_id], [item_id], [comments]) VALUES (25, 8, NULL)
GO
ALTER TABLE [dbo].[item] ADD  DEFAULT ((0)) FOR [tax]
GO
USE [master]
GO
ALTER DATABASE [keedoozle] SET  READ_WRITE 
GO

