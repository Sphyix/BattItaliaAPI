/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @stato INT;
DECLARE @id INT;
-- endDesignTime
UPDATE workOrders
SET 
	stato = @stato
WHERE workOrders_id = @id