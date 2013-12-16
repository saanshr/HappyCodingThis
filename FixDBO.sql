USE sf_HappyCodingThis

DECLARE tabcurs CURSOR
FOR
    SELECT 'dbo.' + [name]
      FROM sysobjects
     WHERE xtype = 'u'

OPEN tabcurs
DECLARE @tname NVARCHAR(517)
FETCH NEXT FROM tabcurs INTO @tname

WHILE @@fetch_status = 0
BEGIN

    EXEC sp_changeobjectowner @tname, 'HappyCodingThis'

    FETCH NEXT FROM tabcurs INTO @tname
END
CLOSE tabcurs
DEALLOCATE tabcurs