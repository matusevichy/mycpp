use BookStore
go

create or alter proc sp_DeleteAllTables as
begin
	drop table Sales;
	drop table Books;
	drop table Authors;
	drop table Shops;
	drop table Countries;
	drop table Themes;
end
go

create or alter proc sp_CreateAllTables as
begin
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
end
go

--insert into Themes
create or alter proc sp_RandFillThemes @count int, @prefix nvarchar(100) as
begin
	declare @counter int =0;
	while @counter<@count
	begin
		insert into Themes values
		(@prefix+' '+convert(varchar(2),@counter));
		set @counter+=1;
	end
end 
go

--insert into Countries
create or alter proc sp_RandFillCountries @count int, @prefix nvarchar(50) as
begin
	declare @counter int =0;
	while @counter<@count
	begin
		insert into Countries values
		(@prefix+' '+convert(varchar(2),@counter));
		set @counter+=1;
	end
end
go

--insert into Shops
create or alter proc sp_RandFillShops @count int, @prefix nvarchar(max) as
begin
	declare @counter int =0;
	while @counter<@count
	begin
		insert into Shops values
		(@prefix+' '+convert(varchar(2),@counter), ROUND(rand()*(select max(id) from Countries), 0)+1);
		set @counter+=1;
	end
end
go

--insert into Authors
create or alter proc sp_RandFillAuthors @count int, @prefixname nvarchar(max), @prefixsname nvarchar(max) as
begin
	declare @counter int =0;
	while @counter<@count
	begin
		insert into Authors values
		(@prefixname+' '+convert(varchar(2),@counter), @prefixsname+' '+convert(varchar(2),@counter), ROUND(rand()*(select max(id) from Countries), 0)+1);
		set @counter+=1;
	end
end
go

--insert into Books
create or alter proc sp_RandFillBooks @count int, @fromdate date, @prefix nvarchar(max), @maxpage int, @maxprice money as
begin
	declare @todate date = getdate();
	declare @counter int=0;
	while @counter<@count
	begin
		insert into Books values(
		@prefix+' '+convert(varchar(4),@counter), 
		ROUND(rand()*@maxpage, 0)+1, 
		ROUND(rand()*@maxprice, 0)+1, 
		dateadd(day, rand()*(1+datediff(day, @FromDate, @ToDate)),@FromDate),
		ROUND(rand()*(select max(id) from Authors), 0)+1, 
		ROUND(rand()*(select max(id) from Themes), 0)+1);
		set @counter+=1;
	end
end
go

--insert into Sales
create or alter proc sp_RandFillSales @count int, @fromdate date, @maxprice money, @maxquantity int as
begin
	declare @todate date = getdate();
	declare @counter int =0;
	while @counter<@count
	begin
		insert into Sales values(
		ROUND(rand()*@maxprice, 0)+1, 
		ROUND(rand()*@maxquantity, 0)+1, 
		dateadd(day, rand()*(1+datediff(day, @FromDate, @ToDate)), @FromDate),
		ROUND(rand()*(select max(id) from Books), 0)+1, 
		ROUND(rand()*(select max(id) from Shops), 0)+1);
		set @counter+=1;
	end
end
go

--Выполнение процедур заполнения таблиц
execute sp_DeleteAllTables;
execute sp_CreateAllTables;
execute sp_RandFillThemes 20, 'Theme';
execute sp_RandFillCountries 30, 'Country';
execute sp_RandFillShops 50, 'Shop';
execute sp_RandFillAuthors 100, 'Name', 'Sname';
execute sp_RandFillBooks 1000, '1910-01-01', 'Book', 1000, 1000;
execute sp_RandFillSales 10000, '2019-01-01', 10000, 50;
go

--Показать все книги, количество страниц в которых больше 500, но меньше 650.
create or alter proc sp_GetBookWithPagesBetween @pagesmin int, @pagesmax int as
begin
	select b.name as bookname, b.pages, b.price, a.name+' '+a.surname as authorname,t.name as theme from Books b
	join Authors a on b.authorid=a.id
	join Themes t on b.themeid=t.id
	where pages between @pagesmin and @pagesmax
end
go

execute sp_GetBookWithPagesBetween 500, 650;
go

--Показать все книги, в которых первая буква названия либо «А», либо «З»
create or alter proc sp_GetBooksWithNameBegin @letter1 nvarchar(1), @letter2 nvarchar(1) as
begin
	select b.name as bookname, b.pages, b.price, a.name+' '+a.surname as authorname,t.name as theme from Books b
	join Authors a on b.authorid=a.id
	join Themes t on b.themeid=t.id
	where b.name like @letter1+'%' or b.name like @letter2+'%'
end
go

execute sp_GetBooksWithNameBegin 'B','C';
go

--Показать все книги жанра «Детектив», количество проданных книг более 30 экземпляров
create or alter proc sp_GetBooksWithThemeAndQuantity @themename nvarchar(100), @quantity int as
begin
	select b.name as bookname, b.pages, b.price, a.name+' '+a.surname as authorname,tmp.count_q, t.name as theme from Books b
	join Authors a on b.authorid=a.id
	join Themes t on b.themeid=t.id
	join (select bookid, sum(quantity) as count_q from Sales group by bookid) tmp on b.id=tmp.bookid 
	where t.name = @themename and count_q>@quantity
end
go

execute sp_GetBooksWithThemeAndQuantity 'Theme 15', 30;
go

--Показать все книги, в названии которых есть слово «Microsoft», но нет слова «Windows».
create or alter proc sp_GetBooksWithNameContainAndNotContainWorlds @world1 nvarchar(20), @world2 nvarchar(20) as
begin
	select b.name as bookname, b.pages, b.price, a.name+' '+a.surname as authorname,t.name as theme from Books b
	join Authors a on b.authorid=a.id
	join Themes t on b.themeid=t.id
	where b.name like '%'+@world1+'%' and b.name not like '%'+@world2+'%'
end
go

execute sp_GetBooksWithNameContainAndNotContainWorlds 15, 45;
go 

--Показать все книги (название, тематика, полное имя автора в одной ячейке), цена одной страницы которых меньше 65 копеек.
create or alter proc sp_GetBooksWithPriceOfPagesBefor @price float as
begin
	select b.name + ' ' + t.name + ' ' + a.name + ' ' + a.surname as bookinfo, round(b.price/b.pages, 2) as priseonepage from Books b
	join Authors a on b.authorid=a.id
	join Themes t on b.themeid=t.id
	where b.price/b.pages < @price
end
go

execute sp_GetBooksWithPriceOfPagesBefor 0.65;
go

--Показать все книги, название которых состоит из 4 слов
create or alter proc sp_GetBooksWithNPages @pages int as
begin
	if @pages < 1 
	begin
		rollback;
	end
	declare @mask varchar(10) = '%';
	if @pages > 1
	declare @counter int=1;
	begin
		while @counter<@pages
		begin
			set @mask+=' %';
			set @counter+=1;
		end
	end
	select b.name as bookname, b.pages, b.price, a.name+' '+a.surname as authorname,t.name as theme from Books b
	join Authors a on b.authorid=a.id
	join Themes t on b.themeid=t.id
	where b.name like @mask
end
go

execute sp_GetBooksWithNPages 4;
go

--Показать информацию о продажах в следующем виде:
---Название книги, но, чтобы оно не содержало букву «А».
---Тематика, но, чтобы не «Программирование».
---Автор, но, чтобы не «Герберт Шилдт».
---Цена, но, чтобы в диапазоне от 10 до 20 гривен.
---Количество продаж, но не менее 8 книг.
---Название магазина, который продал книгу, но он не должен быть в Украине или России.
create or alter proc sp_GetSalesWithExclusiveParam 
		@letter nvarchar(1), 
		@themes nvarchar(100), 
		@author nvarchar(max), 
		@minprice money, 
		@maxprise money, 
		@quantity int,
		@country1 nvarchar(50),
		@country2 nvarchar(50) as
begin
	select b.name as bookname, t.name as theme, a.name+' '+a.surname as authorname, s.price, s.quantity, sh.name as shopname from Books b
	join Authors a on b.authorid=a.id
	join Themes t on b.themeid=t.id
	join Sales s on s.bookid=b.id
	join Shops sh on s.shopid=sh.id
	join Countries c on sh.countryid=c.id
	where
	b.name not like '%'+@letter+'%' and
	t.name <> @themes and
	a.name + ' ' + a.surname <> @author and
	s.price between @minprice and @maxprise and
	s.quantity >= @quantity and
	c.name <> @country1 and c.name<>@country2
end
go

execute sp_GetSalesWithExclusiveParam '1', 'Theme 10', 'Name 6 Surname 6', 10, 20, 8, 'Country 1', 'Country 2';
go

--Показать следующую информацию в два столбца (числа в правом столбце приведены в качестве примера):
---Количество авторов: 14
---Количество книг: 47
---Средняя цена продажи: 85.43 грн.
---Среднее количество страниц: 650.6.

create or alter proc sp_GetStatistic as
begin
	select 'Колличество авторов:', count(id) from Authors
	union 
	select 'Количество книг:', count(id) from Books
	union 
	select 'Средняя цена продажи', avg(price) from Sales
	union
	select 'Среднее количество страниц', avg(pages) from Books
end
go

execute sp_GetStatistic;
go

--Показать тематики книг и сумму страниц всех книг по каждой из них
create or alter proc sp_GetSumPagesOfThemes as
begin
	select t.name as themename, sum(b.pages) as sumpages from Themes t
	join Books b on b.themeid=t.id
	group by t.name
	order by sumpages
end
go

execute sp_GetSumPagesOfThemes;
go

--Показать количество всех книг и сумму страниц этих книг по каждому из авторов
create or alter proc sp_GetBoocsCountAndPagesCountOfAuthors as
begin
	select a.name + ' ' + a.surname as authorname, count(b.id) as countbooks, sum(b.pages) as countpages from Authors a
	join Books b on b.authorid=a.id
	group by a.name, a.surname
end
go

execute sp_GetBoocsCountAndPagesCountOfAuthors;
go

--Показать книгу тематики «Программирование» с наибольшим количеством страниц
create or alter proc sp_GetBookWithMaxPagesInTheme @theme nvarchar(100) as
begin
	select b.name as bookname, b.pages, b.price, a.name+' '+a.surname as authorname,t.name as theme from Books b
	join Authors a on b.authorid=a.id
	join Themes t on b.themeid=t.id
	where t.name=@theme and b.pages = (
		select max(pages) 
		from Books b 
		join Themes t on b.themeid=t.id
		where t.name=@theme
	)
end
go

execute sp_GetBookWithMaxPagesInTheme 'Theme 10';
go

--Показать среднее количество страниц по каждой тематике, которое не превышает 400
create or alter proc sp_GetAVGPagesOfThemes @count int as
begin
	select themename, countpages from
	(select t.name as themename, avg(b.pages) as countpages from Themes t
	join Books b on b.themeid=t.id
	group by t.name) tmp
	where countpages < @count
end
go

execute sp_GetAVGPagesOfThemes 400;
go

--Показать сумму страниц по каждой тематике, учитывая только книги с количеством страниц более 400, и чтобы
---тематики были «Программирование», «Администрирование» и «Дизайн».
create or alter proc sp_GetSumPagesOfThemesLessNIn3Themes @count int, @theme1 nvarchar(100), @theme2 nvarchar(100), @theme3 nvarchar(100) as
begin
	select t.name as themename, sum(b.pages) as sumpages from Themes t
	join Books b on b.themeid=t.id
	where b.pages > @count and t.name in (@theme1, @theme2, @theme3)
	group by t.name
end
go

execute sp_GetSumPagesOfThemesLessNIn3Themes 400, 'Theme 10','Theme 2','Theme 19';
go

--Показать информацию о работе магазинов: что, где, кем, когда и в каком количестве было продано
create or alter proc sp_GetFullSalesInfo as
begin
	select b.name as bookname, c.name as countryname, sh.name as shopname, s.saledate, s.quantity from Sales s
	join Shops sh on s.shopid=sh.id
	join Countries c on sh.countryid=c.id
	join Books b on s.bookid=b.id
end
go

execute sp_GetFullSalesInfo;
go

--Показать самый прибыльный магазин
create or alter proc sp_GetMostProfitableStiore as
begin
	select sh.name as shopname, c.name as countryname, tmp.sumprice from Shops sh 
	join Countries c on sh.countryid=c.id
	join (
	select top 1 shopid, sum(price) as sumprice
	from sales
	group by shopid
	order by sumprice desc) tmp on sh.id=tmp.shopid
end
go

execute sp_GetMostProfitableStiore;
go

