/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
declare @id int;
declare @nome varchar;
declare @cognome varchar;
declare @telefono varchar;
-- endDesignTime


SELECT clients.*, comuni.*  FROM clients
left join caps on clients.ccap = caps.cap
left join comuni on caps.cap_id = comuni.comune_id
WHERE (@id IS NULL OR clients_id = @id)
AND (@nome IS NULL OR nome = @nome)
AND (@cognome IS NULL OR cognome = @cognome)
AND (@telefono IS NULL OR telefono = @telefono)