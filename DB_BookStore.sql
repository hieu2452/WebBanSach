
USE [DB_BookStore]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/8/2023 3:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tChiTietHoaDon]    Script Date: 4/8/2023 3:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tChiTietHoaDon](
	[SoLuong] [int] NULL,
	[MaHD] [int] NOT NULL,
	[MaSach] [int] NOT NULL,
 CONSTRAINT [PK_tChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tHoaDon]    Script Date: 4/8/2023 3:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tHoaDon](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[NgayTao] [datetime] NULL,
	[ID] [int] NULL,
 CONSTRAINT [PK_tHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tKho]    Script Date: 4/8/2023 3:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tKho](
	[MaKho] [int] IDENTITY(1,1) NOT NULL,
	[TenKho] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](100) NULL,
 CONSTRAINT [PK_tKho] PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tNgonNgu]    Script Date: 4/8/2023 3:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNgonNgu](
	[MaNG] [int] IDENTITY(1,1) NOT NULL,
	[Mota] [nvarchar](100) NULL,
 CONSTRAINT [PK_tNgonNgu] PRIMARY KEY CLUSTERED 
(
	[MaNG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tNhaXuatBan]    Script Date: 4/8/2023 3:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNhaXuatBan](
	[MaNXB] [int] IDENTITY(1,1) NOT NULL,
	[TenNXB] [nvarchar](100) NOT NULL,
	[Url] [nvarchar](100) NULL,
 CONSTRAINT [PK_tNhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tSach]    Script Date: 4/8/2023 3:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSach](
	[MaSach] [int] IDENTITY(1,1) NOT NULL,
	[TenSach] [nvarchar](100) NOT NULL,
	[TacGia] [nvarchar](100) NOT NULL,
	[DonGia] [float] NULL,
	[SoLuong] [int] NULL,
	[MaTL] [int] NULL,
	[MaNXB] [int] NULL,
	[Anh] [nvarchar](1000) NULL,
	[MaNG] [int] NULL,
	[Mota] [nvarchar](500) NULL,
	[InActive] [bit] NULL,
	[GiamGia] [float] NULL,
 CONSTRAINT [PK_tSach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tSach_Kho]    Script Date: 4/8/2023 3:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSach_Kho](
	[MaKho] [int] NOT NULL,
	[MaSach] [int] NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_tSach_Kho] PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tTheLoai]    Script Date: 4/8/2023 3:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tTheLoai](
	[MaTL] [int] IDENTITY(1,1) NOT NULL,
	[TenTL] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tTheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tUser]    Script Date: 4/8/2023 3:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserN] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [int] NULL,
	[Email] [nvarchar](100) NULL,
	[passW] [nvarchar](100) NULL,
	[roleID] [varchar](10) NULL,
	[AnhDaiDien] [nvarchar](1000) NULL,
 CONSTRAINT [PK_tUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

alter table tUser
add isActive bit null

/****** Object:  Table [dbo].[tUserRole]    Script Date: 4/8/2023 3:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tUserRole](
	[MoTa] [nvarchar](100) NULL,
	[roleID] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tUserRole] PRIMARY KEY CLUSTERED 
(
	[roleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tChiTietHoaDon_tHoaDon] FOREIGN KEY([MaHD])
REFERENCES [dbo].[tHoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[tChiTietHoaDon] CHECK CONSTRAINT [FK_tChiTietHoaDon_tHoaDon]
GO
ALTER TABLE [dbo].[tChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tChiTietHoaDon_tSach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[tSach] ([MaSach])
GO
ALTER TABLE [dbo].[tChiTietHoaDon] CHECK CONSTRAINT [FK_tChiTietHoaDon_tSach]
GO
ALTER TABLE [dbo].[tHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tHoaDon _tUser] FOREIGN KEY([ID])
REFERENCES [dbo].[tUser] ([ID])
GO
ALTER TABLE [dbo].[tHoaDon] CHECK CONSTRAINT [FK_tHoaDon _tUser]
GO
ALTER TABLE [dbo].[tSach]  WITH CHECK ADD  CONSTRAINT [FK_tSach _tNgonNgu] FOREIGN KEY([MaNG])
REFERENCES [dbo].[tNgonNgu] ([MaNG])
GO
ALTER TABLE [dbo].[tSach] CHECK CONSTRAINT [FK_tSach _tNgonNgu]
GO
ALTER TABLE [dbo].[tSach]  WITH CHECK ADD  CONSTRAINT [FK_tSach _tNhaXuatBan] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[tNhaXuatBan] ([MaNXB])
GO
ALTER TABLE [dbo].[tSach] CHECK CONSTRAINT [FK_tSach _tNhaXuatBan]
GO
ALTER TABLE [dbo].[tSach]  WITH CHECK ADD  CONSTRAINT [FK_tSach _tTheLoai] FOREIGN KEY([MaTL])
REFERENCES [dbo].[tTheLoai] ([MaTL])
GO
ALTER TABLE [dbo].[tSach] CHECK CONSTRAINT [FK_tSach _tTheLoai]
GO
ALTER TABLE [dbo].[tSach_Kho]  WITH CHECK ADD  CONSTRAINT [FK_tSachKho_tKho] FOREIGN KEY([MaKho])
REFERENCES [dbo].[tKho] ([MaKho])
GO
ALTER TABLE [dbo].[tSach_Kho] CHECK CONSTRAINT [FK_tSachKho_tKho]
GO
ALTER TABLE [dbo].[tSach_Kho]  WITH CHECK ADD  CONSTRAINT [FK_tSachKho_tSach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[tSach] ([MaSach])
GO
ALTER TABLE [dbo].[tSach_Kho] CHECK CONSTRAINT [FK_tSachKho_tSach]
GO
ALTER TABLE [dbo].[tUser]  WITH CHECK ADD  CONSTRAINT [FK_tUser_tUserRole] FOREIGN KEY([roleID])
REFERENCES [dbo].[tUserRole] ([roleID])
GO
ALTER TABLE [dbo].[tUser] CHECK CONSTRAINT [FK_tUser_tUserRole]
GO



DBCC CHECKIDENT ('[tTheLoai]', RESEED, 0);
GO
DBCC CHECKIDENT ('[tNhaXuatBan]', RESEED, 0);
GO
DBCC CHECKIDENT ('[tNgonNgu]', RESEED, 0);
GO


INSERT INTO tNgonNgu (Mota)
VALUES (N'Tiếng Việt'),
       (N'Tiếng Anh'),
       (N'Tiếng Nhật'),
       (N'Tiếng Hàn'),
       (N'Tiếng Trung'),
       (N'Tiếng Pháp');


	   INSERT INTO tNhaXuatBan (TenNXB, Url)
VALUES (N'NXB Trẻ', 'https://nxbtre.com.vn'),
       (N'NXB Kim Đồng', 'https://nxbkimdong.com.vn'),
       (N'NXB Tổng Hợp TPHCM', 'https://nxbtonghop.com.vn'),
       (N'NXB Văn hóa - Văn nghệ', 'https://nxbvanhoavannghexxx.vn'),
       (N'NXB Thanh Niên', 'https://nxbthanhnhien.vn'),
       (N'NXB Hội Nhà văn', NULL);

INSERT INTO tTheLoai (TenTL)
VALUES (N'Truyện tranh'),
       (N'Khoa học'),
       (N'Kinh tế'),
       (N'Chính trị - Pháp luật'),
       (N'Văn học - Nghệ thuật'),
       (N'Tâm lý - Giới tính');









INSERT INTO [dbo].[tSach] (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive)
VALUES (N'Sapiens: A Brief History of Humankind', N'Yuval Noah Harari', 15.99, 50, 1, 1, 1, N'Giải thích lịch sử loài người', 0);

INSERT INTO [dbo].[tSach] (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive)
VALUES (N'Homo Deus: A Brief History of Tomorrow', N'Yuval Noah Harari', 16.99, 40, 1, 1, 1, N'Tương lai loài người', 0);

INSERT INTO [dbo].[tSach] (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive)
VALUES (N'Atomic Habits: An Easy & Proven Way to Build Good Habits & Break Bad Ones', N'James Clear', 12.99, 60, 2, 2, 2, N'Xây dựng thói quen tích cực', 0);

INSERT INTO [dbo].[tSach] (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive)
VALUES (N'The Power of Now: A Guide to Spiritual Enlightenment', N'Eckhart Tolle', 11.99, 45, 3, 3, 3, N'Hướng dẫn giác ngộ tâm linh', 0);

INSERT INTO [dbo].[tSach] (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive)
VALUES (N'The Alchemist', N'Paulo Coelho', 10.99, 80, 4, 4, 4, N'Hành trình tìm kiếm bản thân', 0);

INSERT INTO [dbo].[tSach] (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive)
VALUES (N'The Power of Habit: Why We Do What We Do in Life and Business', N'Charles Duhigg', 14.99, 55, 2, 2, 2, N'Sức mạnh của thói quen', 0);

INSERT INTO [dbo].[tSach] (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive)
VALUES (N'Zero to One: Notes on Startups, or How to Build the Future', N'Peter Thiel', 18.99, 35, 5, 5, 5, N'Những ghi chép về khởi nghiệp và xây dựng tương lai', 0);


INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive) 
VALUES (N'Chúa Tể Những Chiếc Nhẫn', N'J.R.R. Tolkien', 250000, 10, 3, 2, 2, N'Cuốn tiểu thuyết nổi tiếng trong loạt truyện The Lord of the Rings của tác giả J.R.R. Tolkien', 0);

INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive) 
VALUES (N'Sách Đen', N'J.K. Rowling', 180000, 15, 1, 1, 1, N'Phần thứ 6 trong loạt truyện Harry Potter của tác giả J.K. Rowling', 0);

INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive) 
VALUES (N'Bố Già', N'Mario Puzo', 220000, 8, 4, 4, 4, N'Cuốn tiểu thuyết nổi tiếng của tác giả Mario Puzo về băng đảng mafia La Cosa Nostra', 0);

INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive) 
VALUES (N'Bảy Ngày Ở Viên Đại Học', N'Mihail Sebastian', 140000, 20, 2, 3, 3, N'Cuốn tiểu thuyết của tác giả Mihail Sebastian kể về những ngày đau khổ của một người Do Thái trong thời kỳ Chiến tranh thế giới thứ hai', 0);

INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive) 
VALUES (N'Tôi Là Bêtônia', N'Nguyễn Nhật Ánh', 90000, 25, 6, 5, 5, N'Cuốn tiểu thuyết của tác giả Nguyễn Nhật Ánh về một cô bé đáng yêu tên Bêtônia', 0);

INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive) 
VALUES (N'Chim Lạc Loài', N'Nguyễn Nhật Ánh', 80000, 30, 6, 5, 5, N'Cuốn tiểu thuyết của tác giả Nguyễn Nhật Ánh kể về chuyến phiêu lưu của cậu bé Trường trong rừng núi Tây Bắc', 0);


INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive) 
VALUES (N'Dế Mèn Phiêu Lưu Ký', N'Tô Hoài', 55000, 10, 4, 3, 1, N'Cuốn sách kể về chuyến phiêu lưu của Dế Mèn và bạn bè', 0);

INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive) 
VALUES (N'Bánh Mì Không', N'Nguyễn Nhật Ánh', 63000, 8, 4, 3, 1, N'Cuốn sách kể về chuyện tình lãng mạn giữa Tuệ và Ngọc', 0);

INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive) 
VALUES (N'Đất Rừng Phương Nam', N'Dương Thu Hương', 79000, 5, 2, 2, 2, N'Cuốn sách kể về những mảnh đời đầy gian nan của người dân miền Tây', 0);

INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive) 
VALUES (N'Tiên Nghịch', N'Tiêu Đỉnh', 98000, 3, 3, 1, 3, N'Truyện kể về chàng trai Thiên Địa, từ một thợ rèn bình thường trở thành một siêu cường trong thế giới tiên hiệp', 0);

INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive) 
VALUES (N'Toán Học Vui', N'Nguyễn Thành Nam', 25000, 15, 1, 5, 4, N'Cuốn sách giúp trẻ rèn luyện kỹ năng toán học qua các trò chơi thú vị', 0);

INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota, InActive) 
VALUES (N'Cô Gái Đến Từ Hôm Qua', N'Nguyễn Nhật Ánh', 69000, 7, 4, 3, 1, N'Cuốn sách kể về chuyến phiêu lưu của cô gái trẻ Tư và anh chàng Khôi', 0);

INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota) VALUES (N'Cách nói chuyện trước công chúng', N'Dale Carnegie', 105000, 10, 1, 2, 2, N'Sách hướng dẫn kỹ năng giao tiếp trước đám đông')
INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota) VALUES (N'Đắc nhân tâm', N'Dale Carnegie', 120000, 8, 1, 2, 2, N'Sách nổi tiếng về phát triển cá nhân và kỹ năng giao tiếp')
INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota) VALUES (N'Nhà giả kim', N'Paulo Coelho', 85000, 15, 2, 1, 1, N'Tiểu thuyết kinh điển về tìm kiếm ý nghĩa cuộc đời')
INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota) VALUES (N'Đời thay đổi khi chúng ta thay đổi', N'Robin Sharma', 135000, 5, 1, 3, 2, N'Sách thực hành về phát triển bản thân và cải thiện cuộc sống')
INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota) VALUES (N'Cô gái mù', N'Alex Michaelides', 95000, 12, 3, 4, 3, N'Tiểu thuyết trinh thám nổi tiếng về tâm lý tội phạm')
INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota) VALUES (N'Tôi tài giỏi, bạn cũng thế', N'Adam Khoo', 125000, 7, 1, 2, 2, N'Sách hướng dẫn phát triển kỹ năng và tư duy tài chính')
INSERT INTO tSach (TenSach, TacGia, DonGia, SoLuong, MaTL, MaNXB, MaNG, Mota) VALUES (N'Truyện Kiều', N'Nguyễn Du', 65000, 20, 2, 1, 1, N'Thơ ca kinh điển của văn học Việt Nam')

select * from tSach