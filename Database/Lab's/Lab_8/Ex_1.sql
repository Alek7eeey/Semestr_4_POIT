use UNIVER;

/* ex_1 */

Create VIEW[Преподаватель]
as select GENDER[Пол], PULPIT[Кафедра], TEACHER[Код], TEACHER_NAME[Имя]
	from TEACHER;

drop view[Преподаватель];
select * from Преподаватель;

/* ex_2 */

Create VIEW[Количество_кафедр]
as select FACULTY_NAME[Факультет], COUNT(PULPIT)[Количество кафедр]
		from FACULTY inner join PULPIT
		on FACULTY.FACULTY = PULPIT.FACULTY 
		group by FACULTY_NAME;

drop view[Количество_кафедр];
select * from Количество_кафедр;

/* ex_3 */

create VIEW[Аудитории]
as select AUDITORIUM[Номер_аудитории], AUDITORIUM_TYPE[Название]
from AUDITORIUM 
where AUDITORIUM.AUDITORIUM_TYPE like 'ЛК%'

drop view[Аудитории];
select * from Аудитории;


/* ex_4 */
create VIEW Лекционные_аудитории(Номер_аудитории,Название)
as select AUDITORIUM, AUDITORIUM_TYPE
from AUDITORIUM 
where AUDITORIUM.AUDITORIUM_TYPE like 'ЛК%' WITH CHECK OPTION

insert Лекционные_аудитории values('934-1', 'ЛК');

drop view[Лекционные_аудитории];
select * from Лекционные_аудитории;

/* ex_5 */
create VIEW Дисциплины(код, наименование_дисциплины, код_кафедры)
as select TOP 100 SUBJECT, SUBJECT_NAME, PULPIT
from SUBJECT order by SUBJECT.SUBJECT_NAME

drop view[Дисциплины];
select * from Дисциплины;

/* ex_6 */

ALTER VIEW [Количество_кафедр] with SCHEMABINDING
as select		fclt.FACULTY_NAME		[Факультет],
				count(plpt.PULPIT)		[Количество_кафедр]
				from dbo.FACULTY fclt inner join dbo.PULPIT plpt
				on fclt.FACULTY = plpt.FACULTY 
				group by FACULTY_NAME;


drop view[Количество_кафедр];	
select * from Количество_кафедр;