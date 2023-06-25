package org.itstep.servlet;

import jakarta.servlet.ServletConfig;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import org.itstep.data.AuthorDao;
import org.itstep.data.BookDao;
import org.itstep.data.impl.AuthorDaoImpl;
import org.itstep.data.impl.BookDaoImpl;

import java.io.IOException;

@WebServlet(urlPatterns = "/authors", loadOnStartup = 1)
public class AuthorServlet extends BaseServlet{
    private AuthorDao authorDao;

    @Override
    public void init(ServletConfig config) throws ServletException {
        super.init(config);
        authorDao = new AuthorDaoImpl(entityManagerFactory);
    }

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.setAttribute("authors", authorDao.findAll());
        req.getRequestDispatcher("/WEB-INF/view/authors/index.jsp").forward(req,resp);
    }
}
