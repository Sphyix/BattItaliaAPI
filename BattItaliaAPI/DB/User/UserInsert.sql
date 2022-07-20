/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @nome VARCHAR(40);
DECLARE @email VARCHAR(45);
DECLARE @passwd VARCHAR(80);
DECLARE @permission INT;
-- endDesignTime
INSERT INTO users (
	nome,
	email,
	passwd,
	permission
)
VALUES (
	@nome,
	@email,
	@passwd,
	@permission
)