package org.itstep.controller;

import lombok.RequiredArgsConstructor;
import org.itstep.data.dao.BookDao;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
@RequiredArgsConstructor
public class BookController {
    private final BookDao bookDao;

    @GetMapping("/")
    public String index(){
        return "index";
    }
}
