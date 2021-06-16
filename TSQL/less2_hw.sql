use Northwind;
go

--������� �������
--1. ����� ������� �� ������������ ������ (� �����) (��� ������/����� ���������� � ���������� �������)
create or alter function getOrdersByPeriod (@datefrom date, @dateto date)
returns table as 
return
(select * from orders o where year(o.OrderDate) between year(@datefrom) and year(@dateto))
go

select * from getOrdersByPeriod('1998-01-01','2000-01-01')
go

--2. ����� ������� � ������� ���� ���� ��������
create or alter function getOrdersWithFreightUnderAvg ()
returns table as
return
(select * from orders o where o.Freight>(select AVG(Freight) from orders))
go

select * from getOrdersWithFreightUnderAvg()
go

--3. ����������� ������� �� ������� (���������� ������� ������� ���� ��������� � ������ ������)
create or alter function countOrdersOfCountries ()
returns table as
return
(select o.ShipCountry, count(o.OrderID) as [Count] from Orders o group by ShipCountry)
go

select * from countOrdersOfCountries()
go

--4. ����������� ������� �� ������� � ��������� ������ (������ ���������� � ���������� �������)
create or alter function countOrdersOfCities (@country nvarchar(20))
returns table as
return
(select o.ShipCity, count(o.orderid) as [Count] from Orders o where o.ShipCountry=@country group by o.ShipCity)
go

select * from countOrdersOfCities('USA')
go

--������� ��������
--1. ������� ��� ��������� ��������� (��� ���������� ��������, ������ ������ ���������� � �����. �����, ����� ���� ��������� �������)
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