CREATE DATABASE QL_DTDD1;

CREATE TABLE Loai
(	
	MaLoai CHAR(10) PRIMARY KEY,
	TenLoai NVARCHAR(100) NOT NULL
);

CREATE TABLE SanPham
(
	MaSP CHAR(10) PRIMARY KEY,
	TenSP NVARCHAR(255) NOT NULL,
	DuongDan VARCHAR(255),
	Gia DECIMAL(18,2) NOT NULL,
	MoTa NVARCHAR(100),
	MaLoai CHAR(10),
	FOREIGN KEY (MaLoai) REFERENCES Loai(MaLoai)
);

CREATE TABLE KhachHang
(
	MaKH CHAR(10) PRIMARY KEY,
	HoTen NVARCHAR(150) NOT NULL,
	DienThoai VARCHAR(20),
	GioiTinh NVARCHAR(10),
	SoThich NVARCHAR(255),
	Email VARCHAR(100),
	MatKhau VARCHAR(255) NOT NULL
);
GO

CREATE TABLE GioHang
(
    MaGH CHAR(10),
    MaKH CHAR(10),
	MaSP CHAR(10),
	SoLuong INT NOT NULL,
	Ngay DATE NOT NULL,
	PRIMARY KEY (MaGH, MaSP), 
	FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
	FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

INSERT INTO Loai VALUES 
('1',N'Nokia'),
('2',N'SamSung'),
('3',N'Motorola'),
('4',N'LG'),
('5',N'Oppo'),
('6',N'Iphone'),
('7',N'BPhone')

INSERT INTO SanPham VALUES
('1', N'N701', N'N70.jpg', 2000000.00, N'Nâng cấp BN', 3),
('2', N'N72', N'N72.jpg', 2100000.00, N'Nâng cấp BN, 2 màu Đen, Xám', 7),
('3', N'N6030', N'N6030.jpg', 3000000.00, N'Nâng cấp BN, Gấp', 1),
('4', N'N6200', N'N6200.jpg', 3200000.00, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 5),
('5', N'Galaxy A6', N'GalaxyA6.jpg', 5200000.00, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 2),
('6', N'Galaxy A9', N'GalaxyA9.jpg', 5500000.00, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 6),
('7', N'Galaxy J5', N'GalaxyJ5.jpg', 6000000.00, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 4),
('16', N'Moto E5', N'MotoE5.jpg', 2300000.00, N'Unlimited Extra', 7),
('17', N'Moto G7', N'MotoG7.jpg', 8000000.00, N'Unlimited Extra', 3);
