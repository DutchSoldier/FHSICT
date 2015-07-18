/* Hoofdstuk 7 oefening 2 
 *
 * Hieronder volgt alleen de uitwerking voor de procedure print. De overige
 * procedures creeert u analoog door de proceduredefinitie van create [or replace] te
 * voorzien.
 ******************************************/

create or replace procedure print 
  ( p_tekst in varchar2 )
is
begin
  dbms_output.put_line( p_tekst );
end print;
/


