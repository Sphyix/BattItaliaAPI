/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @regione int;

-- endDesignTime
SELECT DISTINCT provincia, sigla FROM comuni
WHERE cod_regione = @regione
order by provincia
