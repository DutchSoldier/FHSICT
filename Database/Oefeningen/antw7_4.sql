/* Hoofdstuk 7 oefening 4     *************************************/

create or replace procedure log_melding
   ( p_tekst in varchar2
   , p_getal in number default null)
is
   pragma autonomous_transaction;
begin
   insert into log_tabel
   (getal, tekst, datum)
   values
   (p_getal, p_tekst, sysdate);
   commit;
end log_melding;
/
