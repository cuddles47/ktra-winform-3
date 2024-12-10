<%-- 
    Document   : XoaSP
    Created on : Dec 9, 2024, 7:57:55 PM
    Author     : thy
--%>

<%@page import="java.util.List"%>
<%@page import="com.SanPham"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <h2>Danh Sách Sản Phẩm</h2>
        <form action="XoaSP" method="POST">
            Ma SP: <input type ="text" id ="masp" name="masp"> <input type="submit" value="Xoa" />
        </form>
        <p style ="color: red">${tb}</p>
    <table border="1">
        <thead>
            <tr>
                <th>Mã SP</th>
                <th>Tên SP</th>
                <th>Số Lượng</th>
                <th>Đơn Giá</th>
                <th>Chiết Khấu</th>
            </tr>
        </thead>
         <tbody>
                <%
                    List<SanPham> ds = (List<SanPham>) request.getAttribute("ds");
                    
                        for (SanPham sp : ds) {
                %>
                <tr>
                    <td><%= sp.getMasp()%></td>
                    <td><%= sp.getTensp()%></td>
                    <td><%= sp.getSoluong()%></td>
                    <td><%= sp.getDongia()%></td>
                    <td><%= sp.getChietkhau()%></td>
                </tr>
                <%
                        }                  
                %>
            </tbody>
    </table>
    </body>
</html>
