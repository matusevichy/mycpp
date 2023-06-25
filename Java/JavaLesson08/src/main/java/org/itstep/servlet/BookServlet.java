package org.itstep.servlet;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;
import org.itstep.data.BookDao;
import org.itstep.data.impl.BookDaoImpl;
import org.itstep.entity.Book;

import java.io.IOException;

@WebServlet(urlPatterns = "/books")
public class BookServlet extends BaseServlet {
    BookDao bookDao;

    @Override
    public void init(ServletConfig config) throws ServletException {
        super.init(config);
        bookDao = new BookDaoImpl(entityManagerFactory);
        bookDao.save(new Book("Book1", "Book1", 1990),
                new Book("Book2", "Book2", 1992),
                new Book("Book3", "Book3", 1993));
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.setAttribute("books", bookDao.findAll());
        request.getRequestDispatcher("/WEB-INF/view/books/index.jsp").forward(request, response);
    }

}
