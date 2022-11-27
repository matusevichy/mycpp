<?php

const DATE_FORMAT = 'd-M-Y H:m:s';
$created = filectime('files.php');
$created = date(DATE_FORMAT, $created);
$modified = filemtime('files.php');
$modified = date(DATE_FORMAT, $modified);
$accessed = fileatime('files.php');
$accessed = date(DATE_FORMAT, $accessed);

echo "<p>Created: $created</p>";
echo "<p>Modified: $modified</p>";
echo "<p>Accessed: $accessed</p>";
