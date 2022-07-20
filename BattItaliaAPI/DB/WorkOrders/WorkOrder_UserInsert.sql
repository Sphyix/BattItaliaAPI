/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @userId INT;
DECLARE @workOrderId INT;
DECLARE @dataAssegnazione DATETIME;
-- endDesignTime
INSERT INTO workOrder_user (
	userId,
	workOrderId,
	dataAssegnazione
)
VALUES (
	@userId,
	@workOrderId,
	@dataAssegnazione
)