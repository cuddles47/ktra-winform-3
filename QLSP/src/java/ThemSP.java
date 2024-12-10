/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/JSP_Servlet/Servlet.java to edit this template
 */

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import com.SanPham;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
/**
 *
 * @author thy
 */
public class ThemSP extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        Connection conn = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;
        try {
            Class.forName("com.mysql.jdbc.Driver");  
            conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/qlsp", "root", "");
            String sql = "SELECT * FROM sanpham";
            stmt = conn.prepareStatement(sql);
            rs = stmt.executeQuery();
            List<SanPham> danhSachSP = new ArrayList<>();
            while (rs.next()) {
                int masp = rs.getInt("masp");
                String tensp = rs.getString("tensp");
                int soluong = rs.getInt("soluong");
                int dongia = rs.getInt("dongia");
                danhSachSP.add(new SanPham(masp, tensp, soluong, dongia, 0));
            }
            request.setAttribute("danhSachSP", danhSachSP);
            request.getRequestDispatcher("ThemSP.jsp").forward(request, response);
        } catch (SQLException e) {
            e.printStackTrace();
            request.getRequestDispatcher("ThemSP.jsp").forward(request, response);
        } catch (ClassNotFoundException ex) {
            request.getRequestDispatcher("ThemSP.jsp").forward(request, response);
        } finally {
            try {
                if (rs != null) rs.close();
                if (stmt != null) stmt.close();
                if (conn != null) conn.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        Connection conn = null;
        PreparedStatement stmt = null;
        try {
            int masp = Integer.parseInt(request.getParameter("masp"));
            String tensp = request.getParameter("tensp");
            int soluong = Integer.parseInt(request.getParameter("soluong"));
            int dongia = Integer.parseInt(request.getParameter("dongia"));
            Class.forName("com.mysql.jdbc.Driver");
            conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/qlsp", "root", "");
            String sql = "INSERT INTO sanpham (masp,tensp, soluong, dongia) VALUES (?, ?, ?, ?)";
            stmt = conn.prepareStatement(sql);
            stmt.setInt(1, masp);
            stmt.setString(2, tensp);
            stmt.setInt(3, soluong);
            stmt.setInt(4, dongia);         
            int rowsAffected = stmt.executeUpdate();
            if (rowsAffected > 0) {
                request.setAttribute("message", "Sản phẩm đã được thêm thành công.");
                
            } else {
                request.setAttribute("error", "Không thể thêm sản phẩm.");
            }
            request.getRequestDispatcher("ThemSP.jsp").forward(request, response);

        } catch (SQLException e) {
            e.printStackTrace();
            request.getRequestDispatcher("ThemSP.jsp").forward(request, response);
        } catch (ClassNotFoundException ex) {
           request.getRequestDispatcher("ThemSP.jsp").forward(request, response);
        } finally {
            try {
                if (stmt != null) stmt.close();
                if (conn != null) conn.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
