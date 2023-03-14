use UNIVER;

/*ex1*/
select PULPIT.PULPIT_NAME 
from FACULTY, PULPIT
	where FACULTY.FACULTY = PULPIT.FACULTY 
	and
	FACULTY.FACULTY in (select PROFESSION.FACULTY from PROFESSION
									where PROFESSION.PROFESSION_NAME like N'%технология%' or
										  PROFESSION.PROFESSION_NAME like N'%технологии%')

select * from PROFESSION 
where PROFESSION.PROFESSION_NAME like N'%технология%' or
										  PROFESSION.PROFESSION_NAME like N'%технологии%'

/*ex2*/
select PULPIT.PULPIT_NAME 
from FACULTY inner JOIN PULPIT
	on FACULTY.FACULTY = PULPIT.FACULTY 
	where
	FACULTY.FACULTY in (select PROFESSION.FACULTY from PROFESSION
									where PROFESSION.PROFESSION_NAME like N'%технология%' or
										  PROFESSION.PROFESSION_NAME like N'%технологии%')

/*select * 
from PROFESSION 
where PROFESSION.PROFESSION_NAME like N'%технология%' or
										  PROFESSION.PROFESSION_NAME like N'%технологии%'*/

/*ex3*/
select DISTINCT PULPIT.PULPIT_NAME 
from FACULTY inner JOIN PULPIT
	on FACULTY.FACULTY = PULPIT.FACULTY  inner JOIN PROFESSION
	on FACULTY.FACULTY = PROFESSION.FACULTY
	Where (PROFESSION.PROFESSION_NAME like N'%технология%' or
										  PROFESSION.PROFESSION_NAME like N'%технологии%')

/*ex4*/
select distinct a.AUDITORIUM_TYPE, AUDITORIUM_CAPACITY from
	AUDITORIUM as a
	where a.AUDITORIUM_CAPACITY = (select top(1) aa.AUDITORIUM_CAPACITY from AUDITORIUM as aa
								   where aa.AUDITORIUM_TYPE = a.AUDITORIUM_TYPE 
								   order by aa.AUDITORIUM_CAPACITY desc) order by a.AUDITORIUM_CAPACITY desc
/*ex5*/
select FACULTY.FACULTY_NAME
FROM FACULTY
WHERE not exists (select *  from PULPIT
where FACULTY.FACULTY = PULPIT.FACULTY)

/*ex6*/
select top (1)
(select avg(NOTE)from PROGRESS
	where SUBJECT like 'ОАиП')[ОАиП],
(select avg(NOTE)from PROGRESS
	where SUBJECT like 'БД')[БД],
(select avg(NOTE)from PROGRESS
	where SUBJECT like 'СУБД')[СУБД]
From PROGRESS

/*ex7*/
select [SUBJECT], IDSTUDENT , NOTE 
from PROGRESS as a
	where NOTE >= all (select NOTE from PROGRESS
					   where [SUBJECT] = a.[SUBJECT] )
/*ex8*/
select s.[NAME],sub.SUBJECT_NAME, p.NOTE 
from
	(STUDENT as s join PROGRESS as p on s.IDSTUDENT = p.IDSTUDENT) join [SUBJECT] as sub on sub.SUBJECT = p.SUBJECT 
		where p.NOTE >= any (select p2.NOTE from PROGRESS as p2 where p2.NOTE >= 6) Order by NOTE desc