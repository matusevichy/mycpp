<?php

class Product
{
    private string $_name;
    private float $_price;

    public function __construct(string $_name, float $_price)
    {
        $this->_name = $_name;
        $this->_price=$_price;
    }

    public function getProduct(): string{
        return "Name: $this->_name; Price: $this->_price";
    }
}