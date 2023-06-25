package org.itstep.entity;

import jakarta.persistence.*;
import lombok.*;

import java.util.ArrayList;
import java.util.List;

@Data
@Entity
@RequiredArgsConstructor
@NoArgsConstructor
public class Book {
    @Id @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    @Column(nullable = false)
    @NonNull
    private String title;
    @Column(columnDefinition = "text")
    private String description;
    private int publishYear;
    @ManyToOne
    @JoinColumn(name = "pub_id")
    private Publisher publisher;
    @ManyToMany
    private List<Author> authors = new ArrayList<>();
//    public void addAuthor(Author author){
//        authors.add(author);
//        author.getPublishedBooks().add(this);
//    }
}
