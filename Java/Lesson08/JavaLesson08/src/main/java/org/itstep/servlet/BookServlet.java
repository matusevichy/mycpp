package org.itstep.servlet;

import jakarta.servlet.ServletConfig;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import org.itstep.data.BookDao;
import org.itstep.data.impl.BookDaoImpl;
import org.itstep.entity.Book;

import java.io.IOException;

@WebServlet(urlPatterns = "/books", loadOnStartup = 1)
public class BookServlet extends BaseServlet {
    private BookDao bookDao;

    @Override
    public void init(ServletConfig config) throws ServletException {
        super.init(config);
        bookDao = new BookDaoImpl(entityManagerFactory);
    }

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.setAttribute("books", bookDao.findAll());
        req.getRequestDispatcher("/WEB-INF/view/books/index.jsp")
                .forward(req, resp);
    }
}
