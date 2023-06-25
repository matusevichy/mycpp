package org.itstep.data.impl;

import jakarta.persistence.EntityManager;
import jakarta.persistence.EntityManagerFactory;
import org.itstep.data.PublisherDao;
import org.itstep.entity.Publisher;

import java.util.List;

public class PublisherDaoImpl implements PublisherDao {

    private final EntityManagerFactory entityManagerFactory;

    public PublisherDaoImpl(EntityManagerFactory entityManagerFactory) {
        this.entityManagerFactory = entityManagerFactory;
    }

    @Override
    public void save(Publisher... publishers) {
        var entityManager = entityManagerFactory.createEntityManager();
        try {
            entityManager.getTransaction().begin();
            for(Publisher publisher: publishers) {
                entityManager.persist(publisher);
            }
            entityManager.getTransaction().commit();
        } catch (Throwable ex) {
            entityManager.getTransaction().rollback();
            throw ex;
        }
    }

    @Override
    public List<Publisher> findAll() {
        List<Publisher> publishers;
        try {
            EntityManager entityManager = entityManagerFactory.createEntityManager();
            publishers = entityManager
                    .createQuery("FROM Publisher", Publisher.class)
                    .getResultList();
        }catch (Throwable ex) {
            throw ex;
        }
        return publishers;
    }

}
