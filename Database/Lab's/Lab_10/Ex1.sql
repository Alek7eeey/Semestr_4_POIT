use UNIVER;

/* ex_1 */
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
--DROP INDEX #EXAMPLE_CL1 on #New_table
--
SELECT * FROM #New_table where ID between 150 and 200 order by ID;
checkpoint;  
DBCC DROPCLEANBUFFERS;  

/* ex_2 */
create table #table2
(
	id int identity(1,1),
	stroke varchar(15)
);

drop table #table2

declare @iteration int = 0;
while @iteration < 10000
begin
insert into #table2 values ('stroke')
set @iteration =@iteration + 1;
end

CREATE index #index2 on #table2(id,stroke);
DROP index [#table2].[#index2]
checkpoint;  
DBCC DROPCLEANBUFFERS;

select * from #table2
where #table2.id > 150 and #table2.id<456
order by id

/* ex_3 */
CREATE INDEX #index3 on #table2(id) INCLUDE (stroke);
DROP index [#table2].[#index3]
SELECT stroke from #table2 where id between 1 and 10;

/* ex_4 */
CREATE INDEX #index4 on #table2(id) where(id>=0 and id<=10)
drop INDEX #index4 on #table2

DBCC DROPCLEANBUFFERS;  --очистить буферный кэш
select stroke from #table2 
where id>=0 and id<=10

/* ex_5 */
Use TEMPDB
CREATE TABLE  #TASK5
(
INFO NVARCHAR (20),
ITERATOR INT IDENTITY(1,1),
INDEX_ INT 
)

DROP TABLE #TASK5

DECLARE @X INT =0;
WHILE @X <= 10000
BEGIN
INSERT INTO  #TASK5(INFO,INDEX_)
VALUES ('Строка' + CAST(@X AS NVARCHAR),FLOOR(20000*RAND()))
SET @X +=1;
END

CHECKPOINT;
DBCC DROPCLEANBUFFERS

CREATE INDEX #TASK5_KEY ON #TASK5(INDEX_)
DROP INDEX #TASK5_KEY ON #TASK5

SELECT NAME [Индекс], AVG_FRAGMENTATION_IN_PERCENT [Фрагментация (%)] 
FROM SYS.DM_DB_INDEX_PHYSICAL_STATS(DB_ID(N'TEMPDB'),
OBJECT_ID(N'#TASK5'), NULL, NULL, NULL) SS
JOIN SYS.INDEXES II ON SS.OBJECT_ID = II.OBJECT_ID
AND SS.INDEX_ID = II.INDEX_ID WHERE NAME IS NOT NULL; 

INSERT TOP(10000) #TASK5(INDEX_ ,INFO) SELECT INDEX_, INFO FROM #TASK5

ALTER INDEX #TASK5_KEY ON #TASK5 REORGANIZE
ALTER INDEX #TASK5_KEY ON #TASK5 REBUILD WITH (ONLINE = OFF)

/* ex_6 */
CREATE TABLE  #TASK6
(
INFO NVARCHAR (20),
ITERATOR INT IDENTITY(1,1),
INDEX_ INT 
)

DECLARE @X INT =0;
WHILE @X <= 100000
BEGIN
INSERT INTO  #TASK6(INFO,INDEX_)
VALUES ('СТРОКА' + CAST(@X AS NVARCHAR),FLOOR(20000*RAND()))
SET @X +=1;
END


CREATE INDEX #TASK6_TKEY ON #TASK6(INDEX_) WITH FILLFACTOR = 65

INSERT TOP(100) PERCENT #TASK6(INDEX_, INFO)
SELECT INDEX_, INFO FROM #TASK6

SELECT NAME [Индекс], AVG_FRAGMENTATION_IN_PERCENT [Фрагментация (%)]
        FROM SYS.DM_DB_INDEX_PHYSICAL_STATS(DB_ID(N'TEMPDB'),
        OBJECT_ID(N'#TASK5'), NULL, NULL, NULL) SS
        JOIN SYS.INDEXES II ON SS.OBJECT_ID = II.OBJECT_ID AND SS.INDEX_ID = II.INDEX_ID 
		WHERE NAME IS NOT NULL;

		DROP INDEX #TASK6_TKEY ON #TASK6