package org.itstep.dal.entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor

public class Post {
    private int Id;
    private String name;
    private String text;
    private String author;
}
