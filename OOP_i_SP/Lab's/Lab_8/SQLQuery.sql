use Airport;

create table CrewMembers
(
	ID int not null,
	FIO nvarchar(200) not null,
	Position nvarchar(100) not null,
	Age int not null,
	YearOfExp int not null
);

drop table CrewMembers;

select p.ID, p.Type, p.Model, p.CountSeat,
p.YearOfIssue, p.CapacityLoad, p.DateOfTO,
c.FIO, c.Position, c.Age, c.YearOfExp, i.Image
	from Planes p
	inner join CrewMembers c
	on p.ID = c.ID 
	inner join ImagePlane i
	on i.ID = c.ID


insert Planes(ID, Type, Model, CountSeat, YearOfIssue, CapacityLoad, DateOfTO)
values (1, '��������', '��-24', 55, 1998, 45, '2022-09-22'),
(2, '������������', 'Boeing', 312, 2008, 50, '2016-03-11'),
(3, '������������', 'Airbus', 588, 2018, 53, '2019-04-11');


insert CrewMembers(ID, FIO, Position,Age, YearOfExp)
values(1,'����� �.�.','��������',34,21),
(1,'�������� �.�.','�������� ���������',66,43),
(1,'�������� �.�.','����������',34,16),

(2,'�������� �.�.','��������',52,32),
(2,'�������� �.�.','�������� ���������',33,12),
(2,'���������� �.�.','����������',25,5),

(3,'������� �.�.','��������',64,41),
(3,'������ �.�.','�������� ���������',29,7),
(3,'��������� �.�.','����������',36,19);

insert ImagePlane(ID, Image)
VALUES(1,'D:\studing\4_semestr\OOP_i_SP\Lab''s\Lab_8\Photo\AN.jpg'),
(2,'D:\studing\4_semestr\OOP_i_SP\Lab''s\Lab_8\Photo\Boeing.jpg'),
(3,'D:\studing\4_semestr\OOP_i_SP\Lab''s\Lab_8\Photo\Airbus.jpg');

delete from CrewMembers
delete from Planes
delete from ImagePlane

