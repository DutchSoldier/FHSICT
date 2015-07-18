/* Hoofdstuk 2 oefening 3c     *************************************/


declare
   v_einde constant pls_integer default 10 ;
   v_product        pls_integer default 0 ; 
begin
   for i_factor in 1 .. v_einde loop
      v_product := 6 * i_factor ;
      dbms_output.put_line ('6 * ' || to_char(i_factor) ||
                            ' = '  || to_char(v_product)) ;
   end loop ; 
end ;

/

