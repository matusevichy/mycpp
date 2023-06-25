package org.itstep.data.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class BookDto {
    private String pib;

    private String year;

    private String genre;

    private Integer pageCount;

    private String description;

}
