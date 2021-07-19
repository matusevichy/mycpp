use [Vegetables&Fruits]

create table VandF (
	id int primary key identity,
	[name] nvarchar(30) not null,
	[type] nvarchar(10) not null check([type] in ('����', '�����')),
	color nvarchar(20) not null check (color in ('�����','�����','������','�������','�������','������')),
	calories decimal not null
)
go

insert into VandF values 
('��������','����','������',10),
('�������','����','�������',20),
('��������','����','�����',15),
('�����','�����','�����',25),
('������','�����','�������',30),
('�����','�����','������',11)
go


create or alter proc sp_CaloriesInfo (@min int output, @max int output, @avg int output)
as
begin
	select @min=min(calories), @max=max(calories), @avg=avg(calories) from VandF
end
go

declare @min decimal, @max decimal, @avg decimal;
exec sp_CaloriesInfo @min output, @max output, @avg output
print @min;
print @max;
print @avg;