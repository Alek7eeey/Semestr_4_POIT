use EXAM;

create table ����������
(
	id int identity(1,1) primary key,
	FIO nvarchar(200) not null,
	DateNaima Date not null,
	Post nvarchar(100) not null,
	Deparment nvarchar(100) not null,
	Salary money default 100
)

INSERT INTO ���������� (FIO, DateNaima, Post, Deparment, Salary)
VALUES
    ('������ ���� ��������', '1980-01-01', '��������', '����� ������', 50000),
    ('������ ���� ��������', '1985-02-15', '��������', '����� ����������', 60000),
    ('�������� ���� ���������', '1990-06-30', '���������', '���������� �����', 45000);

create table ������
(
	id int identity(1,1) primary key,
	id���������� int foreign key references ����������(id),
	DateStart Date not null,
	DateEnd Date not null,
	Typev nvarchar(100) not null,
	Oplata money
)

INSERT INTO ������ (id����������, DateStart, DateEnd, Typev, Oplata)
VALUES
    (1, '2023-07-01', '2023-07-15', '��������', 20000),
    (2, '2023-08-01', '2023-08-07', '��������������', 15000),
    (3, '2023-09-01', '2023-09-10', '��������', NULL);


go
create procedure timeProcedure @nameOtd varchar(100)
as
begin
	
	select ����������.FIO, ����������.Deparment, sum(������.Oplata) from ���������� inner join ������
	on ������.id���������� = ����������.id
	group by ����������.FIO, ����������.Deparment;
	return 0;
end

go;

EXEC timeProcedure @nameOtd = '��������'