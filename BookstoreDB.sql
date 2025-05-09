USE [master]
GO
/****** Object:  Database [BookStore]    Script Date: 29-Mar-25 10:07:46 PM ******/
CREATE DATABASE [BookStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BookStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BookStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BookStore] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookStore] SET RECOVERY FULL 
GO
ALTER DATABASE [BookStore] SET  MULTI_USER 
GO
ALTER DATABASE [BookStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookStore', N'ON'
GO
ALTER DATABASE [BookStore] SET QUERY_STORE = ON
GO
ALTER DATABASE [BookStore] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BookStore]
GO
/****** Object:  User [huyenptn]    Script Date: 29-Mar-25 10:07:46 PM ******/
CREATE USER [huyenptn] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 29-Mar-25 10:07:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Fullname] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nvarchar](11) NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 29-Mar-25 10:07:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](255) NOT NULL,
	[Cover] [nvarchar](255) NULL,
	[Author] [nvarchar](255) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Quantity] [int] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[PublisherID] [int] NOT NULL,
	[SubCategoryID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Promotion] [float] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 29-Mar-25 10:07:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 29-Mar-25 10:07:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[MinQuantity] [int] NULL,
	[MaxQuantity] [int] NULL,
	[DiscountPercent] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 29-Mar-25 10:07:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderID] [int] NOT NULL,
	[BookID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[DiscountedPrice] [decimal](18, 2) NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 29-Mar-25 10:07:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[DeliveryDate] [datetime] NULL,
	[AccountID] [int] NOT NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 29-Mar-25 10:07:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[PublisherID] [int] IDENTITY(1,1) NOT NULL,
	[PublisherName] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nvarchar](11) NULL,
 CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED 
(
	[PublisherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 29-Mar-25 10:07:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategories]    Script Date: 29-Mar-25 10:07:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategories](
	[SubCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryName] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_SubCategories] PRIMARY KEY CLUSTERED 
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountID], [Username], [Password], [Fullname], [Email], [Address], [Phone], [RoleID]) VALUES (1, N'admin', N'111', N'Admin', N'admin@gmail.com', NULL, NULL, 1)
INSERT [dbo].[Accounts] ([AccountID], [Username], [Password], [Fullname], [Email], [Address], [Phone], [RoleID]) VALUES (2, N'huyenptn', N'123', N'HuyenPTN', N'huyenptn@gmail.com', NULL, NULL, 2)
INSERT [dbo].[Accounts] ([AccountID], [Username], [Password], [Fullname], [Email], [Address], [Phone], [RoleID]) VALUES (3, N'thanhpn', N'123', N'ThanhPN', N'thanhptn@gmail.com', NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookID], [BookName], [Cover], [Author], [Price], [Description], [Quantity], [UpdatedDate], [PublisherID], [SubCategoryID], [CategoryID], [CreatedDate], [Promotion]) VALUES (1, N'Cây Cam Ngọt Của Tôi', N'cay-cam-ngot-cua-toi.jpg', N'José Mauro de Vasconcelos', CAST(84240.00 AS Decimal(18, 2)), NULL, 50, CAST(N'2024-03-19T11:10:25.993' AS DateTime), 1, 2, 1, CAST(N'2024-03-19T11:10:25.993' AS DateTime), NULL)
INSERT [dbo].[Books] ([BookID], [BookName], [Cover], [Author], [Price], [Description], [Quantity], [UpdatedDate], [PublisherID], [SubCategoryID], [CategoryID], [CreatedDate], [Promotion]) VALUES (2, N'Lén Nhặt Chuyện Đời', N'len-nhat-chuyen-doi.jpg', N'Mộc Trầm', CAST(60000.00 AS Decimal(18, 2)), NULL, 40, CAST(N'2024-03-19T11:18:32.480' AS DateTime), 2, 2, 1, CAST(N'2024-03-19T11:18:32.480' AS DateTime), NULL)
INSERT [dbo].[Books] ([BookID], [BookName], [Cover], [Author], [Price], [Description], [Quantity], [UpdatedDate], [PublisherID], [SubCategoryID], [CategoryID], [CreatedDate], [Promotion]) VALUES (3, N'Nhà Giả Kim', N'nha-gia-kim.jpg', N'Paulo Coelho', CAST(62620.00 AS Decimal(18, 2)), NULL, 50, CAST(N'2024-03-19T11:25:44.397' AS DateTime), 1, 2, 1, CAST(N'2024-03-19T11:25:44.397' AS DateTime), NULL)
INSERT [dbo].[Books] ([BookID], [BookName], [Cover], [Author], [Price], [Description], [Quantity], [UpdatedDate], [PublisherID], [SubCategoryID], [CategoryID], [CreatedDate], [Promotion]) VALUES (4, N'Đám Trẻ Ở Đại Dương Đen', N'dam-tre-o-dai-duong-den.jpg', N'Châu Sa Đáy Mắt', CAST(72270.00 AS Decimal(18, 2)), N'“nỗi buồn không rõ hình thù

ta cho nó dáng, ta thu vào lòng

Đám trẻ ở đại dương đen là lời độc thoại và đối thoại của những đứa trẻ ở đại dương đen, nơi từng lớp sóng của nỗi buồn và tuyệt vọng không ngừng cuộn trào, lúc âm ỉ, khi dữ dội. Những đứa trẻ ấy phải vật lộn trong những góc tối tâm lý, với sự u uất đè nén từ tổn thương khi không được sinh ra trong một gia đình toàn vẹn, ấm êm, khi phải mang trên đôi vai non dại những gánh nặng không tưởng.

Song song đó cũng là quá trình tự chữa lành vô cùng khó khăn của đám trẻ, cố gắng vươn mình ra khỏi đại dương đen, tìm cho mình một ánh sáng. Và chính những sự nỗ lực xoa dịu chính mình đó đã hóa thành những câu từ trong cuốn sách này, bất kể đau đớn thế nào.

Cuốn sách được viết bởi Châu Sa Đáy Mắt, một tác giả GenZ mong muốn cùng các bạn trẻ bộc bạch và vỗ về những xúc cảm chân thật về gia đình, xã hội và chính bản thân.', 40, CAST(N'2024-03-19T11:10:25.993' AS DateTime), 2, 3, 1, CAST(N'2024-03-19T11:10:25.993' AS DateTime), NULL)
INSERT [dbo].[Books] ([BookID], [BookName], [Cover], [Author], [Price], [Description], [Quantity], [UpdatedDate], [PublisherID], [SubCategoryID], [CategoryID], [CreatedDate], [Promotion]) VALUES (5, N'Dune - Xứ Cát', N'dune-xu-cat.jpg', N'Frank Herbert', CAST(194220.00 AS Decimal(18, 2)), N'Một thời điểm rất xa trong tương lai…

Từ đời này sang đời khác, người Fremen trên hành tinh sa mạc lưu truyền lời tiên tri về một đấng cứu tinh sẽ dẫn dắt họ giành lấy tự do đích thực…

Từ thế hệ này sang thế hệ khác, những nữ phù thủy Bene Gesserit mỏi mòn chờ đợi sự xuất hiện của một B.G. nam giới duy nhất, người có thể vượt qua mọi giới hạn không gian - thời gian…

Là Lisal al-Gaib của người Fremen, là Kwisatz Haderach của học viện Bene Gesserit, chàng công tước trẻ tuổi Paul Atreides đã làm tất cả những gì có thể để thay đổi định mệnh đó. Cha bị giết chết, mẹ bị cho là kẻ phản bội, gia tộc bị tàn sát, bản thân bị săn đuổi đến đường cùng, Paul đơn độc dấn thân vào một cuộc phiêu lưu sinh tử, không hề biết rằng mỗi hành động của mình sẽ góp phần quyết định vận mệnh của cả thiên hà. Sa mạc Arrakis khắc nghiệt tưởng như sẽ là nơi chôn vùi vĩnh viễn vinh quang của gia tộc Atreides, nhưng hóa ra lại thành điểm khởi đầu cho một huyền thoại mới…

Là một trong những cuốn tiểu thuyết khoa học giả tưởng bán chạy nhất mọi thời đại, Xứ Cát không chỉ là lựa chọn đối với những tín đồ của Chúa nhẫn, Chiến tranh giữa các vì sao… mà còn chinh phục độc giả đủ mọi lứa tuổi, mọi tầng lớp và sở thích bởi sự đa dạng và phức tạp của con người và không gian trong truyện, bởi sự tinh tế trong xây dựng tâm lý, bởi sự hấp dẫn, căng thẳng và bất ngờ của cốt truyện, bởi sự độc đáo và thú vị của khối lượng kiến thức khổng lồ cũng như bởi sự hấp dẫn trong những tư tưởng về tôn giáo, về tự do, về tình yêu, về sự sống và cái chết…', 50, CAST(N'2024-03-19T11:10:25.993' AS DateTime), 1, 3, 1, CAST(N'2024-03-19T11:10:25.993' AS DateTime), NULL)
INSERT [dbo].[Books] ([BookID], [BookName], [Cover], [Author], [Price], [Description], [Quantity], [UpdatedDate], [PublisherID], [SubCategoryID], [CategoryID], [CreatedDate], [Promotion]) VALUES (6, N'Chờ Ngày Tuyết Tan', N'cho-ngay-tuyet-tan.jpg', N'Shiro Kuro, Rensuke Oshikiri', CAST(38400.00 AS Decimal(18, 2)), N'Rời khỏi Tokyo, Nozaki theo gia đình chuyển đến một vùng quê ngột ngạt và lạnh lẽo. Trường học nơi đây đón chào Nozaki bằng cái nhìn đầy hằn học và đủ trò thù địch của lũ bạn cùng lớp, cùng sự thờ ơ của cô giáo chủ nhiệm khi chứng kiến học sinh bị bắt nạt ngay trước mắt. Mặc kệ những điều đó, Nozaki chấp nhận nhẫn nhịn và cam chịu. Khi tuyết ngừng rơi cũng là lúc Nozaki tốt nghiệp cấp hai, cô sẽ cùng gia đình rời khỏi nơi đây để tránh xa những hiểm nguy đang rình rập. Nhưng một cơn bão tuyết đã quét ngang qua gia đình Nozaki, tàn phá mọi thứ và kéo theo đó là những sự kiện khủng khiếp xảy đến với thị trấn bé nhỏ này.', 40, CAST(N'2024-03-19T11:10:25.993' AS DateTime), 3, 4, 1, CAST(N'2024-03-19T11:10:25.993' AS DateTime), NULL)
INSERT [dbo].[Books] ([BookID], [BookName], [Cover], [Author], [Price], [Description], [Quantity], [UpdatedDate], [PublisherID], [SubCategoryID], [CategoryID], [CreatedDate], [Promotion]) VALUES (7, N'Đứa Con Của Thời Tiết', N'dua-con-cua-thoi-tiet.jpg', N'Shinkai Makoto', CAST(85000.00 AS Decimal(18, 2)), N'Đứa con của thời tiết phác ra thương yêu cô đọng giữa hoang mang của đô thị lớn và ngặt nghèo hơn, là giữa hoang mang của một thời đại biến đổi khí hậu bấp bênh.

Vì một sự cố tình cờ, Hina được tạo hóa ban cho năng lực đặc biệt: làm nắng. Năng lực ấy càng thêm nhiệm màu khi đặt vào bối cảnh Nhật Bản hứng mưa triền miên, mưa đến mức vòm trời âm u trở thành cơm bữa, nước dâng gặm dần các đảo, và Tokyo có nguy cơ biến thành đô thị kênh đào.

Nhưng đến đây, phong cách song hành nhất quán của Shinkai lại trỗi dậy. Trong lạc có bi, trong hạnh phúc sẵn chia ly, được ban phép màu ắt phải đánh đổi. Đứa con của thời tiết cũng không thể tùy ý tắt bật nắng mưa mà không phải trả giá gì. Theo sau một lần làm nắng, là chất chứa hàng chuỗi ăn mòn, hối hận, mạo hiểm, giải cứu, và đằng đẵng cách xa.

Cũng như Your Name., ĐỨA CON CỦA THỜI TIẾT tiếp tục đan cài giữa truyền thống và hiện đại, huyền thoại và thực tế, nguy cơ và mộng ước, thiên tai và con người… nhưng có điểm khác là, lần đầu tiên hạnh phúc cá nhân đã được nhấn mạnh, nhân vật đã bứt mình khỏi tâm thế bao la vì mọi người.', 50, NULL, 4, 5, 1, CAST(N'2024-03-19T11:10:25.993' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (1, N'Văn Học')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (2, N'Kinh Tế')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (3, N'Tâm Lý - Kỹ Năng Sống')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (4, N'Nuôi Dạy Con ')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (5, N'Sách Thiếu Nhi')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (6, N'Tiểu Sử - Hồi Ký')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (7, N'Giáo Khoa - Tham Khảo')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (8, N'Sách Học Ngoại Ngữ')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
INSERT [dbo].[OrderDetails] ([OrderID], [BookID], [Quantity], [UnitPrice], [DiscountedPrice]) VALUES (2, 4, 1, CAST(194220.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderDetails] ([OrderID], [BookID], [Quantity], [UnitPrice], [DiscountedPrice]) VALUES (3, 5, 1, CAST(72270.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderDetails] ([OrderID], [BookID], [Quantity], [UnitPrice], [DiscountedPrice]) VALUES (4, 7, 1, CAST(85000.00 AS Decimal(18, 2)), NULL)
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [Status], [OrderDate], [DeliveryDate], [AccountID], [TotalAmount], [DiscountAmount]) VALUES (2, N'Đang giao hàng', CAST(N'2024-03-25T02:22:38.960' AS DateTime), NULL, 2, NULL, NULL)
INSERT [dbo].[Orders] ([OrderID], [Status], [OrderDate], [DeliveryDate], [AccountID], [TotalAmount], [DiscountAmount]) VALUES (3, N'Xác nhận đơn hàng', CAST(N'2024-03-25T02:23:22.050' AS DateTime), NULL, 2, NULL, NULL)
INSERT [dbo].[Orders] ([OrderID], [Status], [OrderDate], [DeliveryDate], [AccountID], [TotalAmount], [DiscountAmount]) VALUES (4, N'Đang giao hàng', CAST(N'2024-03-25T02:23:47.030' AS DateTime), NULL, 3, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Publishers] ON 

INSERT [dbo].[Publishers] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (1, N'Hội Nhà Văn', NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (2, N'Thế Giới', NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (3, N'Thanh Niên', NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (4, N'Hà Nội', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Publishers] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (2, N'Customer')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[SubCategories] ON 

INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (2, N'Tiểu Thuyết', 1)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (3, N'Truyện Ngắn - Tản Văn', 1)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (4, N'Light Novel', 1)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5, N'Ngôn Tình', 1)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (6, N'Đam Mỹ', 1)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (8, N'Truyện Trinh Thám', 1)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (10, N'Huyền Bí - Giả Tưởng - Kinh Dị', 1)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (11, N'Phóng Sự - Ký Sự - Phê Bình Văn Học', 1)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (12, N'Du Ký', 1)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (13, N'Thơ Ca, Tục Ngữ, Ca Dao, Thành Ngữ', 1)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (14, N'Tác Phẩm Kinh Điển', 1)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (15, N'Quản Trị - Lãnh Đạo', 2)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (16, N'Nhân Vật - Bài Học Kinh Doanh', 2)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (17, N'Marketing - Bán Hàng', 2)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (18, N'Khởi nghiệp - Làm Giàu', 2)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (19, N'Phân Tích Kinh Tế ', 2)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (21, N'Chứng Khoán - Bất Động Sản - Đầu Tư', 2)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (22, N'Tài Chính - Ngân Hàng', 2)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (23, N'Nhân Sự - Việc Làm', 2)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (24, N'Kế Toán - Kiểm Toán - Thuế', 2)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (25, N'Kỹ Năng Sống', 3)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (27, N'Tâm Lý', 3)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (28, N'Sách Cho Tuổi Mới Lớn', 3)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (29, N'Chicken Soup - Hạt Giống Tâm Hồn', 3)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (30, N'Rèn Luyện Nhân Cách', 3)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (31, N'Cẩm Nang Làm Cha Mẹ', 4)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (32, N'Phát Triển Kỹ Năng - Trí Tuệ Cho Trẻ', 4)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (33, N'Phương Pháp Giáo Dục Trẻ Các Nước', 4)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (34, N'Dinh Dưỡng - Sức Khỏe Cho Trẻ', 4)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (35, N'Giáo Dục Trẻ Tuổi Teen', 4)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (36, N'Dành Cho Mẹ Bầu', 4)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (37, N'Manga - Comic', 5)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (38, N'Truyện Thiếu Nhi', 5)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (39, N'Kiến Thức - Kỹ Năng Sống Cho Trẻ', 5)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (40, N'Kiến Thức Bách Khoa', 5)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (41, N'Tô Màu, Luyện Chữ', 5)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (42, N'Từ Điển Thiếu Nhi', 5)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (43, N'Flashcard - Thẻ Học Thông Minh', 5)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (44, N'Sách Nói', 5)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (45, N'Câu Chuyện Cuộc Đời', 6)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (46, N'Lịch Sử', 6)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (47, N'Nghệ Thuật - Giải Trí', 6)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (48, N'Chính Trị', 6)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (49, N'Kinh Tế', 6)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (50, N'Sách Tham Khảo', 7)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (51, N'Mẫu Giáo', 7)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (52, N'Sách Giáo Khoa', 7)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (53, N'Sách Giáo Viên', 7)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (55, N'Đại Học', 7)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (56, N'Tiếng Anh', 8)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (57, N'Tiếng Trung', 8)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (58, N'Tiếng Nhật', 8)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (59, N'Tiếng Hàn', 8)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (60, N'Tiếng Việt Cho Người Nước Ngoài', 8)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (61, N'
Tiếng Pháp', 8)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (62, N'Tiếng Đức', 8)
INSERT [dbo].[SubCategories] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (63, N'Ngoại Ngữ Khác ', 8)
SET IDENTITY_INSERT [dbo].[SubCategories] OFF
GO
ALTER TABLE [dbo].[Books] ADD  CONSTRAINT [DF_Books_Cover]  DEFAULT (N'cover-default.jpg') FOR [Cover]
GO
ALTER TABLE [dbo].[Books] ADD  CONSTRAINT [DF_Books_UpdateDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_OrderDate]  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Roles]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Categories]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Publishers] FOREIGN KEY([PublisherID])
REFERENCES [dbo].[Publishers] ([PublisherID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Publishers]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_SubCategories] FOREIGN KEY([SubCategoryID])
REFERENCES [dbo].[SubCategories] ([SubCategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_SubCategories]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([BookID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Books]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Accounts]
GO
ALTER TABLE [dbo].[SubCategories]  WITH CHECK ADD  CONSTRAINT [FK_SubCategories_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubCategories] CHECK CONSTRAINT [FK_SubCategories_Categories]
GO
USE [master]
GO
ALTER DATABASE [BookStore] SET  READ_WRITE 
GO
