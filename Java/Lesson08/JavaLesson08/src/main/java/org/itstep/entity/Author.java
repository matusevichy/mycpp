package org.itstep.entity;

import jakarta.persistence.*;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.NonNull;
import lombok.RequiredArgsConstructor;

import java.util.*;

@Data
@Entity
@RequiredArgsConstructor
@NoArgsConstructor
public class Author {
    @Id @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    @NonNull
    private String firstName;
    @NonNull
    private String lastName;
    @ManyToMany(mappedBy = "authors")
    private List<Book> publishedBooks = new ArrayList<>();
    public void addBook(Book book){
        publishedBooks.add(book);
        book.getAuthors().add(this);
    }
}
