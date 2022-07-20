/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @nome VARCHAR(30);
DECLARE @cognome VARCHAR(30);
DECLARE @telefono VARCHAR(15);
DECLARE @mail VARCHAR(40);
DECLARE @via VARCHAR(50);
DECLARE @civico VARCHAR(8);
DECLARE @ccap INT;
-- endDesignTime
INSERT INTO clients (
	nome,
	cognome,
	telefono,
	mail,
	via,
	civico,
	ccap
)
VALUES (
	@nome,
	@cognome,
	@telefono,
	@mail,
	@via,
	@civico,
	@ccap
)