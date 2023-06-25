package org.itstep.data.impl;

import jakarta.persistence.EntityManagerFactory;
import org.itstep.data.AbstractDao;
import org.itstep.data.PublisherDao;
import org.itstep.entity.Publisher;


public class PublisherDaoImpl extends AbstractDao<Publisher> implements PublisherDao {

    public PublisherDaoImpl(EntityManagerFactory entityManagerFactory) {
        super(entityManagerFactory);
    }

    @Override
    public Class<? extends Publisher> getEntityClass() {
        return Publisher.class;
    }

}
