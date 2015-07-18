/* Hoofdstuk 6 oefening 3     *************************************/

declare
   cursor c_med 
   is
      select naam
      ,      gbdatum
      from medewerkers
      order by gbdatum; 
begin
   for r_med in c_med 
   loop
      exit when c_med%rowcount >= 5;
         dbms_output.put_line( r_med.naam || ' ' 
         || to_char ( r_med.gbdatum ) );
   end loop; 
end;
/

