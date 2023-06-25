package org.itstep.data;

import jakarta.persistence.EntityManager;
import org.itstep.entity.Book;
import org.itstep.entity.Publisher;

import javax.swing.text.html.parser.Entity;
import java.util.Arrays;
import java.util.List;

public interface GenericDao<T> {

    void save(T... entities);

    default void save(EntityManager entityManager, T... entities) {
        try {
            entityManager.getTransaction().begin();
            Arrays.stream(entities).forEach(entityManager::persist);
            entityManager.getTransaction().commit();
        } catch (Throwable ex) {
            entityManager.getTransaction().rollback();
            throw ex;
        }
    }

    void update(T... entities);

    default void update(EntityManager entityManager, T... entities) {
        try {
            entityManager.getTransaction().begin();
            Arrays.stream(entities).forEach(entityManager::merge);
            entityManager.getTransaction().commit();
        } catch (Throwable ex) {
            entityManager.getTransaction().rollback();
            throw ex;
        }
    }

    List<T> findAll();

    Class<? extends T> getEntityClass();

    default List<T> findAll(EntityManager entityManager) {
        List<T> publishers;
        try {
            publishers = entityManager
                    .createQuery("FROM " + getEntityClass().getSimpleName())
                    .getResultList();
        } catch (Throwable ex) {
            throw ex;
        }
        return publishers;
    }
}
