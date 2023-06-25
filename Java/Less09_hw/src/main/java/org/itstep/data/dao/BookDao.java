package org.itstep.data.dao;

import org.h2.engine.User;
import org.itstep.entity.Book;

public class BookDao extends GenericDao<Book> {
    @Override
    public Class<Book> getDomainClass() {
        return Book.class;
    }
}
