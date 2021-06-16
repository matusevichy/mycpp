CREATE TABLE Author (
	id INT PRIMARY KEY IDENTITY,
	name nvarchar(50)
)

CREATE TABLE Genre (
	id INT PRIMARY KEY IDENTITY,
	name NVARCHAR (30)
)

CREATE TABLE Publisher (
	id	INT PRIMARY KEY IDENTITY,
	name NVARCHAR(50)
)

CREATE TABLE Books (
	id INT PRIMARY KEY IDENTITY,
	name NVARCHAR(30) NOT NULL,
	authorid INT REFERENCES Author(id),
	genreid INT REFERENCES Genre(id),
	published DATE,
	publisherid INT REFERENCES Publisher(id),
	pagecount INT NOT NULL,
	count INT,
	cost FLOAT(1)
)
