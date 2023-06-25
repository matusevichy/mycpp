package org.itstep.util;

import jakarta.persistence.EntityManagerFactory;
import jakarta.persistence.Persistence;

public class DatabaseUtil {
    private static DatabaseUtil instance;
    private final EntityManagerFactory emf;

    private DatabaseUtil() {
        emf = Persistence.createEntityManagerFactory("default");
    }

    public static DatabaseUtil getInstance() {
        if (instance == null) {
            instance = new DatabaseUtil();
        }
        return instance;
    }

    public EntityManagerFactory getEntityManagerFactory() {
        return emf;
    }
}
