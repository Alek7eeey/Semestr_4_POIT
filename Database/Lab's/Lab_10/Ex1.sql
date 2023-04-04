use UNIVER;
exec sp_helpindex 'AUDITORIUM' 
exec sp_helpindex 'AUDITORIUM_TYPE'
exec sp_helpindex 'FACULTY'
exec sp_helpindex 'GROUPS'
exec sp_helpindex 'PROFESSION'
exec sp_helpindex 'PROGRESS'
exec sp_helpindex 'PULPIT'
exec sp_helpindex 'STUDENT'
exec sp_helpindex 'SUBJECT'
exec sp_helpindex 'TEACHER'

CREATE TABLE #New_table
(	
	ID int identity(1,1),
	STRING varchar(13)
)
set nocount on;
DECLARE @iter int = 0;
WHILE @iter < 10000
	begin
	INSERT INTO #New_table values (REPLICATE('строка ',2));
	SET @iter = @iter + 1;
	end;

DROP TABLE #New_table

 checkpoint;  --фиксация БД
 DBCC DROPCLEANBUFFERS;  --очистить буферный кэш
CREATE CLUSTERED INDEX #EXAMPLE_CL1 on #New_table(ID asc);
DROP INDEX [#EXAMPLE].[#EXAMPLE_CL1]
--
SELECT * FROM #New_table where ID between 150 and 200 order by ID;
checkpoint;  
DBCC DROPCLEANBUFFERS;  