use BookStore

drop table Sales;
drop table Books;
drop table Authors;
drop table Shops;
drop table Countries;
drop table Themes;

create table Themes (
	id int primary key identity,
	name nvarchar(100) not null unique
)
create table Countries (
	id int primary key identity,
	name nvarchar(50) not null unique
)

create table Authors (
	id int primary key identity,
	[name] nvarchar(max) not null,
	surname nvarchar(max) not null,
	countryid int not null,
	foreign key(countryid) references Countries(id)
)

create table Shops (
	id int primary key identity,
	name nvarchar(max) not null,
	countryid int not null,
	foreign key (countryid) references Countries(id)
)

create table Books (
	id int primary key identity,
	[name] nvarchar(max) not null,
	pages int not null check (pages >0),
	price money not null check (price >=0),
	publishdate date not null check (publishdate <= getdate()),
	authorid int not null,
	themeid int not null,
	foreign key (authorid) references Authors(id),
	foreign key (themeid) references Themes(id)
)

create table Sales (
	id int primary key identity,
	price money not null check(price >=0),
	quantity int not null check (quantity >0),
	saledate date not null default getdate() check (saledate < getdate()),
	bookid int not null,
	shopid int not null,
	foreign key (bookid) references Books (id),
	foreign key (shopid) references Shops(id)
)


declare @counter int =0;
--insert into Themes
while @counter<20
begin
	insert into Themes values
	('Theme '+convert(varchar(2),@counter));
	set @counter+=1;
end

--insert into Countries
set @counter=0;
while @counter<30
begin
	insert into Countries values
	('Country '+convert(varchar(2),@counter));
	set @counter+=1;
end

--insert into Shops
set @counter=0;
while @counter<50
begin
	insert into Shops values
	('Shop '+convert(varchar(2),@counter), ROUND(rand()*(select max(id) from Countries), 0)+1);
	set @counter+=1;
end

--insert into Authors
set @counter=0;
while @counter<100
begin
	insert into Authors values
	('Name '+convert(varchar(2),@counter), 'Surname '+convert(varchar(2),@counter), ROUND(rand()*(select max(id) from Countries), 0)+1);
	set @counter+=1;
end

--insert into Books
declare @fromdate date = '1910-01-01';
declare @todate date = getdate();

set @counter=0;
while @counter<1000
begin
	insert into Books values(
	'Book '+convert(varchar(4),@counter), 
	ROUND(rand()*1000, 0)+1, 
	ROUND(rand()*1000, 0)+1, 
	dateadd(day, rand()*(1+datediff(day, @FromDate, @ToDate)), 
               @FromDate),
	ROUND(rand()*(select max(id) from Authors), 0)+1, 
	ROUND(rand()*(select max(id) from Themes), 0)+1);
	set @counter+=1;
end

--insert into Sales
set @fromdate = '2019-01-01';
set @todate = getdate();

set @counter=0;
while @counter<10000
begin
	insert into Sales values(
	ROUND(rand()*10000, 0)+1, 
	ROUND(rand()*50, 0)+1, 
	dateadd(day, rand()*(1+datediff(day, @FromDate, @ToDate)), 
               @FromDate),
	ROUND(rand()*(select max(id) from Books), 0)+1, 
	ROUND(rand()*(select max(id) from Shops), 0)+1);
	set @counter+=1;
end

--�������� ��� �����, ���������� ������� � ������� ������ 500, �� ������ 650.
select b.name as bookname, b.pages, b.price, a.name+' '+a.surname as authorname,t.name as theme from Books b
join Authors a on b.authorid=a.id
join Themes t on b.themeid=t.id
where pages between 500 and 650

--�������� ��� �����, � ������� ������ ����� �������� ���� ���, ���� �ǻ
select b.name as bookname, b.pages, b.price, a.name+' '+a.surname as authorname,t.name as theme from Books b
join Authors a on b.authorid=a.id
join Themes t on b.themeid=t.id
where b.name like '% 10%' or b.name like '% 40%'

--�������� ��� ����� ����� ���������, ���������� ��������� ���� ����� 30 �����������
select b.name as bookname, b.pages, b.price, a.name+' '+a.surname as authorname,tmp.count_q, t.name as theme from Books b
join Authors a on b.authorid=a.id
join Themes t on b.themeid=t.id
join (select bookid, sum(quantity) as count_q from Sales group by bookid) tmp on b.id=tmp.bookid 
where t.name = 'Theme 15' and count_q>30

--�������� ��� �����, � �������� ������� ���� ����� �Microsoft�, �� ��� ����� �Windows�.
select b.name as bookname, b.pages, b.price, a.name+' '+a.surname as authorname,t.name as theme from Books b
join Authors a on b.authorid=a.id
join Themes t on b.themeid=t.id
where b.name like '%55%' and b.name not like '% 4%'

--�������� ��� ����� (��������, ��������, ������ ��� ������ � ����� ������), ���� ����� �������� ������� ������ 65 ������.
select b.name + ' ' + t.name + ' ' + a.name + ' ' + a.surname as bookinfo, round(b.price/b.pages, 2) as priseonepage from Books b
join Authors a on b.authorid=a.id
join Themes t on b.themeid=t.id
where b.price/b.pages < 0.65

--�������� ��� �����, �������� ������� ������� �� 4 ����
select b.name as bookname, b.pages, b.price, a.name+' '+a.surname as authorname,t.name as theme from Books b
join Authors a on b.authorid=a.id
join Themes t on b.themeid=t.id
where b.name like '% % % %'

--�������� ���������� � �������� � ��������� ����:
---�������� �����, ��, ����� ��� �� ��������� ����� ���.
---��������, ��, ����� �� �����������������.
---�����, ��, ����� �� �������� �����.
---����, ��, ����� � ��������� �� 10 �� 20 ������.
---���������� ������, �� �� ����� 8 ����.
---�������� ��������, ������� ������ �����, �� �� �� ������ ���� � ������� ��� ������.
select b.name as bookname, t.name as theme, a.name+' '+a.surname as authorname, s.price, s.quantity, sh.name as shopname from Books b
join Authors a on b.authorid=a.id
join Themes t on b.themeid=t.id
join Sales s on s.bookid=b.id
join Shops sh on s.shopid=sh.id
join Countries c on sh.countryid=c.id
where
b.name not like '%1%' and
t.name <> 'Theme 10' and
a.name + ' ' + a.surname <> 'Name 6 Surname 6' and
s.price between 10 and 20 and
s.quantity >= 8 and
c.name <> 'Country 1' and c.name<>'Country 2'

--�������� ��������� ���������� � ��� ������� (����� � ������ ������� ��������� � �������� �������):
---���������� �������: 14
---���������� ����: 47
---������� ���� �������: 85.43 ���.
---������� ���������� �������: 650.6.
select '����������� �������:', count(id) from Authors
union 
select '���������� ����:', count(id) from Books
union 
select '������� ���� �������', avg(price) from Sales
union
select '������� ���������� �������', avg(pages) from Books

--�������� �������� ���� � ����� ������� ���� ���� �� ������ �� ���
select t.name as themename, sum(b.pages) as sumpages from Themes t
join Books b on b.themeid=t.id
group by t.name
order by sumpages

--�������� ���������� ���� ���� � ����� ������� ���� ���� �� ������� �� �������
select a.name + ' ' + a.surname as authorname, count(b.id) as countbooks, sum(b.pages) as countpages from Authors a
join Books b on b.authorid=a.id
group by a.name, a.surname

--�������� ����� �������� ����������������� � ���������� ����������� �������
select b.name as bookname, b.pages, b.price, a.name+' '+a.surname as authorname,t.name as theme from Books b
join Authors a on b.authorid=a.id
join Themes t on b.themeid=t.id
where t.name='Theme 10' and b.pages = (
	select max(pages) 
	from Books b 
	join Themes t on b.themeid=t.id
	where t.name='Theme 10'
)

--�������� ������� ���������� ������� �� ������ ��������, ������� �� ��������� 400
select themename, countpages from
(select t.name as themename, avg(b.pages) as countpages from Themes t
join Books b on b.themeid=t.id
group by t.name) tmp
where countpages < 400

--�������� ����� ������� �� ������ ��������, �������� ������ ����� � ����������� ������� ����� 400, � �����
---�������� ���� �����������������, ������������������ � �������.
select t.name as themename, sum(b.pages) as sumpages from Themes t
join Books b on b.themeid=t.id
where b.pages > 400 and t.name in ('Theme 10','Theme 2','Theme 19')
group by t.name

--�������� ���������� � ������ ���������: ���, ���, ���, ����� � � ����� ���������� ���� �������
select b.name as bookname, c.name as countryname, sh.name as shopname, s.saledate, s.quantity from Sales s
join Shops sh on s.shopid=sh.id
join Countries c on sh.countryid=c.id
join Books b on s.bookid=b.id

--�������� ����� ���������� �������
select sh.name as shopname, c.name as countryname, tmp.sumprice from Shops sh 
join Countries c on sh.countryid=c.id
join (
select top 1 shopid, sum(price) as sumprice
from sales
group by shopid
order by sumprice desc) tmp on sh.id=tmp.shopid