package org.itstep.servlet;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;

@WebServlet(urlPatterns = {"/", "/home"})
public class HomeServlet extends BaseServlet {

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.setAttribute("title", "Home Page");
        req.setAttribute("isEntityManagerFactoryExists", entityManagerFactory != null);
        req.getRequestDispatcher("/WEB-INF/view/index.jsp")
                .forward(req, resp);
    }
}
