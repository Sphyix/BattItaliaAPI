/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @username varchar;
DECLARE @id int;
-- endDesignTime

SELECT * FROM users
WHERE (@id IS NULL OR users_id = @id)
AND (@username IS NULL OR nome = @username)

