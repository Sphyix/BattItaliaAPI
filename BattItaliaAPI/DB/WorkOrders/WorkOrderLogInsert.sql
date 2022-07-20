/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @workOrderId INT;
DECLARE @userId INT;
DECLARE @azione VARCHAR(50);
DECLARE @statoInziale INT;
DECLARE @statoFinale INT;
DECLARE @dataEvento DATETIME;
-- endDesignTime
INSERT INTO WorkOrderLog (
	workOrderId,
	userId,
	azione,
	statoInziale,
	statoFinale,
	dataEvento
)
VALUES (
	@workOrderId,
	@userId,
	@azione,
	@statoInziale,
	@statoFinale,
	@dataEvento
)