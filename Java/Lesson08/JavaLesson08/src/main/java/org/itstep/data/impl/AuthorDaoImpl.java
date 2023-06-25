package org.itstep.data.impl;

import jakarta.persistence.EntityManagerFactory;
import org.itstep.data.AbstractDao;
import org.itstep.data.AuthorDao;
import org.itstep.entity.Author;

public class AuthorDaoImpl extends AbstractDao<Author> implements AuthorDao {
    public AuthorDaoImpl(EntityManagerFactory entityManagerFactory) {
        super(entityManagerFactory);
    }

    @Override
    public Class<? extends Author> getEntityClass() {
        return Author.class;
    }
}
