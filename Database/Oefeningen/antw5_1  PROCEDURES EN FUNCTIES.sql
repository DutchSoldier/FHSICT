/* Hoofdstuk 5 oefening 1 ******************************************/

declare
   procedure print 
      ( p_tekst in varchar2 )
   is
   begin
     dbms_output.put_line( p_tekst );
   end print;
begin
   print( user );
   print( sysdate );
end;
/


