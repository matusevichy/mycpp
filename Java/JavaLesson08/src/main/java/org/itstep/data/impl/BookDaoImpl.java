package org.itstep.data.impl;

import jakarta.persistence.EntityManagerFactory;
import org.itstep.data.BookDao;
import org.itstep.entity.Book;

import java.util.List;

public class BookDaoImpl implements BookDao {
    private final EntityManagerFactory entityManagerFactory;

    public BookDaoImpl(EntityManagerFactory entityManagerFactory) {
        this.entityManagerFactory = entityManagerFactory;
    }

    @Override
    public void save(Book... books) {
        var entityManager = entityManagerFactory.createEntityManager();
        try{
            entityManager.getTransaction().begin();
            for(Book book : books){
                entityManager.persist(book);
            }
            entityManager.getTransaction().commit();
        } catch (Exception e) {
            entityManager.getTransaction().rollback();
            throw e;
        }
    }

    @Override
    public List<Book> findAll() {
        var entityManager = entityManagerFactory.createEntityManager();
        List<Book> books;
        try {
            books = entityManager.createQuery("FROM Book", Book.class).getResultList();
        } catch (Exception e) {
            throw e;
        }
        return books;
    }
}
