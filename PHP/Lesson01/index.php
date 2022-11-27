<?php

function get_array_odd($min, $max){
    $arr=[];
    for ($i=$min; $i<=$max; $i++)
    {
        if ($i % 2 == 0) array_push($arr, $i);
    }
    return $arr;
}

function get_fibonachy($count)
{
    $arr=[0,1];
    for ($i=0; $i<$count-2; $i++)
    {
        $len=count($arr);
        array_push($arr, $arr[$len-1]+$arr[$len-2]);
    }
    return $arr;
}

function array_print($arr)
{
    foreach ($arr as $key=>$value)
    {
        if (is_array($value))
        {
            $col=count($value);
            for ($i=0; $i<$col; $i++)
            {
                echo "$value[$i] ";
            }
            echo "\n";
        }
        else
        {
            echo "$value ";
        }
    }
    echo "\n";
}

function get_array_rand_twodim($row, $col, $min, $max)
{
    $arr=[];
    for ($i=0; $i<$row; $i++)
    {
        $arr_row=[];
        for ($j=0; $j<$col; $j++)
        {
            $num = rand($min, $max);
            array_push($arr_row, $num);
        }
        array_push($arr, $arr_row);
    }
    return $arr;
}

$arr_odd = get_array_odd(0,99);
array_print($arr_odd);

$fib=get_fibonachy(20);
array_print($fib);

$arr_rand=get_array_rand_twodim(8,5,10,99);
array_print($arr_rand);