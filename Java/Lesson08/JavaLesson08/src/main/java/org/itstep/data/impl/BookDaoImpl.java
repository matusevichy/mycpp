package org.itstep.data.impl;

import jakarta.persistence.EntityManagerFactory;
import org.itstep.data.AbstractDao;
import org.itstep.data.BookDao;
import org.itstep.entity.Book;

public class BookDaoImpl extends AbstractDao<Book> implements BookDao {
    public BookDaoImpl(EntityManagerFactory entityManagerFactory) {
        super(entityManagerFactory);
    }

    @Override
    public Class<? extends Book> getEntityClass() {
        return Book.class;
    }
}
