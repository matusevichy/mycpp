use Hospital;

DROP TABLE Doctors2Departments;
DROP TABLE Patient2Therapy;
DROP TABLE Doctor2Therapy;
DROP TABLE Patients;
DROP TABLE Departments;
DROP TABLE Doctors;
DROP TABLE Therapyes;

CREATE TABLE Patients (
	id INT PRIMARY KEY identity, 
	firstname NVARCHAR(20) NOT NULL,
	lastname NVARCHAR(20) NOT NULL,
	phone VARCHAR(13) UNIQUE,
	birthday date
)

CREATE TABLE Departments (
	id INT PRIMARY KEY identity,
	departmentname NVARCHAR(20) NOT NULL	
)

CREATE TABLE Doctors (
	id INT PRIMARY KEY identity,
	firstname NVARCHAR(20) NOT NULL,
	lastname NVARCHAR(20) NOT NULL,
	position NVARCHAR(30)
)

CREATE TABLE Therapyes (
	id INT PRIMARY KEY identity,
	diagnosis NVARCHAR(30) NOT NULL,
	datebegin date NOT NULL,
	dateend date DEFAULT NULL,
	result NVARCHAR(100)
)

CREATE TABLE Doctors2Departments (
	doctorid INT,
	departmentid INT,
	FOREIGN KEY (doctorid) references Doctors(id),
	FOREIGN KEY (departmentid) references Departments(id)
)

CREATE TABLE Patient2Therapy (
	patientid INT,
	therapyid INT,
	FOREIGN KEY (patientid) references Patients(id),
	FOREIGn KEY (therapyid) references Therapyes(id)
)

CREATE TABLE Doctor2Therapy (
	doctorid INT,
	therapyid INT,
	FOREIGN KEY (doctorid) references Doctors(id),
	FOREIGn KEY (therapyid) references Therapyes(id)
)

INSERT INTO Patients VALUES 
('Ivan', 'Ivanov', '1234556','1978-02-23'),
('Petr','Petrov','345678','1988-01-01'),
('Sidor','Sidorov','12367890','1999-02-07'),
('Vasya','Pupkin','23487654','2000-06-07'),
('Sergey','Sergeev','43345787','1977-02-25'),
('Andrey','Andreev','23557679','1995-09-12'),
('Maks','Maksimenko','23434656','1992-12-01')

INSERT INTO Departments VALUES
('Терапия'),
('Неврология'),
('Хирургия'),
('Травматология')

INSERT INTO Doctors VALUES
('Изя','Кацман','Главврач'),
('Гиви','Мкртчан','Зав.терапии'),
('Саша','Петренко','Зав.неврологии'),
('Игорь','Александров','Зав.хирургии'),
('Сема','Кульман','Зав.травматологии')

INSERT INTO Therapyes VALUES
('ОРЗ','2020-12-10','2021-01-05',''),
('ОРЗ','2020-10-11','2020-12-12',''),
('Коронавирус','2020-11-01',NULL,''),
('Прелом ноги','2021-02-01',NULL,''),
('Апендицит','2020-09-15','2020-10-15',''),
('Нервный тик','2020-01-01','2020-01-02','Рекомендовано бросить пить после 14 января'),
('Ущемление нерва','2021-01-01',NULL,''),
('Сотрясение мозга','2020-10-13','2020-12-13','')

INSERT INTO Doctors2Departments VALUES
(2,1),(3,2),(4,3),(5,4)

INSERT INTO Doctor2Therapy VALUES
(2,1),(2,2),(2,3),(5,4),(4,5),(3,6),(3,7),(5,8)

INSERT INTO Patient2Therapy VALUES
(1,1),(2,2),(2,3),(3,4),(4,5),(5,6),(6,7),(7,8)

--вывести информацию обо всех пациентах, находящихся в больнице;
select pa.firstname + ' ' + pa.lastname as fio, diagnosis, datebegin,dateend, do.firstname+' '+do.lastname as doctor, departmentname
from Patients pa, Patient2Therapy pa2th, Therapyes th, Doctor2Therapy do2th, Doctors do, Doctors2Departments do2de, Departments de
where pa.id=pa2th.patientid and pa2th.therapyid=th.id and th.id=do2th.therapyid and do2th.doctorid=do.id and do.id=do2de.doctorid and do2de.departmentid=de.id and
dateend is null

--показать данные о пациентах, которые лежат в определенном отделении
select pa.firstname + ' ' + pa.lastname as fio, diagnosis, datebegin,dateend, do.firstname+' '+do.lastname as doctor, departmentname
from Patients pa, Patient2Therapy pa2th, Therapyes th, Doctor2Therapy do2th, Doctors do, Doctors2Departments do2de, Departments de
where pa.id=pa2th.patientid and pa2th.therapyid=th.id and th.id=do2th.therapyid and do2th.doctorid=do.id and do.id=do2de.doctorid and do2de.departmentid=de.id and
dateend is null and departmentname='Терапия'

--получить данные о пациентах, которые лежат в больнице больше месяца, отсортировав их по возрастанию даты поступления;
select pa.firstname + ' ' + pa.lastname as fio, diagnosis, datebegin,dateend, do.firstname+' '+do.lastname as doctor, departmentname
from Patients pa, Patient2Therapy pa2th, Therapyes th, Doctor2Therapy do2th, Doctors do, Doctors2Departments do2de, Departments de
where pa.id=pa2th.patientid and pa2th.therapyid=th.id and th.id=do2th.therapyid and do2th.doctorid=do.id and do.id=do2de.doctorid and do2de.departmentid=de.id and
dateend is null and DATEDIFF(month,datebegin,GETDATE())>1 order by datebegin

--вывести информацию о пациентах, которые были выписаны в прошлом месяце;
select pa.firstname + ' ' + pa.lastname as fio, diagnosis, datebegin,dateend, do.firstname+' '+do.lastname as doctor, departmentname
from Patients pa, Patient2Therapy pa2th, Therapyes th, Doctor2Therapy do2th, Doctors do, Doctors2Departments do2de, Departments de
where pa.id=pa2th.patientid and pa2th.therapyid=th.id and th.id=do2th.therapyid and do2th.doctorid=do.id and do.id=do2de.doctorid and do2de.departmentid=de.id and
DATEDIFF(month, dateend,GETDATE())=1

--показать информацию о пациентах, которые лежали в больнице с октября по декабрь прошлого года в определенном отделении;
select pa.firstname + ' ' + pa.lastname as fio, diagnosis, datebegin,dateend, do.firstname+' '+do.lastname as doctor, departmentname
from Patients pa, Patient2Therapy pa2th, Therapyes th, Doctor2Therapy do2th, Doctors do, Doctors2Departments do2de, Departments de
where pa.id=pa2th.patientid and pa2th.therapyid=th.id and th.id=do2th.therapyid and do2th.doctorid=do.id and do.id=do2de.doctorid and do2de.departmentid=de.id and
(dateend is null or dateend >= '2020-10-01') and datebegin<'2021-01-01'

--вывести данные о пациентах, которых лечит определенный врач с одинаковыми заболеваниями
select pa.firstname + ' ' + pa.lastname as fio, diagnosis, datebegin,dateend, do.firstname+' '+do.lastname as doctor, departmentname
from Patients pa, Patient2Therapy pa2th, Therapyes th, Doctor2Therapy do2th, Doctors do, Doctors2Departments do2de, Departments de
where pa.id=pa2th.patientid and pa2th.therapyid=th.id and th.id=do2th.therapyid and do2th.doctorid=do.id and do.id=do2de.doctorid and do2de.departmentid=de.id and
do.lastname='Мкртчан' and diagnosis in 
(SELECT diagnosis FROM Therapyes th, Doctor2Therapy do2th, Doctors do  WHERE th.id=do2th.therapyid and do2th.doctorid=do.id and do.lastname = 'Мкртчан' GROUP BY diagnosis HAVING COUNT(*)>1)
