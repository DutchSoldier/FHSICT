/* Hoofdstuk 2 oefening 8 ******************************************/

declare
   v_sal_10_procent number;
   v_sal_80_euro    number ;
begin
   select sum(maandsal * 1.1)
   ,      sum(maandsal + 80)
   into   v_sal_10_procent
   ,      v_sal_80_euro
   from   medewerkers;

   dbms_output.put_line('v_sal_10_procent: '|| to_char(v_sal_10_procent));
   dbms_output.put_line('v_sal_80_euro   : '|| to_char(v_sal_80_euro));


   if v_sal_10_procent < v_sal_80_euro
   then
      update medewerkers
      set maandsal = maandsal * 1.1;
   else
      update medewerkers
      set maandsal = maandsal + 80;
   end if;

end;
/

