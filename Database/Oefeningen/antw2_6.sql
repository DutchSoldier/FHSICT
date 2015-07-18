/* Hoofdstuk 2 oefening 6 ******************************************/
 
declare 
   v_bedrag      number;
   v_beschikbaar constant number := 8000;
   v_aantal      pls_integer;
begin
   select count(*)
   into   v_aantal
   from   medewerkers;

   v_bedrag := v_beschikbaar / v_aantal;

   update medewerkers
   set maandsal = maandsal + v_bedrag ;

   if v_aantal <> sql%rowcount
   then
      dbms_output.put_line ( 'Onjuist aantal updates');
      rollback;
   else
      dbms_output.put_line ( 'De salarisverhoging bedraagt: '
                             || to_char( v_bedrag ));
   end if;
end ;
/

