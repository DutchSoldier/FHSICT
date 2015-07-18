/* Hoofdstuk 2 oefening 5a ******************************************/

declare
   v_tijd_volw number := 1.25;
   v_tijd_kind number := .75;
   v_polis     number := 8;
   v_door_volw number := 50;
   v_door_kind number := 20;

   v_#_volw    pls_integer := 2;
   v_#_kind    pls_integer := 1;
   v_#_dag     pls_integer := 7;

   v_tijd_tot number := 0;
   v_door_tot number := 0;
begin
   v_tijd_tot := v_polis 
                 + v_#_dag * ( ( v_#_volw * v_tijd_volw) + ( v_#_kind * v_tijd_kind));
   v_door_tot := v_polis 
                 + ( v_#_volw * v_door_volw ) 
                 + ( v_#_kind * v_door_kind) ;

   dbms_output.put_line( 'Tijdelijk: '  ||  v_tijd_tot );
   dbms_output.put_line( 'Doorlopend: ' ||  v_door_tot );
end;
/

