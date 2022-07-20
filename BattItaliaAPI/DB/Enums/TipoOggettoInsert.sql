/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @oggetto_nome VARCHAR(40);
-- endDesignTime
INSERT INTO tipoOggetto (
	oggetto_nome
)
VALUES (
	@oggetto_nome
)