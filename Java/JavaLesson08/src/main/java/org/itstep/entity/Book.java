package org.itstep.entity;

import jakarta.persistence.*;
import lombok.*;

@Entity
@Data
@NoArgsConstructor
@RequiredArgsConstructor
public class Book {
    @Id @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    @NonNull
    @Column(nullable = false)
    private String title;

    @NonNull @Column(nullable = false)
    private String description;
    @NonNull
    @Column(nullable = false)
    private int publishYear;
    @ManyToOne
    private Publisher publisher;
}
