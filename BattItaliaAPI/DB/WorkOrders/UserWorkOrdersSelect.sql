/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @userId int;
-- endDesignTime
	SELECT workOrders.*, users.nome FROM workOrders
	INNER JOIN workOrder_user ON workOrders.workOrders_id = workOrder_user.workOrderId and workOrder_user.userId = @userId
	INNER JOIN users on users.users_id = workOrder_user.userId