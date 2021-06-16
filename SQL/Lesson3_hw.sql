DROP TABLE Patients

CREATE TABLE Patients (
	fio NVARCHAR(30),
	phone VARCHAR(13),
	birthday date,
	diagnosis NVARCHAR(30),
	datebegin date,
	dateend date,
	departmentname NVARCHAR(20),
	doctor NVARCHAR(30)
)

DELETE FROM Patients

INSERT Patients VALUES 
('Вася', '+380951111111','1978-02-23','ОРЗ','2020-12-12',NULL,'Терапия','Иванов'),
('Петя', '+380951122111','1988-11-20','ОРЗ','2020-11-21','2020-12-25','Терапия','Иванов'),
('Юра', '+380951133311','1978-06-22','Грип','2020-10-05','2021-01-05','Терапия','Иванов'),
('Рита', '+380951114671','1978-08-13','Апендицит','2020-11-01',NULL,'Хирургия','Сидоров'),
('Света', '+380952311111','1978-05-21','Перелом','2020-01-10',NULL,'Хирургия','Сидоров'),
('Ира', '+380951199111','1978-12-11','Гипертония','2020-11-07','2020-01-15','Терапия','Куликович'),
('Коля', '+380957891111','1978-10-05','Гипертония','2020-12-01',NULL,'Терапия','Куликович'),
('Саша', '+380951111158','1978-04-05','Мигрень','2020-10-17','2021-01-19','Неврология','Федоров'),
('Рома', '+380951111122','1978-02-11','Ущемление','2021-01-12',NULL,'Неврология','Федоров'),
('Гоша', '+380951114567','1978-01-12','Порез','2020-07-16','2020-10-11','Травматология','Черный')

--вывести информацию обо всех пациентах, находящихся в больнице;

SELECT * FROM Patients

--показать данные о пациентах, которые лежат в определенном отделении;

SELECT * FROM Patients WHERE departmentname='Терапия'

--вывести названия всех отделений больницы;

SELECT DISTINCT departmentname FROM Patients 

--получить данные о пациентах, которые лежат в больнице больше месяца, отсортировав их по возрастанию даты поступления;

SELECT * FROM Patients WHERE dateend IS NULL AND DATEDIFF(month, datebegin, GETDATE()) > 1

--вывести информацию о пациентах, которые были выписаны в прошлом месяце 

SELECT * FROM Patients WHERE  DATEDIFF(month,dateend,GETDATE()) = 1 

--показать информацию о пациентах, которые лежали в больнице с октября по декабрь прошлого года в определенном отделении;

SELECT * FROM Patients WHERE datebegin < '2021-01-01' AND (dateend >= '2020-10-01' OR dateend IS NULL)

--вывести информацию о самом молодом пациенте и его возраст

SELECT *, DATEDIFF(year,birthday, GETDATE()) as yearsold FROM Patients WHERE birthday = (SELECT MAX(birthday) FROM Patients)

--получить информацию о пациентах, которые лежат в любых трех отделениях;

SELECT * FROM Patients WHERE departmentname IN ('Терапия', 'Хирургия', 'Неврология')

--показать всех пациентов, фамилия которых начинается на букву Р;

SELECT * FROM Patients WHERE fio LIKE 'Р%'

--вывести данные о пациентах, которых лечит определенный врач с одинаковыми заболеваниями;

SELECT * FROM Patients WHERE doctor = 'Иванов' AND diagnosis = 'ОРЗ' 

SELECT * FROM Patients WHERE doctor = 'Иванов' AND diagnosis IN (SELECT diagnosis FROM Patients  WHERE doctor = 'Иванов' GROUP BY diagnosis HAVING COUNT(*)>1)

--получить данные о пациентах, пользующихся услугами определенного мобильного оператора;

SELECT * FROM Patients WHERE phone LIKE '+38095%'

--переименовать название определенного отделения;

UPDATE Patients SET departmentname = 'Терапия+' WHERE departmentname = 'Терапия'

--удалить всех пациентов, которые были выписаны больше чем полгода назад.

DELETE FROM Patients WHERE DATEDIFF(month, dateend, GETDATE()) > 6