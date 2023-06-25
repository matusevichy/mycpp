package org.itstep.servlet;

import jakarta.persistence.EntityManagerFactory;
import jakarta.servlet.ServletConfig;
import jakarta.servlet.ServletException;
import jakarta.servlet.http.HttpServlet;
import org.itstep.util.DatabaseUtil;

public abstract class BaseServlet extends HttpServlet {
    protected EntityManagerFactory entityManagerFactory;

    @Override
    public void init(ServletConfig config) throws ServletException {
        entityManagerFactory = DatabaseUtil.getInstance().getEntityManagerFactory();
    }
}
