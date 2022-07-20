/* .sql query managed by QueryFirst add-in */
-- designTime - put parameter declarations and design time initialization here
DECLARE @provincia varchar(28);
declare @cap int = 58022;

-- endDesignTime
SELECT comune, caps.cap, provincia, regione, sigla from comuni
inner join caps on comuni.comune_id = caps.cap_id and (@cap IS NULL OR caps.cap = @cap)
WHERE (@provincia IS NULL OR sigla = @provincia)
order by comune

