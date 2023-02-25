package org.itstep;

import org.itstep.bll.models.PostDto;
import org.itstep.bll.services.PostService;
import org.itstep.dal.entities.Post;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;

import java.util.Arrays;

public class Console {
    public static void main(String[] args) {
        var applicationContext = new AnnotationConfigApplicationContext();
        applicationContext.refresh();
        applicationContext.scan("org.itstep");
        PostService postService = applicationContext.getBean(PostService.class);
        PostDto post = new PostDto(0, "first", "first message", "Yura");
        postService.save(post);
        PostDto post1 = new PostDto(0, "second", "second message", "Vasya");
        postService.save(post1);
        System.out.println(Arrays.deepToString(postService.findAll().toArray()));
        PostDto post2 = postService.findById(1);
        System.out.println(post2.toString());
        post2.setName("first updated");
        postService.update(post2);
        System.out.println(Arrays.deepToString(postService.findAll().toArray()));
        postService.delete(1);
        System.out.println(Arrays.deepToString(postService.findAll().toArray()));
    }
}
