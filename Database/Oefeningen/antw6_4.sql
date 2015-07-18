/* Hoofdstuk 6 oefening 4     *************************************/

declare
   cursor c_med 
   is
   select *
   from   medewerkers
   order by maandsal
   for update;

   v_opgemaakt number := 0 ;
   v_grens number     := 1500;

begin

   for r_med in c_med 
   loop   
      exit when v_opgemaakt + ( r_med.maandsal * 0.1 ) > v_grens;

      update medewerkers
      set    maandsal = maandsal * 1.10
      where  current of c_med;

      v_opgemaakt := v_opgemaakt + ( r_med.maandsal * 0.1 );
      end loop;

  dbms_output.put_line ( 'Opgemaakt: ' || to_char( v_opgemaakt ));
  commit;
end;
/

