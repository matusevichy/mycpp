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

<form method="post">
    <fieldset>
        <legend>Product form</legend>
        <div>
            <label for="title">Title</label>
            <input type="text" name="title" id="title" required>
        </div>
        <div>
            <label for="category">Category</label>
            <input type="text" name="category" id="category" required>
        </div>
        <div>
            <label for="count">Count</label>
            <input type="number" step="1" name="count" id="count" min="0" value="0">
        </div>
        <div>
            <label for="cost">Cost</label>
            <input type="number" step="0.01" name="cost" id="cost" min="0" value="0">
        </div>
    </fieldset>
    <input type="submit">
</form>
<?php
    $products=[];
    $db_name="db/products.db";

    if(file_exists($db_name))
    {
        $products=unserialize(file_get_contents($db_name));
    }

    if ($_SERVER['REQUEST_METHOD'] === 'POST')
    {
        $title = $_POST['title'];
        $category = $_POST['category'];
        $count = $_POST['count'];
        $cost = $_POST['cost'];
        if(is_array($products))
        {
            array_push($products, [$title, $category, $count, $cost]);
        }
        else
        {
            $products =  [0=> [$title, $category, $count, $cost]];
        }
        file_put_contents($db_name, serialize($products));
    }
    if(is_array($products))
    {
        echo "<table><thead><tr><td>Title</td><td>Category</td><td>Count</td><td>Cost</td></tr></thead><tbody>";
        foreach ($products as $key=>$value) {
            echo "<tr>";
            foreach ($value as $tk=>$tv)
            {
                echo "<td>$tv</td>";
            }
            echo "</tr>";
        }
        echo "</tbody></table>";
    }
    ?>
</body>
</html>

