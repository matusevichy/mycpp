use Northwind;
go

--Создать функции
--1. Выбор заказов за определенный период (в годах) (год начала/конца передается в параметрах функции)
create or alter function getOrdersByPeriod (@datefrom date, @dateto date)
returns table as 
return
(select * from orders o where year(o.OrderDate) between year(@datefrom) and year(@dateto))
go

select * from getOrdersByPeriod('1998-01-01','2000-01-01')
go

--2. Выбор заказов у которых груз выше среднего
create or alter function getOrdersWithFreightUnderAvg ()
returns table as
return
(select * from orders o where o.Freight>(select AVG(Freight) from orders))
go

select * from getOrdersWithFreightUnderAvg()
go

--3. Группировка заказов по странам (определить сколько заказов было выполнено в каждую страну)
create or alter function countOrdersOfCountries ()
returns table as
return
(select o.ShipCountry, count(o.OrderID) as [Count] from Orders o group by ShipCountry)
go

select * from countOrdersOfCountries()
go

--4. Группировка заказов по городам в указанной стране (страна передается в параметрах функции)
create or alter function countOrdersOfCities (@country nvarchar(20))
returns table as
return
(select o.ShipCity, count(o.orderid) as [Count] from Orders o where o.ShipCountry=@country group by o.ShipCity)
go

select * from countOrdersOfCities('USA')
go

--Создать триггеры
--1. Триггер для оновления продуктов (при обновлении продукта, старая запись помещается в архив. Архив, новая вами созданная таблица)
create table productArchive (
	ProductID int primary key NOT NULL,
	ProductName nvarchar(40) NOT NULL,
	SupplierID int NULL,
	CategoryID int NULL,
	QuantityPerUnit nvarchar(20) NULL,
	UnitPrice money NULL,
	UnitsInStock smallint NULL,
	UnitsOnOrder smallint NULL,
	ReorderLevel smallint NULL,
	Discontinued bit NOT NULL,
	foreign key(SupplierID) references Suppliers(SupplierID),
	foreign key(CategoryID) references Categories(CategoryID)
)
go

create or alter trigger Products_Updates
on Products
after update
as
insert into productArchive select * from deleted
go

update Products set ProductName='New_'+ProductName where ProductID=1

select * from Products where ProductID=1
union
select * from productArchive