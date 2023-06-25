package org.itstep.config;

import jakarta.servlet.ServletContext;
import jakarta.servlet.ServletException;
import org.h2.server.web.JakartaWebServlet;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.web.WebApplicationInitializer;
import org.springframework.web.context.ContextLoaderListener;
import org.springframework.web.context.support.AnnotationConfigWebApplicationContext;
import org.springframework.web.context.support.GenericWebApplicationContext;
import org.springframework.web.servlet.DispatcherServlet;

public class ApplicationInitializer implements WebApplicationInitializer {
    @Override
    public void onStartup(ServletContext servletContext) throws ServletException {
        var context = new AnnotationConfigWebApplicationContext();
        context.scan("org.itstep");
        servletContext.addListener(new ContextLoaderListener(context));
        var dispatcherServlet = servletContext.addServlet("dispatcherServlet", new DispatcherServlet(new GenericWebApplicationContext()));
        dispatcherServlet.addMapping("/");
        dispatcherServlet.setLoadOnStartup(1);

        var h2Console = servletContext.addServlet("h2-console", new JakartaWebServlet());
        h2Console.addMapping("/h2-console/*");
        h2Console.setLoadOnStartup(1);
    }
}
