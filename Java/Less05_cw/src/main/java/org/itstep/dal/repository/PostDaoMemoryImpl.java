package org.itstep.dal.repository;

import org.itstep.dal.entities.Post;
import org.itstep.dal.interfaces.PostDao;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

@Component
public class PostDaoMemoryImpl implements PostDao {
    private List<Post> posts;

    public PostDaoMemoryImpl() {
        posts = new ArrayList<>();
    }

    @Override
    public Integer save(Post data) {
        int id;
        if(posts.size()>0) id = Collections.max(posts, Comparator.comparingInt(Post::getId)).getId();
        else id = 0;
        data.setId(++id);
        posts.add(data);
        return id;
    }

    @Override
    public List<Post> findAll() {
        return posts;
    }

    @Override
    public Post findById(Integer aInt) {
        Post post = posts.stream().filter(p -> aInt.equals(p.getId())).collect(Collectors.toList()).get(0);
        return post;
    }

    @Override
    public void delete(Integer aInt) {
        posts.remove(findById(aInt));
    }

    @Override
    public Post update(Post data) {
        Post post = findById(data.getId());
        post.setName(data.getName());
        post.setText(data.getText());
        post.setAuthor(data.getAuthor());
        return post;
    }
}
