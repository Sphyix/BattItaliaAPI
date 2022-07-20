/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @id int;
DECLARE @nome VARCHAR(30);
DECLARE @cognome VARCHAR(30);
DECLARE @telefono VARCHAR(15);
DECLARE @mail VARCHAR(40);
DECLARE @ccap INT;
DECLARE @via VARCHAR(50);
DECLARE @civico VARCHAR(5);
-- endDesignTime
UPDATE clients
SET 
	nome = @nome,
	cognome = @cognome,
	telefono = @telefono,
	mail = @mail,
	ccap = @ccap,
	via = @via,
	civico = @civico
WHERE clients_id = @id