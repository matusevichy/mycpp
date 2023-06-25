package org.itstep.data.dao;

import jakarta.persistence.EntityManager;
import jakarta.persistence.PersistenceContext;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

public abstract class GenericDao<T> {
    @PersistenceContext
    EntityManager entityManager;

    public abstract Class<T> getDomainClass();

    @Transactional
    public void save(T domain){
        entityManager.persist(domain);
    }

    public List<T> findAll(){
        return entityManager.createQuery("SELECT from " + getDomainClass().getSimpleName(), getDomainClass())
                .getResultList();
    }



}
