package org.itstep.controller;

import org.itstep.data.dto.UserDto;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

@Controller
public class HomeController {

    @GetMapping("/") //@RequestMapping(path="/", method = RequestMethod.GET)
    //@ResponseBody
    String index(/*Model model*/) {
        //return "Hello Spring World";
//        return "/WEB-INF/views/index.jsp";
//        model.addAttribute("currentTime",
//                LocalDateTime.now().format(DateTimeFormatter.ISO_LOCAL_TIME));
        return "index";
    }

    @ModelAttribute("currentTime")
    String getCurrentTime() {
        return LocalDateTime.now().format(DateTimeFormatter.ISO_LOCAL_TIME);
    }

    @PostMapping("/")
    String getName(UserDto user, Model model) {
        model.addAttribute("user", user);
        return "index";
    }
}
