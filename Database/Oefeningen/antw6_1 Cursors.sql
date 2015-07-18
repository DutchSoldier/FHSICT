/* Hoofdstuk 6 oefening 1     *************************************/

declare 
   v_bedrag      number;
   v_beschikbaar constant number := 8000;
   v_aantal      pls_integer;
   cursor c_med
   is
      select count(*)
      from   medewerkers;
      
begin
   open c_med;
   fetch c_med into   v_aantal;
   close c_med;

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
