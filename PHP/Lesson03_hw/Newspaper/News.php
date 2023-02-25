<?php
namespace newspaper;

class News
{
    private $listArticles = array();

    public function GetArticles(){
        if(is_array($this->listArticles)){
            foreach ($this->listArticles as $article){
                $article->GetHeader('blue','15px');
                $article->GetShortText('green','13px');
                echo "<hr>";
            }
        }
    }

    public function GetArticle($id){
        if (is_array($this->listArticles)){
            return $this->listArticles[$id];
        }
    }

    public function AddArticle(string $header, string $shortText, string $fullText){
        $id = count($this->listArticles);
        $article = new Article($id, $header, $shortText, $fullText);
        $this->listArticles[$id] = $article;
    }
}
