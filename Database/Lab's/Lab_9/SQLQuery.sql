use UNIVER;

/* ex_1 */
DECLARE @c char = 'A', 
		@vc varchar(4) = 'BSTU',
		@dt datetime,
		@t time(0),
		@i int,
		@si smallint,
		@ti tinyint,
		@num numeric(12,5)

SET @i = (select sum(NOTE) from PROGRESS);
SET @dt = Getdate();
SET @t = '11:34:45';

SELECT @si = min(NOTE), @num = avg(NOTE) from PROGRESS;
set @ti = @i + @si; 

print 'Переменная c = ' + @c;
print 'Переменная vc = ' + @vc;
print 'Переменная dt = ' + cast(@dt as varchar(13));
print 'Переменная t = ' + cast(@t as varchar(13));

select @i, @si, @ti, @num

/* ex_2 */
DECLARE @capacity int = (select cast(sum(AUDITORIUM_CAPACITY) as int) from AUDITORIUM),
		@q int = (select cast(count(*) as int) from AUDITORIUM),
		@avg int = (select cast(avg(AUDITORIUM_CAPACITY) as int) from AUDITORIUM);

DECLARE	@lessavg int =  (select cast(count(*) as int) from AUDITORIUM where AUDITORIUM_CAPACITY < @avg);
DECLARE	@percent float =  cast(cast(@lessavg as float) / cast(@q as float) * 100  as float);
		
	IF @capacity > 200
		begin 
		SELECT @q 'Количество аудиторий',			@avg 'Среднее количество мест',
			   @lessavg  'Количество аудиторий < среднего',		cast(@percent as varchar) + '%'   'Процент аудиторий, которые < среднего'
		end
	ELSE IF @capacity < 200
		begin
		PRINT @capacity
		end;

/* ex_3 */
print 'число обработанных строк = ' + cast(@@ROWCOUNT as varchar(10));
print 'версия SQL Server = ' + cast(@@VERSION as varchar(300));
print 'системный идентификатор процесса, назначенный сервером текущему подключению = ' + cast(@@SPID as varchar(300));
print 'код последней ошибки = ' + cast(@@ERROR as varchar(30));
print 'имя сервера = ' + cast(@@SERVERNAME as varchar(30));
print 'уровень вложенности транзакции = ' + cast(@@trancount as varchar(30));
print 'проверка результата считывания строк результирующего набора = ' + cast(@@FETCH_STATUS as varchar(30));
print 'уровень вложенности текущей процедуры = ' + cast(@@NESTLEVEL as varchar(30));

/* ex_4 */
/*---------------------*/
DECLARE @t2 int = 45, 
		@z float(10),
		@x int = 52;

if @t2 > @x
begin
set @z = power(sin(@t2),2);
print 'Z = '+cast(@z as varchar(15));
end

else if @t2 < @x
begin
set @z = 4 * (@t2 + @x);
print 'Z = '+cast(@z as varchar(15));
end

else if @t2 = @x
begin
set @z = 1 - exp(@x-2);
print 'Z = '+cast(@z as varchar(15));
end

/*---------------------*/
DECLARE @full_name varchar(100) = 'Кравченко Алексей Дмитриевич';

set @full_name = (select substring(@full_name, 1, charindex(' ', @full_name)) +
								 substring(@full_name, charindex(' ', @full_name)+1, 1) + '.' +
								 substring(@full_name, charindex(' ', @full_name, charindex(' ', @full_name)+1)+1,1)+'.');
print @full_name;

/*---------------------*/
DECLARE @next_month int = MONTH(GETDATE()) + 1;
select * from STUDENT where MONTH(STUDENT.BDAY) = @next_month;

/*---------------------*/
select CASE 
							when DATEPART(weekday,PDATE) = 1 then 'Понедельник'
							when DATEPART(weekday,PDATE) = 2 then 'Вторник'
							when DATEPART(weekday,PDATE) = 3 then 'Среда'
							when DATEPART(weekday,PDATE) = 4 then 'Четверг'
							when DATEPART(weekday,PDATE) = 5 then 'Пятница'
							when DATEPART(weekday,PDATE) = 6 then 'Суббота'
							when DATEPART(weekday,PDATE) = 7 then 'Воскресенье'
						end
from PROGRESS where SUBJECT = 'СУБД'

/* ex_5 */
DECLARE @averageMark float(4), @coun int;

set @averageMark = (select avg(NOTE) from PROGRESS);
set @coun = (select count(NOTE) from PROGRESS);

if @averageMark < 5
begin
print 'Средние оценки меньше 5'
end

else if @averageMark > 5
begin
print 'Средние оценки больше 5'
end

print 'Количество оценок = '+ cast(@coun as varchar);

/* ex_6 */
select	PROGRESS.IDSTUDENT,PROGRESS.SUBJECT, case	
			when AVG(PROGRESS.NOTE) = 4 then 'Оценка ниже 4'
			when AVG(PROGRESS.NOTE)	between 5 and 6 then 'Оценка удовлетворительно'
			when AVG(PROGRESS.NOTE) between 7 and 8 then 'Оценка хорошо'
			when AVG(PROGRESS.NOTE) between 9 and 10 then 'Оценка отлично'
			end

from PROGRESS
group by idstudent, SUBJECT

/* ex_7 */
DROP TABLE #TEMP1;
CREATE TABLE #TEMP1
		(
			ID int identity(1,1),
			RANDOM_NUMBER int,
		);

DECLARE  @iter int = 0;
WHILE @iter < 10
	begin
	INSERT #TEMP1(RANDOM_NUMBER)
			values(rand() * 1000);
	SET @iter = @iter + 1;
	end
SELECT * from #TEMP1;

/* ex_8 */
DECLARE @par int = 1
print @par+1
print @par+2
RETURN
print @par+3

/* ex_9 */
declare @dat date = '1995-03-11';
begin try
Select * from STUDENT where STUDENT.BDAY =  @dat
end try
begin catch
print 'Код последней ошибки: ' + ERROR_NUMBER()
print 'Сообщение об ошибке: ' + ERROR_MESSAGE()
print 'Номер строки с ошибкой: ' + ERROR_LINE()
print 'Имя процедуры или NULL: ' + ERROR_PROCEDURE()
print 'Уровень серьезности ошибки: ' + ERROR_SEVERITY()
print 'Метка ошибки: ' + ERROR_STATE()
end catch