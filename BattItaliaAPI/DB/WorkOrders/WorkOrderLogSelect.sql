/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @username varchar;
-- endDesignTime
	SELECT * FROM workOrderLog
	INNER JOIN users ON users.nome = @username and users.users_id = workOrderLog.userId
