/* Hoofdstuk 2 oefening 7 ******************************************/

declare
   v_teller  pls_integer     default 0;
   v_opslag  constant number := 1.1;
   v_tot_sal number;
   v_maxtot  constant number default 55000;
begin
   select sum(maandsal)
   into   v_tot_sal
   from   medewerkers;

   while ( v_tot_sal * v_opslag ) < v_maxtot 
   loop 
      v_teller := v_teller + 1;

      update medewerkers
      set maandsal = maandsal * v_opslag;

      v_tot_sal := v_tot_sal * v_opslag;
  
   end loop;

   dbms_output.put_line('Aantal updates: '|| to_char(v_teller));
   dbms_output.put_line('Totaal aan salarissen: '||to_char(v_tot_sal));
end;
/


