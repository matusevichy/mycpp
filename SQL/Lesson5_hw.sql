use Northwind;

--������� ���������� ������������ �� ������ ������
select Country, COUNT(companyName) from Suppliers group by Country order by Country

--�������� ���������� �����, ������� ������ ���������� � ������������ ������ ������� � ������ ������;
select ShipCity, count(EmployeeID) from Orders where year(ShippedDate)=1996 group by ShipCity 

--������� ���������� ����������� ������ �����, ������� ���������� �������� ������������� ���������� ���������;
select count(EmployeeID) from Employees where HomePhone LIKE '%(206)%'

--�������� ���������� �����������, � ������� ������� ��������� � ��������� �� ������������� ������;
select count(EmployeeID) from Employees where LastName in ('Buchanan','Davolio','Leverling','King')

--�������� ���������� ����� � ����������� �������, ������� ���������� � ������������� �����������;
select LastName, count(ShipCountry) from Orders o, Employees e where o.EmployeeID=e.EmployeeID and ShipCountry='USA' group by LastName

--�������� ���������� � �����, ������� �������� ������ ��� ����������� ���������� ���;
select LastName, FirstName, count(ShipCountry) from Orders o, Employees e where o.EmployeeID=e.EmployeeID group by LastName, FirstName having count(ShipCountry)=
(select min(CountCountry) from (select LastName, count(ShipCountry) as CountCountry from Orders o, Employees e where o.EmployeeID=e.EmployeeID group by LastName) tmp) 

--������� ���������� �����������, ������� ���������� � ������������ ������ �� ������ �������� �������� ����;
select count(*) from Orders where ShippedDate>='1997-01-01' and ShippedDate<'1997-01-07' and ShipName='Ernst Handel'

--���������� ����� ���������� �����, ���������� ������ ��� �� ������� ���.
select count(*) from Orders where year(ShippedDate)=1996 
