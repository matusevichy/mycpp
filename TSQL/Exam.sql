use matusevichexam;

--Гостинницы
create table Hotels (
	id int primary key identity,
	[name] nvarchar(30) not null,
	adress nvarchar(50) not null,
	[image] nvarchar(256)
)
--Должности
create table Positions (
	id int primary key identity,
	[name] nvarchar(30) not null
)
--Страны
create table Countries (
	id int primary key identity,
	[name] nvarchar(50) not null
)
--Города
create table Towns (
	id int primary key identity,
	[name] nvarchar(50) not null
)
--Города в странах
create table Country2Town (
	id int primary key identity,
	countryid int,
	townid int,
	foreign key (countryid) references Countries(id),
	foreign key (townid) references Towns(id)
)

--Достопримечательности
create table Atractoins (
	id int primary key identity,
	[name] nvarchar(50) not null,
	country2townid int,
	atextracost bit not null,
	[image] nvarchar(256)
	foreign key (country2townid) references Country2Town(id)
)

--Способы передвижения
create table Way2Travels (
	id int primary key identity,
	[name] nvarchar(20) not null
)
--Сотрудники
create table Workers (
	id int primary key identity,
	firstname nvarchar(20) not null,
	lastname nvarchar(20) not null,
	positionid int,
	phone varchar(15) check (phone like '%+%'),
	email varchar(30) check (email like '%@%'),
	datebegin date check (datebegin > '1900-01-01' and datebegin<=getdate()) not null,
	foreign key (positionid) references Positions(id)
)
--Туры
create table Tours (
	id int primary key identity,
	[name] nvarchar(50) not null,
	cost money check (cost>0) not null,
	datebegin date not null,
	dateend date not null,
	maxclients int not null,
	constraint chk_dateend check (dateend > datebegin)
)
create index i_tours_datebegin on Tours(datebegin)

--Сотрудники, ответственные за туры
create table Worker2Tour (
	workerid int,
	tourid int,
	foreign key (workerid) references Workers(id),
	foreign key (tourid) references Tours(id)
)
--Сотрудники, ответственные за страны
create table Worker2Country (
	workerid int,
	countryid int,
	foreign key (workerid) references Workers(id),
	foreign key (countryid) references Countries(id)
)
--Способы передвижения для туров
create table Way2Tours (
	way2travelid int,
	tourid int,
	foreign key (way2travelid) references Way2Travels(id),
	foreign key (tourid) references Tours(id)
)
--Даты посещения городов в турах
create table TourDates (
	id int primary key identity,
	country2townid int,
	tourid int,
	visitdate date not null,
	foreign key (country2townid) references Country2Town(id),
	foreign key (tourid) references Tours(id)
)
--Гостинницы по датам туров
create table Hotel2Tourdate (
	hotelid int,
	tourdateid int,
	foreign key (hotelid) references Hotels(id),
	foreign key (tourdateid) references TourDates(id)
)

create table Clients (
	id int primary key identity,
	fio nvarchar(50) not null,
	phone varchar(15) check (phone like '%+%'),
	email varchar(30) check (email like '%@%'),
	birth date check (birth > '1900-01-01' and birth<=getdate()) not null
)

create table Client2Tour (
	clientid int,
	tourid int,
	foreign key (clientid) references Clients(id),
	foreign key (tourid) references Tours(id)
)

create table ViewsTour (
	clientid int,
	tourid int,
	foreign key (clientid) references Clients(id),
	foreign key (tourid) references Tours(id)
)

create table Archive (
	id int primary key identity,
	[name] nvarchar(50) not null,
	cost money check (cost>0) not null,
	datebegin date not null,
	dateend date not null,
	datearchive date not null
)

create index i_archive_datebegin on Archive(datebegin)
go

--Функции
--Колличество клиентов, оплативших тур
create or alter function getTotalClientsCount (@tourid int)
returns table as
return
(select count(*) as totalcount from Client2Tour where tourid=@tourid)
go

--Проверить для конкретного туриста по ФИО находится ли он сейчас в туре. ФИО туриста передаётся в качестве параметра
create or alter function dbo.isClientInTourNow (@fio nvarchar(50))
returns int as
begin
	declare @count int = (select count(*) from Tours t
	join 
	Client2Tour c2t on c2t.tourid=t.id
	join 
	Clients c on c.id=c2t.clientid
	where c.fio=@fio and t.datebegin <= GETDATE() and t.dateend>=GETDATE())
	return @count
end
go

--Процедуры
create or alter proc sp_FillBases as
begin
	declare @counter int =0
	--Towns
	while @counter<20
	begin
		insert into Towns values
		('Town '+convert(varchar(2),@counter));
		set @counter+=1;
	end
	--Countries
	set @counter=0
	while @counter<10
	begin
		insert into Countries values
		('Country '+convert(varchar(2),@counter));
		set @counter+=1;
	end
	--Country@Town
	set @counter=0
	while @counter<20
	begin
		insert into Country2Town values
		(ROUND(rand()*(select max(id) from Countries), 0)+1, @counter);
		set @counter+=1;
	end
	--Positions
	set @counter=0
	while @counter<10
	begin
		insert into Positions values
		('Position '+convert(varchar(2),@counter));
		set @counter+=1;
	end
	--Workers
	set @counter =0
	while @counter<20
	begin
		insert into Workers values
		('Firstname '+convert(varchar(2),@counter), 'Lastname '+convert(varchar(2),@counter),ROUND(rand()*(select max(id) from Positions), 0)+1, 'Phone+'+convert(varchar(2),@counter),'Email@'+convert(varchar(2),@counter), dateadd(day, rand()*(1+datediff(day, 2000-01-01, GETDATE())),2000-01-01));
		set @counter+=1;
	end
	--Worker2Country
	set @counter=0
	while @counter<10
	begin
		insert into Worker2Country values
		(ROUND(rand()*(select max(id) from Workers),0), @counter);
		set @counter+=1;
	end
	--Clients
	set @counter=0
	while @counter<20
	begin
		insert into Clients values
		('Fio '+convert(varchar(2),@counter),  'Phone+'+convert(varchar(2),@counter),'Email@'+convert(varchar(2),@counter), dateadd(day, rand()*(1+datediff(day, 1920-01-01, GETDATE())),1920-01-01));
		set @counter+=1;
	end
	--Hotels
	set @counter=0
	while @counter<20
	begin
		insert into Hotels values
		('Hotel '+convert(varchar(2),@counter),  'Addr '+convert(varchar(2),@counter),'Image '+convert(varchar(2),@counter));
		set @counter+=1;
	end
	--Tours
	set @counter=0
	while @counter<50
	begin
		insert into Tours values
		('Tour '+convert(varchar(2),@counter), ROUND(rand()*1000, 0)+1, dateadd(day, rand()*(1+datediff(day, 2020-01-01, 2021-12-31)),2020-01-01),dateadd(day, rand()*(1+datediff(day, 2021-01-01, 2022-12-31)),2021-01-01), ROUND(rand()*100, 0)+1);
		set @counter+=1;
	end
	--TourDates
	set @counter=0
	while @counter<100
	begin
		insert into TourDates values
		(ROUND(rand()*(select max(id) from Country2Town),0), ROUND(rand()*(select max(id) from Tours),0), dateadd(day, rand()*(1+datediff(day, 2020-01-01, 2021-12-31)),2020-01-01));
		set @counter+=1;
	end
	--Hotel2TourDate
	set @counter=0
	while @counter<20
	begin
		insert into Hotel2TourDate values
		(@counter, ROUND(rand()*(select max(id) from TourDates),0));
		set @counter+=1;
	end
	--Way2Travels
	set @counter=0
	while @counter<10
	begin
		insert into Way2Travels values
		('Way '+convert(varchar(2),@counter));
		set @counter+=1;
	end
	--Way2Tours
	set @counter=0
	while @counter<50
	begin
		insert into Way2Tours values
		(ROUND(rand()*(select max(id) from Way2Travels),0), @counter);
		set @counter+=1;
	end
	--Client2Tour
	set @counter =0
	while @counter<50
	begin
		insert into Client2Tour values
		(ROUND(rand()*(select max(id) from Clients),0), ROUND(rand()*(select max(id) from Tours),0));
		set @counter+=1;
	end

end

go

exec sp_FillBases
go

--Предоставьте информацию о всех актуальных турах
create or alter proc sp_GetActiveTours as
begin
	select [name], cost, datebegin, dateend, maxclients, (select * from getTotalClientsCount(id)) as totalclients from Tours where datebegin>GETDATE()
end
go

exec sp_GetActiveTours
go

--Отобразите информацию о всех турах, которые стартуют
--в указанном диапазоне дат. Диапазон дат передаётся в качестве параметра
create or alter proc sp_ToursOnDates @datefrom date, @dateto date as
begin
	select [name], cost, datebegin, dateend, maxclients, (select * from getTotalClientsCount(id))  as totalclients from Tours where datebegin between @datefrom and @dateto  
end
go

exec sp_ToursOnDates '1900-01-01', '2022-01-01'
go
--Отобразите информацию о всех турах, которые посетят
--указанную страну. Страна передаётся в качестве параметра
create or alter proc sp_ToursInCountry @country nvarchar(50) as
begin
	select t.[name], t.cost, t.datebegin, t.dateend, t.maxclients, (select * from getTotalClientsCount(t.id))  as totalclients from Tours t 
	join 
	TourDates td on t.id=td.tourid
	join 
	Country2Town c2t on td.country2townid=c2t.id
	join 
	Countries c on c.id=c2t.countryid
	where c.name=@country   
end
go

exec sp_ToursInCountry 'Country 2'
go

--Отобразите самую популярную туристическую страну (по самому большому количеству туров с учетом архивных)
create or alter proc sp_PopularCountry as
begin
	select [name] from Countries c
	join
	Country2Town c2t on c.id=c2t.countryid
	join
	(select top 1 count(tourid) as counttours, country2townid from TourDates group by country2townid order by counttours desc) tmp on
	c2t.id=tmp.country2townid
end
go

exec sp_PopularCountry
go

--Показать самый популярный актуальный тур (по максимальному количеству купленных туристических путевок)
create or alter proc sp_PopularTour as
begin
	select top 1 [name], cost, datebegin, dateend, maxclients, (select * from getTotalClientsCount(id))  as totalclients from Tours where datebegin > GETDATE() order by totalclients desc  
end
go

exec sp_PopularTour
go

--Показать самый популярный архивный тур (по максимальному количеству купленных туристических путевок)
create or alter proc sp_PopularArchiveTour as
begin
	select top 1 [name], cost, datebegin, dateend, (select * from getTotalClientsCount(id))  as totalclients from Archive where datebegin > GETDATE() order by totalclients desc  
end
go

exec sp_PopularArchiveTour
go

--Показать самый непопулярный актуальный тур (по минимальному количеству купленных туристических путевок)
create or alter proc sp_NoPopularTour as
begin
	select top 1 [name], cost, datebegin, dateend, maxclients, (select * from getTotalClientsCount(id))  as totalclients from Tours where datebegin > GETDATE() order by totalclients asc  
end
go

exec sp_NoPopularTour
go

--Показать для конкретного туриста по ФИО список всех его туров. ФИО туриста передаётся в качестве параметра
create or alter proc sp_ToursForClient @fio nvarchar(50) as
begin
	select [name], cost, datebegin, dateend from Tours t
	join 
	Client2Tour c2t on c2t.tourid=t.id
	join 
	Clients c on c.id=c2t.clientid
	where c.fio=@fio
end
go

exec sp_ToursForClient 'Fio 1'
go

--Отобразить информацию о том, где находится конкретный турист по ФИО. Если турист не в туре сгенерировать
--ошибку с описанием возникшей проблемы. ФИО туриста передаётся в качестве параметра
create or alter proc sp_ClientInTourNow @fio nvarchar(50) as
begin
	declare @count int = (select dbo.isClientInTourNow(@fio))
	if ( @count = 0) throw 50000, 'Client not in the tour', 1
end
go

exec sp_ClientInTourNow 'Fio 1'
go

--Отобразить информацию о самом активном туристе (по количеству приобретённых туров)
create or alter proc sp_BestClient  as
begin
	select c.fio, c.phone, c.email, c.birth from Clients c 
	join
	(select top 1 count(*) as [count], clientid from Client2Tour group by clientid order by [count] desc) as tmp 
	on c.id=tmp.clientid
end
go

exec sp_BestClient
go

--Отобразить информацию о всех турах указанного способа передвижения. Способ передвижения передаётся в качестве параметра
create or alter proc sp_TuorsWithWay2Travels @way nvarchar(20) as
begin
	select t.[name], t.cost, t.datebegin, t.dateend from Tours t
	join Way2Tours w2to on t.id=w2to.tourid
	join Way2Travels w2tr on w2to.way2travelid=w2tr.id
	where w2tr.name=@way
end
go

exec sp_TuorsWithWay2Travels 'Way 1'
go

--При вставке нового клиента нужно проверять, нет ли его уже в базе данных. Если такой клиент есть, генерировать
--ошибку с описанием возникшей проблемы
create or alter trigger Clients_Insert 
on Clients
after insert as
begin
	if exists (select * from Clients where fio = (select fio from inserted))
		throw 50001, 'Client exist!', 1
		rollback transaction
end
go

--При удалении прошедших туров необходимо переносить их в архив туров
create or alter trigger Tours_Delete
on Tours
after delete as
insert into Archive select name, cost, datebegin, dateend, getdate() from deleted
go

--Отобразить информацию о самой популярной гостинице среди туристов (по количеству туристов)
create or alter proc sp_BestHotel as
begin
	select * from Hotels h
	join 
	(select top 1 count(*) clientcount, h2td.hotelid from Client2Tour c2t
	join Tours t on t.id=c2t.tourid
	join TourDates td on td.id=t.id
	join Hotel2Tourdate h2td on h2td.tourdateid=td.id group by h2td.hotelid order by clientcount desc) tmp on h.id=tmp.hotelid
end
go

exec sp_BestHotel
go

--При добавлении нового туриста в тур проверять не достигнуто ли уже максимальное количество. 
--Если максимальное количество достигнуто, генерировать ошибку с информацией о возникшей проблеме
create or alter trigger InsertClientInTour 
on Client2Tour
after insert as
begin
	declare @tourid int=(select tourid from inserted)
	declare @total int=(select * from getTotalClientsCount(@tourid))
	declare @maxclient int=(select maxclients from Tours where id=@tourid)
	select @total, @maxclient
	if (@total>=@maxclient) 
	throw 50002, 'Tour is full!', 1
	rollback transaction
end