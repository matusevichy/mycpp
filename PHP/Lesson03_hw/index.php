<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="css/style.css">
    <title>Document</title>
</head>
<body>
<?php
    spl_autoload_register(function($class) {
        require_once "$class.php";
    });
    use newspaper\{Article, News};
    $url = substr($_SERVER['REQUEST_URI'],strrpos($_SERVER['REQUEST_URI'],'/')+1);
    $news = new News();
    $news->AddArticle('Article 1', 'Article 1 short text', 'Article 1 full text');
    $news->AddArticle('Article 2', 'Article 2 short text', 'Article 2 full text');
    $news->AddArticle('Article 3', 'Article 3 short text', 'Article 3 full text');
    $news->AddArticle('Article 4', 'Article 4 short text', 'Article 4 full text');
    $news->AddArticle('Article 5', 'Article 5 short text', 'Article 5 full text');
    if ($url === ''){
        $news->GetArticles();
    }
    else{
        $article = $news->GetArticle($url);
        $article->GetHeader('blue','15px');
        $article->GetFullText('black', '12px');
        echo "<a href='/'>Back to list</a>";
    }

?>
</body>
</html>
