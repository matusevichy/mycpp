package org.itstep.data;

import jakarta.persistence.EntityManagerFactory;
import lombok.RequiredArgsConstructor;

import java.util.List;

@RequiredArgsConstructor
public abstract class AbstractDao<T> implements GenericDao<T> {

    protected final EntityManagerFactory entityManagerFactory;

    @Override
    public void save(T... entities) {
        save(entityManagerFactory.createEntityManager(), entities);
    }

    @Override
    public List<T> findAll() {
        return findAll(entityManagerFactory.createEntityManager());
    }

    @Override
    public void update(T... entities) {
        update(entityManagerFactory.createEntityManager(), entities);
    }
}
