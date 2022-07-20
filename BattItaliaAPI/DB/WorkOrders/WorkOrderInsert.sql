/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @clientId INT;
DECLARE @tipoOggetto INT;
DECLARE @modello VARCHAR(50);
DECLARE @accessori VARCHAR(300);
DECLARE @difetto VARCHAR(300);
DECLARE @difettofisso INT;
DECLARE @stato INT;
DECLARE @difficolta INT;
DECLARE @descrizione VARCHAR(400);
DECLARE @note VARCHAR(400);
DECLARE @dataInizio DATETIME;
DECLARE @dataFine DATETIME;
DECLARE @riferimento VARCHAR(30);
-- endDesignTime
INSERT INTO workOrders (
	clientId,
	tipoOggetto,
	modello,
	accessori,
	difetto,
	difettofisso,
	stato,
	difficolta,
	descrizione,
	note,
	dataInizio,
	dataFine,
	riferimento
)
VALUES (
	@clientId,
	@tipoOggetto,
	@modello,
	@accessori,
	@difetto,
	@difettofisso,
	@stato,
	@difficolta,
	@descrizione,
	@note,
	@dataInizio,
	@dataFine,
	@riferimento
)