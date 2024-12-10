package com;

public class SanPham {
    private int id;
    private String tensp;
    private int soluong;
    private int dongia;
    private double chietkhau;

    // Constructor để khởi tạo đối tượng với việc tính toán chiết khấu ngay lập tức
    public SanPham(int masp, String tensp, int soluong, int dongia, double chietkhau1) {
        this.id = masp;
        this.tensp = tensp;
        this.soluong = soluong;
        this.dongia = dongia;
        this.chietkhau = tinhChietKhau(soluong, dongia); 
    }

    
    private double tinhChietKhau(int soluong, int dongia) {
        if (soluong > 10) {
            return 0.10 * (soluong * dongia); 
        } else if (soluong > 5) {
            return 0.05 * (soluong * dongia); 
        }
        return 0; // Không có chiết khấu
    }

    // Getter và Setter cho các thuộc tính
    public int getMasp() {
        return id;
    }

    public void setMasp(int masp) {
        this.id = masp;
    }

    public String getTensp() {
        return tensp;
    }

    public void setTensp(String tensp) {
        this.tensp = tensp;
    }

    public int getSoluong() {
        return soluong;
    }

    public void setSoluong(int soluong) {
        this.soluong = soluong;
        this.chietkhau = tinhChietKhau(soluong, this.dongia); // Tính lại chiết khấu nếu số lượng thay đổi
    }

    public int getDongia() {
        return dongia;
    }

    public void setDongia(int dongia) {
        this.dongia = dongia;
        this.chietkhau = tinhChietKhau(this.soluong, dongia); // Tính lại chiết khấu nếu đơn giá thay đổi
    }

    public double getChietkhau() {
        return chietkhau;
    }

    public void setChietkhau(double chietkhau) {
        this.chietkhau = chietkhau;
    }
}
