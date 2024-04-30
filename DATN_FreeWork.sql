USE [master]
GO
/****** Object:  Database [db_WebsiteTimkiemvieclam]    Script Date: 4/5/2024 3:41:44 PM ******/
CREATE DATABASE [db_WebsiteTimkiemvieclam]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_WebsiteTimkiemvieclam', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\db_WebsiteTimkiemvieclam.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_WebsiteTimkiemvieclam_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\db_WebsiteTimkiemvieclam_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_WebsiteTimkiemvieclam].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET  MULTI_USER 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET QUERY_STORE = OFF
GO
USE [db_WebsiteTimkiemvieclam]
GO
/****** Object:  Table [dbo].[tblBaituyendung]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBaituyendung](
	[PK_sMaBai] [bigint] IDENTITY(1,1) NOT NULL,
	[sTenBai] [nvarchar](100) NOT NULL,
	[sMoTa] [nvarchar](max) NULL,
	[sYeuCau] [nvarchar](max) NOT NULL,
	[sQuyenLoi] [nvarchar](max) NULL,
	[fMucLuongtoithieu] [float] NULL,
	[fNamKinhNghiem] [float] NULL,
	[dTgTuyenDung] [date] NULL,
	[iSoLuong] [int] NULL,
	[dTgDangBai] [date] NULL,
	[FK_sMaDN] [bigint] NOT NULL,
	[iTrangthai] [int] NULL,
	[sDiachicuthe] [nvarchar](max) NULL,
	[fMucluongtoida] [float] NULL,
 CONSTRAINT [PK_tblBaituyendung] PRIMARY KEY CLUSTERED 
(
	[PK_sMaBai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDoanhnghiep]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDoanhnghiep](
	[PK_sMaDN] [bigint] IDENTITY(1,1) NOT NULL,
	[sMasothue] [bigint] NOT NULL,
	[sTenDN] [nvarchar](100) NOT NULL,
	[sLogo] [varchar](max) NOT NULL,
	[sMota] [nvarchar](max) NULL,
	[sDiachi] [nvarchar](200) NULL,
	[sSDT] [varchar](10) NULL,
	[FK_sEmail] [varchar](200) NOT NULL,
 CONSTRAINT [PK_tblDoanhnghiep] PRIMARY KEY CLUSTERED 
(
	[PK_sMaDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblQuyen]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblQuyen](
	[PK_sMaQuyen] [bigint] IDENTITY(1,1) NOT NULL,
	[sTenQuyen] [nvarchar](50) NOT NULL,
	[bTrangThai] [bit] NOT NULL,
 CONSTRAINT [PK_tblQuyen] PRIMARY KEY CLUSTERED 
(
	[PK_sMaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTaikhoan]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTaikhoan](
	[PK_sEmail] [varchar](200) NOT NULL,
	[sMatkhau] [varchar](100) NOT NULL,
	[FK_sMaQuyen] [bigint] NOT NULL,
 CONSTRAINT [PK_tblTaikhoan] PRIMARY KEY CLUSTERED 
(
	[PK_sEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblThongTinUngTuyen]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblThongTinUngTuyen](
	[PK_FK_sMaUngVien] [bigint] NOT NULL,
	[PK_FK_sMaBai] [bigint] NOT NULL,
	[dNgayGui] [date] NOT NULL,
	[sGioithieu] [nvarchar](200) NULL,
	[sCV] [varchar](max) NOT NULL,
	[bTrangthai] [bit] NOT NULL,
 CONSTRAINT [PK_tblThongTinUnTuyen] PRIMARY KEY CLUSTERED 
(
	[PK_FK_sMaUngVien] ASC,
	[PK_FK_sMaBai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUngVien]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUngVien](
	[PK_sMaUngVien] [bigint] IDENTITY(1,1) NOT NULL,
	[sHoTen] [nvarchar](50) NULL,
	[bGioiTinh] [bit] NULL,
	[sAnh] [varchar](max) NULL,
	[sSDT] [varchar](10) NULL,
	[FK_sEmail] [varchar](200) NOT NULL,
 CONSTRAINT [PK_tblUngVien] PRIMARY KEY CLUSTERED 
(
	[PK_sMaUngVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblWebsite]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblWebsite](
	[PK_sMaWebsite] [bigint] NOT NULL,
	[sTenWebsite] [nvarchar](200) NOT NULL,
	[sLink] [varchar](100) NOT NULL,
	[FK_sMaDN] [bigint] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblBaituyendung]  WITH CHECK ADD  CONSTRAINT [FK_tblBaituyendung_tblDoanhnghiep] FOREIGN KEY([FK_sMaDN])
REFERENCES [dbo].[tblDoanhnghiep] ([PK_sMaDN])
GO
ALTER TABLE [dbo].[tblBaituyendung] CHECK CONSTRAINT [FK_tblBaituyendung_tblDoanhnghiep]
GO
ALTER TABLE [dbo].[tblDoanhnghiep]  WITH CHECK ADD  CONSTRAINT [FK_tblDoanhnghiep_tblTaikhoan] FOREIGN KEY([FK_sEmail])
REFERENCES [dbo].[tblTaikhoan] ([PK_sEmail])
GO
ALTER TABLE [dbo].[tblDoanhnghiep] CHECK CONSTRAINT [FK_tblDoanhnghiep_tblTaikhoan]
GO
ALTER TABLE [dbo].[tblTaikhoan]  WITH CHECK ADD  CONSTRAINT [FK_tblTaikhoan_tblQuyen] FOREIGN KEY([FK_sMaQuyen])
REFERENCES [dbo].[tblQuyen] ([PK_sMaQuyen])
GO
ALTER TABLE [dbo].[tblTaikhoan] CHECK CONSTRAINT [FK_tblTaikhoan_tblQuyen]
GO
ALTER TABLE [dbo].[tblThongTinUngTuyen]  WITH CHECK ADD  CONSTRAINT [FK_tblThongTinUngTuyen_tblBaituyendung] FOREIGN KEY([PK_FK_sMaBai])
REFERENCES [dbo].[tblBaituyendung] ([PK_sMaBai])
GO
ALTER TABLE [dbo].[tblThongTinUngTuyen] CHECK CONSTRAINT [FK_tblThongTinUngTuyen_tblBaituyendung]
GO
ALTER TABLE [dbo].[tblThongTinUngTuyen]  WITH CHECK ADD  CONSTRAINT [FK_tblThongTinUngTuyen_tblUngVien] FOREIGN KEY([PK_FK_sMaUngVien])
REFERENCES [dbo].[tblUngVien] ([PK_sMaUngVien])
GO
ALTER TABLE [dbo].[tblThongTinUngTuyen] CHECK CONSTRAINT [FK_tblThongTinUngTuyen_tblUngVien]
GO
ALTER TABLE [dbo].[tblUngVien]  WITH CHECK ADD  CONSTRAINT [fk_CustomerID] FOREIGN KEY([FK_sEmail])
REFERENCES [dbo].[tblTaikhoan] ([PK_sEmail])
GO
ALTER TABLE [dbo].[tblUngVien] CHECK CONSTRAINT [fk_CustomerID]
GO
ALTER TABLE [dbo].[tblWebsite]  WITH CHECK ADD  CONSTRAINT [FK_tblWebsite_tblDoanhnghiep] FOREIGN KEY([FK_sMaDN])
REFERENCES [dbo].[tblDoanhnghiep] ([PK_sMaDN])
GO
ALTER TABLE [dbo].[tblWebsite] CHECK CONSTRAINT [FK_tblWebsite_tblDoanhnghiep]
GO
/****** Object:  StoredProcedure [dbo].[sp_dangki]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_dangki](@PK_sEmail nvarchar(200), @sMatkhau varchar(100),@FK_sMaQuyen bigint )
as
	begin
		insert into tblTaikhoan
		values(@PK_sEmail,@sMatkhau,@FK_sMaQuyen)
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_dangnhap]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_dangnhap](@PK_sEmail nvarchar(200),@sMatkhau varchar(100))
as
	begin
		select * from tblTaikhoan where (tblTaikhoan.PK_sEmail=PK_sEmail and sMatkhau=@sMatkhau)
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_ketthucthoigianTD]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ketthucthoigianTD](@FK_sMaDN bigint, @PK_sMabai bigint)
as 
	begin
		update tblBaituyendung
		set bTrangThai=2
		where (@FK_sMaDN=FK_sMaDN and @PK_sMabai=FK_sMaDN)
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_suabaidang]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suabaidang](@PK_sMabai bigint,@sTenBai nvarchar(100), @sMota nvarchar(max), @sYeucau nvarchar(max),@sQuyenloi nvarchar(max),@fMucLuong float, @fNamKinhNghiem float,@dTgTuyenDung datetime, @isoluong int, @dTgDangbai datetime, @bTrangthai bit, @FK_sMaDN bigint, @sVitri nvarchar(500))
as
	begin
	Update tblBaituyendung
	set sTenBai=@sTenBai,
		sMoTa=@sMota,
		sYeuCau=@sYeucau,
		sQuyenLoi=@sQuyenloi,
		fMucLuong=@fMucLuong,
		fNamKinhNghiem=@fNamKinhNghiem,
		dTgTuyenDung=@dTgTuyenDung,
		iSoLuong=@isoluong,
		dTgDangBai=@dTgDangbai,
		bTrangThai=@bTrangthai ,
		FK_sMaDN=@FK_sMaDN,
		sVitri=@sVitri
	where (@PK_sMabai=PK_sMaBai)
	end 
GO
/****** Object:  StoredProcedure [dbo].[sp_thembaidang]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_thembaidang](@PK_sMabai bigint, @sTenBai nvarchar(100), @sMota nvarchar(max), @sYeucau nvarchar(max),@sQuyenloi nvarchar(max),@fMucLuong float, @fNamKinhNghiem float,@dTgTuyenDung datetime, @isoluong int, @dTgDangbai datetime, @bTrangthai bit, @FK_sMaDN bigint, @sVitri nvarchar(500))
as
	begin
	insert into  [dbo].[tblBaituyendung] ([sTenBai],[sMoTa],[sYeuCau],[sQuyenLoi],[fMucLuong],[fNamKinhNghiem],[dTgTuyenDung],[iSoLuong],[dTgDangBai],[bTrangThai] ,[FK_sMaDN],[sVitri])
		values(@sTenBai,@sMota,@sYeucau,@sQuyenloi,@fMucLuong,@fNamKinhNghiem,@dTgTuyenDung,@isoluong,@dTgDangbai,@bTrangthai,@FK_sMaDN,@sVitri)
	end 
GO
/****** Object:  StoredProcedure [dbo].[sp_timkiemCVtheovitri]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_timkiemCVtheovitri](@PK_sMaDN bigint, @PK_sMabai bigint)
as 
	begin 
	select tblThongTinUngTuyen.PK_FK_sMaUngVien,tblThongTinUngTuyen.dNgayGui from tblThongTinUngTuyen inner join tblBaituyendung on(tblThongTinUngTuyen.PK_FK_sMaBai=tblBaituyendung.PK_sMaBai) where( @PK_sMaDN=tblBaituyendung.FK_sMaDN and PK_sMaBai=@PK_sMabai)
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_xoabaidang]    Script Date: 4/5/2024 3:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_xoabaidang](@PK_sMabai bigint)
as 
	begin 
	delete  from tblBaituyendung where (@PK_sMabai=PK_sMaBai) 
	end
GO
USE [master]
GO
ALTER DATABASE [db_WebsiteTimkiemvieclam] SET  READ_WRITE 
GO

-----Bo sung du lieu-----------------






