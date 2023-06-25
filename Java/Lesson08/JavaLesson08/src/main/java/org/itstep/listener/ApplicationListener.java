package org.itstep.listener;

import jakarta.persistence.EntityManagerFactory;
import jakarta.servlet.*;
import jakarta.servlet.annotation.*;
import org.h2.server.web.JakartaWebServlet;
import org.itstep.data.AuthorDao;
import org.itstep.data.BookDao;
import org.itstep.data.PublisherDao;
import org.itstep.data.impl.AuthorDaoImpl;
import org.itstep.data.impl.BookDaoImpl;
import org.itstep.data.impl.PublisherDaoImpl;
import org.itstep.entity.Author;
import org.itstep.entity.Book;
import org.itstep.entity.Publisher;
import org.itstep.util.DatabaseUtil;

@WebListener
public class ApplicationListener implements ServletContextListener {

    @Override
    public void contextInitialized(ServletContextEvent sce) {
        JakartaWebServlet webServlet = new JakartaWebServlet();
        ServletContext servletContext = sce.getServletContext();
        ServletRegistration.Dynamic servletRegistration = servletContext.addServlet("H2Console", webServlet);
        servletRegistration.addMapping("/h2-console/*");
        servletRegistration.setLoadOnStartup(1);
        
        initDatabase();
    }

    private void initDatabase() {
        var entityManagerFactory = DatabaseUtil.getInstance().getEntityManagerFactory();
        PublisherDao publisherDao = new PublisherDaoImpl(entityManagerFactory);
        BookDao bookDao = new BookDaoImpl(entityManagerFactory);
        AuthorDao authorDao = new AuthorDaoImpl(entityManagerFactory);
        Book cleanCode = new Book("Clean Code");
        cleanCode.setDescription("""
                Even bad code can function. But if code isn’t clean, it can bring a development
                organization to its knees. Every year, countless hours and significant resources are
                lost because of poorly written code. But it doesn’t have to be that way.
                """);
        Book blackAndWhite = new Book("Black and White");
        Book javaHeadFirst = new Book("Java. Head first.");
        Publisher kiyvPress = new Publisher("Kiyv Press");
        Author pratchett = new Author("Terry", "Pratchett");
        Author belyanin = new Author("Andrei", "Belyanin");
        pratchett.addBook(blackAndWhite);
        belyanin.addBook(javaHeadFirst);
        belyanin.addBook(blackAndWhite);
        kiyvPress.addBook(cleanCode);
        kiyvPress.addBook(blackAndWhite);
        Publisher tokioPress = new Publisher("Tokio Press");
        tokioPress.addBook(javaHeadFirst);
        Publisher newYorkPress = new Publisher("New York Press");
        publisherDao.save(kiyvPress, tokioPress, newYorkPress);
        authorDao.save(pratchett, belyanin);
        bookDao.update(blackAndWhite, javaHeadFirst, cleanCode);
    }
}
