CREATE TABLE MonAn (
    MaMon INT PRIMARY KEY,
    TenMon NVARCHAR(50) NOT NULL,
    LoaiMon NVARCHAR(30) NOT NULL,
    DonGia DECIMAL(10, 2) CHECK (DonGia > 0),
    SoLuongTon INT CHECK (SoLuongTon >= 0)
);
Go

CREATE TABLE HoaDonDatMon (
    MaHD INT PRIMARY KEY,
    MaMon INT NOT NULL,
    KhachHang NVARCHAR(50) CHECK (LEN(KhachHang) BETWEEN 5 AND 50),
    NgayDat DATETIME NOT NULL,
    SoLuong INT CHECK (SoLuong > 0),
    FOREIGN KEY (MaMon) REFERENCES MonAn(MaMon) ON DELETE CASCADE
);
Go

INSERT INTO MonAn (MaMon, TenMon, LoaiMon, DonGia, SoLuongTon)
VALUES
    (1, N'Phở bò', N'Món chính', 50000, 100),
    (2, N'Cơm gà', N'Món chính', 70000, 50),
    (3, N'Trá sữa', N'Đồ uống', 30000, 200);

INSERT INTO HoaDonDatMon (MaHD, MaMon, KhachHang, NgayDat, SoLuong)
VALUES
    (1, 1, N'Nguyễn Văn A', '2024-01-05', 2),
    (2, 2, N'Trần Thị B', '2024-01-06', 3),
    (3, 3, N'Lê Hồng C', '2024-01-07', 5);
