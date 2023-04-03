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
values (1, 'Грузовой', 'АН-24', 55, 1998, 45, '2022-09-22'),
(2, 'Пассажирский', 'Boeing', 312, 2008, 50, '2016-03-11'),
(3, 'Пассажирский', 'Airbus', 588, 2018, 53, '2019-04-11');


insert CrewMembers(ID, FIO, Position,Age, YearOfExp)
values(1,'Бирюк А.М.','Командир',34,21),
(1,'Картузов К.М.','Помощник командира',66,43),
(1,'Ахарцова В.О.','Стюардесса',34,16),

(2,'Краченко А.Д.','Командир',52,32),
(2,'Адамович А.Д.','Помощник командира',33,12),
(2,'Гарлукович Д.М.','Стюардесса',25,5),

(3,'Новиков Р.В.','Командир',64,41),
(3,'Гайков Д.В.','Помощник командира',29,7),
(3,'Авсюкевич П.В.','Стюардесса',36,19);

insert ImagePlane(ID, Image)
VALUES(1,'D:\studing\4_semestr\OOP_i_SP\Lab''s\Lab_8\Photo\AN.jpg'),
(2,'D:\studing\4_semestr\OOP_i_SP\Lab''s\Lab_8\Photo\Boeing.jpg'),
(3,'D:\studing\4_semestr\OOP_i_SP\Lab''s\Lab_8\Photo\Airbus.jpg');

delete from CrewMembers
delete from Planes
delete from ImagePlane

