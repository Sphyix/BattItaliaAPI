/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @id int;
DECLARE @nome VARCHAR(40);
DECLARE @email VARCHAR(45);
DECLARE @passwd VARCHAR(80);
DECLARE @permission INT;
-- endDesignTime
UPDATE users
SET 
	nome = @nome,
	email = @email,
	passwd = @passwd,
	permission = @permission
WHERE users_id = @id