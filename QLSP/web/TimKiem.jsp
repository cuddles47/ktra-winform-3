<%@ page import="java.util.List" %>
<%@ page import="com.SanPham" %>
<%@ page contentType="text/html; charset=UTF-8" %>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Tìm kiếm sản phẩm</title>
    </head>
    <body>
        <h2>Danh sách sản phẩm</h2>
        <form action="TimKiemSP" method="get">
            Mã sản phẩm: <input type="text" name="masp"/>
            <input type="submit" value="Tìm kiếm" />
        </form>

        <% 
            // Lấy danh sách sản phẩm từ request
            List<SanPham> dssp = (List<SanPham>) request.getAttribute("dssp");
            if (dssp != null && !dssp.isEmpty()) {
        %>

        <table border="1">
            <thead>
                <tr>
                    <th>Mã sản phẩm</th>
                    <th>Tên sản phẩm</th>
                    <th>Số lượng</th>
                    <th>Đơn giá</th>
                    <th>Chiết khấu</th>
                </tr>
            </thead>
            <tbody>
                <% for (SanPham sp : dssp) { %>
                <tr>
                    <td><%= sp.getMasp() %></td>
                    <td><%= sp.getTensp() %></td>
                    <td><%= sp.getSoluong() %></td>
                    <td><%= sp.getDongia() %></td>
                    <td><%= sp.getChietkhau() %></td>
                </tr>
                <% } %>
            </tbody>
        </table>

        <% } else { %>
            <p>Không có sản phẩm nào trong cơ sở dữ liệu.</p>
        <% } %>
    </body>
</html>
