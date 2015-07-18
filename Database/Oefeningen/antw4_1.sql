/* Hoofdstuk 4 oefening 1     *************************************/

declare

   type type_tab_naam
   is table of medewerkers.naam%type;

   t_namen  type_tab_naam;

begin

   select naam
   bulk collect into t_namen
   from medewerkers
   order by naam;

   if t_namen.count > 0
   then
      dbms_output.put_line( 'Namen met een A');
      for i in 1 .. t_namen.count 
      loop
         if t_namen( i ) like '%A%' 
         then
            dbms_output.put_line(t_namen( i ) );
         end if;
      end loop;

      dbms_output.put_line( 'Namen langer dan 6 tekens');
      for i in 1 .. t_namen.count 
      loop
         if length( t_namen( i ) ) > 6 
         then
            dbms_output.put_line(t_namen( i ) );
         end if;
      end loop; 
   end if;
end;
/

