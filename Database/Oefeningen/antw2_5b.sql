/* Hoofdstuk 2 oefening 5b ******************************************/

declare
   v_tijd_volw number := 1.25;
   v_tijd_kind number := .75;
   v_polis     number := 8;
   v_door_volw number := 50;
   v_door_kind number := 20;

   v_#_volw    pls_integer := 2;
   v_#_kind    pls_integer := 1;
   v_#_dag     pls_integer := 0;
   v_tijd_tot  pls_integer := 0;
   v_door_tot  pls_integer := 0;
begin
   v_door_tot := v_polis 
                 + ( v_#_volw * v_door_volw ) 
                 + ( v_#_kind * v_door_kind) ;

   while v_tijd_tot < v_door_tot 
   loop
      v_#_dag := v_#_dag + 1; 
      v_tijd_tot := v_polis 
                    + v_#_dag * ( ( v_#_volw * v_tijd_volw) 
                                  + ( v_#_kind * v_tijd_kind));
   end loop;

   dbms_output.put_line( 'Aantal dagen: '  ||  v_#_dag );
   dbms_output.put_line( 'Tijdelijk:    '  ||  v_tijd_tot );
   dbms_output.put_line( 'Doorlopend:    ' ||  v_door_tot );
end;
/

