package org.itstep.entity;

import jakarta.persistence.*;
import lombok.*;

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
}
