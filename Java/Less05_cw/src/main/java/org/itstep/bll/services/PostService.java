package org.itstep.bll.services;

import org.itstep.bll.models.PostDto;
import org.itstep.dal.entities.Post;
import org.itstep.dal.interfaces.PostDao;
import org.modelmapper.ModelMapper;
import org.modelmapper.TypeToken;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
@Scope("singleton")
public class PostService {
    private PostDao postDao;
    private ModelMapper mapper;

    public PostService() {
        this.mapper = new ModelMapper();
    }

    @Autowired @Qualifier("postDaoMemoryImpl")
    public void setPostDao(PostDao postDao){
        this.postDao = postDao;
    }

    public int save (PostDto post){
        return postDao.save(mapper.map(post,Post.class));
    }

    public List<PostDto> findAll(){
        return mapper.map(postDao.findAll(),new TypeToken<List<PostDto>>(){}.getType());
    }

    public PostDto findById(int id){
        return mapper.map(postDao.findById(id),PostDto.class);
    }

    public void delete(int id){
        postDao.delete(id);
    }

    public PostDto update(PostDto post){
        return mapper.map(postDao.update(mapper.map(post,Post.class)), PostDto.class);
    }


}
