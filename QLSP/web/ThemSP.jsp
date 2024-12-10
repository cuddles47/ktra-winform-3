<%@ page import="java.util.List" %>
<%@ page import="com.SanPham" %>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Qu?n l� S?n Ph?m</title>
    </head>
    <body>

        <h2>Danh s�ch s?n ph?m</h2>

        <%-- Hi?n th? th�ng b�o --%>
        <% if (request.getAttribute("message") != null) {%>
        <p style="color: green;"><%= request.getAttribute("message")%></p>
        <% } %>
        <% if (request.getAttribute("error") != null) {%>
        <p style="color: red;"><%= request.getAttribute("error")%></p>
        <% } %>

        <%-- Hi?n th? b?ng s?n ph?m --%>
        <table border="1">
            <thead>
                <tr>
                    <th>M� SP</th>
                    <th>T�n SP</th>
                    <th>S? l??ng</th>
                    <th>??n gi�</th>
                    <th>Chi?t kh?u</th>
                </tr>
            </thead>
            <tbody>
                <%
                    List<SanPham> danhSachSP = (List<SanPham>) request.getAttribute("danhSachSP");
                    if (danhSachSP != null) {
                        for (SanPham sp : danhSachSP) {
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
                    }
                %>
            </tbody>
        </table>

        <h2>Th�m S?n Ph?m</h2>

        <form method="post" action="ThemSP">
            <label for="tensp">M� s?n ph?m:</label><br>
            <input type="text" id="masp" name="masp" required><br><br>

            <label for="tensp">T�n S?n Ph?m:</label><br>
            <input type="text" id="tensp" name="tensp" required><br><br>

            <label for="soluong">S? L??ng:</label><br>
            <input type="number" id="soluong" name="soluong" required><br><br>

            <label for="dongia">??n Gi�:</label><br>
            <input type="number" id="dongia" name="dongia" required><br><br>

            <input type="submit" value="Th�m S?n Ph?m">
        </form>

    </body>
</html>
