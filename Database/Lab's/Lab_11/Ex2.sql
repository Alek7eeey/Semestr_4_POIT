USE KAD_MyBase;

/* ***************** */
DECLARE @name varchar(200), @list varchar(600) = '';
DECLARE first_cursor CURSOR LOCAL FOR SELECT Данные_клиента.Контактное_лицо FROM Данные_клиента;
--deallocate first_cursor;

OPEN first_cursor;
FETCH first_cursor INTO @name;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @list = RTRIM(@name) + ',' + @list;
    FETCH first_cursor INTO @name;
END;

CLOSE first_cursor;

IF LEN(@list) > 0
BEGIN
    PRINT 'Все имена: ' + @list;
END
ELSE
BEGIN
    PRINT 'Ничего не найдено';
END

/* ***************** */
go
DECLARE @name varchar(200), @list varchar(600) = '';

OPEN first_cursor;
FETCH first_cursor INTO @name;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @list = RTRIM(@name) + ',' + @list;
    FETCH first_cursor INTO @name;
END;

CLOSE first_cursor;

IF LEN(@list) > 0
BEGIN
    PRINT 'Все имена: ' + @list;
END
ELSE
BEGIN
    PRINT 'Ничего не найдено';
END

/* ***************** */
insert into Данные_клиента(Название_фирмы_клиента, Вид_собственности, Адрес, Телефон, Контактное_лицо, Пол) 
VALUES
('Новая фирма', 'ООО', 'ул.Сурганова 22', '+375441213211', 'Веремко Сергей', 'М');

DECLARE @name2 varchar(200), @list2 varchar(600) = '';
DECLARE first_cursor2 CURSOR LOCAL dynamic /*static*/ FOR SELECT Данные_клиента.Контактное_лицо FROM Данные_клиента;
--deallocate first_cursor2;

OPEN first_cursor2;
delete Данные_клиента where Название_фирмы_клиента like 'Новая фирма';
FETCH first_cursor2 INTO @name2;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @list2 = RTRIM(@name2) + ',' + @list2;
    FETCH first_cursor2 INTO @name2;
END;

CLOSE first_cursor2;

IF LEN(@list2) > 0
BEGIN
    PRINT 'Все имена: ' + @list2;
END
ELSE
BEGIN
    PRINT 'Ничего не найдено';
END

/* ***************** */
DECLARE @name3 varchar(200), @list3 varchar(600) = '';
DECLARE first_cursor3 CURSOR LOCAL static FOR SELECT Данные_клиента.Контактное_лицо FROM Данные_клиента;
--deallocate first_curso3;

OPEN first_cursor3;
FETCH last from first_cursor3 INTO @name3;
    SET @list3 = 'Последняя строка: ' +RTRIM(@name3) + ',' + @list3;

FETCH ABSOLUTE 3 FROM first_cursor3 INTO @name3;
	 SET @list3 = 'Первая строка: ' +RTRIM(@name3) + ',' + @list3;

FETCH ABSOLUTE -2 from first_cursor3 INTO @name3;
	SET @list3 = 'Вторая строка с конца: ' +RTRIM(@name3) + ',' + @list3;

CLOSE first_cursor3;

IF LEN(@list3) > 0
BEGIN
    PRINT @list3;
END
ELSE
BEGIN
    PRINT 'Ничего не найдено';
END