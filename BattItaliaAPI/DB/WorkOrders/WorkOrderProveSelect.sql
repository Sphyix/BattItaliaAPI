/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @workOrdersId int = 1;
-- endDesignTime

	SELECT * FROM workOrder_prove
	WHERE (@workOrdersId IS NULL OR workOrdersId = @workOrdersId)