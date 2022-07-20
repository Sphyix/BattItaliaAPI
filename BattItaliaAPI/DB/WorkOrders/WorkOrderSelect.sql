/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @workOrderId int;
DECLARE @stato int;
DECLARE @difficolta int;
DECLARE @modello varchar;
-- endDesignTime
	SELECT workOrders.*, users.nome FROM workOrders
	LEFT JOIN workOrder_user ON workOrders.workOrders_id = workOrder_user.workOrderId
	LEFT JOIN users on users.users_id = workOrder_user.userId
	WHERE (@workOrderId IS NULL OR workOrders_id = @workOrderId)
	AND (@stato IS NULL OR stato = @stato)
	AND (@difficolta IS NULL OR difficolta = @difficolta)
	AND (@modello IS NULL OR modello LIKE @modello)