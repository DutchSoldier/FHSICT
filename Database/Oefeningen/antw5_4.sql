/* Hoofdstuk 5 oefening 4 ******************************************/

declare
   v_rekening varchar2( 20 );

   function geldig_bankrek ( p_reknr in varchar2 )
      return boolean
   is 
      v_reknr  varchar2( 20 ) := p_reknr;
      v_lengte constant number := 9;
      v_som    number default 0;
      v_cijfer varchar2( 1 );
   begin
      v_reknr := replace( v_reknr , '.' , '' );
      v_reknr := replace( v_reknr , ' ' , '' ); 
      if length( v_reknr ) <> v_lengte
      then
         return false;
      else
         for i in 1 .. v_lengte 
         loop
            v_cijfer := substr( v_reknr , i , 1 );
            if v_cijfer not between 0 and 9
            then
               return false;
            end if;
            v_som := v_som + ( ((v_lengte+1) - i) * v_cijfer );
         end loop ;
         if mod( v_som , 11 ) <> 0 
         then 
            return false;
         else
            return true;
         end if;
      end if;
   end geldig_bankrek ;

begin
   v_rekening := '&rekeningnummer';
   if geldig_bankrek( p_reknr => v_rekening ) 
   then
      dbms_output.put_line( 'Geldig rekeningnummer' );
   else
      dbms_output.put_line( 'Ongeldig rekeningnummer' ); 
   end if;
end;
/


