drop database KAD_MyBase;
USE master;

CREATE database KAD_MyBase on primary
(name = 'KAD_MyBase_mdf', filename = 'D:\studing\4_semestr\Database\savePr\KAD_MyBase_mdf.mdf',
size = 10240Kb,maxsize=UNLIMITED, filegrowth=1024Kb),
( name = 'KAD_MyBase_ndf', filename = 'D:\studing\4_semestr\Database\savePr\KAD_MyBase_ndf.ndf', 
   size = 10240KB, maxsize=1Gb, filegrowth=25%),
filegroup FG
( name = 'KAD_MyBase_fg1_1', filename = 'D:\studing\4_semestr\Database\savePr\KAD_MyBase_fg1_1.ndf', 
   size = 10240Kb, maxsize=1Gb, filegrowth=25%),
( name = 'KAD_MyBase_fg1_2', filename = 'D:\studing\4_semestr\Database\savePr\KAD_MyBase_fg1_2.ndf', 
   size = 10240Kb, maxsize=1Gb, filegrowth=25%)
log on
( name = 'KAD_MyBase_log', filename='D:\studing\4_semestr\Database\savePr\KAD_MyBase_log.ldf',       
   size=10240Kb,  maxsize=2048Gb, filegrowth=10%)


use KAD_MyBase

create table Выдача_кредитов
(
	Номер_выдачи int primary key,
	Название_вида_кредита nvarchar(30) not null,
	Ставка nvarchar(10) not null,
	Сумма int not null,
	Дата_выдачи date,
	Дата_возврата date
) on FG;

create table Клиент
(
	Номер_выдачи int references Выдача_кредитов(Номер_выдачи),
	Название_фирмы_клиента nvarchar(40) primary key
)on FG;

create table Данные_клиента
(
	Название_фирмы_клиента nvarchar(40) primary key references Клиент(Название_фирмы_клиента),
	Вид_собственности nvarchar(10) not null,
	Адрес nvarchar(40) not null,
	Телефон nvarchar(15),
	Контактное_лицо nvarchar(40)
)on FG;

ALTER Table Данные_клиента ADD Доп_информация nvarchar(50);
ALTER TABLE Данные_клиента DROP COLUMN Доп_информация;

ALTER Table Данные_клиента ADD Пол nvarchar(1) default 'м' check (ПОЛ in('м', 'ж'));

ALTER TABLE Данные_клиента DROP CONSTRAINT DF_Данные_клиента_Пол;
ALTER TABLE Данные_клиента DROP COLUMN Пол;

INSERT into Данные_клиента (Название_фирмы_клиента, Вид_собственности, Адрес, Телефон, Контактное_лицо)
	Values('Фирма 1', 'OOO', 'ул.Ленина,5', '80293381168', 'Дмитрий Гайков'),
	('Фирма 2', 'ИП', 'ул.Шаранговича,66', '+375445635869', 'Кравченко Алексей'),
	('Фирма 3', 'ЗАО', 'ул.Свердлова, 13', '+375296161143', 'Адамович Алексей');

INSERT into Клиент(Название_фирмы_клиента, Номер_выдачи)
	Values('Фирма 1', 1),
	('Фирма 2', 2),
	('Фирма 3', 3);

INSERT INTO Выдача_кредитов(Номер_выдачи, Название_вида_кредита, Сумма, Ставка, Дата_выдачи, Дата_возврата)
VALUES
		(1, 'Кредит 1', 15000, '20%', '2023-09-11', '2024-09-11'),
		(2, 'Кредит 2', 25000, '30%', '2023-01-11', '2024-01-11'),
		(3, 'Кредит 3', 11000, '40%', '2023-11-22', '2026-12-13');

select *from Выдача_кредитов;
select Название_фирмы_клиента, Вид_собственности from Данные_клиента;
select count(*)from Выдача_кредитов;
update Выдача_кредитов set Ставка = '5%' where Номер_выдачи = 1;
select * from Выдача_кредитов;
