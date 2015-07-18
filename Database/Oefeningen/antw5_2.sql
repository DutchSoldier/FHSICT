/* Hoofdstuk 5 oefening 2 ******************************************/

declare
   v_woord varchar2( 200 );
   function revstr 
      ( p_tekst in varchar2 )
      return varchar2
   is
      v_revtekst varchar2( 200 );
   begin
      for i in 1 .. length( p_tekst ) 
      loop
         v_revtekst := substr( p_tekst , i , 1 ) || v_revtekst ;
      end loop;
      return v_revtekst;
   end revstr;
begin
   v_woord := '&woord';
   dbms_output.put_line( revstr( p_tekst => v_woord ));
end;
/




