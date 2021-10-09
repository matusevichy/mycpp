use Library

create table Genres (
	id int primary key identity,
	[name] nvarchar(50) not null unique check(len([name]) >0 )
)

insert into Genres values
('Genre 1'),
('Genre 2'),
('Genre 3'),
('Genre 4'),
('Genre 5')

create table Authors (
	id int primary key identity,
	firstname nvarchar(20) not null,
	lastname nvarchar(30) not null,
	birth date not null
)

create table Books (
	id int primary key identity,
	title nvarchar(50) not null,
	genreid int null,
	pages int not null,
	[description] nvarchar(max),
	instock int not null,
	foreign key(genreid) references Genres(id)
)

create table Author2Book (
	authorid int,
	bookid int,
	foreign key(authorid) references Authors(id),
	foreign key(bookid) references Books(id)
)

create table BooksOnHands (
	bookid int,
	userid int,
	foreign key(bookid) references Books(id),
	foreign key(userid) references Users(id)
)

create table Users 
(
	id int primary key identity,
	[login] varchar(20) not null unique,
	[password] nvarchar(20) not null,
	email varchar(50) not null check(email like '%@%')
)

select scope_identity();

delete from Author2Book
insert into Author2Book values (1,3)

select b.id, b.title, b.genreid, b.pages, b.description, b.instock from Books b 
join Author2Book a2b on b.id=a2b.bookid
where a2b.authorid = 1
