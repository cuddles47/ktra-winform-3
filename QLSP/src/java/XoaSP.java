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
/**
 *
 * @author thy
 */
public class XoaSP extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        ResultSet rs =null;
        PreparedStatement stm = null;
        Connection conn =null;
        try {
            Class.forName("com.mysql.jdbc.Driver");
            conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/qlsp","root","");
            String sql = "select * from sanpham";
            stm = conn.prepareStatement(sql);
            rs = stm.executeQuery();
            List<SanPham> ds = new ArrayList<>();
            while(rs.next())
            {
                int masp = rs.getInt("masp");
                String tensp = rs.getString("tensp");
                int soluong = rs.getInt("soluong");
                int dongia = rs.getInt("dongia");
                
                ds.add(new SanPham(masp,tensp,soluong,dongia,0));
            }
            request.setAttribute("ds", ds);
            request.getRequestDispatcher("XoaSP.jsp").forward(request, response);
        } catch (Exception e) {
            e.printStackTrace();            
        }   
    }
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        String masp = request.getParameter("masp");
        try {
            Class.forName("com.mysql.jdbc.Driver");
            Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/qlsp","root","");
            String sql = "delete from sanpham where masp = ?";
            PreparedStatement stm = conn.prepareStatement(sql);
            stm.setString(1,masp);
            int rowsAffected = stm.executeUpdate();
            String sql2 = "select * from sanpham";
            stm = conn.prepareStatement(sql2);
            ResultSet rs = stm.executeQuery();
            List<SanPham> ds = new ArrayList<>();
            while(rs.next())
            {
                int id = rs.getInt("masp");
                String tensp = rs.getString("tensp");
                int soluong = rs.getInt("soluong");
                int dongia = rs.getInt("dongia");
                
                ds.add(new SanPham(id,tensp,soluong,dongia,0));
            }
            request.setAttribute("ds", ds);
            request.setAttribute( "tb","xoa thanh cong");
            request.getRequestDispatcher("XoaSP.jsp").forward(request, response);
        } catch (Exception e) {
            
        }
    }
    

}
