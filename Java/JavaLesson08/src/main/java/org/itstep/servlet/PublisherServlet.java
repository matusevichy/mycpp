package org.itstep.servlet;

import jakarta.servlet.ServletConfig;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import org.itstep.data.PublisherDao;
import org.itstep.data.impl.PublisherDaoImpl;
import org.itstep.entity.Publisher;

import java.io.IOException;

@WebServlet(urlPatterns = "/publishers")
public class PublisherServlet extends BaseServlet {

    private PublisherDao publisherDao;

    @Override
    public void init(ServletConfig config) throws ServletException {
        super.init(config);
        publisherDao = new PublisherDaoImpl(entityManagerFactory);
        publisherDao.save(new Publisher("Kiyv Press"),
                        new Publisher("Tokio Press"),
                        new Publisher("New York Press"));
    }

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.setAttribute("publishers", publisherDao.findAll());
        req.getRequestDispatcher("/WEB-INF/view/publishers/index.jsp")
                .forward(req, resp);
    }
}
