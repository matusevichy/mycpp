package org.itstep.data;

import org.itstep.entity.Publisher;

import java.util.List;

public interface GenericDao<T> {

    void save(T... entities);
    List<T> findAll();
}
