<?php

namespace newspaper;

class Galery
{
    private $imgList = array();
    private $count;
    private $page;
    private $imgWidth;
    private $imgHeight;

    public function __construct()
    {
        $this->count = $_GET['count']??5;
        $this->page = $_GET['page']??0;
        $this->imgHeight = $_GET['imgHeight']??80;
        $this->imgWidth = $_GET['imgWidth']??120;
    }

    public function AddImage(string $src){
        array_push($this->imgList, $src);
    }

    public function GetImages(){
        $start = $this->page*$this->count;
        $end = $start+$this->count;
        $arraySize = count($this->imgList);
        if ($end>$arraySize) $end=$arraySize;
        if ($start<$arraySize) {
            echo "<input type=number name=img-count id=img-count min=1 max=5 value=$this->count onchange='ChangeCount()'>";
            echo "<div id=images>";
            for ($i = $start; $i < $end; $i++) {
                echo "<img src=/img/" . $this->imgList[$i] . " alt=" . $this->imgList[$i] . " width=$this->imgWidth height=$this->imgHeight>";
            }
            echo "</div>";
        }
        if ($arraySize > $this->count) {
            echo "<div id=paginator>";
            if ($this->page > 0) {
                echo "<a href=./galery.php?count=" . $this->count . "&page=" . ($this->page - 1) . ">Previous</a> | ";
            }

            if ($end < $arraySize) {
                echo "<a href=./galery.php?count=" . $this->count . "&page=" . ($this->page + 1) . ">Next</a>";
            }
            echo "</div>";
        }
    }
}
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="/css/style.css">
    <title>Document</title>
</head>
<body>
<?php
$galery = new Galery();
$galery->AddImage('img1.jpg');
$galery->AddImage('img2.jpg');
$galery->AddImage('img3.jpg');
$galery->AddImage('img4.jpg');
$galery->AddImage('img5.jpg');
$galery->AddImage('img6.jpg');
$galery->AddImage('img7.jpg');
echo $galery->GetImages();
?>
<script>
    function ChangeCount(){
        $params = new URLSearchParams(location.search);
        $count = document.getElementById('img-count').value;
        $params.set('count',$count);
       location.search=$params.toString();
    }
</script>
</body>
</html>
