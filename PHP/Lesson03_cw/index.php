<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
</head>
<body>
<form method="post">
    <fieldset>
        <legend>Product form</legend>
        <div>
            <label for="productName">Product name</label>
            <input type="text" name="productName" id="productName" required>
        </div>
        <div>
            <label for="price">Price</label>
            <input type="number" step="0.01" name="price" id="price" min="0" value="0">
        </div>
    </fieldset>
    <input type="submit">
</form>

<?php
spl_autoload_register(function($class) {
    require_once "$class.php";
});

$products = [];
$dbName = "product.db";

if (file_exists($dbName)){
    $products = unserialize(file_get_contents($dbName));
}

if ($_SERVER['REQUEST_METHOD'] === 'POST'){
    $product = new Product($_POST['productName'], $_POST['price']);
    if (is_array($products)){
        array_push($products, $product);
    }
    else{
        $products = [0, $product];
    }
    file_put_contents($dbName, serialize($products));
}
if (is_array($products))
    foreach ($products as $item){
        echo $item -> getProduct() ."<hr>";
    }
?>
</body>
</html>

