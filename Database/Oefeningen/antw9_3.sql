/* Hoofdstuk 9 oefening 3     *************************************/


create table uit_audit
   (wie varchar2(30)
   , wat varchar2(3)
   , wanneer date
   , aantal number)
/
create or replace package pck_audit
as
   procedure init;
   procedure telop;
   procedure schrijf;
end pck_audit;
/
create or replace package body pck_audit
as
   g_aantal pls_integer := 0;

   procedure init 
   is
   begin
      g_aantal := 0;
   end init ;

   procedure telop
   is
   begin
      g_aantal := g_aantal + 1;
   end telop;

   procedure schrijf
   is
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
        ( wie, wat , wanneer , aantal ) 
     values
        ( user, v_action , sysdate , g_aantal );
    
   end schrijf;
end pck_audit ;
/

create or replace trigger biuds_uit
   before insert or update or delete 
   on uitvoeringen
begin
   pck_audit.init ;
end biuds_uit;
/
create or replace trigger aiudr_uit
   after insert or update or delete 
   on uitvoeringen
   for each row
begin
   pck_audit.telop;
end aiudr_uit;
/
create or replace trigger aiuds_uit
   after insert or update or delete 
   on uitvoeringen
begin
   pck_audit.schrijf;
end aiuds_uit;
/


