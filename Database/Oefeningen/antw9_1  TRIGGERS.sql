/* Hoofdstuk 9 oefening 1     *************************************/

create table uit_audit
   ( wie varchar2(30)
   , wat varchar2(3)
   , wanneer date )
/
create or replace trigger asiud_uit
   after insert or update or delete
   on uitvoeringen
declare 
   v_action varchar2( 3 ) ;
begin
   if ( inserting ) 
   then
      v_action := 'INS';
   elsif( updating )
   then
      v_action := 'UPD';
   else
      v_action := 'DEL';
   end if;

   insert into uit_audit
      ( wie, wat , wanneer ) 
   values
      ( user, v_action , sysdate );
end asiud_uit;
/


