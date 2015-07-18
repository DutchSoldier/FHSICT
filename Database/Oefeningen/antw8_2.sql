/* Hoofdstuk 8 oefening 2     *************************************/

create or replace package timer
as
   procedure aanzetten;
   procedure stopzetten;
   function verstreken_msecs
      return pls_integer;
end;
/
create or replace package body timer
as
   g_begin pls_integer;
   g_eind  pls_integer;


   procedure aanzetten
   is
   begin
      g_begin := dbms_utility.get_time();
   end aanzetten;

   procedure stopzetten
   is
   begin
      g_eind := dbms_utility.get_time();
   end stopzetten;

   function verstreken_msecs 
      return pls_integer
   is
   begin
      return (g_eind - g_begin);
   end verstreken_msecs ;
end;
/

set serveroutput on

DECLARE
   v_aantal pls_integer;
BEGIN
   timer.aanzetten;
   select count(*)
   into v_aantal
   from all_objects;
   timer.stopzetten;
   dbms_output.put_line('Aantal records ' ||  v_aantal);
   dbms_output.put_line('Milliseconden  ' || timer.verstreken_msecs());

   timer.aanzetten;
   select count(*)
   into v_aantal
   from all_tables;
   timer.stopzetten;
   dbms_output.put_line('Aantal records ' ||  v_aantal);
   dbms_output.put_line('Milliseconden  ' || timer.verstreken_msecs());

END;
/
