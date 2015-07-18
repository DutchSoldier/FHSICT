/* Hoofdstuk 2 oefening 9 ******************************************/

declare
   v_sal_10_procent number;
   v_sal_80_euro    number ;
   v_som            number;
   v_aantal         pls_integer;
begin
   select count(*)
   into   v_aantal
   from   user_tables
   where  table_name = 'LOG_TABEL';

   if v_aantal = 0
   then
      execute immediate 'create table log_tabel ( '
                        || '  getal  number' 
                        || ', tekst varchar2(200)'
                        || ', datum date )';
   end if;

   select sum(maandsal * 1.1)
   ,      sum(maandsal + 80)
   into   v_sal_10_procent
   ,      v_sal_80_euro
   from   medewerkers;

   
   if v_sal_10_procent < v_sal_80_euro
   then
      v_som := v_sal_10_procent;
      update medewerkers
      set maandsal = maandsal * 1.1;
   else
      v_som := v_sal_80_euro;
      update medewerkers
      set maandsal = maandsal + 80;
   end if;
  
   -- de insert moet ookmet dynamisch SQL
   -- Het programma compileert niet als op compile-time
   -- de tabel log_tabel nog niet bestaat!
   execute immediate 'insert into log_tabel (getal) '
                     || ' values (' || v_som  || ')';

end;
/

