use EXAM;

create table сотрудники
(
	id int identity(1,1) primary key,
	FIO nvarchar(200) not null,
	DateNaima Date not null,
	Post nvarchar(100) not null,
	Deparment nvarchar(100) not null,
	Salary money default 100
)

INSERT INTO Сотрудники (FIO, DateNaima, Post, Deparment, Salary)
VALUES
    ('Иванов Иван Иванович', '1980-01-01', 'Менеджер', 'Отдел продаж', 50000),
    ('Петров Петр Петрович', '1985-02-15', 'Аналитик', 'Отдел разработки', 60000),
    ('Сидорова Анна Сергеевна', '1990-06-30', 'Бухгалтер', 'Финансовый отдел', 45000);

create table отпуск
(
	id int identity(1,1) primary key,
	idСотрудника int foreign key references сотрудники(id),
	DateStart Date not null,
	DateEnd Date not null,
	Typev nvarchar(100) not null,
	Oplata money
)

INSERT INTO Отпуск (idСотрудника, DateStart, DateEnd, Typev, Oplata)
VALUES
    (1, '2023-07-01', '2023-07-15', 'Основной', 20000),
    (2, '2023-08-01', '2023-08-07', 'Дополнительный', 15000),
    (3, '2023-09-01', '2023-09-10', 'Основной', NULL);


go
create procedure timeProcedure @nameOtd varchar(100)
as
begin
	
	select сотрудники.FIO, сотрудники.Deparment, sum(отпуск.Oplata) from сотрудники inner join отпуск
	on отпуск.idСотрудника = сотрудники.id
	group by сотрудники.FIO, сотрудники.Deparment;
	return 0;
end

go;

EXEC timeProcedure @nameOtd = 'Аналитик'