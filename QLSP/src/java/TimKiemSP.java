import java.io.IOException;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import com.SanPham;

public class TimKiemSP extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        String masp = request.getParameter("masp");
        List<SanPham> dssp = new ArrayList<>();
        Connection conn = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;
        try {
            Class.forName("com.mysql.jdbc.Driver");
            conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/qlsp", "root", "");
            String sql = "SELECT * FROM sanpham";
            if (masp != null && !masp.isEmpty()) {
                sql += " WHERE masp = ?";
            }
            stmt = conn.prepareStatement(sql);
            if (masp != null && !masp.isEmpty()) {
                stmt.setString(1, masp);
            }
             rs = stmt.executeQuery();
            while (rs.next()) {
                int id = rs.getInt("masp");
                String ten = rs.getString("tensp");
                int soluong = rs.getInt("soluong");
                int dongia = rs.getInt("dongia");
                SanPham sp = new SanPham(id, ten, soluong, dongia, 0); 
                dssp.add(sp);
            }
        } catch (Exception e) {
            e.printStackTrace();
            request.setAttribute("error", "Có lỗi xảy ra khi truy vấn cơ sở dữ liệu.");
        } finally {
            // Đảm bảo đóng tài nguyên
            try {
                if (rs != null) rs.close();
                if (stmt != null) stmt.close();
                if (conn != null) conn.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }

        // Gửi danh sách sản phẩm tới JSP
        request.setAttribute("dssp", dssp);
        request.getRequestDispatcher("TimKiem.jsp").forward(request, response);
    }

    @Override
    public String getServletInfo() {
        return "Servlet hiển thị danh sách sản phẩm hoặc tìm kiếm theo mã.";
    }
}
