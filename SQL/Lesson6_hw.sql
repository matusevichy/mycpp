use Airport

drop table tickets;
drop table passengers;
drop table classtypes;
drop table flights;
drop table towns;

create table towns (
	id int primary key identity,
	name nvarchar(30) not null
)

create table flights (
	id int primary key identity,
	number int not null,
	datefrom datetime2 not null,
	dateto datetime2 not null,
	townid int not null,
	bussinescount int default 0,
	economcount int default 0,
	foreign key(townid) references towns(id)
)

create table passengers (
	id int primary key identity,
	firstname nvarchar(20) not null,
	lastname nvarchar(30) not null
)

create table classtypes (
	id int primary key identity,
	[name] varchar(10)
)

create table tickets (
	id int primary key identity,
	flightid int,
	passengerid int,
	classtypeid int,
	datepay date not null,
	[sum] float default 0.0,
	foreign key(flightid) references flights(id),
	foreign key(passengerid) references passengers(id),
	foreign key(classtypeid) references classtypes(id)
)

insert into towns values 
('London'),
('Bagdad'),
('Minsk'),
('Berlin'),
('Dnipro'),
('Kiev'),
('Lviv')

insert into classtypes values
('bussines'),
('econom')

insert into passengers values
('vasya','pupkin'),
('ivan','petrov'),
('sergey','fedorov'),
('igor','sidorov'),
('jora','gorin'),
('kolya','nikolaev'),
('egor','krutogolov')

insert into flights values
('10','2021-01-01 10:11:12','2021-01-02 01:10:12',1,20,50),
('10','2021-01-02 10:11:12','2021-01-03 01:10:12',1,20,50),
('10','2021-01-03 10:11:12','2021-01-04 01:10:12',1,20,50),
('10','2021-01-04 10:11:12','2021-01-05 01:10:12',1,20,50),
('10','2021-01-05 10:11:12','2021-01-06 01:10:12',1,20,50),
('20','2021-01-01 05:05:12','2021-01-01 18:10:12',2,20,50),
('20','2021-01-02 05:05:12','2021-01-02 18:10:12',2,20,50),
('20','2021-01-03 05:05:12','2021-01-03 18:10:12',2,20,50),
('20','2021-01-04 05:05:12','2021-01-04 18:10:12',2,20,50),
('20','2021-01-05 05:05:12','2021-01-05 18:10:12',2,20,50),
('30','2021-01-01 01:02:12','2021-01-01 10:10:12',3,20,50),
('30','2021-01-02 01:02:12','2021-01-02 10:10:12',3,20,50),
('30','2021-01-03 01:02:12','2021-01-03 10:10:12',3,20,50),
('30','2021-01-04 01:02:12','2021-01-04 10:10:12',3,20,50),
('30','2021-01-05 01:02:12','2021-01-05 10:10:12',3,20,50),
('40','2021-01-01 00:02:12','2021-01-01 08:10:12',4,20,50),
('40','2021-01-01 10:05:12','2021-01-01 18:10:12',4,20,50),
('40','2021-01-02 00:02:12','2021-01-02 08:10:12',4,20,50),
('40','2021-01-02 10:05:12','2021-01-02 18:10:12',4,20,50),
('40','2021-01-03 00:02:12','2021-01-03 08:10:12',4,20,50),
('40','2021-01-03 10:05:12','2021-01-03 18:10:12',4,20,50),
('40','2021-01-04 00:02:12','2021-01-04 08:10:12',4,20,50),
('40','2021-01-04 10:05:12','2021-01-04 18:10:12',4,20,50),
('40','2021-01-05 00:02:12','2021-01-05 08:10:12',4,20,50),
('40','2021-01-05 10:05:12','2021-01-05 18:10:12',4,20,50),
('50','2021-01-02 20:05:12','2021-01-02 21:10:12',5,20,50),
('50','2021-01-04 20:05:12','2021-01-04 21:10:12',5,20,50),
('60','2021-01-03 12:12:12','2021-01-04 23:10:12',6,20,50),
('70','2021-01-01 10:05:12','2021-01-02 23:20:12',7,20,50),
('70','2021-01-03 10:05:12','2021-01-04 23:20:12',7,20,50),
('70','2021-01-05 10:05:12','2021-01-06 23:20:12',7,20,50)

insert into tickets values
(1,1,1,'2020-10-01',100),
(1,1,1,'2020-10-05',100),
(1,1,1,'2020-10-01',100),
(1,1,1,'2020-11-10',100),
(1,1,1,'2020-10-01',100),
(1,2,2,'2020-12-12',50),
(1,2,2,'2020-10-05',50),
(1,2,2,'2020-10-01',50),
(1,2,2,'2020-12-31',50),
(1,2,2,'2020-11-03',50),
(1,2,2,'2020-10-01',50),
(1,2,2,'2020-11-03',50),
(1,2,2,'2020-11-10',50),
(1,2,2,'2020-12-31',50),
(1,2,2,'2020-12-12',50),
(1,2,2,'2020-10-01',50),
(2,3,1,'2020-11-03',1000),
(2,3,1,'2020-10-05',1000),
(2,3,1,'2020-11-03',1000),
(2,3,1,'2020-10-01',1000),
(2,3,1,'2020-11-03',1000),
(2,3,1,'2020-12-31',1000),
(2,3,1,'2020-11-03',1000),
(2,3,1,'2020-10-01',1000),
(2,3,2,'2020-11-03',500),
(2,3,2,'2020-11-10',500),
(2,3,2,'2020-11-03',500),
(2,3,2,'2020-10-01',500),
(2,3,2,'2020-11-03',500),
(2,3,2,'2020-11-03',500),
(2,3,2,'2020-10-05',500),
(2,3,2,'2020-11-03',500),
(2,3,2,'2020-12-12',500),
(2,3,2,'2020-10-01',500),
(2,3,2,'2020-12-31',500),
(2,3,2,'2020-11-10',500),
(2,3,2,'2020-12-31',500),
(2,3,2,'2020-11-03',500),
(2,3,2,'2020-10-01',500),
(2,3,2,'2020-12-12',500)

--вывести все рейсы в определенный город на произвольную дату, упорядочив их по времени вылета;
select f.number, f.datefrom, f.dateto, t.name from flights f 
join towns t 
on f.townid=t.id
where t.name='Berlin' and datefrom like '2021-01-03%'
order by datefrom

--вывести информацию о рейсе с наибольшей длительностью полета по времени;
select f.number, f.datefrom, f.dateto, t.name from flights f 
join towns t 
on f.townid=t.id
where DATEDIFF(MINUTE, f.datefrom,f.dateto) = (select max(DATEDIFF(MINUTE, datefrom,dateto)) from flights)

--показать все рейсы, длительность полета которых превышает два часа;
select f.number, f.datefrom, f.dateto, t.name from flights f 
join towns t 
on f.townid=t.id
where DATEDIFF(hour, f.datefrom,f.dateto) > 2

--получить количество рейсов в каждый город;
insert into towns values 
('Kharkov')

select t.name, count(f.number) as [count] from flights f
right join towns t 
on f.townid = t.id 
group by t.name
order by count

--показать город, в который наиболее часто осуществляются полеты;
select name from towns t
join (select top 1 townid, count(*) as flightcount from flights group by townid 
order by flightcount desc) v
on t.id = v.townid

--получить информацию о количестве рейсов в каждый город и общее количество рейсов за определенный месяц;
select t.name, count(f.number) as [count] from flights f
right join towns t 
on f.townid = t.id 
where month(f.datefrom)=1 and year(f.datefrom)=2021
group by t.name
union
select 'All', count(*) as [count] from flights
where month(datefrom)=1 and year(datefrom)=2021
order by count

--вывести список рейсов, вылетающих сегодня, на которые есть свободные места в бизнес классе;
select f.number, f.datefrom, f.dateto, t.name, f.bussinescount, v.count as bussinescountfact, f.economcount from flights f
join 
(select f.id, count(*) as [count] from flights f
join tickets t
	on f.id=t.flightid
join classtypes c
	on t.classtypeid=c.id
where c.name='bussines' and f.datefrom like '2021-01-01%'
group by f.id) v
	on f.id=v.id
join towns t
	on f.townid=t.id
where v.count<f.bussinescount

--получить информацию о количестве проданных билетов на все рейсы за указанный день и их общую сумму;
select count(id) as [count], sum(sum) from tickets
where datepay='2020-12-31'

--вывести информацию о предварительной продаже билетов на определенную дату с указанием всех рейсов и количестве проданных на них билетов;
select f.number, f.datefrom, f.dateto, tw.name, count(t.id) from flights f
left join tickets t
	on f.id=t.flightid
join towns tw
	on f.townid=tw.id
where  f.datefrom like '2021-01-01%'
group by f.number, f.datefrom, f.dateto, tw.name

--вывести номера всех рейсов и названия всех городов, в которые совершаются полеты из данного аэропорта.
select cast(number as varchar(10)) from flights 
union
select name from towns t
join flights f
	on t.id=f.townid
