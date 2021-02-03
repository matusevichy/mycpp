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
('����', '+380951111111','1978-02-23','���','2020-12-12',NULL,'�������','������'),
('����', '+380951122111','1988-11-20','���','2020-11-21','2020-12-25','�������','������'),
('���', '+380951133311','1978-06-22','����','2020-10-05','2021-01-05','�������','������'),
('����', '+380951114671','1978-08-13','���������','2020-11-01',NULL,'��������','�������'),
('�����', '+380952311111','1978-05-21','�������','2020-01-10',NULL,'��������','�������'),
('���', '+380951199111','1978-12-11','����������','2020-11-07','2020-01-15','�������','���������'),
('����', '+380957891111','1978-10-05','����������','2020-12-01',NULL,'�������','���������'),
('����', '+380951111158','1978-04-05','�������','2020-10-17','2021-01-19','����������','�������'),
('����', '+380951111122','1978-02-11','���������','2021-01-12',NULL,'����������','�������'),
('����', '+380951114567','1978-01-12','�����','2020-07-16','2020-10-11','�������������','������')

--������� ���������� ��� ���� ���������, ����������� � ��������;

SELECT * FROM Patients

--�������� ������ � ���������, ������� ����� � ������������ ���������;

SELECT * FROM Patients WHERE departmentname='�������'

--������� �������� ���� ��������� ��������;

SELECT DISTINCT departmentname FROM Patients 

--�������� ������ � ���������, ������� ����� � �������� ������ ������, ������������ �� �� ����������� ���� �����������;

SELECT * FROM Patients WHERE dateend IS NULL AND DATEDIFF(month, datebegin, GETDATE()) > 1

--������� ���������� � ���������, ������� ���� �������� � ������� ������ 

SELECT * FROM Patients WHERE  DATEDIFF(month,dateend,GETDATE()) = 1 

--�������� ���������� � ���������, ������� ������ � �������� � ������� �� ������� �������� ���� � ������������ ���������;

SELECT * FROM Patients WHERE datebegin < '2021-01-01' AND (dateend >= '2020-10-01' OR dateend IS NULL)

--������� ���������� � ����� ������� �������� � ��� �������

SELECT *, DATEDIFF(year,birthday, GETDATE()) as yearsold FROM Patients WHERE birthday = (SELECT MAX(birthday) FROM Patients)

--�������� ���������� � ���������, ������� ����� � ����� ���� ����������;

SELECT * FROM Patients WHERE departmentname IN ('�������', '��������', '����������')

--�������� ���� ���������, ������� ������� ���������� �� ����� �;

SELECT * FROM Patients WHERE fio LIKE '�%'

--������� ������ � ���������, ������� ����� ������������ ���� � ����������� �������������;

SELECT * FROM Patients WHERE doctor = '������' AND diagnosis = '���' 

SELECT * FROM Patients WHERE doctor = '������' AND diagnosis IN (SELECT diagnosis FROM Patients  WHERE doctor = '������' GROUP BY diagnosis HAVING COUNT(*)>1)

--�������� ������ � ���������, ������������ �������� ������������� ���������� ���������;

SELECT * FROM Patients WHERE phone LIKE '+38095%'

--������������� �������� ������������� ���������;

UPDATE Patients SET departmentname = '�������+' WHERE departmentname = '�������'

--������� ���� ���������, ������� ���� �������� ������ ��� ������� �����.

DELETE FROM Patients WHERE DATEDIFF(month, dateend, GETDATE()) > 6