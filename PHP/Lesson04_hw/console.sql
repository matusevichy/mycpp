create database if not exists mydb default char set utf8;

use mydb;

create table if not exists users (
    id int auto_increment primary key,
    email varchar(30) not null unique,
    password varchar(50) not null ,
    phone varchar(13) not null ,
    fblink varchar(255),
    instalink varchar(255)
);


