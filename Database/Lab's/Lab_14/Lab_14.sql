﻿use UNIVER;

/*--------------------------------*/
go
CREATE FUNCTION countTeacher(@p VARCHAR(20)) 
RETURNS TABLE 
AS
 RETURN SELECT COUNT(TEACHER.TEACHER) AS teacher_count FROM TEACHER WHERE TEACHER.PULPIT = @p;
GO


select * from countTeacher('ИСиТ');

/*-----------------------------*/

go
create function changePol() returns table
AS
 return select t.TEACHER, t.TEACHER_NAME, CASE
			WHEN GENDER = 'м' THEN 'ж'
			WHEN GENDER = 'ж' THEN 'м'
			ELSE GENDER
		END AS GENDER from TEACHER t
go


select * from changePol();

--ЗАДАНИЕ 1
go 
create function COUNT_STUDENTS(@faculty varchar(20)) returns int
as begin 
declare @ret int = 0;
set @ret = (select count(IDSTUDENT) from 
			GROUPS inner join FACULTY 
			on GROUPS.FACULTY = FACULTY.FACULTY inner join STUDENT
			on STUDENT.IDGROUP = GROUPS.IDGROUP where GROUPS.FACULTY = @faculty);
return @ret;
end;

--DROP FUNCTION COUNT_STUDENTS;

declare @faculty_name char(10) = 'ХТиТ';
declare @f_result int = dbo.COUNT_STUDENTS(@faculty_name);
print 'Количество студентов факультета ' + rtrim(@faculty_name) + ': ' + cast(@f_result as varchar);


--ЗАДАНИЕ 2
go
create function FSUBJECTS(@p varchar(20)) returns varchar(300)
as begin
DECLARE Discipline CURSOR LOCAL for select [SUBJECT_NAME] from [SUBJECT] where [SUBJECT].PULPIT = @p;
DECLARE @subject varchar(60), @subject_ot varchar(300) ='';
OPEN Discipline;
FETCH Discipline into @subject;
while @@FETCH_STATUS = 0
	begin
		set @subject_ot = RTRIM(@subject) +', ' +  @subject_ot;
		FETCH  Discipline into @subject;
	end;
CLOSE Discipline;
set @subject_ot = '•Дисциплины: ' + @subject_ot;
return @subject_ot;
end;

--DROP FUNCTION FSUBJECTS;

select PULPIT.PULPIT 'Кафедра', dbo.FSUBJECTS(PULPIT.PULPIT) 'Дисцплины кафедры' from PULPIT;


--ЗАДАНИЕ 3
go
create function FFACPUL(@faculty varchar(20), @pulpit varchar(20)) returns table
as return 
	select FACULTY.FACULTY,PULPIT.PULPIT from
		FACULTY left outer join PULPIT
		on FACULTY.FACULTY = PULPIT.FACULTY
		where FACULTY.FACULTY = isnull(@faculty,FACULTY.FACULTY)and
			PULPIT.PULPIT = isnull(@pulpit,PULPIT.PULPIT);

--DROP FUNCTION FFACPUL;

select * from dbo.FFACPUL(NULL,NULL);
select * from dbo.FFACPUL('ТТЛП',NULL);
select * from dbo.FFACPUL(NULL,'ИСиТ');
select * from dbo.FFACPUL('ЛХ','ТиП');
select * from dbo.FFACPUL('ЛХ','ПИ');

--ЗАДАНИЕ 4
go
create function FTEACHER (@pulpit varchar(20)) returns int
as begin
		declare @result int = 0;
		set @result  = (select count(*) from
									TEACHER inner join PULPIT
									on TEACHER.PULPIT = PULPIT.PULPIT
									where PULPIT.PULPIT = isnull(@pulpit,PULPIT.PULPIT));
		return @result;
end;

--DROP FUNCTION FTEACHER;

select PULPIT, dbo.FTEACHER(PULPIT.PULPIT) 'Количество преподавателей ☺' from PULPIT;
select dbo.FTEACHER(NULL) 'Всего преподавателей';

--ЗАДАЧА 6
create function FACULTY_REPORT(@c int) returns @fr table
	                        ( [Факультет] varchar(50), [Количество кафедр] int, [Количество групп]  int, 
	                                                                 [Количество студентов] int, [Количество специальностей] int )
	as begin 
                 declare cc CURSOR static for 
	       select FACULTY from FACULTY 
                                                    where dbo.COUNT_STUDENTS(FACULTY, default) > @c; 
	       declare @f varchar(30);
	       open cc;  
                 fetch cc into @f;
	       while @@fetch_status = 0
	       begin
	            insert @fr values( @f,  (select count(PULPIT) from PULPIT where FACULTY = @f),
	            (select count(IDGROUP) from GROUPS where FACULTY = @f),   dbo.COUNT_STUDENTS(@f, default),
	            (select count(PROFESSION) from PROFESSION where FACULTY = @f)   ); 
	            fetch cc into @f;  
	       end;   
                 return; 
	end;


