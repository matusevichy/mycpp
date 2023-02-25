package org.itstep.bll.models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor

public class PostDto {
    private int Id;
    private String name;
    private String text;
    private String author;
}
