package org.itstep.ui;

import jakarta.persistence.EntityManager;
import jakarta.persistence.EntityManagerFactory;
import jakarta.persistence.Persistence;
import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;
import org.itstep.dal.entity.Book;

import java.io.IOException;

@WebServlet(name = "BookServlet", value = "/BookServlet")
public class BookServlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        try(EntityManagerFactory emf = Persistence.createEntityManagerFactory("library")){
            EntityManager em = emf.createEntityManager();
            Book book = new Book("Book1", "author1", "2022", "genre 1", 22, "description 1");
            save(em, book);
        }
        String message = "Hello";
        response.setContentType("text/html");
        var writer = response.getWriter();
        writer.println(message);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }

    public static void save(EntityManager em, Book book){
        try{
            em.getTransaction().begin();
            em.persist(book);
            em.getTransaction().commit();
        }
        catch (Throwable ex)
        {
            em.getTransaction().rollback();
        }
    }
}
