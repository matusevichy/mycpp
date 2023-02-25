package org.itstep.dal.entity;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.NonNull;
import lombok.RequiredArgsConstructor;
import org.hibernate.annotations.NotFound;

@Entity
@Data
@RequiredArgsConstructor
@NoArgsConstructor
public class Book {
    @Id @GeneratedValue(strategy = GenerationType.IDENTITY)
    int id;
    @NonNull
    String title;
    @NonNull
    String author;
    @NonNull
    String year;
    @NonNull
    String genre;
    @NonNull
    int pageCount;
    @NonNull
    String description;
}
