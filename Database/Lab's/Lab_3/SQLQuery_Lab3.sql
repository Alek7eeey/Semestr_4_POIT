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

create table ������_��������
(
	�����_������ int primary key,
	��������_����_������� nvarchar(30) not null,
	������ nvarchar(10) not null,
	����� int not null,
	����_������ date,
	����_�������� date
) on FG;

create table ������
(
	�����_������ int references ������_��������(�����_������),
	��������_�����_������� nvarchar(40) primary key
)on FG;

create table ������_�������
(
	��������_�����_������� nvarchar(40) primary key references ������(��������_�����_�������),
	���_������������� nvarchar(10) not null,
	����� nvarchar(40) not null,
	������� nvarchar(15),
	����������_���� nvarchar(40)
)on FG;

ALTER Table ������_������� ADD ���_���������� nvarchar(50);
ALTER TABLE ������_������� DROP COLUMN ���_����������;

ALTER Table ������_������� ADD ��� nvarchar(1) default '�' check (��� in('�', '�'));

ALTER TABLE ������_������� DROP CONSTRAINT DF_������_�������_���;
ALTER TABLE ������_������� DROP COLUMN ���;

INSERT into ������_������� (��������_�����_�������, ���_�������������, �����, �������, ����������_����)
	Values('����� 1', 'OOO', '��.������,5', '80293381168', '������� ������'),
	('����� 2', '��', '��.�����������,66', '+375445635869', '��������� �������'),
	('����� 3', '���', '��.���������, 13', '+375296161143', '�������� �������');

INSERT into ������(��������_�����_�������, �����_������)
	Values('����� 1', 1),
	('����� 2', 2),
	('����� 3', 3);

INSERT INTO ������_��������(�����_������, ��������_����_�������, �����, ������, ����_������, ����_��������)
VALUES
		(1, '������ 1', 15000, '20%', '2023-09-11', '2024-09-11'),
		(2, '������ 2', 25000, '30%', '2023-01-11', '2024-01-11'),
		(3, '������ 3', 11000, '40%', '2023-11-22', '2026-12-13');

select *from ������_��������;
select ��������_�����_�������, ���_������������� from ������_�������;
select count(*)from ������_��������;
update ������_�������� set ������ = '5%' where �����_������ = 1;
select * from ������_��������;
