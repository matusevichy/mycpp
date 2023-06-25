package org.itstep.entity;

import jakarta.persistence.*;
import lombok.*;

import java.util.ArrayList;
import java.util.List;

@Data
@Entity
@Table(name = "publishers")
@NoArgsConstructor
@RequiredArgsConstructor
public class Publisher {
    @Id @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    @NonNull
    @Column(unique = true, nullable = false, length = 100)
    private String name;
    @OneToMany(mappedBy = "publisher")
    private List<Book> books = new ArrayList<>();
    public void addBook(Book book) {
        book.setPublisher(this);
        books.add(book);
    }
}
