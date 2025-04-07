USE [master]
GO
/****** Object:  Database [VDStoreDB]    Script Date: 4/7/2025 11:49:07 PM ******/
CREATE DATABASE [VDStoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VDStoreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\VDStoreDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VDStoreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\VDStoreDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [VDStoreDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VDStoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VDStoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VDStoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VDStoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VDStoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VDStoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [VDStoreDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [VDStoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VDStoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VDStoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VDStoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VDStoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VDStoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VDStoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VDStoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VDStoreDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [VDStoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VDStoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VDStoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VDStoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VDStoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VDStoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VDStoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VDStoreDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VDStoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [VDStoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VDStoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VDStoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VDStoreDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VDStoreDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VDStoreDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [VDStoreDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [VDStoreDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [VDStoreDB]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 4/7/2025 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ClientID] [int] NULL,
	[EmployeeID] [int] NULL,
	[BillDate] [datetime] NULL,
	[TotalAmount] [decimal](10, 2) NOT NULL,
	[IsPaid] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 4/7/2025 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 4/7/2025 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](255) NULL,
	[Salary] [decimal](10, 2) NULL,
	[HireDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 4/7/2025 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NULL,
	[EmployeeID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[TotalPrice] [decimal](10, 2) NOT NULL,
	[Status] [nvarchar](20) NOT NULL DEFAULT ('Active'),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 4/7/2025 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/7/2025 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[ImagePath] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/7/2025 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Role] [nvarchar](20) NOT NULL,
	[EmployeeID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([ID], [OrderID], [ClientID], [EmployeeID], [BillDate], [TotalAmount], [IsPaid]) VALUES (1, 2, 1, 1, CAST(N'2025-04-07T15:46:57.037' AS DateTime), CAST(25.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Bill] ([ID], [OrderID], [ClientID], [EmployeeID], [BillDate], [TotalAmount], [IsPaid]) VALUES (2, 1, 1, 1, CAST(N'2025-04-07T15:56:10.780' AS DateTime), CAST(30.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Bill] ([ID], [OrderID], [ClientID], [EmployeeID], [BillDate], [TotalAmount], [IsPaid]) VALUES (3, 6, 2, 1, CAST(N'2025-04-07T17:15:31.810' AS DateTime), CAST(239.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Bill] ([ID], [OrderID], [ClientID], [EmployeeID], [BillDate], [TotalAmount], [IsPaid]) VALUES (4, 7, 1, 2, CAST(N'2025-04-07T19:40:24.830' AS DateTime), CAST(70.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Bill] ([ID], [OrderID], [ClientID], [EmployeeID], [BillDate], [TotalAmount], [IsPaid]) VALUES (5, 1, 1, 1, CAST(N'2025-04-07T23:12:47.407' AS DateTime), CAST(30.00 AS Decimal(10, 2)), 0)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (1, N'Trần Hải Duy', N'Dewippro2031@gmail.com', N'0828983419', N'Ton Dan Q4 HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (2, N'Huỳnh Văn Đệ', N'huynhvande2k2@gmail.com', N'0828983419', N'Ton Duc Thang ')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (4, N'Nguyễn Văn A', N'a.nguyen@example.com', N'0909123456', N'123 Lý Thường Kiệt, Q.10, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (5, N'Trần Thị B', N'b.tran@example.com', N'0912345678', N'45 Nguyễn Trãi, Q.5, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (6, N'Lê Văn C', N'c.le@example.com', N'0923456789', N'78 Trường Chinh, Q.Tân Bình, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (7, N'Phạm Thị D', N'd.pham@example.com', N'0934567890', N'12 Hoàng Văn Thụ, Q.Phú Nhuận, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (8, N'Hoàng Văn E', N'e.hoang@example.com', N'0945678901', N'88 Cách Mạng Tháng 8, Q.3, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (9, N'Vũ Thị F', N'f.vu@example.com', N'0956789012', N'25 Phan Xích Long, Q.Bình Thạnh, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (10, N'Đặng Văn G', N'g.dang@example.com', N'0967890123', N'99 Pasteur, Q.1, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (11, N'Bùi Thị H', N'h.bui@example.com', N'0978901234', N'30 Hai Bà Trưng, Q.1, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (12, N'Tô Văn I', N'i.to@example.com', N'0989012345', N'15 Nguyễn Huệ, Q.1, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (13, N'Ngô Thị J', N'j.ngo@example.com', N'0990123456', N'60 Điện Biên Phủ, Q.Bình Thạnh, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (14, N'Dương Văn K', N'k.duong@example.com', N'0901123456', N'21 Võ Thị Sáu, Q.3, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (15, N'Huỳnh Thị L', N'l.huynh@example.com', N'0912233445', N'34 Lê Lợi, Q.1, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (16, N'Phan Văn M', N'm.phan@example.com', N'0923344556', N'67 Nguyễn Đình Chiểu, Q.3, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (17, N'Đỗ Thị N', N'n.do@example.com', N'0934455667', N'89 Trần Hưng Đạo, Q.5, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (18, N'Mai Văn O', N'o.mai@example.com', N'0945566778', N'56 Tô Hiến Thành, Q.10, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (19, N'Lâm Thị P', N'p.lam@example.com', N'0956677889', N'101 Lê Văn Sỹ, Q.Phú Nhuận, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (20, N'Trịnh Văn Q', N'q.trinh@example.com', N'0967788990', N'17 Nguyễn Thái Học, Q.1, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (21, N'Tống Thị R', N'r.tong@example.com', N'0978899001', N'40 Trần Quang Khải, Q.1, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (22, N'Châu Văn S', N's.chau@example.com', N'0989900112', N'55 Bùi Thị Xuân, Q.1, TP.HCM')
INSERT [dbo].[Client] ([ID], [Name], [Email], [Phone], [Address]) VALUES (23, N'Lý Thị T', N't.ly@example.com', N'0991011123', N'22 Nguyễn Cư Trinh, Q.1, TP.HCM')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [Name], [Email], [Phone], [Address], [Salary], [HireDate]) VALUES (1, N'Admin', N'admin@vdstore.com', N'012874218', N'VD Store Address', CAST(500.00 AS Decimal(10, 2)), CAST(N'2025-04-07T15:01:01.157' AS DateTime))
INSERT [dbo].[Employee] ([ID], [Name], [Email], [Phone], [Address], [Salary], [HireDate]) VALUES (2, N'Huỳnh Văn Đệ', N'nhanvien1@vdstore.com', N'0124234234', N'343/a Ton That Thuyet', CAST(400.00 AS Decimal(10, 2)), CAST(N'2025-04-07T16:25:34.133' AS DateTime))
INSERT [dbo].[Employee] ([ID], [Name], [Email], [Phone], [Address], [Salary], [HireDate]) VALUES (3, N'Trần Hải Duy', N'nhanvien2@vdstore.com', N'0123471318', N'321 Phan Dinh Phung Q1', CAST(490.00 AS Decimal(10, 2)), CAST(N'2025-04-07T16:51:48.847' AS DateTime))
INSERT [dbo].[Employee] ([ID], [Name], [Email], [Phone], [Address], [Salary], [HireDate]) VALUES (5, N'Võ Hoàng Bảo', N'nhanvien3@gmail.com', N'0187387114', N'8 Trường Chinh, Q.Tân Bình, TP.HCM', CAST(600.00 AS Decimal(10, 2)), CAST(N'2025-04-07T23:07:35.090' AS DateTime))
INSERT [dbo].[Employee] ([ID], [Name], [Email], [Phone], [Address], [Salary], [HireDate]) VALUES (6, N'Lâm Chí Khanh', N'nhanvien4@gmail.com', N'09719347192', N'Thủ Đức', CAST(700.00 AS Decimal(10, 2)), CAST(N'2025-04-07T23:09:01.080' AS DateTime))
INSERT [dbo].[Employee] ([ID], [Name], [Email], [Phone], [Address], [Salary], [HireDate]) VALUES (7, N'Nguyễn Xuân Thịnh', N'nhanvien5@gmail.com', N'0837138493', N'Bình Tân HCM', CAST(200.00 AS Decimal(10, 2)), CAST(N'2025-04-07T23:10:51.127' AS DateTime))
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [ClientID], [EmployeeID], [OrderDate], [TotalPrice]) VALUES (1, 1, 1, CAST(N'2025-04-07T15:38:29.360' AS DateTime), CAST(30.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([ID], [ClientID], [EmployeeID], [OrderDate], [TotalPrice]) VALUES (2, 1, 1, CAST(N'2025-04-07T15:46:10.310' AS DateTime), CAST(25.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([ID], [ClientID], [EmployeeID], [OrderDate], [TotalPrice]) VALUES (3, 1, 1, CAST(N'2025-04-07T15:55:18.787' AS DateTime), CAST(55.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([ID], [ClientID], [EmployeeID], [OrderDate], [TotalPrice]) VALUES (4, 2, 1, CAST(N'2025-04-07T16:03:28.570' AS DateTime), CAST(30.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([ID], [ClientID], [EmployeeID], [OrderDate], [TotalPrice]) VALUES (5, 1, 2, CAST(N'2025-04-07T16:31:30.473' AS DateTime), CAST(30.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([ID], [ClientID], [EmployeeID], [OrderDate], [TotalPrice]) VALUES (6, 2, 1, CAST(N'2025-04-07T17:14:52.823' AS DateTime), CAST(239.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([ID], [ClientID], [EmployeeID], [OrderDate], [TotalPrice]) VALUES (7, 1, 2, CAST(N'2025-04-07T19:40:02.913' AS DateTime), CAST(70.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItem] ON 

INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (1, 1, 2, 1, CAST(30.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (2, 2, 1, 1, CAST(25.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (3, 3, 1, 1, CAST(25.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (4, 3, 2, 1, CAST(30.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (5, 4, 2, 1, CAST(30.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (6, 5, 2, 1, CAST(30.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (7, 6, 11, 1, CAST(30.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (8, 6, 12, 1, CAST(15.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (9, 6, 10, 1, CAST(40.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (10, 6, 9, 1, CAST(30.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (11, 6, 8, 1, CAST(99.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (12, 6, 7, 1, CAST(25.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (13, 7, 1, 1, CAST(25.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (14, 7, 12, 1, CAST(15.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderItem] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (15, 7, 11, 1, CAST(30.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[OrderItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [ImagePath]) VALUES (1, N'Burger Bò', N'Bánh mì kẹp thịt bò nướng, phô mai, rau xà lách, cà chua, sốt đặc trưng', CAST(25.00 AS Decimal(10, 2)), 7, N'ProductImages\product_20250407170014.png')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [ImagePath]) VALUES (2, N'Xúc xích đức', N'Thơm ngon tròn vị', CAST(30.00 AS Decimal(10, 2)), 6, N'ProductImages\product_20250407165238.png')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [ImagePath]) VALUES (3, N'Bánh mì', N'Bánh mì sài gòn', CAST(20.00 AS Decimal(10, 2)), 10, N'ProductImages\product_20250407170059.png')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [ImagePath]) VALUES (4, N'Coca', N'Nước giải khác', CAST(15.00 AS Decimal(10, 2)), 100, N'ProductImages\product_20250407170146.png')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [ImagePath]) VALUES (5, N'Gà rán', N'Gà tẩm bột chiên giòn rụm', CAST(40.00 AS Decimal(10, 2)), 100, N'ProductImages\product_20250407170214.png')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [ImagePath]) VALUES (6, N'Hot dog', N'Bánh mì dài kẹp xúc xích', CAST(20.00 AS Decimal(10, 2)), 10, N'ProductImages\product_20250407170458.png')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [ImagePath]) VALUES (7, N'Khoai tây chiên', N'Rất giòn', CAST(25.00 AS Decimal(10, 2)), 9, N'ProductImages\product_20250407170556.png')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [ImagePath]) VALUES (8, N'Pizza hải sản', N'Tươi ngon', CAST(99.00 AS Decimal(10, 2)), 9, N'ProductImages\product_20250407170703.png')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [ImagePath]) VALUES (9, N'Sandwich', N'Rau tươi', CAST(30.00 AS Decimal(10, 2)), 9, N'ProductImages\product_20250407170812.png')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [ImagePath]) VALUES (10, N'Tacos', N'Quá đã', CAST(40.00 AS Decimal(10, 2)), 9, N'ProductImages\product_20250407170932.png')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [ImagePath]) VALUES (11, N'Trà sữa', N'Có trân châu', CAST(30.00 AS Decimal(10, 2)), 8, N'ProductImages\product_20250407171034.png')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [ImagePath]) VALUES (12, N'Càfe', N'Cafe đá', CAST(15.00 AS Decimal(10, 2)), 8, N'ProductImages\product_20250407171152.png')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Username], [Password], [Role], [EmployeeID]) VALUES (1, N'admin', N'admin', N'Admin', 1)
INSERT [dbo].[User] ([ID], [Username], [Password], [Role], [EmployeeID]) VALUES (2, N'dewipro', N'123456', N'Customer', NULL)
INSERT [dbo].[User] ([ID], [Username], [Password], [Role], [EmployeeID]) VALUES (3, N'nhanvien1', N'123456', N'Employee', 2)
INSERT [dbo].[User] ([ID], [Username], [Password], [Role], [EmployeeID]) VALUES (6, N'nhanvien2', N'123456', N'Employee', 3)
INSERT [dbo].[User] ([ID], [Username], [Password], [Role], [EmployeeID]) VALUES (7, N'nhanvien3', N'123456', N'Employee', 5)
INSERT [dbo].[User] ([ID], [Username], [Password], [Role], [EmployeeID]) VALUES (8, N'nhanvien4', N'123456', N'Employee', 6)
INSERT [dbo].[User] ([ID], [Username], [Password], [Role], [EmployeeID]) VALUES (9, N'nhanvien5', N'123456', N'Employee', 7)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Employee__A9D10534181F47CC]    Script Date: 4/7/2025 11:49:07 PM ******/
ALTER TABLE [dbo].[Employee] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__536C85E46C48F8A1]    Script Date: 4/7/2025 11:49:07 PM ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [BillDate]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [IsPaid]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT (getdate()) FOR [HireDate]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ID])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[sp_AddOrderItem]    Script Date: 4/7/2025 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedure to add an item to an order
CREATE PROCEDURE [dbo].[sp_AddOrderItem]
    @OrderID INT,
    @ProductID INT,
    @Quantity INT
AS
BEGIN
    BEGIN TRANSACTION;
    
    BEGIN TRY
        DECLARE @UnitPrice DECIMAL(10, 2);
        DECLARE @CurrentQuantity INT;
        
        -- Get the product price and current quantity
        SELECT @UnitPrice = Price, @CurrentQuantity = Quantity
        FROM Product
        WHERE ID = @ProductID;
        
        -- Check if there's enough quantity
        IF @CurrentQuantity < @Quantity
        BEGIN
            THROW 50001, 'Not enough products in stock', 1;
        END;
        
        -- Add the order item
        INSERT INTO OrderItem (OrderID, ProductID, Quantity, UnitPrice)
        VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice);
        
        -- Update the product quantity
        UPDATE Product
        SET Quantity = Quantity - @Quantity
        WHERE ID = @ProductID;
        
        -- Update the order total price
        UPDATE [Order]
        SET TotalPrice = TotalPrice + (@UnitPrice * @Quantity)
        WHERE ID = @OrderID;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GenerateBill]    Script Date: 4/7/2025 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedure to generate a bill
CREATE PROCEDURE [dbo].[sp_GenerateBill]
    @OrderID INT,
    @BillID INT OUTPUT
AS
BEGIN
    BEGIN TRANSACTION;
    
    BEGIN TRY
        DECLARE @ClientID INT;
        DECLARE @EmployeeID INT;
        DECLARE @TotalAmount DECIMAL(10, 2);
        
        -- Get order details
        SELECT @ClientID = ClientID, @EmployeeID = EmployeeID, @TotalAmount = TotalPrice
        FROM [Order]
        WHERE ID = @OrderID;
        
        -- Insert the bill
        INSERT INTO Bill (OrderID, ClientID, EmployeeID, BillDate, TotalAmount, IsPaid)
        VALUES (@OrderID, @ClientID, @EmployeeID, GETDATE(), @TotalAmount, 0);
        
        -- Get the bill ID
        SET @BillID = SCOPE_IDENTITY();
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_MarkBillAsPaid]    Script Date: 4/7/2025 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedure to mark bill as paid
CREATE PROCEDURE [dbo].[sp_MarkBillAsPaid]
    @BillID INT
AS
BEGIN
    UPDATE Bill
    SET IsPaid = 1
    WHERE ID = @BillID;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_PlaceOrder]    Script Date: 4/7/2025 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedure to place an order
CREATE PROCEDURE [dbo].[sp_PlaceOrder]
    @ClientID INT,
    @EmployeeID INT,
    @OrderDate DATETIME,
    @Status NVARCHAR(20) = 'Active',
    @OrderID INT OUTPUT
AS
BEGIN
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Insert the order
        INSERT INTO [Order] (ClientID, EmployeeID, OrderDate, TotalPrice, Status)
        VALUES (@ClientID, @EmployeeID, @OrderDate, 0, @Status);
        
        -- Get the order ID
        SET @OrderID = SCOPE_IDENTITY();
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
USE [master]
GO
ALTER DATABASE [VDStoreDB] SET  READ_WRITE 
GO
