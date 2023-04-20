use UNIVER;

/* ex_1 */
DECLARE discpipline CURSOR for select SUBJECT.SUBJECT_NAME from SUBJECT where SUBJECT.PULPIT like 'ИСиТ';
--deallocate  discpipline;

DECLARE @subject char(35), @subjects char(500) = '';
OPEN discpipline;
FETCH discpipline into @subject;
print 'Дисциплины кафедры ИСиТ';
while @@FETCH_STATUS = 0
	begin
		set @subjects = RTRIM(@subject) +', ' +  @subjects;
		FETCH  discpipline into @subject;
	end;
	print @subjects;
CLOSE discpipline;

/* ex_2 */
DECLARE Puplit_cursor CURSOR GLOBAL for select PULPIT.FACULTY from PULPIT where PULPIT.PULPIT = 'ИСиТ';
--deallocate Puplit_cursor;
DECLARE @pupl char(50), @pupls char(100) ='';
OPEN Puplit_cursor;
print 'Факультеты ИСиТ: ';
FETCH  Puplit_cursor into @pupl;
	set @pupls ='1. ' + RTRIM(@pupl);	
	print @pupls;
CLOSE Puplit_cursor;

go
DECLARE @pupl char(50), @pupls char(100) ='';
OPEN Puplit_cursor;
FETCH  Puplit_cursor into @pupl;
	set @pupls ='2. ' + RTRIM(@pupl);	
	print @pupls;
CLOSE Puplit_cursor

/* ex_3 */
INSERT Into AUDITORIUM values('301-1','ЛБ-К','15','301-1');
DECLARE Auditorium_local_static CURSOR  STATIC for select AUDITORIUM,AUDITORIUM_CAPACITY from AUDITORIUM where  AUDITORIUM_TYPE = 'ЛБ-К';

DECLARE @q int = 0, @auditorium char(10), @iter int = 1;
open Auditorium_local_static;
print 'Количество строк: ' + cast(@@CURSOR_ROWS as varchar(5));
DELETE AUDITORIUM where AUDITORIUM ='301-1';
FETCH Auditorium_local_static into @auditorium, @q;
while @@FETCH_STATUS = 0
	begin
		print cast(@iter as varchar(5)) + '. Аудитория ' + rtrim(@auditorium) +': ' + cast(@q as varchar(5)) + ' мест' ;
		set @iter += 1;
		FETCH Auditorium_local_static into @auditorium, @q;
	end;
CLOSE Auditorium_local_static;

go
INSERT Into AUDITORIUM values('301-1','ЛБ-К','15','301-1');
DECLARE Auditorium_local_dynamic CURSOR  DYNAMIC for select AUDITORIUM,AUDITORIUM_CAPACITY from AUDITORIUM where  AUDITORIUM_TYPE = 'ЛБ-К';
DECLARE @q int = 0, @auditorium char(10), @iter int = 1;
open Auditorium_local_dynamic;
print 'Количество строк: ' + cast(@@CURSOR_ROWS as varchar(5));
DELETE AUDITORIUM where AUDITORIUM ='301-1';
FETCH Auditorium_local_dynamic into @auditorium, @q;
while @@FETCH_STATUS = 0
	begin
		print cast(@iter as varchar(5)) + '. Аудитория ' + rtrim(@auditorium) +': ' + cast(@q as varchar(5)) + ' мест' ;
		set @iter += 1;
		FETCH Auditorium_local_dynamic into @auditorium, @q;
	end;
CLOSE Auditorium_local_dynamic;

/* ex_4 */
DECLARE @number varchar(100), @sub varchar(10), @idstudent varchar(6), @pdate varchar (11), @note varchar (2);
DECLARE PROGRESS_CURSOR_SCROLL CURSOR LOCAL DYNAMIC SCROLL
	for select ROW_NUMBER() over (order by IDSTUDENT) Номер,
	* from PROGRESS;

OPEN PROGRESS_CURSOR_SCROLL
FETCH PROGRESS_CURSOR_SCROLL into @number, @sub ,@idstudent ,@pdate,@note;
print 'Первая выбранная строка: ' + CHAR(10) +
'Номер записи: '+ rtrim(@number)  +
'. Дисциплина: '+ rtrim(@sub) +
'. ID студента: ' + rtrim(@idstudent) +
'. Дата экзамена: '  + rtrim(@pdate) + 
'. Оценка: ' + rtrim(@note);

FETCH LAST from PROGRESS_CURSOR_SCROLL into @number, @sub ,@idstudent ,@pdate,@note;
print 'Последняя строка: ' + CHAR(10) +
'Номер записи: '+ rtrim(@number)  +
'. Дисциплина: '+ rtrim(@sub) +
'. ID студента: ' + rtrim(@idstudent) +
'. Дата экзамена: '  + rtrim(@pdate) + 
'. Оценка: ' + rtrim(@note);

FETCH RELATIVE -1  from PROGRESS_CURSOR_SCROLL into @number, @sub ,@idstudent ,@pdate,@note;
print 'Первая до предыдущей строка: ' + CHAR(10) +
'Номер записи: '+ rtrim(@number)  +
'. Дисциплина: '+ rtrim(@sub) +
'. ID студента: ' + rtrim(@idstudent) +
'. Дата экзамена: '  + rtrim(@pdate) + 
'. Оценка: ' + rtrim(@note);

FETCH ABSOLUTE 2  from PROGRESS_CURSOR_SCROLL into @number, @sub ,@idstudent ,@pdate,@note;
print 'Вторая с начала строка: ' + CHAR(10) +
'Номер записи: '+ rtrim(@number)  +
'. Дисциплина: '+ rtrim(@sub) +
'. ID студента: ' + rtrim(@idstudent) +
'. Дата экзамена: '  + rtrim(@pdate) + 
'. Оценка: ' + rtrim(@note);

FETCH RELATIVE 1  from PROGRESS_CURSOR_SCROLL into @number, @sub ,@idstudent ,@pdate,@note;
print 'Первая после предыдущей строка: ' + CHAR(10) +
'Номер записи: '+ rtrim(@number)  +
'. Дисциплина: '+ rtrim(@sub) +
'. ID студента: ' + rtrim(@idstudent) +
'. Дата экзамена: '  + rtrim(@pdate) + 
'. Оценка: ' + rtrim(@note);

FETCH ABSOLUTE -3  from PROGRESS_CURSOR_SCROLL into @number, @sub ,@idstudent ,@pdate,@note;
print 'Третья с конца строка: ' + CHAR(10) +
'Номер записи: '+ rtrim(@number)  +
'. Дисциплина: '+ rtrim(@sub) +
'. ID студента: ' + rtrim(@idstudent) +
'. Дата экзамена: '  + rtrim(@pdate) + 
'. Оценка: ' + rtrim(@note);
close PROGRESS_CURSOR_SCROLL

/* ex_5 */
use master;
CREATE TABLE #EXAMPLE
(
	ID int identity(1,1),
	WORD varchar(100)
);

INSERT INTO #EXAMPLE values ('Яблоко'),('Груша'),('Апельсин'),('Мандарин'),('Вишня'),('Клубника'),('Клюква');


DECLARE @id varchar(10), @word varchar(100);
DECLARE CURRENT_OF_CURSROR CURSOR LOCAL DYNAMIC
	for SELECT * from #EXAMPLE FOR UPDATE;
OPEN CURRENT_OF_CURSROR
fetch CURRENT_OF_CURSROR into @id,@word;
print @id + '-' + @word;
DELETE #EXAMPLE where CURRENT OF CURRENT_OF_CURSROR;
fetch  CURRENT_OF_CURSROR into @id,@word;
UPDATE #EXAMPLE set WORD += ' - updated' where CURRENT OF CURRENT_OF_CURSROR;
print @id + '-' + @word;
close CURRENT_OF_CURSROR;

OPEN CURRENT_OF_CURSROR
while(@@FETCH_STATUS = 0)
	begin
		fetch CURRENT_OF_CURSROR into @id,@word;
		print @id + '-' + @word;
	end;
close CURRENT_OF_CURSROR;

DROP TABLE #EXAMPLE;

/* ex_6 */
use UNIVER;
DECLARE newCursor cursor local dynamic 
						for SELECT STUDENT.NAME, GROUPS.PROFESSION, PROGRESS.NOTE
						from STUDENT inner join GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP inner join
						PROGRESS on PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT;

DECLARE @name varchar(300), @profession varchar(300), @mark varchar(2), @list varchar(400);

OPEN newCursor;
fetch newCursor into @name,@profession,@mark;
if(@mark < 4)
			begin
				DELETE PROGRESS where CURRENT OF newCursor;
			end;
print @name + ' - '+ @profession + ' - ' + @mark ;
While (@@FETCH_STATUS = 0)
	begin
		fetch newCursor into @name,@profession,@mark;
		print @name + ' ▬ '+ @profession + ' ▬ ' + @mark ;
		if(@mark < 4)
			begin
				DELETE PROGRESS where CURRENT OF newCursor;
			end;
	end;
CLOSE newCursor;
						