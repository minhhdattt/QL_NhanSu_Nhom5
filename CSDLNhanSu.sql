USE [master]
GO

if exists(select * from sysdatabases where name='QuanLyNhanSu')
	drop database QuanLyNhanSu
go

/****** Object:  Table [dbo].[BangCC]    Script Date: 01/06/2018 6:28:25 SA ******/
USE [master]
GO

CREATE DATABASE [QuanLyNhanSu]
GO

USE [QuanLyNhanSu]
GO
/****** Object:  Table [dbo].[BangCC]    Script Date: 01/06/2018 6:28:25 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangCC](
	[Thang] [int] NOT NULL,
	[Nam] [int] NOT NULL,
 CONSTRAINT [PK_BangCC] PRIMARY KEY CLUSTERED 
(
	[Thang] ASC,
	[Nam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BangPT]    Script Date: 01/06/2018 6:28:25 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangPT](
	[Thang] [int] NOT NULL,
	[Nam] [int] NOT NULL,
 CONSTRAINT [PK_BangPT] PRIMARY KEY CLUSTERED 
(
	[Thang] ASC,
	[Nam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietCC]    Script Date: 01/06/2018 6:28:25 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietCC](
	[Thang] [int] NOT NULL,
	[Nam] [int] NOT NULL,
	[Ngay] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChiTietCC] PRIMARY KEY CLUSTERED 
(
	[Thang] ASC,
	[Nam] ASC,
	[Ngay] ASC,
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPT]    Script Date: 01/06/2018 6:28:25 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPT](
	[Thang] [int] NOT NULL,
	[Nam] [int] NOT NULL,
	[Ngay] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[GioPT] [int] NULL,
 CONSTRAINT [PK_ChiTietPT] PRIMARY KEY CLUSTERED 
(
	[Thang] ASC,
	[Nam] ASC,
	[Ngay] ASC,
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 01/06/2018 6:28:25 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaCV] [int] IDENTITY(1,1) NOT NULL,
	[TenChucVu] [nvarchar](50) NOT NULL,
	[ThoiGianThuViec] [tinyint] NOT NULL,
	[MucLuongThuViec] [money] NOT NULL,
	[MucLuongCT] [money] NOT NULL,
	[PhuCap] [money] NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhSachUV]    Script Date: 01/06/2018 6:28:25 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhSachUV](
	[MaQD] [int] NOT NULL,
	[MaUV] [int] NOT NULL,
	[NgayNop] [date] NOT NULL,
	[Trangthai] [nvarchar](50) NULL,
 CONSTRAINT [PK_DanhSachUV] PRIMARY KEY CLUSTERED 
(
	[MaQD] ASC,
	[MaUV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HopDongTD]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDongTD](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[Ngay] [date] NOT NULL,
	[ThoiHan] [int] NOT NULL,
	[Loai] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_HopDongTD] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoSoUngVien]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoSoUngVien](
	[MaUV] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[CMND] [char](9) NOT NULL,
	[DiaChi] [nvarchar](max) NOT NULL,
	[SDT] [char](11) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[TrinhDoHocVan] [nvarchar](50) NOT NULL,
	[TinhTrangSucKhoe] [nvarchar](50) NOT NULL,
	[NgoaiNgu] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_HoSoUngVien] PRIMARY KEY CLUSTERED 
(
	[MaUV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KT_KL]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KT_KL](
	[MaKT_KL] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung] [nvarchar](max) NOT NULL,
	[Ngay] [date] NOT NULL,
	[Loai] [nvarchar](50) NOT NULL,
	[GiaTri] [money] NOT NULL,
	[MaNV] [int] NOT NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_KT_KL] PRIMARY KEY CLUSTERED 
(
	[MaKT_KL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luong]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luong](
	[MaLuong] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NOT NULL,
	[GiaTri] [money] NOT NULL,
	[TinhTrang] [nvarchar](50) NULL,
	[Thang] [int] NOT NULL,
	[Nam] [int] NOT NULL,
	[Songaycong] [int] NULL,
	[Solantresom] [int] NULL,
	[Songaynghicop] [int] NULL,
	[Songaynghikp] [int] NULL,
	[Sogiopt] [int] NULL,
	[Khenthuong] [money] NULL,
	[Kyluat] [money] NULL,
 CONSTRAINT [PK_Luong] PRIMARY KEY CLUSTERED 
(
	[MaLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[NgaySinh] [date] NOT NULL,
	[CMND] [char](9) NOT NULL,
	[DiaChi] [nvarchar](max) NOT NULL,
	[SDT] [char](11) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[TrinhDoHocVan] [nvarchar](50) NOT NULL,
	[TinhTrangSucKhoe] [nvarchar](50) NOT NULL,
	[NgoaiNgu] [nvarchar](50) NOT NULL,
	[NgayVaoLam] [date] NOT NULL,
	[MaQD] [int] NOT NULL,
	[TinhTrang] [nvarchar](50) NOT NULL,
	[MaHD] [int] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPB] [varchar](10) NOT NULL,
	[TenPhongBan] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLy]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLy](
	[Username] [varchar](30) NOT NULL,
	[Password] [varchar](50) NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[Allower] [int] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[SDT] [char](11) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuyetDinhTD]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuyetDinhTD](
	[MaQD] [int] IDENTITY(1,1) NOT NULL,
	[MaPB] [varchar](10) NOT NULL,
	[MaCV] [int] NOT NULL,
	[Mota] [nvarchar](max) NOT NULL,
	[Ngaycapnhat] [date] NOT NULL,
	[TrangThai] [nvarchar](50) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[SoHoSo] [int] NULL,
 CONSTRAINT [PK_QuyetDinhTD] PRIMARY KEY CLUSTERED 
(
	[MaQD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[Username] [varchar](30) NOT NULL,
	[Password] [varchar](50) NULL,
	[MaUV] [int] NULL,
	[MaNV] [int] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BangCC] ([Thang], [Nam]) VALUES (5, 2018)
INSERT [dbo].[BangPT] ([Thang], [Nam]) VALUES (5, 2018)
INSERT [dbo].[BangPT] ([Thang], [Nam]) VALUES (6, 2018)
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 17, 3, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 18, 3, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 19, 3, N'Nghỉ (có phép)')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 21, 3, N'Vào trễ')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 22, 3, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 23, 1, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 23, 2, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 23, 3, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 24, 1, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 24, 2, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 24, 3, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 25, 1, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 25, 2, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 25, 3, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 26, 1, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 26, 2, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 26, 3, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 27, 1, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 27, 2, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 27, 3, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 28, 1, N'Vào trễ')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 28, 2, N'Nghỉ (không phép)')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 28, 3, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 29, 1, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 29, 2, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 29, 3, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 30, 1, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 30, 2, N'Hoàn thành')
INSERT [dbo].[ChiTietCC] ([Thang], [Nam], [Ngay], [MaNV], [TrangThai]) VALUES (5, 2018, 30, 3, N'Hoàn thành')
INSERT [dbo].[ChiTietPT] ([Thang], [Nam], [Ngay], [MaNV], [GioPT]) VALUES (5, 2018, 19, 3, 3)
INSERT [dbo].[ChiTietPT] ([Thang], [Nam], [Ngay], [MaNV], [GioPT]) VALUES (6, 2018, 1, 2, 6)
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([MaCV], [TenChucVu], [ThoiGianThuViec], [MucLuongThuViec], [MucLuongCT], [PhuCap]) VALUES (1, N'Nhân viên', 60, 160000.0000, 240000.0000, 30000.0000)
INSERT [dbo].[ChucVu] ([MaCV], [TenChucVu], [ThoiGianThuViec], [MucLuongThuViec], [MucLuongCT], [PhuCap]) VALUES (2, N'Trưởng phòng', 60, 260000.0000, 330000.0000, 30000.0000)
INSERT [dbo].[ChucVu] ([MaCV], [TenChucVu], [ThoiGianThuViec], [MucLuongThuViec], [MucLuongCT], [PhuCap]) VALUES (3, N'Trưởng nhóm', 60, 200000.0000, 260000.0000, 30000.0000)
INSERT [dbo].[ChucVu] ([MaCV], [TenChucVu], [ThoiGianThuViec], [MucLuongThuViec], [MucLuongCT], [PhuCap]) VALUES (4, N'Trưởng bộ phận', 60, 330000.0000, 400000.0000, 30000.0000)
INSERT [dbo].[ChucVu] ([MaCV], [TenChucVu], [ThoiGianThuViec], [MucLuongThuViec], [MucLuongCT], [PhuCap]) VALUES (5, N'Thư kí', 60, 400000.0000, 470000.0000, 30000.0000)
INSERT [dbo].[ChucVu] ([MaCV], [TenChucVu], [ThoiGianThuViec], [MucLuongThuViec], [MucLuongCT], [PhuCap]) VALUES (6, N'Công nhân', 30, 160000.0000, 220000.0000, 30000.0000)
INSERT [dbo].[ChucVu] ([MaCV], [TenChucVu], [ThoiGianThuViec], [MucLuongThuViec], [MucLuongCT], [PhuCap]) VALUES (7, N'Part-time', 6, 88000.0000, 100000.0000, 0.0000)
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
INSERT [dbo].[DanhSachUV] ([MaQD], [MaUV], [NgayNop], [Trangthai]) VALUES (1, 1, CAST(N'2018-05-22' AS Date), NULL)
INSERT [dbo].[DanhSachUV] ([MaQD], [MaUV], [NgayNop], [Trangthai]) VALUES (1, 5, CAST(N'2018-05-16' AS Date), N'Chấp nhận')
INSERT [dbo].[DanhSachUV] ([MaQD], [MaUV], [NgayNop], [Trangthai]) VALUES (2, 1, CAST(N'2018-05-22' AS Date), NULL)
INSERT [dbo].[DanhSachUV] ([MaQD], [MaUV], [NgayNop], [Trangthai]) VALUES (2, 2, CAST(N'2018-05-22' AS Date), NULL)
INSERT [dbo].[DanhSachUV] ([MaQD], [MaUV], [NgayNop], [Trangthai]) VALUES (2, 3, CAST(N'2018-05-22' AS Date), NULL)
INSERT [dbo].[DanhSachUV] ([MaQD], [MaUV], [NgayNop], [Trangthai]) VALUES (3, 3, CAST(N'2018-05-22' AS Date), NULL)
INSERT [dbo].[DanhSachUV] ([MaQD], [MaUV], [NgayNop], [Trangthai]) VALUES (5, 2, CAST(N'2018-05-22' AS Date), NULL)
INSERT [dbo].[DanhSachUV] ([MaQD], [MaUV], [NgayNop], [Trangthai]) VALUES (5, 6, CAST(N'2018-05-22' AS Date), N'Chấp nhận')
INSERT [dbo].[DanhSachUV] ([MaQD], [MaUV], [NgayNop], [Trangthai]) VALUES (6, 4, CAST(N'2018-05-22' AS Date), N'Chấp nhận')
SET IDENTITY_INSERT [dbo].[HopDongTD] ON 

INSERT [dbo].[HopDongTD] ([MaHD], [Ngay], [ThoiHan], [Loai]) VALUES (1, CAST(N'2018-05-22' AS Date), 1, N'Ngắn hạn')
SET IDENTITY_INSERT [dbo].[HopDongTD] OFF
SET IDENTITY_INSERT [dbo].[HoSoUngVien] ON 

INSERT [dbo].[HoSoUngVien] ([MaUV], [HoTen], [GioiTinh], [NgaySinh], [CMND], [DiaChi], [SDT], [Email], [TrinhDoHocVan], [TinhTrangSucKhoe], [NgoaiNgu]) VALUES (1, N'Nhan Đặng Minh Đạt', N'Nam', CAST(N'1997-09-29' AS Date), N'025511677', N'62 Trần Văn Quang, phường 10, quận Tân Bình, Tp. Hồ Chí Minh', N'0903993243 ', N'datnhan2909@gmail.com', N'Đại học', N'Tốt', N'Tiếng Anh')
INSERT [dbo].[HoSoUngVien] ([MaUV], [HoTen], [GioiTinh], [NgaySinh], [CMND], [DiaChi], [SDT], [Email], [TrinhDoHocVan], [TinhTrangSucKhoe], [NgoaiNgu]) VALUES (2, N'Nguyễn Đình Bảo', N'Nam', CAST(N'1997-07-23' AS Date), N'241799348', N'Bùi Thị Xuân, Tân Bình, Tp.Hồ Chí Minh', N'0981875528 ', N'nguyenbao230797@gmail.com', N'Đại học', N'Tốt', N'Tiếng Anh')
INSERT [dbo].[HoSoUngVien] ([MaUV], [HoTen], [GioiTinh], [NgaySinh], [CMND], [DiaChi], [SDT], [Email], [TrinhDoHocVan], [TinhTrangSucKhoe], [NgoaiNgu]) VALUES (3, N'Cảnh Dương', N'Nam', CAST(N'1997-11-13' AS Date), N'025555571', N'Số 2 Bùi Thị Xuân, Tân Bình', N'01646145326', N'canhduong131197@gmail.com', N'Đại học', N'Tốt', N'Tiếng Anh')
INSERT [dbo].[HoSoUngVien] ([MaUV], [HoTen], [GioiTinh], [NgaySinh], [CMND], [DiaChi], [SDT], [Email], [TrinhDoHocVan], [TinhTrangSucKhoe], [NgoaiNgu]) VALUES (4, N'Vũ Thanh Hoàng', N'Nam', CAST(N'1997-08-21' AS Date), N'025555395', N'687/42 Lạc Long Quân, Tân Bình', N'01204444380', N'tinhcakhunglong@gmail.com', N'Đại học', N'Tốt', N'Tiếng Anh')
INSERT [dbo].[HoSoUngVien] ([MaUV], [HoTen], [GioiTinh], [NgaySinh], [CMND], [DiaChi], [SDT], [Email], [TrinhDoHocVan], [TinhTrangSucKhoe], [NgoaiNgu]) VALUES (5, N'user1', N'Nam', CAST(N'1997-01-01' AS Date), N'012345678', N'abcxyz', N'0123456789 ', N'baobao.vuonggia@gmail.com', N'Đại học', N'Tốt', N'Tiếng Anh')
INSERT [dbo].[HoSoUngVien] ([MaUV], [HoTen], [GioiTinh], [NgaySinh], [CMND], [DiaChi], [SDT], [Email], [TrinhDoHocVan], [TinhTrangSucKhoe], [NgoaiNgu]) VALUES (6, N'test', N'Nam', CAST(N'1997-01-01' AS Date), N'023456789', N'abcxyz', N'0123456789 ', N'datnhan2909@gmail.com', N'Đại học', N'Tốt', N'Anh văn')
INSERT [dbo].[HoSoUngVien] ([MaUV], [HoTen], [GioiTinh], [NgaySinh], [CMND], [DiaChi], [SDT], [Email], [TrinhDoHocVan], [TinhTrangSucKhoe], [NgoaiNgu]) VALUES (7, N'Vương Gia Bảo', N'Nam', CAST(N'1997-01-01' AS Date), N'023456789', N'Quận 8', N'0123456789 ', N'baobao.vuonggia@gmail.com', N'Đại học', N'Tốt', N'Tiếng Anh')
SET IDENTITY_INSERT [dbo].[HoSoUngVien] OFF
SET IDENTITY_INSERT [dbo].[KT_KL] ON 

INSERT [dbo].[KT_KL] ([MaKT_KL], [NoiDung], [Ngay], [Loai], [GiaTri], [MaNV], [TrangThai]) VALUES (1, N'Hoàn thành tốt công việc', CAST(N'2018-05-22' AS Date), N'Khen thưởng', 100000.0000, 3, N'Đã xử lý')
SET IDENTITY_INSERT [dbo].[KT_KL] OFF
SET IDENTITY_INSERT [dbo].[Luong] ON 

INSERT [dbo].[Luong] ([MaLuong], [MaNV], [GiaTri], [TinhTrang], [Thang], [Nam], [Songaycong], [Solantresom], [Songaynghicop], [Songaynghikp], [Sogiopt], [Khenthuong], [Kyluat]) VALUES (1, 3, 1306250.0000, N'Chưa nhận', 5, 2018, 12, 1, 1, 0, 3, 100000.0000, 0.0000)
SET IDENTITY_INSERT [dbo].[Luong] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [CMND], [DiaChi], [SDT], [Email], [TrinhDoHocVan], [TinhTrangSucKhoe], [NgoaiNgu], [NgayVaoLam], [MaQD], [TinhTrang], [MaHD]) VALUES (1, N'Vũ Thanh Hoàng', N'Nam', CAST(N'1997-08-21' AS Date), N'025555395', N'687/42 Lạc Long Quân, Tân Bình', N'01204444380', N'tinhcakhunglong@gmail.com', N'Đại học', N'Tốt', N'Tiếng Anh', CAST(N'2018-05-22' AS Date), 6, N'Thử việc', NULL)
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [CMND], [DiaChi], [SDT], [Email], [TrinhDoHocVan], [TinhTrangSucKhoe], [NgoaiNgu], [NgayVaoLam], [MaQD], [TinhTrang], [MaHD]) VALUES (2, N'test', N'Nam', CAST(N'1997-01-01' AS Date), N'023456789', N'abcxyz', N'0123456789 ', N'datnhan2909@gmail.com', N'Đại học', N'Tốt', N'Anh văn', CAST(N'2018-05-22' AS Date), 5, N'Thử việc', NULL)
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [CMND], [DiaChi], [SDT], [Email], [TrinhDoHocVan], [TinhTrangSucKhoe], [NgoaiNgu], [NgayVaoLam], [MaQD], [TinhTrang], [MaHD]) VALUES (3, N'user1', N'Nam', CAST(N'1997-01-01' AS Date), N'012345678', N'abcxyz', N'0123456789 ', N'baobao.vuonggia@gmail.com', N'Đại học', N'Tốt', N'Tiếng Anh', CAST(N'2018-05-16' AS Date), 1, N'Chính thức', 1)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
INSERT [dbo].[PhongBan] ([MaPB], [TenPhongBan]) VALUES (N'CS', N'Chăm sóc khách hàng')
INSERT [dbo].[PhongBan] ([MaPB], [TenPhongBan]) VALUES (N'IT', N'Công nghệ thông tin')
INSERT [dbo].[PhongBan] ([MaPB], [TenPhongBan]) VALUES (N'KD', N'Kinh doanh')
INSERT [dbo].[PhongBan] ([MaPB], [TenPhongBan]) VALUES (N'KT-SX', N'Kỹ thuật - Sản xuất')
INSERT [dbo].[PhongBan] ([MaPB], [TenPhongBan]) VALUES (N'KT-TC', N'Kế toán - Tài chính')
INSERT [dbo].[PhongBan] ([MaPB], [TenPhongBan]) VALUES (N'NC', N'Nghiên cứu')
INSERT [dbo].[PhongBan] ([MaPB], [TenPhongBan]) VALUES (N'NS', N'Hành chính - Nhân sự')
INSERT [dbo].[PhongBan] ([MaPB], [TenPhongBan]) VALUES (N'TK', N'Thiết kế đồ họa')
INSERT [dbo].[PhongBan] ([MaPB], [TenPhongBan]) VALUES (N'TT', N'Marketing')
INSERT [dbo].[QuanLy] ([Username], [Password], [Fullname], [IsAdmin], [Allower], [Email], [SDT]) VALUES (N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'Nhóm 5', 1, 4, N'adminhotro@gmail.com', N'0981231560 ')
INSERT [dbo].[QuanLy] ([Username], [Password], [Fullname], [IsAdmin], [Allower], [Email], [SDT]) VALUES (N'usercap1', N'e10adc3949ba59abbe56e057f20f883e', N'Danh sách ứng viên - QĐTD', 0, 1, N'cap1@gmail.com', N'0123456789 ')
INSERT [dbo].[QuanLy] ([Username], [Password], [Fullname], [IsAdmin], [Allower], [Email], [SDT]) VALUES (N'usercap2', N'e10adc3949ba59abbe56e057f20f883e', N'NV - CC - PT - KTKL - Lương', 0, 2, N'cap2@gmail.com', N'0123456789 ')
INSERT [dbo].[QuanLy] ([Username], [Password], [Fullname], [IsAdmin], [Allower], [Email], [SDT]) VALUES (N'usercap3', N'e10adc3949ba59abbe56e057f20f883e', N'Chức vụ - Phòng ban', 0, 3, N'cap3@gmail.com', N'0123456789 ')
SET IDENTITY_INSERT [dbo].[QuyetDinhTD] ON 

INSERT [dbo].[QuyetDinhTD] ([MaQD], [MaPB], [MaCV], [Mota], [Ngaycapnhat], [TrangThai], [SoLuong], [SoHoSo]) VALUES (1, N'CS', 7, N'Trực điện thoại tư vấn khách hàng, lương 2,000,000 đến 3,000,000', CAST(N'2018-05-16' AS Date), N'Còn tuyển', 3, 1)
INSERT [dbo].[QuyetDinhTD] ([MaQD], [MaPB], [MaCV], [Mota], [Ngaycapnhat], [TrangThai], [SoLuong], [SoHoSo]) VALUES (2, N'IT', 1, N'Thiết kế, bảo trì web ASP.NET ', CAST(N'2018-05-22' AS Date), N'Còn tuyển', 2, 3)
INSERT [dbo].[QuyetDinhTD] ([MaQD], [MaPB], [MaCV], [Mota], [Ngaycapnhat], [TrangThai], [SoLuong], [SoHoSo]) VALUES (3, N'KT-TC', 1, N'Kiểm toán công ty, lương thử việc 5,000,000 đến 7,000,000', CAST(N'2018-05-22' AS Date), N'Còn tuyển', 3, 1)
INSERT [dbo].[QuyetDinhTD] ([MaQD], [MaPB], [MaCV], [Mota], [Ngaycapnhat], [TrangThai], [SoLuong], [SoHoSo]) VALUES (4, N'KD', 5, N'Thư kí cho giám đốc phòng kinh doanh', CAST(N'2018-05-22' AS Date), N'Còn tuyển', 0, 0)
INSERT [dbo].[QuyetDinhTD] ([MaQD], [MaPB], [MaCV], [Mota], [Ngaycapnhat], [TrangThai], [SoLuong], [SoHoSo]) VALUES (5, N'KT-SX', 6, N'Công nhân làm việc tại nhà máy. Lương từ 5,000,000 đến 7,000,000', CAST(N'2018-05-22' AS Date), N'Còn tuyển', 9, 1)
INSERT [dbo].[QuyetDinhTD] ([MaQD], [MaPB], [MaCV], [Mota], [Ngaycapnhat], [TrangThai], [SoLuong], [SoHoSo]) VALUES (6, N'TK', 2, N'Quản lý nhân viên phòng thiết kế đồ họa', CAST(N'2018-05-22' AS Date), N'Còn tuyển', 0, 0)
SET IDENTITY_INSERT [dbo].[QuyetDinhTD] OFF
INSERT [dbo].[TaiKhoan] ([Username], [Password], [MaUV], [MaNV]) VALUES (N'baobao', N'e10adc3949ba59abbe56e057f20f883e', 7, NULL)
INSERT [dbo].[TaiKhoan] ([Username], [Password], [MaUV], [MaNV]) VALUES (N'baonguyen', N'e10adc3949ba59abbe56e057f20f883e', 2, NULL)
INSERT [dbo].[TaiKhoan] ([Username], [Password], [MaUV], [MaNV]) VALUES (N'chuhonho13', N'e10adc3949ba59abbe56e057f20f883e', 3, NULL)
INSERT [dbo].[TaiKhoan] ([Username], [Password], [MaUV], [MaNV]) VALUES (N'minhhdattt', N'e10adc3949ba59abbe56e057f20f883e', 1, NULL)
INSERT [dbo].[TaiKhoan] ([Username], [Password], [MaUV], [MaNV]) VALUES (N'test', N'81dc9bdb52d04dc20036dbd8313ed055', NULL, 2)
INSERT [dbo].[TaiKhoan] ([Username], [Password], [MaUV], [MaNV]) VALUES (N'trumsanco', N'e10adc3949ba59abbe56e057f20f883e', NULL, 1)
INSERT [dbo].[TaiKhoan] ([Username], [Password], [MaUV], [MaNV]) VALUES (N'user1', N'81dc9bdb52d04dc20036dbd8313ed055', NULL, 3)
ALTER TABLE [dbo].[ChucVu] ADD  DEFAULT ((0)) FOR [PhuCap]
GO
ALTER TABLE [dbo].[QuyetDinhTD] ADD  DEFAULT ((0)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[QuyetDinhTD] ADD  DEFAULT ((0)) FOR [SoHoSo]
GO
ALTER TABLE [dbo].[ChiTietCC]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietCC_BangCC] FOREIGN KEY([Thang], [Nam])
REFERENCES [dbo].[BangCC] ([Thang], [Nam])
GO
ALTER TABLE [dbo].[ChiTietCC] CHECK CONSTRAINT [FK_ChiTietCC_BangCC]
GO
ALTER TABLE [dbo].[ChiTietCC]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietCC_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChiTietCC] CHECK CONSTRAINT [FK_ChiTietCC_NhanVien]
GO
ALTER TABLE [dbo].[ChiTietPT]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPT_BangPT] FOREIGN KEY([Thang], [Nam])
REFERENCES [dbo].[BangPT] ([Thang], [Nam])
GO
ALTER TABLE [dbo].[ChiTietPT] CHECK CONSTRAINT [FK_ChiTietPT_BangPT]
GO
ALTER TABLE [dbo].[ChiTietPT]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPT_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChiTietPT] CHECK CONSTRAINT [FK_ChiTietPT_NhanVien]
GO
ALTER TABLE [dbo].[DanhSachUV]  WITH CHECK ADD  CONSTRAINT [FK_DanhSachUV_HoSoUngVien] FOREIGN KEY([MaUV])
REFERENCES [dbo].[HoSoUngVien] ([MaUV])
GO
ALTER TABLE [dbo].[DanhSachUV] CHECK CONSTRAINT [FK_DanhSachUV_HoSoUngVien]
GO
ALTER TABLE [dbo].[DanhSachUV]  WITH CHECK ADD  CONSTRAINT [FK_DanhSachUV_QuyetDinhTD] FOREIGN KEY([MaQD])
REFERENCES [dbo].[QuyetDinhTD] ([MaQD])
GO
ALTER TABLE [dbo].[DanhSachUV] CHECK CONSTRAINT [FK_DanhSachUV_QuyetDinhTD]
GO
ALTER TABLE [dbo].[KT_KL]  WITH CHECK ADD  CONSTRAINT [FK_KT_KL_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[KT_KL] CHECK CONSTRAINT [FK_KT_KL_NhanVien]
GO
ALTER TABLE [dbo].[Luong]  WITH CHECK ADD  CONSTRAINT [FK_Luong_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[Luong] CHECK CONSTRAINT [FK_Luong_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_HopDongTD] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HopDongTD] ([MaHD])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_HopDongTD]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_QuyetDinhTD] FOREIGN KEY([MaQD])
REFERENCES [dbo].[QuyetDinhTD] ([MaQD])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_QuyetDinhTD]
GO
ALTER TABLE [dbo].[QuyetDinhTD]  WITH CHECK ADD  CONSTRAINT [FK_QuyetDinhTD_ChucVu] FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([MaCV])
GO
ALTER TABLE [dbo].[QuyetDinhTD] CHECK CONSTRAINT [FK_QuyetDinhTD_ChucVu]
GO
ALTER TABLE [dbo].[QuyetDinhTD]  WITH CHECK ADD  CONSTRAINT [FK_QuyetDinhTD_PhongBan] FOREIGN KEY([MaPB])
REFERENCES [dbo].[PhongBan] ([MaPB])
GO
ALTER TABLE [dbo].[QuyetDinhTD] CHECK CONSTRAINT [FK_QuyetDinhTD_PhongBan]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_HoSoUngVien] FOREIGN KEY([MaUV])
REFERENCES [dbo].[HoSoUngVien] ([MaUV])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_HoSoUngVien]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
/****** Object:  StoredProcedure [dbo].[AcceptHoSo]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AcceptHoSo]
	@MaUV int, 
	@MaQD int
as
begin
	update DanhSachUV
	set Trangthai = N'Chấp nhận'
	where MaQD = @MaQD and MaUV = @MaUV
	delete from DanhSachUV
	where @MaQD != MaQD and MaUV = @MaUV
	update QuyetDinhTD
	set SoHoSo = SoHoSo - 1,
	SoLuong = SoLuong - 1
	where MaQD = @MaQD
end
GO
/****** Object:  StoredProcedure [dbo].[CapNhatLuong]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CapNhatLuong]
	@manv int,
	@thang int,
	@nam int
as
begin
	update Luong
	set Songaycong = (select COUNT(TrangThai) from ChiTietCC where MaNV = @manv and Thang =@thang and Nam = @nam and TrangThai not like N'Nghỉ%'),
	Solantresom = (select COUNT(TrangThai) from ChiTietCC where (MaNV = @manv and Thang =@thang and Nam = @nam and TrangThai like N'Vào trễ') or (MaNV = @manv and Thang =@thang and Nam = @nam and TrangThai like N'Ra sớm')),
	Songaynghicop = (select COUNT(TrangThai) from ChiTietCC where MaNV = @manv and Thang =@thang and Nam = @nam and TrangThai like N'%có phép%'),
	Songaynghikp = (select COUNT(TrangThai) from ChiTietCC where MaNV = @manv and Thang =@thang and Nam = @nam and TrangThai like N'%không phép%'),
	Sogiopt = (select SUM(GioPT) from ChiTietPT where MaNV = @manv and Thang =@thang and Nam = @nam),
	Khenthuong = (select SUM(GiaTri) from KT_KL where MaNV = @manv and Loai like N'Khen thưởng' and MONTH(Ngay) = @thang and YEAR(Ngay) = @nam),
	Kyluat = (select SUM(GiaTri) from KT_KL where MaNV = @manv and Loai like N'Kỷ luật' and MONTH(Ngay) = @thang and YEAR(Ngay) = @nam)
	where MaNV = @manv and Thang = @thang and Nam = @nam
	update KT_KL
	set TrangThai = N'Đã xử lý'
	where MaNV = @manv and MONTH(Ngay) = @thang and YEAR(Ngay) = @nam
	if((select Sogiopt from Luong where MaNV = @manv and Thang = @thang and Nam = @nam) is null)
		update Luong
		set Sogiopt = 0
		where MaNV = @manv and Thang = @thang and Nam = @nam
	if((select Khenthuong from Luong where MaNV = @manv and Thang = @thang and Nam = @nam) is null)
		update Luong
		set Khenthuong = 0
		where MaNV = @manv and Thang = @thang and Nam = @nam
	if((select Kyluat from Luong where MaNV = @manv and Thang = @thang and Nam = @nam) is null)
		update Luong
		set Kyluat = 0
		where MaNV = @manv and Thang = @thang and Nam = @nam
	if((select TinhTrang from NhanVien where MaNV = @manv) like N'Thử việc')
		update Luong
		set GiaTri = Songaycong * (select MucLuongThuViec from ChucVu where MaCV = (select MaCV from QuyetDinhTD where MaQD = (select MaQD from NhanVien where MaNV =@manv))) + Sogiopt * (select MucLuongThuViec from ChucVu where MaCV = (select MaCV from QuyetDinhTD where MaQD = (select MaQD from NhanVien where MaNV =@manv)))/8*15/10 - Solantresom * 50000 - Songaynghikp * 200000 + Khenthuong - Kyluat
		where MaNV = @manv and Thang = @thang and Nam = @nam
	else
		update Luong
		set GiaTri = Songaycong * (select MucLuongCT from ChucVu where MaCV = (select MaCV from QuyetDinhTD where MaQD = (select MaQD from NhanVien where MaNV =@manv))) + Sogiopt * (select MucLuongCT from ChucVu where MaCV = (select MaCV from QuyetDinhTD where MaQD = (select MaQD from NhanVien where MaNV =@manv)))/8*15/10 - Solantresom * 50000 - Songaynghikp * 200000 + Khenthuong - Kyluat
		where MaNV = @manv and Thang = @thang and Nam = @nam
end
GO
/****** Object:  StoredProcedure [dbo].[DeclineHoSo]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[DeclineHoSo]
	@MaUV int, 
	@MaQD int
as
begin
	update DanhSachUV
	set Trangthai = N'Từ chối'
	where MaQD = @MaQD and MaUV = @MaUV
	update QuyetDinhTD
	set SoHoSo = SoHoSo - 1 
	where MaQD = @MaQD
end
GO
/****** Object:  StoredProcedure [dbo].[ThemHoSo]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ThemHoSo]
	@MaUV int, 
	@MaQD int,
	@Ngay date
as
begin
	if ((select SoHoSo from QuyetDinhTD where MaQD =@MaQD)is null)
		update QuyetDinhTD
		set SoHoSo = 0
		where MaQD =@MaQD
	insert [dbo].[DanhSachUV] (MaQD, MaUV, NgayNop) values (@MaQD, @MaUV, @Ngay)	
	update QuyetDinhTD
	set SoHoSo = SoHoSo + 1
	where MaQD = @MaQD
end
GO
/****** Object:  StoredProcedure [dbo].[TinhLuong]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[TinhLuong]
	@manv int,
	@thang int,
	@nam int
as
begin
	insert [dbo].[Luong] ([MaNV], [Thang], [Nam], [GiaTri], [TinhTrang]) values (@manv, @thang, @nam, 0, N'Chưa nhận')
	update Luong
	set Songaycong = (select COUNT(TrangThai) from ChiTietCC where MaNV = @manv and Thang =@thang and Nam = @nam and TrangThai not like N'Nghỉ%'),
	Solantresom = (select COUNT(TrangThai) from ChiTietCC where (MaNV = @manv and Thang =@thang and Nam = @nam and TrangThai like N'Vào trễ') or (MaNV = @manv and Thang =@thang and Nam = @nam and TrangThai like N'Ra sớm')),
	Songaynghicop = (select COUNT(TrangThai) from ChiTietCC where MaNV = @manv and Thang =@thang and Nam = @nam and TrangThai like N'%có phép%'),
	Songaynghikp = (select COUNT(TrangThai) from ChiTietCC where MaNV = @manv and Thang =@thang and Nam = @nam and TrangThai like N'%không phép%'),
	Sogiopt = (select SUM(GioPT) from ChiTietPT where MaNV = @manv and Thang =@thang and Nam = @nam),
	Khenthuong = (select SUM(GiaTri) from KT_KL where MaNV = @manv and Loai like N'Khen thưởng' and MONTH(Ngay) = @thang and YEAR(Ngay) = @nam),
	Kyluat = (select SUM(GiaTri) from KT_KL where MaNV = @manv and Loai like N'Kỷ luật' and MONTH(Ngay) = @thang and YEAR(Ngay) = @nam)
	where MaNV = @manv and Thang = @thang and Nam = @nam
	update KT_KL
	set TrangThai = N'Đã xử lý'
	where MaNV = @manv and MONTH(Ngay) = @thang and YEAR(Ngay) = @nam
	if((select Sogiopt from Luong where MaNV = @manv and Thang = @thang and Nam = @nam) is null)
		update Luong
		set Sogiopt = 0
		where MaNV = @manv and Thang = @thang and Nam = @nam
	if((select Khenthuong from Luong where MaNV = @manv and Thang = @thang and Nam = @nam) is null)
		update Luong
		set Khenthuong = 0
		where MaNV = @manv and Thang = @thang and Nam = @nam
	if((select Kyluat from Luong where MaNV = @manv and Thang = @thang and Nam = @nam) is null)
		update Luong
		set Kyluat = 0
		where MaNV = @manv and Thang = @thang and Nam = @nam
	if((select TinhTrang from NhanVien where MaNV = @manv) like N'Thử việc')
		update Luong
		set GiaTri = Songaycong * (select MucLuongThuViec from ChucVu where MaCV = (select MaCV from QuyetDinhTD where MaQD = (select MaQD from NhanVien where MaNV =@manv))) + Sogiopt * (select MucLuongThuViec from ChucVu where MaCV = (select MaCV from QuyetDinhTD where MaQD = (select MaQD from NhanVien where MaNV =@manv)))/8*15/10 - Solantresom * 50000 - Songaynghikp * 200000 + Khenthuong - Kyluat
		where MaNV = @manv and Thang = @thang and Nam = @nam
	else
		update Luong
		set GiaTri = Songaycong * (select MucLuongCT from ChucVu where MaCV = (select MaCV from QuyetDinhTD where MaQD = (select MaQD from NhanVien where MaNV =@manv))) + Sogiopt * (select MucLuongCT from ChucVu where MaCV = (select MaCV from QuyetDinhTD where MaQD = (select MaQD from NhanVien where MaNV =@manv)))/8*15/10 - Solantresom * 50000 - Songaynghikp * 200000 + Khenthuong - Kyluat
		where MaNV = @manv and Thang = @thang and Nam = @nam

end
GO
/****** Object:  StoredProcedure [dbo].[XoaNhanVien]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[XoaNhanVien]
	@MaNV int
as
begin
	Delete from ChiTietCC Where MaNV = @MaNV
	Delete from ChiTietPT Where MaNV = @MaNV
	Delete from KT_KL Where MaNV = @MaNV
	Delete from TaiKhoan Where MaNV = @MaNV
	Delete from Luong Where MaNV = @MaNV
	Delete from NhanVien where MaNV = @MaNV
end
GO
/****** Object:  StoredProcedure [dbo].[XoaPhongBan]    Script Date: 01/06/2018 6:28:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[XoaPhongBan]
	@MaPB varchar(10)
as
begin
	Delete from ChiTietCC Where MaNV = (select MaNV from NhanVien
										where MaQD = (select MaQD from QuyetDinhTD
													  where MaPB = @MaPB))
	Delete from ChiTietPT Where MaNV = (select MaNV from NhanVien
										where MaQD = (select MaQD from QuyetDinhTD
													  where MaPB = @MaPB))
	Delete from KT_KL Where MaNV = (select MaNV from NhanVien
										where MaQD = (select MaQD from QuyetDinhTD
													  where MaPB = @MaPB))
	Delete from TaiKhoan Where MaNV = (select MaNV from NhanVien
										where MaQD = (select MaQD from QuyetDinhTD
													  where MaPB = @MaPB))
	Delete from Luong Where MaNV = (select MaNV from NhanVien
										where MaQD = (select MaQD from QuyetDinhTD
													  where MaPB = @MaPB))
	Delete from NhanVien where MaQD = (select MaQD from QuyetDinhTD where MaPB = @MaPB)
	Delete from DanhSachUV where MaQD = (select MaQD from QuyetDinhTD where MaPB = @MaPB)
	Delete from QuyetDinhTD where MaPB = @MaPB
	Delete from PhongBan where MaPB = @MaPB
end
GO
