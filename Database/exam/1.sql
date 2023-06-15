USE EXAM;
select * from сотрудники
select * from отпуск

create procedure newPr @otdel nvarchar(50), @year nvarchar(50)
as
    begin try
    begin
        select FIO,A.Salary+O.Oplata as sum from сотрудники as A
            inner join отпуск O on A.id = O.idСотрудника
        where A.Deparment like @otdel and cast(year(A.DateNaima) as nvarchar(20)) like @year
        group by Salary+O.Oplata, FIO;
        return 1;
    end;
    end try
    begin catch
        raiserror ('Error', 13, 1);
    end catch

    go
CREATE TRIGGER newtr ON отпуск INSTEAD OF INSERT
AS
BEGIN
    DECLARE @DateStart DATE, @DateEnd DATE;

    SELECT @DateStart = DateStart, @DateEnd = DateEnd FROM inserted;

    IF (DATEDIFF(MONTH, @DateStart, @DateEnd) <= 6)
    BEGIN
        RAISERROR ('Нельзя пойти в отпуск!', 13, 7);
        ROLLBACK;
    END
    ELSE
    BEGIN
        INSERT INTO отпуск (idСотрудника, DateStart, DateEnd, Typev, Oplata)
        SELECT idСотрудника, DateStart, DateEnd, Typev, Oplata
        FROM inserted;
    END
END





