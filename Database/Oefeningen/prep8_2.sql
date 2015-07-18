/********* Hulpscript bij oefening 2 bij Hoofdstuk 8
 *
 *  Als u het package timer hebt gemaakt, dan kunt u met onderstaand programma
 *  testen of het werkt.
 *
 ************************************************/


DECLARE
   v_aantal pls_integer;
BEGIN
   timer.aanzetten;
   select count(*)
   into v_aantal
   from all_objects;
   timer.stopzetten;
   dbms_output.put_line('Aantal records ' ||  v_aantal);
   dbms_output.put_line('Milliseconden  ' || timer.verstreken_msecs());

   timer.aanzetten;
   select count(*)
   into v_aantal
   from all_tables;
   timer.stopzetten;
   dbms_output.put_line('Aantal records ' ||  v_aantal);
   dbms_output.put_line('Milliseconden  ' || timer.verstreken_msecs());

END;
/


