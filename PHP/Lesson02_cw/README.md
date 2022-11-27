# PHP Lesson 2

## Form handle

### POST Request

Html form:
```html
<form method="post">
    <input name="title" >
    ...
</form>
```

Handle request:
```php
// global arrays
$title = $_POST['title'];
...
```

Html form:
```html
<form method="get">
    <input name="title" >
    ...
</form>
```
### GET Request
Handle request:
```php
// global arrays
$title = $_GET['title'];
...
```

### Method independent request handling:
```php
$title = $_REQUEST['title'];
```

## File

### Save and read files:

Functions `C` library:
```php
$f = fopen('file', 'w');
while(!feof($f)) {
    $line = fgets($f);
    print $line;
}
fclose($f);
```

PHP functions:
```php
// read all file
$lines = file('filename.txt');
print_r($lines);

$content = file_get_contents('filename.txt');

// write all to file
file_put_contents("filename.txt", "data");
```
### Files info

```php
$size = filesize('filename.txt');
if($size) {
    echo "file size: $size";
}

$created = filectime('filename.txt');
$modified = filemtime('filename.txt');
$accessed = fileatime('filename.txt');

if(file_exists('filename.txt')) {
    echo 'exists';
}

echo 'current file ' . __FILE__; 
```

### Directories

```php
mkdir('db'); // create directory db
if(file_exists('db')) {
    echo 'dir exists';
}
echo 'current dir ' . __DIR__;
chdir('..'); // switch to parent dir
echo 'present dir: ' . getcwd(); // current work dir
```

## Serialization
```php
$serialized_string = serialize($data);

$data = unserialize($serialized_string);

// json
$json = json_encode($data);
$data = json_decode($json);
```


## Cookie

## Session

## Database