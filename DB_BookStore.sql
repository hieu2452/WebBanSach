create database [DB_BookStore]
use [DB_BookStore]

CREATE TABLE [dbo].[tSach](
	[MaSach] int NOT NULL IDENTITY(1,1),
	[TenSach] [nvarchar](100) NOT NULL,
	[TacGia] [nvarchar](100) NOT NULL,
	[DonGia] [float] NULL,
	[SoLuong] [int] NULL,
	[MaTL] int  NULL,
	[MaNXB] int  NULL,
 CONSTRAINT [PK_tSach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

alter table tSach
add Anh [nvarchar](1000 )
alter table tSach
add MaNG int
alter table tSach
add Mota [nvarchar](500)

CREATE TABLE [dbo].[tHoaDon](
	[MaHD] int NOT NULL IDENTITY(1,1),
	[NgayTao] [datetime] NULL,
	[ID] int  NULL,
 CONSTRAINT [PK_tHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



CREATE TABLE [dbo].[tUser](
	[ID] int NOT NULL IDENTITY(1,1),
	[UserN] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [int] NULL,
	[Email] [nvarchar](100) NULL,
	[passW] [nvarchar](100) NULL,
	[roleID] int NULL,
 CONSTRAINT [PK_tUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
alter table tUSer
drop column roleID

alter table tUSer
add  roleID varchar(10) null

alter table tUSer
add AnhDaiDien [nvarchar](1000 )


CREATE TABLE [dbo].[tTheLoai](
	[MaTL] int NOT NULL IDENTITY(1,1),
	[TenTL] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tTheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[tNhaXuatBan](
	[MaNXB] int NOT NULL IDENTITY(1,1),
	[TenNXB] [nvarchar](100) NOT NULL,
	[Url] [nvarchar](100) NULL,
 CONSTRAINT [PK_tNhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[tUserRole](
	[roleID] int NOT NULL IDENTITY(1,1),
	[MoTa] [nvarchar](100) NULL,
 CONSTRAINT [PK_tUserRole] PRIMARY KEY CLUSTERED 
(
	[roleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE tUSerRole
DROP CONSTRAINT PK_tUserRole;
GO

alter table tUSerRole
drop column roleID

alter table tUSerRole
add  roleID varchar(10) not null

ALTER TABLE tUSerRole
ADD CONSTRAINT PK_tUserRole PRIMARY KEY CLUSTERED (roleID);
GO


CREATE TABLE [dbo].[tKho](
	[MaKho] int NOT NULL IDENTITY(1,1),
	[TenKho] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](100) NULL,
 CONSTRAINT [PK_tKho] PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[tSach_Kho](
	[MaKho] int NOT NULL ,
	[MaSach] int NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_tSach_Kho] PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[tChiTietHoaDon](
	[MaHD] int NOT NULL ,
	[MaSach] int NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_tChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE tChiTietHoaDon
DROP CONSTRAINT PK_tChiTietHoaDon;
GO
ALTER TABLE tChiTietHoaDon
DROP CONSTRAINT [FK_tChiTietHoaDon_tHoaDon];
GO
ALTER TABLE tChiTietHoaDon
DROP CONSTRAINT [FK_tChiTietHoaDon_tSach];
GO

alter table tChiTietHoaDon
drop column [MaHD]

alter table tChiTietHoaDon
drop column [MaSach]

alter table tChiTietHoaDon
add  [MaHD] int not null

alter table tChiTietHoaDon
add  [MaSach] int not null 

ALTER TABLE tChiTietHoaDon
ADD CONSTRAINT PK_tChiTietHoaDon PRIMARY KEY CLUSTERED ([MaHD],[MaSach]);
GO


CREATE TABLE [dbo].[tNgonNgu](
	[MaNG] int NOT NULL IDENTITY(1,1),
	[Mota] [nvarchar](100) NULL,
 CONSTRAINT [PK_tNgonNgu] PRIMARY KEY CLUSTERED 
(
	[MaNG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[tSach]  WITH CHECK ADD  CONSTRAINT [FK_tSach _tNgonNgu] FOREIGN KEY([MaNG])
REFERENCES [dbo].[tNgonNgu] ([MaNG])


ALTER TABLE [dbo].[tSach]  WITH CHECK ADD  CONSTRAINT [FK_tSach _tTheLoai] FOREIGN KEY([MaTL])
REFERENCES [dbo].[tTheLoai] ([MaTL])

ALTER TABLE [dbo].[tSach]  WITH CHECK ADD  CONSTRAINT [FK_tSach _tNhaXuatBan] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[tNhaXuatBan] ([MaNXB])

ALTER TABLE [dbo].[tHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tHoaDon _tUser] FOREIGN KEY([ID])
REFERENCES [dbo].[tUser] ([ID])

ALTER TABLE [dbo].[tUser]  WITH CHECK ADD  CONSTRAINT [FK_tUser_tUserRole] FOREIGN KEY([roleID])
REFERENCES [dbo].[tUserRole] ([roleID])

ALTER TABLE [dbo].[tSach_Kho]  WITH CHECK ADD  CONSTRAINT [FK_tSachKho_tSach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[tSach] ([MaSach])

ALTER TABLE [dbo].[tSach_Kho]  WITH CHECK ADD  CONSTRAINT [FK_tSachKho_tKho] FOREIGN KEY([MaKho])
REFERENCES [dbo].[tKho] ([MaKho])

ALTER TABLE [dbo].[tChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tChiTietHoaDon_tHoaDon] FOREIGN KEY([MaHD])
REFERENCES [dbo].[tHoaDon] ([MaHD])

ALTER TABLE [dbo].[tChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tChiTietHoaDon_tSach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[tSach] ([MaSach])

insert into tUserRole(roleID,MoTa) values ('Admin','Quan ly')
insert into tUserRole(roleID,MoTa) values ('User','Nguoi dung')

insert into tUser(ID,UserN,DiaChi,SDT,Email,passW,roleID) values ('3','admin','Ha Noi','0932323','admin@gmail.com','123','Admin')
insert into tUser(ID,UserN,DiaChi,SDT,Email,passW,roleID) values ('4','user','Ha Noi','093232333','user@gmail.com','123','User')
insert into tUser(UserN,DiaChi,SDT,Email,passW,roleID) values ('user','Ha Noi','093232333','user@gmail.com','123','User')
insert into tUser(UserN,DiaChi,SDT,Email,passW,roleID) values ('user','Ha Noi','093232333','user1@gmail.com','123','User')

insert into tTheLoai(TenTL) values ('Hai Huoc')
insert into tNgonNgu(Mota) values ('Tieng Viet')

select * from tSach