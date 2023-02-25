package org.itstep;

import jakarta.servlet.ServletException;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.io.PrintWriter;

public class HomeServlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String message = "<form method=post>" +
                "           <label for=login style='width: 70px; display: inline-block'>Login</label><input type=text name=login><br>" +
                "           <label for=password style='width: 70px; display: inline-block'>Password</label><input type=text name=password><br>" +
                "           <input type=submit" +
                "         </form>";
        resp.setContentType("text/html");
        PrintWriter writer = resp.getWriter();
        writer.println(message);
    }
}
