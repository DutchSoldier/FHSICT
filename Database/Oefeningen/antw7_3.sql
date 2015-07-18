/* Hoofdstuk 7 oefening 3     *************************************/

create or replace function years_between
   ( p_datum1 in date
   , p_datum2 in date
   )
   return number
is
begin
   return ( months_between( p_datum1, p_datum2) / 12);
end years_between;
/




select naam
,      gbdatum
,      trunc( years_between (sysdate, gbdatum) ) as leeftijd
from medewerkers
/
