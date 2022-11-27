<?php

$arr = [
  'users' => [
      'vasja',
      'masha',
      'petja',
      'roma'
  ]
];

$serialized_string = serialize($arr);
echo '<pre>';
echo $serialized_string . '<br/>';
echo '</pre>';

$arr = unserialize($serialized_string);
echo "<pre>";
print_r($arr);
echo "</pre>";