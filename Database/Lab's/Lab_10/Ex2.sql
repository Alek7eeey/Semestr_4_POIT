use KAD_MyBase;
--use TEMPDB;

/* ex_1 */
exec sp_helpindex 'Выдача_кредитов'
exec sp_helpindex 'Данные_клиента'
exec sp_helpindex 'Клиент' 

CREATE CLUSTERED INDEX #index1 on Выдача_кредитов(Сумма asc);
--DROP INDEX #index1 on Выдача_кредитов
--
SELECT * FROM Выдача_кредитов where Сумма between 150 and 2000 order by Сумма;
checkpoint;  
DBCC DROPCLEANBUFFERS;  

/* ex_2 */
CREATE INDEX #index2 on Выдача_кредитов(Сумма,Номер_выдачи);
--DROP INDEX #index2 on Выдача_кредитов
--
SELECT * FROM Выдача_кредитов where Сумма between 150 and 2000 order by Сумма;
checkpoint;  
DBCC DROPCLEANBUFFERS;  

/* ex_3 */
CREATE INDEX #index3 on Выдача_кредитов(Сумма) INCLUDE(Номер_выдачи)
--DROP INDEX #index3 on Выдача_кредитов
--
SELECT * FROM Выдача_кредитов where Сумма between 150 and 2000 order by Сумма;
checkpoint;  
DBCC DROPCLEANBUFFERS;  

/* ex_4 */
CREATE INDEX #index4 on Выдача_кредитов(Сумма) where(Сумма >= 150 and Сумма <= 2000)
--DROP INDEX #index4 on Выдача_кредитов
--
SELECT * FROM Выдача_кредитов where Сумма between 150 and 2000 order by Сумма;
checkpoint;  
DBCC DROPCLEANBUFFERS;  