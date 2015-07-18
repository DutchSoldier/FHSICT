/* Hoofdstuk 3 oefening 4 ******************************************/

declare
   v_code   cursussen.code%type;
   v_oms    cursussen.omschrijving%type;
   v_type   cursussen.type%type;
   v_lengte cursussen.lengte%type;
begin
   v_code   := upper( '&cursuscode' );
   v_oms    := '&cursusomschrijving';
   v_type   := upper( '&cursustype' );
   v_lengte := &cursuslengte;
 
   insert into cursussen
   ( code , omschrijving , type , lengte )
   values 
   ( v_code , v_oms , v_type , v_lengte );

   dbms_output.put_line( 'Cursus ' || v_code || ' is toegevoegd' );

exception
   when dup_val_on_index then
      update  cursussen
      set     omschrijving = v_oms
      ,       type = v_type
      ,       lengte = v_lengte
      where   code = v_code;
      dbms_output.put_line( 'Cursus ' || v_code || ' is gewijzigd' );

end;
/


